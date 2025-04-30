using System.ComponentModel.DataAnnotations;
using System.Drawing.Drawing2D;

namespace DentElora.Entities
{
    public class TreatmentPhoto
    {
        public int Id { get; set; }
        [Display(Name = "Resim")]
        public string? Image{ get; set; }
        [Display(Name = "Resim2")]
        public string? Image2 { get; set; }
        [Display(Name = "Tedavi")]
        public int TreatmentId { get; set; }
        [Display(Name = "Tedavi")]
        public virtual Treatment? Treatment { get; set; }
    }
}
