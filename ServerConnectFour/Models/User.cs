using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ServerConnectFour.Models
{
    public class User
    {
        [Key]
        [Required(ErrorMessage = "Please enter an ID number")]
        [Range(1, 1000, ErrorMessage = "The id must be in range of 1 to 1000")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; } = default!;

        [Required(ErrorMessage = "Please enter the name")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Must be at least 2 characters")]
        public string Name { get; set; } = default!;

        [Required(ErrorMessage = "Please enter the phone-number")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Insert valid phone-number")]
        public string Phone { get; set; } = default!;

        [Required(ErrorMessage = "Please enter the country")]
        public string Country { get; set; } = default!;
    }
}
