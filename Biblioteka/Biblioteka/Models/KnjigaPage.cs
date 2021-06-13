using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Models
{
    public class KnjigaPage
    {
        
        public int id { get; set; }
        public string naslov { get; set; }
        public string autor { get; set; }

        public int broj_stranica { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime datum_izdavanja { get; set; }


        public int kolicina { get; set; }

        public string opis { get; set; } 

        public Knjiga knjiga { get; set; }
        [DisplayName("Jezici: ")]
        public List<String> jezici { get; set; }

        [DisplayName("Zanrovi: ")]
        public List<String> zanrovi { get; set; }

        [DisplayName("Ocjena: ")]
        public List<String> ocjene { get; set; }

        [DisplayName("Komentari: ")]
        public List<String> komentari { get; set; }

        public Ocjena ocjena { get; set; }

        public KnjigaPage() {  }

        public KnjigaPage(Knjiga knjiga,List<String> jezici) { this.knjiga = knjiga; this.jezici = jezici; }
    }
}
