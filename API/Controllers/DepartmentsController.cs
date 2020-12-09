using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route(template:"[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok("get all departments");
        }

        [HttpGet (template:"{code}")]
        public IActionResult GetA(string code)
        {
            return Ok("get this  " + code + " department data");
        }

        [HttpPost]
        public IActionResult Insert()
        {
            return Ok("Insert department");
        }

        [HttpPut(template :"{code}")]
        public IActionResult Update(string code)
        {
            return Ok("Update this " + code + " department data");
        }

        [HttpDelete(template: "{code}")]
        public IActionResult Delete(string code)
        {
            return Ok("Delete this " + code + " department data");
        }
    }
}
