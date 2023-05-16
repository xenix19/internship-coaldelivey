using System.ComponentModel.DataAnnotations.Schema;

namespace _111.Schemas
{
    public class User
    {
        public int ID { get; set; }
        public string token { get; set; }
        public string surname { get; set; }
        public string firstname { get; set; }
        public string patronomic { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string login { get; set; }
    }

    public class RegisteringUser
    {
        public string surname { get; set; }
        public string firstname { get; set; }
        public string patronomic { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string login { get; set; }
        public int code { get; set; }
    }

    public class Me 
    {
        public string surname { get; set; }
        public string firstname { get; set; }
        public string patronomic { get; set; }
        public string email { get; set; }
    }

    public class UserCredentials
    {
        public string password { get; set; }
        public string login { get; set; }
    }

}
