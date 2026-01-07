using System.ComponentModel.DataAnnotations;

namespace BookBank.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? BookName { get; set; }

        [Required]
        [StringLength(20)]
        public string? Genre { get; set; }

        public bool AvailabilityStatus { get; set; }
    }
}
