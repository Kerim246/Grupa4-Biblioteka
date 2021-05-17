using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Models
{
   
    public class KnjigaModel
    {
        public enum Zanr { Fantazija, Horror, Historija, Triler, SciFi, Romansa, Akcija, Misterija, Drama };
        public enum Ocjena { Jedan, Dva, Tri, Cetiri, Pet };
        public enum Jezik { Bosanski, Engleski, Fransuki, Njemacki, Spanski };
        public string naslov { get; set; }
        public string autor { get; set; }
        public int broj_stranica { get; set; }

        public List<Zanr> zanrovi { get; set; }

        public List<Jezik> jezici { get; set; }

        private DateTime datum_izdavanja { get; set; }

        public int koolicina { get; set; }

        public List<string> komentari { get; set; }

        public string opis { get; set; }

        public Ocjena ocj { get; set; }
        
    }
}

