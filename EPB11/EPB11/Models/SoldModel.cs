using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EPB11.Models
{
    public class SoldModel
    {
        [Key]
        public int SoldId { get; set; }
        //Relationship
        [Display(Name = "Sumă totală venituri")]
        [ForeignKey("VenitId")]
        public int VenitId { get; set; }
        [Display(Name = "Sumă totală venituri")]
        public VenitModel venit { get; set; }
        //Relationship
        [Display(Name = "Sumă totală achiziții")]
        [ForeignKey("AchizitieId")]
        public int AchizitieId { get; set; }
        [Display(Name = "Sumă totală achiziții")]
        public AchizitieModel achizitie { get; set; }
        public int Sold { get; set; }
        [Display(Name = "Monedă")]
        public string Moneda { get; set; }
    }
}
