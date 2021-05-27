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
        private string naslov { get; set; }
        private string autor { get; set; }
        private int broj_stranica { get; set; }

        private List<Zanr> zanrovi { get; set; }

        private List<Jezik> jezici { get; set; }

        private DateTime datum_izdavanja { get; set; }

        private int koolicina { get; set; }

        private List<string> komentari { get; set; }

        private string opis { get; set; }

        private Ocjena ocj { get; set; }
        
    }
}

