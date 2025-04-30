using System.ComponentModel.DataAnnotations;

namespace DentElora.Entities
{
    public class Gallery
    {
        public int Id { get; set; }
        [Display(Name = "Resim")]
        public string? Image { get; set; }
        [Display(Name = "Aktif?")]
        public bool isActive { get; set; }=true;
    }
}
