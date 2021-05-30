using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Models
{
    [Table("Administrator")]
    public class Administrator 
    {
        [ForeignKey("Osoba")]
        [Required]

        public int id { get; set; }
    }
}
