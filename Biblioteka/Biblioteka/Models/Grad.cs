using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Models
{
    public class Grad
    {
        [Key]
        [Required]
        public int id { get; set; }

        [Required]

        public string naziv { get; set; }

        [Foreignkey("Biblioteka")]
        [Required]

        public int biblioteka_id { get; set; }
    }
}
