using System.Numerics;

namespace Excercise.Models
{
    public class ProductOrder
    {

        public int ProductId { get; set; }

        public int OrderId { get; set; }

        public int Amount { get; set; }

        public virtual Product Product { get; set; } = null!;

        public virtual Order Order { get; set; } = null!;

    }
}
