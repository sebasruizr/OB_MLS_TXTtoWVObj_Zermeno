using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Artisoft.OnBase.Montepio.FileLoader.Pocos
{
    public class Row
    {
        public List<string> Elements { get; set; }

        public Row()
        {
            Elements = new List<string>();
        }

        public Row(string[] elements)
        {
            Elements = new List<string>(elements);
        }

        public int Length
        {
            get { return Elements != null ? Elements.Count : 0; }
        }

        public string this[int elementIndex]
        {
            get { return Elements != null && Elements.Count > elementIndex ? Elements[elementIndex] : null; }
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}