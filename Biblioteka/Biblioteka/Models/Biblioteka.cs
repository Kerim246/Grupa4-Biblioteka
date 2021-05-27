using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Models
{
    public class BibliotekaModel
    {
        public enum Grad { Sarajevo, Zenica, Tuzla, Mostar}
        public List<KnjigaModel> knjige { get; set; }

        public Grad grad { get; set; }

        public string adresa { get; set; }

        public string naziv { get; set; }
    }
}
