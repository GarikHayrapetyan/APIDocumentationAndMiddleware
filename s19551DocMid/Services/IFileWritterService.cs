using s19551DocMid.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s19551DocMid.Services
{
    public interface IFileWritterService
    {
        public void SaveLogData(LoggingFile loggingFile);
    }
}
