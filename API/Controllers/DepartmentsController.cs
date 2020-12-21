using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DLL.Model;
using DLL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class DepartmentsController : MainApiController
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        [HttpGet]
        public  async Task<IActionResult> GetAll()
        {
            return Ok(await _departmentRepository.GetAllAsync());
        }

       [HttpGet (template:"{code}")]
        public async Task<IActionResult> GetA(string code)
        {
            return Ok(await _departmentRepository.GetAAsync(code));
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Department department)
        {
            return Ok(await _departmentRepository.InsertAsync(department));
        }

        [HttpPut(template :"{code}")]
        public async  Task<IActionResult> Update(string code,Department department)
        {
            return Ok(await _departmentRepository.UpdateAsync(code,department));
        }

        [HttpDelete(template: "{code}")]
        public  async Task<IActionResult> Delete(string code)
        {
            return Ok( await _departmentRepository.DeleteAsync(code));
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
