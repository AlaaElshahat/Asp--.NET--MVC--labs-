using Microsoft.EntityFrameworkCore;

namespace WebApplicationlab09.Models
{
    public class DepartmentDB
    {
        ITIContext db = new ITIContext();
        public  List< Department> GetALL()
        {
            return db.Departments.ToList();


       }
        public Department GetOneWithitsCourses(int id)
        {
            return db.Departments.Include(a => a.Courses).FirstOrDefault(a => a.Id ==id);
        }
    }
}
