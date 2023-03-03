using System.ComponentModel.DataAnnotations;

namespace CarSection.Models
{
    public class CarModel
    {
        [Key]
        public int Id { get; set; }
        public string CarName { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
    }
}
