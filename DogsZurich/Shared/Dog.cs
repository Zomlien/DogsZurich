using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogsZurich.Shared
{
    internal class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Color Colors { get; set;}
        public Breed Breed1 { get; set; }
        public Breed Breed2 { get; set; }
        public Breedstatus Breedstatuss { get; set; }
        public Breedtype Breedtypee { get; set; }

    }
}
