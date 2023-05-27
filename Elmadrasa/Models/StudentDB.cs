namespace WebApplicationlab09.Models
{
    public class StudentDB
    {
        ITIContext db=new ITIContext();
        public   void Add(Students student)
        {

            db.Students.Add(student);
            
            db.SaveChanges();
            

        }
        public List<Students> getStudents ()
        {
            return db.Students.ToList();
        }

    }
}
