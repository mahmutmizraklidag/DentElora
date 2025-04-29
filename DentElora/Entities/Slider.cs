using System.ComponentModel.DataAnnotations;

namespace DentElora.Entities
{
    public class Slider
    {
        public int id { get; set; }
        [Display(Name = "Resim")]
        public string? image { get; set; }
        [Display(Name = "Resim-2")]
        public string? image2 { get; set; }
    }
}
