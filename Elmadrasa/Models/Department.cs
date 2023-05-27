using System.Collections.Generic;
namespace WebApplicationlab09.Models
{
    public class Department
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Capacity { get; set; }
        public   ICollection<Courses> Courses { get; set; }
    }
}
