using System.ComponentModel.DataAnnotations;

namespace DentElora.Entities
{
    public class FAQ
    {
        public int Id { get; set; }
        [Display(Name = "Soru")]
        public string Question { get; set; }
        [Display(Name = "Cevap")]
        public string Answer { get; set; }
    }
}
