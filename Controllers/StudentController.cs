using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCInterview.Models;

namespace MVCInterview.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            StudentDBHandler studentDBHandler = new StudentDBHandler();
            ModelState.Clear();
            return View(studentDBHandler.GetStudentList());
        }

        // Add student
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(StudentInfoModel studentInfoModel )
        {
           
            if (ModelState.IsValid)
            {
                StudentDBHandler stDBHandler = new StudentDBHandler();
                if (stDBHandler.InsertStudent(studentInfoModel))
                {
                    ViewBag.Message = "Item Added Successfully";
                    ModelState.Clear();
                }
            }
            return View();
            
        }
    }
}