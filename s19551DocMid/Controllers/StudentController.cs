using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using s19551DocMid.Services;

namespace s19551DocMid.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStudents()
        {
            var sql = new SqlServerDbService();
            var result = sql.GetStudents();
            if (result.Count() > 0)
                return Ok(result);

            return NotFound("Empty!!!");
        }

        [HttpGet("{index}")]
        public IActionResult GetStudents(string index)
        {
            var sql = new SqlServerDbService();
            var result = sql.GetStudent(index);
            if (result!=null)
                 return Ok(result);

            return NotFound("Index number does not exists!!!");
        }
    }
}