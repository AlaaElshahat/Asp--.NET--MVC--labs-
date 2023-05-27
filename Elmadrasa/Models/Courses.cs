using WebApplicationlab09.Migrations;
using System.Collections.Generic;
namespace WebApplicationlab09.Models
{
    public class Courses
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Department> depts{ get; set; }
    }
}
