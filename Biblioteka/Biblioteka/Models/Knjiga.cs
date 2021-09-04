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
        [RegularExpression(@"[a-zA-Z]*$", ErrorMessage ="Unesite ispravan naziv!")]
        public string naslov { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z]*$",ErrorMessage ="Unesite ispravno ime autora")]
        public string autor { get; set; }

        [Required]
        [DisplayName("Broj stranica")]
        [Range(5,10000,ErrorMessage = "Unesite validan broj stranica!")]
        public int broj_stranica { get; set; }

        [Required, DataType(DataType.DateTime)]
        [DisplayName("Datum izdavanja")]
        [ValidacijaDatuma]
        [DateRange("01/01/1900")]
        public DateTime datum_izdavanja { get; set; }

        [Required]
        [DisplayName("Kolicina")]
        [Range(5, 10000, ErrorMessage = "Unesite validan broj kolicine!")]

        public int kolicina { get; set; }

        [Required(ErrorMessage ="Unesite opis knjige!")]
        [DisplayName("Opis:")]
        public string opis { get; set; }

        [Required]
        public double ocjena { get; set; }

        [Required]
        public int broj_puta_iznajmljena { get; set; }
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

