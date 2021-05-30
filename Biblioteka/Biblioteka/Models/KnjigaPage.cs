using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Models
{
    public class KnjigaPage
    {
        public Knjiga Knjiga {get; set;}
        public Jezik Jezik {get; set;} 
        public Zanr Zanr { get; set; }
        public Grad Grad { get; set; }

        public Ocjena Ocjena { get; set; }

        public Komentar Komentar { get; set; }
    }
}
