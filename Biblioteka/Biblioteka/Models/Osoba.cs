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
        public int Id { get; set; }

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

    [Table("Administrator")]
    public class Administrator : Osoba
    {
        [ForeignKey("Osoba")]
        [Required]

        public int id { get; set; }
    }

    [Table("Bibliotekar")]
    public class Bibliotekar : Osoba
    {
        [ForeignKey("Osoba")]
        [Required]
        public int id { get; set; }

        [ForeignKey("BibliotekaM")]
        [Required]
        public int biblioteka_id { get; set; }
    } 
}
