﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DLL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class StudentController : MainApiController
    {
        [HttpGet]
        public IActionResult GetAll([FromQuery] string rollNumber,[FromQuery] string nickName)
        {
            return Ok(StudentStatic.GetAllStudent());
        }

        [HttpGet(template: "{email}")]
        public IActionResult GetA(string email)
        {
            return Ok(StudentStatic.GetAStudent(email));
        }

        [HttpPost]
        public IActionResult Insert([FromForm] Student student)
        {
            return Ok(StudentStatic.InsertStudent(student));
        }

        [HttpPut(template: "{email}")]
        public IActionResult Update(string email, Student student)
        {
            return Ok(StudentStatic.updateStudent(email, student));
        }

        [HttpDelete(template: "{email}")]
        public IActionResult Delete(string email)
        {
            return Ok(StudentStatic.DeleteStudent(email));
        }
    }

    public static class StudentStatic
    {
        private static List<Student> AllStudent { get; set; } = new List<Student>();

        public static Student InsertStudent(Student student)
        {
            AllStudent.Add(student);

            return student;
        }

        public static List<Student> GetAllStudent()
        {
            return AllStudent;
        }

        public static Student GetAStudent(string email)
        {
            return AllStudent.FirstOrDefault(x => x.Email == email);
        }

        public static Student updateStudent(string email, Student student)
        {
            Student result = new Student();
            foreach (var aStudent in AllStudent)
            {
                if (aStudent.Email == email)
                {
                    aStudent.Name = student.Name;
                    result = aStudent;
                }

            }

            return result;
        }

        public static Student DeleteStudent(string email)
        {
            var student = AllStudent.FirstOrDefault(x => x.Email == email);
            AllStudent = AllStudent.Where(x => x.Email != email).ToList();
            return student;

        }
    }
}
