using s19551DocMid.DTO;
using s19551DocMid.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace s19551DocMid.Services
{
    public class SqlServerDbService : IDbService
    {
       
        public Student GetStudent(string index)
        {
            using (SqlConnection connection = new SqlConnection(Statics.StaticValues.CONNECTION_STRING))
            using (SqlCommand command=new SqlCommand())
            {
                command.CommandText = @"select IndexNumber,FirstName,LastName
                                        from student
                                        where IndexNumber=@index";
                command.Parameters.AddWithValue("index",index);
                command.Connection = connection;

                connection.Open();
                var st = command.ExecuteReader();
                if (st.Read())
                {
                    return new Student {
                        indexNumber = st["IndexNumber"].ToString(),
                        Name = st["FirstName"].ToString(),
                        LastName = st["LastName"].ToString()
                        };
                }
            }


                return null;
        }

        public IEnumerable<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            using (SqlConnection connection = new SqlConnection(Statics.StaticValues.CONNECTION_STRING))
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = @"select IndexNumber, FirstName, LastName from student";
               

                connection.Open();
                var st = command.ExecuteReader();
                while (st.Read())
                {
                    students.Add(new Student
                    {
                        indexNumber = st["IndexNumber"].ToString(),
                        Name = st["FirstName"].ToString(),
                        LastName = st["LastName"].ToString()
                    });
                }
                return students;
            }

        }

        public void SaveLogData(LoggingFile loggingFile)
        {
            var jsonString = JsonSerializer.Serialize(loggingFile, typeof(LoggingFile));
            File.WriteAllText($"{Statics.StaticValues.LOGGING_FILE_PATH}", jsonString, Encoding.UTF8);

        }
    }
    
}
