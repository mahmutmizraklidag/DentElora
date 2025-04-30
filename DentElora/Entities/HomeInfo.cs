using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentElora.Entities
{
    public class HomeInfo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlık boş geçilemez.")]
        [StringLength(100, ErrorMessage = "Başlık en fazla 100 karakter olabilir.")]
        [Display(Name = "Başlık")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Açıklama alanı gereklidir.")]
        [DataType(DataType.MultilineText)]
        [StringLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir.")]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        
        [StringLength(100, ErrorMessage = "İkon en fazla 100 karakter olabilir.")]
        [Display(Name = "İkon")]
        public string? Icon { get; set; }
    }
}
