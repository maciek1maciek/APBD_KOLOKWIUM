namespace Excercise.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }

        public virtual ICollection<ProductOrder> ProductOrder { get; set; } = new List<ProductOrder>();

    }
}
