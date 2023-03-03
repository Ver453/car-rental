using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarSection.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string CityName { get; set; }

        [ForeignKey("Country")]
        [DisplayName("Country")]
        public int CountryId { get; set; }
        public virtual Country Country { get ; set; }
    }
}
