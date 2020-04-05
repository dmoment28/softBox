namespace SoftBox.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }

        public int UserProfileId { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}
