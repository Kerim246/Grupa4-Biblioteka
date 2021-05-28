using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Models
{
   
    public class Knjiga
    {
        public enum Zanr { Fantazija, Horror, Historija, Triler, SciFi, Romansa, Akcija, Misterija, Drama };
        public enum Ocjena { Jedan, Dva, Tri, Cetiri, Pet };
        public enum Jezik { Bosanski, Engleski, Fransuki, Njemacki, Spanski };

        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        private string naslov { get; set; }
        [Required]
        private string autor { get; set; }
        [Required]
        private int broj_stranica { get; set; }

        [Required]
        private DateTime datum_izdavanja { get; set; }

        [Required]
        private int kolicina { get; set; }

        [Required]
        private string opis { get; set; }
        
    }
}

