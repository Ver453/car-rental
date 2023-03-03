using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarSection.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(75)]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage ="Email is not valid")]
        public string Email { get; set; }
        [ForeignKey("Country")]
        [DisplayName("Country")]
        public int CountryId { get; set; }
        public virtual Country Country { get ; set; }

        [ForeignKey("City")]
        [DisplayName("City")]
        public int CityId { get; set; }
        public virtual City City { get; set; }
    }
}
