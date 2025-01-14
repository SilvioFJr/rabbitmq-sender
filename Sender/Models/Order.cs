using System.ComponentModel.DataAnnotations;

namespace Sender.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; } 
        public required string Name { get; set; }
        public required decimal Value { get; set; }
        public required int Quantity { get; set; }

    }
}