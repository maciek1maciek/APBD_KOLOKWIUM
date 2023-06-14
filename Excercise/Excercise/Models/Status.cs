namespace Excercise.Models
{
    public class Status
    {

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<Order> Order { get; set; } = new List<Order>();
    }

}
