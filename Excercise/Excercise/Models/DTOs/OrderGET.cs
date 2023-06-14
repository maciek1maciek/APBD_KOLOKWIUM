using System.ComponentModel.DataAnnotations;

namespace Excercise.Models.DTOs
{
    public class OrderGET
    {
        [Required]
        public int Id { get; set; }

        public string ClientsLastName { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime? FulFilledAt { get; set; }
        [Required]
        public int ClientId { get; set; }
        [Required]
        public int StatusId { get; set; }
    }
}
