using System.ComponentModel.DataAnnotations;

namespace Practice1.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [AllowedValues(["sai","vamsi","kolli"],ErrorMessage ="didn't get expected value")]
        public string AllowedValues { get; set; }

        [Required]
        [Range(18,30)]
        [Display(Name ="Age")]
        public int CustomerAge { get; set; }
    }
}
