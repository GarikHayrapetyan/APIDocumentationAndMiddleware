using s19551DocMid.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace s19551DocMid.Services
{
    //I left this to ask something 
    public class JsonFileWritterService : IFileWritterService
    {
       
        public void SaveLogData(LoggingFile loggingFile)
        {
            var jsonString = JsonSerializer.Serialize(loggingFile, typeof(LoggingFile));
            File.WriteAllText($"{Statics.StaticValues.LOGGING_FILE_PATH}", jsonString, Encoding.UTF8);

        }
    }
}
