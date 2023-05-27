using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationlab09.Models;

namespace WebApplicationlab09.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentDB deptDB=new DepartmentDB();
        CourseDB courseDB=new CourseDB();
        ITIContext db = new ITIContext();
        [Authorize]
        public IActionResult Index()
        {
            return View(deptDB.GetALL());
        }
        public IActionResult UpdateCouursesList(int id)
        {
            var dept= deptDB.GetOneWithitsCourses(id);
            var allCourses = courseDB.GetALL();
            var coursesInDept=dept.Courses.ToList();
            var coursesNotInDept=allCourses.Except(coursesInDept);
            ViewBag.DeptCourses = new SelectList(coursesInDept, "Id", "Name");
            ViewBag.NotDeptCourses = new SelectList(coursesNotInDept, "Id", "Name");
            ViewBag.id = dept.Id;
            return View();
        }
        [HttpPost]
        public IActionResult UpdateCouursesList(int id,int[] coursetoRemove, int[] coursetoAdd)
        {
            var dept = deptDB.GetOneWithitsCourses(id);
            var crss = db.Courses.FirstOrDefault(a => a.Id == 1); ;
            dept.Courses.Add(crss);
            foreach (var courseId in coursetoRemove)
            {

                var crs= db.Courses.FirstOrDefault(a => a.Id == courseId); ;
                dept.Courses.Remove(crs);
            }
            foreach (var courseId in coursetoAdd)
            {
                Console.WriteLine("=============="+courseId);
                var crs = db.Courses.FirstOrDefault(a => a.Id == 1); ;
                dept.Courses.Add(crs); 
                   

            }
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
