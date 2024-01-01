using System.ComponentModel.DataAnnotations;

namespace EPB11.Models
{
    public class AchizitieModel
    {
        [Key]
        public int AchizitieId { get; set; }
        public string Denumire { get; set; }
        public string Descriere { get; set; }
        [Display(Name = "Offline/Online")]
        public string OfflineOnline { get; set; }
        [Display(Name = "Locație")]
        public string Locatie { get; set; }
        [Range(1, int.MaxValue)]
        public int Unitate { get; set; }
        [Display(Name = "Preț/Unitate")]
        [Range(0, int.MaxValue)]
        public int PretPerUnitate { get; set; }
        [Display(Name = "Preț total")]
        public int PretTotal { get; set; }
        [Display(Name = "Monedă")]
        public string Moneda { get; set; }
        [Display(Name = "Dată")]
        public DateTime Data { get; set; }
        [Display(Name = "Sumă totală achiziții")]
        [Range(0, int.MaxValue)]
        public int SumaTotalaAchizitii { get; set; }
    }
}
