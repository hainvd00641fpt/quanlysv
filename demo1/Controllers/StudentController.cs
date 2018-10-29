using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace demo1.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentContext _content;

        public StudentController(StudentContext context)
        {
            _content = context;
        }
        public IActionResult Index()
        {
            return View(_content.students.ToList());
           // return new JsonResult(_content.students.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Store(student student)
        {
            _content.students.Add(student);
            _content.SaveChanges();
            return new JsonResult(student);
        }
        public IActionResult Edit(int id)
        {
            return Index();   
        }
    }
}