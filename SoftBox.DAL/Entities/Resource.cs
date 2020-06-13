namespace SoftBox.DAL.Entities
{
    public class Resource
    {
        public int Id { get; set; }

        public string Information { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
