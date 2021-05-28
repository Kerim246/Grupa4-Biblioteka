using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Models
{
    public class Komentar
    {
        [ForeignKey("Knjiga")]
        [Required]
        public int knjiga_id { get; set; }

        [Required]
        public string komentar { get; set; }
    }
}
