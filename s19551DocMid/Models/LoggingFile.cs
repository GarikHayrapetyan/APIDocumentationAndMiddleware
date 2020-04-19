using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s19551DocMid.DTO
{
    public class LoggingFile
    {
        public string path { get; set; }
        public string method { get; set; }
        public string queryString { get; set; }
        public string body { get; set; }
    }
}
