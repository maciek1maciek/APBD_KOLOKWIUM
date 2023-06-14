namespace Excercise.Models
{
    public class Client
    {

        public int Id { get; set; }

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public virtual ICollection<Order> Order { get; set; } = new List<Order>();
    }
}
