using System.ComponentModel.DataAnnotations;

namespace CarSection.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(75)]
        public string CountryName { get; set; }
    }
}
