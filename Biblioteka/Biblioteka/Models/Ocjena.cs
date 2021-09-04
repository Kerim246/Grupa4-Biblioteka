using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Models
{
    public class Ocjena
    {
        [ForeignKey("Knjiga")]
        [Required]
        public int id { get; set; }

        [Required]
        public double ocjena { get; set; }

        [ForeignKey("Korisnik")]
        [Required]

        public int korisnik_id { get; set; }
    }
}
