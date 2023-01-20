using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogsZurich.Shared
{
    public class Dog
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Name ist zu lang")]
        public string Name { get; set; }
        public int BirthYear { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Bitte wählen Sie ein Geschlecht")]
        public int SexId { get; set; }
        public Sex? Sex { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Bitte wählen Sie eine Fellfarbe")]
        public int ColorsId { get; set; }
        public Color? Colors { get; set;}
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Bitte wählen Sie eine Rasse")]
        public int Breed1Id { get; set; }
        public Breed? Breed1 { get; set; }
        public int Breed2Id { get; set; }
        public Breed? Breed2 { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Bitte wählen Sie aus ob ihr Hund ein Mischling ist oder nicht")]
        public int BreedstatusId { get; set; }
        public Breedstatus? Breedstatus { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Bitte wählen Sie aus zu welcher Klasse ihr Hund gehört")]
        public int BreedtypeId { get; set; }
        public Breedtype? Breedtype { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Bitte wählen Sie Ihre Besitzer ID aus")]
        public int DogownerId { get; set; }
        public Dogowner? Dogowner { get; set; }
        

    }
}
