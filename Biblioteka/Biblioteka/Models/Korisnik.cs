using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Models
{
    public class Korisnik
    {

        [Required]
        [Key]
        public int id;

        public string email { get; set; }


    } 
}
