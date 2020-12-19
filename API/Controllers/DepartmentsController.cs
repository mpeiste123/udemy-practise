using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class DepartmentsController : MainApiController
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(DepartmentsStatic.GetAllDepartment());
        }

       [HttpGet (template:"{code}")]
        public IActionResult GetA(string code)
        {
            return Ok(DepartmentsStatic.GetADepartment(code));
        }

        [HttpPost]
        public IActionResult Insert(Department department)
        {
            return Ok(DepartmentsStatic.InsertDepartment(department));
        }

        [HttpPut(template :"{code}")]
        public IActionResult Update(string code,Department department)
        {
            return Ok(DepartmentsStatic.updateDepartment(code,department));
        }

        [HttpDelete(template: "{code}")]
        public IActionResult Delete(string code)
        {
            return Ok(DepartmentsStatic.DeleteDepartment(code));
        }
    }

    public static class DepartmentsStatic
    {
        private static List<Department> AllDepartment { get; set; } = new List<Department>();

        public static Department InsertDepartment(Department department)
        {
            AllDepartment.Add(department);

            return department;
        }

        public static List<Department> GetAllDepartment()
        {
            return AllDepartment;
        }

        public static Department GetADepartment(string code)
        {
            return AllDepartment.FirstOrDefault(x => x.Code == code);
        }

        public static Department updateDepartment(string code,Department department)
        {
            Department result = new Department();
            foreach(var aDepartment in AllDepartment)
            {
                if(aDepartment.Code == code)
                {
                    aDepartment.Name = department.Name;
                    result = aDepartment;
                }
                
            }

            return result;
        }

        public static Department DeleteDepartment(string code)
        {
            var department = AllDepartment.FirstOrDefault(x=> x.Code == code);
            AllDepartment = AllDepartment.Where(x => x.Code != code).ToList();
            return department;

        }
    }
}
