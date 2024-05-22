using System.ComponentModel.DataAnnotations;

namespace EfCore_Task1.Models
{
    public class CustomerProduct
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
