namespace WebApplicationlab09.Models
{
    public class UsersDB
    {
        ITIContext db = new ITIContext();
        public void Add(Users user)
        {

            db.users.Add(user);
            db.SaveChanges();


        }
    }
}
