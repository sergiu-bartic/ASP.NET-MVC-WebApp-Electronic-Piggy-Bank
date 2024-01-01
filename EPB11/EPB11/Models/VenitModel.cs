using System.ComponentModel.DataAnnotations;

namespace EPB11.Models
{
    public class VenitModel
    {
        [Key]
        public int VenitId { get; set; }
        public string Denumire { get; set; }
        public string Descriere { get; set; }
        [Display(Name = "Sursă")]
        public string Sursa { get; set; }
        [Display(Name = "Dată")]
        public DateTime Data { get; set; }
        [Display(Name = "Sumă")]
        [Range(0, int.MaxValue)]
        public int Suma { get; set; }
        [Display(Name = "Monedă")]
        public string Moneda { get; set; }
        [Display(Name = "Sumă totală venituri")]
        [Range(0, int.MaxValue)]
        public int SumaTotalaVenituri { get; set; }
    }
}
