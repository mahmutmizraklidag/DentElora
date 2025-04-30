using System.ComponentModel.DataAnnotations;

namespace DentElora.Entities
{
    public class Treatment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlık gereklidir.")]
        [StringLength(150, ErrorMessage = "Başlık en fazla 150 karakter olabilir.")]
        [Display(Name = "Başlık")]
        public string Title { get; set; }

        [StringLength(500, ErrorMessage = "Kısa açıklama en fazla 500 karakter olabilir.")]
        [Display(Name = "Kısa Açıklama")]
        public string? shortDescription { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(4000, ErrorMessage = "Açıklama en fazla 4000 karakter olabilir.")]
        [Display(Name = "Açıklama")]
        public string? Description { get; set; }
        [Display(Name = "Resim")]
        public string? Image { get; set; }
        [Display(Name = "İkon")]
        public string? İcon { get; set; }
        [Display(Name = "Tedavi Fotoğrafları")]
        public virtual ICollection<TreatmentPhoto> TreatmentPhotos { get; set; }

        public Treatment()
        {
            TreatmentPhotos = new List<TreatmentPhoto>();
        }
    }
}
