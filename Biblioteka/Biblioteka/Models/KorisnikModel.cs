using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Models
{
    public class KorisnikModel
    {
        private List<KnjigaModel> pozajmljene_knjige { get; set; }

        private long broj_ziror_acuna { get; set; }

        private DateTime datum_isteka_clanarine { get; set; }


    }
}
