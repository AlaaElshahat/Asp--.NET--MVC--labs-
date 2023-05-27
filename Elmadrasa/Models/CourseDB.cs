namespace WebApplicationlab09.Models
{
    public class CourseDB
    {
        ITIContext db = new ITIContext();
        public List<Courses> GetALL()
        {
            return db.Courses.ToList();


        }
        public Courses GetOneById(int id)
        {
            return db.Courses.FirstOrDefault(a => a.Id == id);
        }
    }
}
