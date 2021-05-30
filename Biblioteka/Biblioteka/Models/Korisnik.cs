using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Models
{
    public class Korisnik
    {

        [ForeignKey("Osoba")]
        [Required]
        public int korisnik_id { get; set; }

        [Required]
        public long broj_ziror_acuna { get; set; }

        [ForeignKey("BibliotekaM")]
        [Required]
        public int biblioteka_id { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTime datum_isteka_clanarine { get; set; }


    } 
}
