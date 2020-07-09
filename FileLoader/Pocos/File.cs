using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Artisoft.OnBase.Montepio.FileLoader.Pocos
{
    public class File
    {
        public List<Row> Rows { get; private set; }
        public Row Header { get; set; }
        public Row SourceHeader { get; set; }

        public File()
        {
            Rows = new List<Row>();
        }

        public int Length
        {
            get { return Rows != null ? Rows.Count : 0; }
        }

        public int Columns
        {
            get { return Header.Length; }
        }

        public Row this[int rowIndex]
        {
            get { return Rows != null && Rows.Count > rowIndex ? Rows[rowIndex] : null; }
        }

        public int ValidRows
        {
            get { return Rows.Where(row => row.Length == Header.Length).Count(); }
        }
        
        public void Add(Row row)
        {
            Rows.Add(row);
        }

        public void Add(string[] row)
        {
            this.Add(new Row(row));
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}