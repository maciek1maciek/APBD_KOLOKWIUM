namespace Excercise.Models
{
    public class Order
    {

        public int Id { get; set; }
        
        public DateTime CreatedAt { get; set; }

        public DateTime? FulFilledAt { get; set; }

        public int ClientId { get; set; }

        public int StatusId{ get; set; }

        public virtual ICollection<ProductOrder> ProductOrder { get; set; } = new List<ProductOrder>();

        public virtual Client Client { get; set; } = null!;
        public virtual Status Status { get; set; } = null!;

    }
}
