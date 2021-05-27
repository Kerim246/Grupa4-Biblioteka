using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Models
{
    public class Korisnik : Osoba
    {

        [ForeignKey("Osoba")]
        [Required]
        public int Id { get; set; }
        [Required]
        public List<Knjiga> pozajmljene_knjige { get; set; }

        [Required]
        private long broj_ziror_acuna { get; set; }

        [Required]
        private DateTime datum_isteka_clanarine { get; set; }


    }
}
