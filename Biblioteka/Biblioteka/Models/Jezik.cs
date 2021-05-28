using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Models
{
    public class Jezik
    {
        public enum jezik { bosanski,engleski,francuski,njemacki,ruski }

        [ForeignKey("Knjiga")]
        [Required]
        public int knjiga_id { get; set; }

        [Required]
        public string naziv { get; set; }
    }
}
