using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogsZurich.Shared
{
    public class Dogowner
    {
        public int Id { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Bitte wählen Sie ihr Geschlecht")]
        public int SexId { get; set; }
        public Sex?  Sex { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Bitte wählen Sie ihr Quartier")]
        public int QuartierId { get; set; }
        public Quartier? Quartier { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Bitte wählen Sie ihr Kreis")]
        public int KreisId { get; set; }
        public Kreis? Kreis { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Bitte wählen Sie Ihre Altersklasse")]
        public int AgeclassId { get; set; }
        public Ageclass? Ageclass { get; set; }
        
    }
}
