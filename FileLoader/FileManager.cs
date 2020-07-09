using System;
using System.Collections.Generic;
using Artisoft.OnBase.Montepio.FileLoader.Pocos;
using IO = System.IO;
using log4net;

namespace Artisoft.OnBase.Montepio.FileLoader
{
    public class FileManager
    {
        private static readonly ILog Log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static File LoadFile(string filePath)
        {
            if (!IO.File.Exists(filePath))
            {
                Log.Error(string.Format("El archivo que se intentó cargar con el path {0} no existe", filePath));
                throw new ArgumentException(string.Format("Archivo inexistente {0}", filePath));
            }
            else
            {
                File file = new File();
                try
                {
                    using (var sr = IO.File.OpenText(filePath))
                    {
                        string line;
                        int count = 0;
                        while ((line = sr.ReadLine()) != null)
                        {
                            try
                            {
                                var row = line.Split('|');
                                if (count == 0)
                                    //TODO Por ahora se carga lo mismo en SourceHeader y Header, pero en Header debe de ir el encabezado configurado
                                    file.Header = file.SourceHeader = new Row(row);
                                else
                                    file.Add(row);
                            }
                            catch (Exception e)
                            {
                                Log.Error(string.Format("Línea {0} omitida por error, contenido: {1}", count, line), e);
                            }

                            count++;
                        }

                        if (file.Header.Length == 0)
                        {
                            Log.Error(string.Format("No se pudo determinar el encabezado para el archivo {0}", filePath));
                            throw new ArgumentException(string.Format("Archivo inválido {0}", filePath));
                        }
                        if (file.ValidRows == 0)
                        {
                            Log.Error(string.Format("El archivo {0} no contiene renglones válidos", filePath));
                            throw new ArgumentException(string.Format("Archivo inválido {0}", filePath));
                        }

                        return file;
                    }
                }
                catch (Exception e)
                {
                    Log.Error(string.Format("El archivo {0} no pudo ser procesado debido a errores", filePath), e);
                    throw new ArgumentException(string.Format("Archivo inválido {0}", filePath));
                }
            }
        }
    }
}