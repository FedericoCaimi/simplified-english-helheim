
namespace Domain
{
    public class User : DomainEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public Course Course { get; set; }
        public string Rol { get; set; }

        public override bool Equals(object obj)
        {
            var user = obj as User;
            return user != null &&
                   Email == user.Email;
        }
    }
}