using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Models
{
    [Table("Osoba")]
    public class Osoba
    {
        [Key]
        [Required]
        public int id { get; set; }

        [Required]
        public string ime { get; set; }

        [Required]
        public string prezime { get; set; }
        [Required]
        public long broj_telefona { get; set; }

        [Required]
        public string email { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string sifra { get; set; }

    }
}
