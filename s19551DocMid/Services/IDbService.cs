using System.Collections.Generic;
using s19551DocMid.DTO;
using s19551DocMid.Models;

namespace s19551DocMid.Services
{
    public interface IDbService
    {
        public IEnumerable<Student> GetStudents();
        public Student GetStudent(string index);

        public void SaveLogData(LoggingFile loggingFile);

    }
}
