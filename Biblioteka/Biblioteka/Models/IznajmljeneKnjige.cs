using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Models
{
  
    public class IznajmljeneKnjige
    {
        [ForeignKey("Knjiga")]
        [Required]
        public int knjiga_id { get; set; }

        [ForeignKey("Korisnik")]
        [Required]
        public int korisnik_id { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTime datum_vracanja { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTime datum_iznajmljivanja { get; set; }

    }
}
