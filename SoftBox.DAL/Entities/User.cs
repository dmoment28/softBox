using System.Collections.Generic;

namespace SoftBox.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }

        public int RoleId { get; set; }

        public virtual Role Role { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }
    }
}
