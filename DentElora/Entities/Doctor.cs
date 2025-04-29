using System.ComponentModel.DataAnnotations;

namespace DentElora.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        [Display(Name = "İsim Soyisim")]
        public string Name { get; set; }
        [Display(Name = "Resim")]
        public string? Image { get; set; }

    }
}
