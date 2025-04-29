using System.ComponentModel.DataAnnotations;

namespace DentElora.Entities
{
    public class Treatment
    {
        public int Id { get; set; }
        [Display(Name = "Başlık")]
        public string Title { get; set; }
        [Display(Name = "Resim")]
        public string? Image { get; set; }
        [Display(Name = "Kısa Açıklama")]
        public string? shortDescription { get; set; }
        [Display(Name = "Açıklama")]
        public string? Description { get; set; }
    }
}
