using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EPB11.Models
{
    public class ObiectivModel
    {
        [Key]
        public int ObiectivId { get; set; }
        public string Denumire { get; set; }
        public string Descriere { get; set; }
        [Range(1, int.MaxValue)]
        public int Unitate { get; set; }
        [Display(Name = "Preț/Unitate")]
        [Range(0, int.MaxValue)]
        public int PretPerUnitate { get; set; }
        [Display(Name = "Suma totală")]
        public int SumaTotala { get; set; }
        [Display(Name = "Sold")]
        [ForeignKey("SoldId")]
        public int SoldId { get; set; }
        [Display(Name = "Sold")]
        public SoldModel sold { get; set; }
        [Display(Name = "Sumă de strâns")]
        public int SumaDeStrans { get; set; }
        [Display(Name = "Monedă")]
        public string Moneda { get; set; }
        [Display(Name = "Dată")]
        public DateTime Data { get; set; }
        [Display(Name = "Timp rămas")]
        public DateTime TimpRamas { get; set; }
        [Display(Name = "Sumă/Timp")]
        public string SumaPerTimp { get; set; }
        [Display(Name = "Offline/Online")]
        public string OfflineOnline { get; set; }
        [Display(Name = "Locație")]
        public string Locatie { get; set; }
    }
}
