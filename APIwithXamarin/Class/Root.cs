using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIwithXamarin
{
    public class Root

    {
        public bool error { get; set; }
        public int statusCode { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }
}
