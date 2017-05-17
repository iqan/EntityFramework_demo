using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogsDemo()
        {
            return View();
        }
        

        public JsonResult GetStudents()
        {
            IEnumerable<Student> students = new List<Student>();

            SignalR.LogHub.Send("Fetching data");

            using (var db = new DataContext())
            {
                db.Database.Log = SignalR.LogHub.Send;
                try
                {
                    //var s = new List<Student> {
                    //    new Student { StudentName = "abc", RegistrationNumber = 1, RowVersion = new byte[1]},
                    //    new Student { StudentName = "abc1", RegistrationNumber = 2, RowVersion = new byte[1]},
                    //    new Student { StudentName = "abc2", RegistrationNumber = 3, RowVersion = new byte[1]},
                    //    new Student { StudentName = "abc3", RegistrationNumber = 4, RowVersion = new byte[1]},
                    //};
                    //db.Students.AddRange(s);
                    //db.SaveChanges();
                    students = db.Students.ToList();
                }
                catch (System.Exception e)
                {
                    SignalR.LogHub.Send("Error: " + e.Message);
                }
            }
            
            SignalR.LogHub.Send("done");

            SignalR.LogHub.Send("converting to json");
            var jstudents = JsonConvert.SerializeObject(students, Formatting.Indented);
            SignalR.LogHub.Send("done");
            return Json(jstudents, JsonRequestBehavior.AllowGet);
        }
    }
}