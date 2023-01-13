using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogsZurich.Shared
{
    internal class Dogowner
    {
        public int Id { get; set; }
        public Sex  Sexx { get; set; }
        public Quartier Quartierr { get; set; }
        public Kreis Kreiss { get; set; }
        public Ageclass Ageclasss { get; set; }
        public ICollection<Dog> Dogs { get; set; }
    }
}
