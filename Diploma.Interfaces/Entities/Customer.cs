namespace Diploma.Interfaces.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Coordinates { get; set; }

        public User User { get; set; }
    }
}
