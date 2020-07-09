using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Artisoft.OnBase.Montepio.FileLoader;
using Artisoft.OnBase.Montepio.FileLoader.Pocos;
using Artisoft.OnBase.Montepio.FileLoader.Pocos.Config;
using log4net;
using Newtonsoft.Json;
using IO = System.IO;

namespace Load
{
    internal class Tester
    {
        private static readonly ILog Log =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void Main(string[] args)
        {
            const string defaultConfigFile =
                "/Users/alfredozn/workspace/artisoft/Montepio/Load/Config/Montepio.Load.Config.json";


            try
            {
                /**************************************
                 * ************************************
                 * ****       Load config    **********
                 * ************************************
                 * ************************************
                 */
                string configFile = null;
                
                if (args.Length > 0 && args[0] != null)
                {
                    configFile = args[1];
                }
                else
                {
                    Log.InfoFormat("Cargando configuración predeterminada de {0}", new[] {defaultConfigFile});
                    configFile = defaultConfigFile;
                }

                List<FileConfig> config;
                try
                {
                    using (var sr = IO.File.OpenText(configFile))
                    {
                        var serializer = new JsonSerializer();
                        config = (List<FileConfig>)serializer.Deserialize(sr,typeof(List<FileConfig>));
                    }
                }
                catch (Exception e)
                {
                    Log.Error("Error cargando configuración");
                    throw new ArgumentException("Archivo de configuración inválido", e);
                }


                IEnumerable<string> filePaths;
                // filePaths = Directory.EnumerateFiles("/Users/alfredozn/workspace/artisoft/Montepio/InputFiles");
                filePaths = new[] {"/Users/alfredozn/workspace/artisoft/Montepio/InputFiles/invalid_length.txt"};
                foreach (var filePath in filePaths)
                {
                    var file = FileManager.LoadFile(filePath);
                    Log.Debug(string.Format(
                        "Statistics: File:{5}, HeaderColumns: {0}, SourceHeaderColumns: {1}, RowsLengths: {2}, Rows: {3}, InvalidRows: {4}",
                        file.Header.Length, file.SourceHeader.Length,
                        string.Format("[{0}]",
                            string.Join(",",
                                (from r in file.Rows group r by r.Length into groups select groups.First().Length)
                                .ToArray())),
                        file.Rows.Count, file.Rows.Count - file.ValidRows, filePath.Split('/').Last()));
                    // Log.Debug(file);
                }
            }
            catch (Exception e)
            {
                Log.Error("Error al procesar archivo", e);
            }
        }
    }
}