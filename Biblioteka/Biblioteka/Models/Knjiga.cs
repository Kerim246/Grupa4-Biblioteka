using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Models
{
   
    public class Knjiga
    {

        public Knjiga() { }
        public enum Zanr { Fantazija, Horror, Historija, Triler, SciFi, Romansa, Akcija, Misterija, Drama };
        public enum Ocjena { Jedan, Dva, Tri, Cetiri, Pet };
        public enum Jezik { Bosanski, Engleski, Fransuki, Njemacki, Spanski };

        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        public string naslov { get; set; }
        [Required]
        public string autor { get; set; }
        [Required]
        [DisplayName("Broj stranica")]

        public int broj_stranica { get; set; }

        [Required, DataType(DataType.DateTime)]
        [DisplayName("Datum izdavanja")]

        public DateTime datum_izdavanja { get; set; }

        [Required]
        [DisplayName("Kolicina")]

        public int kolicina { get; set; }

        [Required]
        [DisplayName("Opis:")]
        public string opis { get; set; }
        

        public Knjiga(string naslov,string autor,int broj_stranica,DateTime datum_izdavanja,int kolicina,string opis)
        {
            this.naslov = naslov;
            this.autor = autor;
            this.broj_stranica = broj_stranica;
            this.datum_izdavanja = datum_izdavanja;
            this.kolicina = kolicina;
            this.opis = opis;
        }
    }
}

