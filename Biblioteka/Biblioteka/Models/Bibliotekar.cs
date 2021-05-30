using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Models
{
    [Table("Bibliotekar")]
    public class Bibliotekar
    {
        [ForeignKey("Osoba")]
        [Required]
        public int bibliotekar_id { get; set; }

        [ForeignKey("BibliotekaM")]
        [Required]
        public int biblioteka_id { get; set; }
    }
}
