namespace WebApplicationlab09.Models
{
    public class DepartCourses
    {
        public int DeptId { get; set; }
        public int CourseId { get; set;}
        public Department Department { get; set; }
        public Courses Courses { get; set; }
    }
}
