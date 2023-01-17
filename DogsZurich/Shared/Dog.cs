using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogsZurich.Shared
{
    public class Dog
    {
        public int Id { get; set; }
        //public string Name { get; set; }
        public int SexId { get; set; }
        public Sex? Sex { get; set; }
        public int ColorsId { get; set; }
        public Color? Colors { get; set;}
        public int Breed1Id { get; set; }
        public Breed? Breed1 { get; set; }
        public int Breed2Id { get; set; }
        public Breed? Breed2 { get; set; }
        public int BreedstatusId { get; set; }
        public Breedstatus? Breedstatus { get; set; }
        public int BreedtypeId { get; set; }
        public Breedtype? Breedtype { get; set; }
        public int DogownerId { get; set; }
        public Dogowner? Dogowner { get; set; }
        

    }
}
