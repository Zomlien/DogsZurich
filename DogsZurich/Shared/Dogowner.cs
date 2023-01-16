using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogsZurich.Shared
{
    public class Dogowner
    {
        public int Id { get; set; }
        public Sex  Sex { get; set; }
        public Quartier Quartier { get; set; }
        public Kreis Kreis { get; set; }
        public Ageclass Ageclass { get; set; }
        
    }
}
