using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteka.Data;
using Biblioteka.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Biblioteka.Service;

namespace Biblioteka.Controllers
{
    public class KnjigeController : Controller
    {
        private readonly BibliotekaContext _context;
        private string _connectionString = @"Server=sql11.freesqldatabase.com;Port=3306;Database=sql11422704;User=sql11422704;Password=K89mJvgU41;";
        public static int ajdi;
        private readonly IUserService _userService;
        private static double trenutnaOcjena; 

        public IConfiguration Configuration { get; }

        public KnjigeController(BibliotekaContext context,IUserService _userService)
        {
            _context = context;
            this._userService = _userService;
        }

        public int specialComparer(Knjiga k1, Knjiga k2)
        {
            if (k1.broj_stranica > k2.broj_stranica) return 1;
            else return -1;
        }

        // GET: Knjige
        public async Task<IActionResult> Index(string searching,string jezik, string zanr, string sort)
        {
            var knjige = from k in _context.Knjiga select k;

            if (!String.IsNullOrEmpty(searching))
            {
                knjige = knjige.Where(k => k.naslov.Contains(searching) || k.autor.Contains(searching));

            }        

            if (!String.IsNullOrEmpty(jezik))
            {
                //   knjige = knjige.Where(k => k.autor.Equals(sort));
                
                foreach (var k in knjige)
                {
                    var str = "select j.knjiga_id from Jezik j,Knjiga k where j.knjiga_id = k.id AND j.naziv = '" + jezik + "'";

                    List<String> l = vratiListu(str);
                    List<String> sigurnaLista = new List<String>();

                    foreach(var asd in l)
                    {
                        if (!asd.Equals(",")) sigurnaLista.Add(asd);
                    }

                   // List<int> intList = sigurnaLista.ConvertAll(int.Parse);

                    List<int> ints = sigurnaLista.Select(s => Int32.TryParse(s, out int n) ? n : (int?)null).Where(n => n.HasValue).Select(n => n.Value).ToList();

                      foreach (int id in ints)
                           {
                             knjige = knjige.Where(k => k.id == id);
                            }
                    
                }
                
            }
            
            if (!String.IsNullOrEmpty(zanr))
            {
                //   knjige = knjige.Where(k => k.autor.Equals(sort));

                foreach (var k in knjige)
                {
                    var str = "select z.knjiga_id from Zanr z,Knjiga k where z.knjiga_id = k.id AND z.naziv = '" +zanr + "'";

                    List<String> l = vratiListu(str);
                    List<String> sigurnaLista = new List<String>();

                    foreach (var asd in l)
                    {
                        if (!asd.Equals(",")) sigurnaLista.Add(asd);
                    }

                    // List<int> intList = sigurnaLista.ConvertAll(int.Parse);

                    List<int> ints = sigurnaLista.Select(s => Int32.TryParse(s, out int n) ? n : (int?)null).Where(n => n.HasValue).Select(n => n.Value).ToList();

                    foreach (int id in ints)
                    {
                        knjige = knjige.Where(k => k.id == id);
                    }

                }

            }

            if (!String.IsNullOrEmpty(sort))
            {
                switch(sort)
                {
                    case "Abecedni":
                        knjige = knjige.OrderBy(x => x.naslov);
                        break;

                    case "Datumu":
                        knjige = knjige.OrderByDescending(x => x.datum_izdavanja);
                        break;

                    case "brojuStranica":
                        knjige = knjige.OrderByDescending(k => k.broj_stranica);
                        break;

                    case "Kolicina":
                        knjige = knjige.OrderByDescending(k => k.kolicina);
                        break;

                }

            }
            
                return View(await knjige.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Sortiraj(IFormCollection formCollection)
        {
            string zanr = formCollection["zanr"];
            string language = formCollection["jezik"];

            string sortValue = formCollection["sort"];

            return RedirectToAction("Index",new { jezik = language, zanr = zanr, sort = sortValue});
        }

        // GET: Knjige/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var knjiga = await _context.Knjiga
                .FirstOrDefaultAsync(m => m.id == id);
            if (knjiga == null)
            {
                return NotFound();
            }

            KnjigaPage k = new KnjigaPage();

            k.id = knjiga.id;
            k.autor = knjiga.autor;
            k.broj_stranica = knjiga.broj_stranica;
            k.naslov = knjiga.naslov;
            k.opis = knjiga.opis;
            k.kolicina = knjiga.kolicina;
            k.datum_izdavanja = knjiga.datum_izdavanja;
            ajdi = k.id;


            var str = "select naziv from Jezik where knjiga_id = '" + knjiga.id + "'";
           // var str = "select naziv from Jezik where knjiga_id = @id";

            var str1 = "SELECT naziv from Zanr where knjiga_id=" + k.id;
            var str2 = "SELECT komentar from Komentar where knjiga_id=" + k.id;
            var vratiOcjenu = "SELECT ocjena FROM Ocjena where id=" + k.id;

            // var idParamtear = new SqlParameter("@id", k.id);
            //var jezici = _context.Jezik.FromSql("SELECT naziv from Jezik where id = @id", idParamtear);
            //k.jezici = jezici;

            k.jezici = vratiListu(str);
            k.zanrovi = vratiListu(str1);
            k.komentari = vratiListu(str2);
            var mapa = VratiOcjenu();
            double ocjena = 0;
        
            foreach (KeyValuePair<double, int> kvp in mapa)
            {
                ocjena = kvp.Key;

            }
            k.ocjena = Math.Round(ocjena,2);             // Zaokruzeno na dvije decimale


            return View(k);
        }
        [HttpPost]
        public ActionResult Update(string komentar="")
        {

            var cmd = "INSERT INTO Komentar(Knjiga_id,komentar) values (@Knjiga_id,@komentar)";

            MySqlConnection connection = new MySqlConnection(_connectionString);

            MySqlCommand command = new MySqlCommand(cmd, connection);
            command.Parameters.AddWithValue("@Knjiga_id", ajdi);
            command.Parameters.AddWithValue("@komentar", komentar);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            return RedirectToAction("Index");

        } 
       
        public List<string> vratiListu(String str)
        {

            MySqlConnection connection = new MySqlConnection(_connectionString);
            connection.Open();
                MySqlCommand command = new MySqlCommand(str, connection);
               // command.Parameters["@id"].Value = id;

                MySqlDataReader datareader = command.ExecuteReader();
            
                List<String> lista = new List<String>();
                string izlaz = "";
                while (datareader.Read())
                {
                    izlaz = izlaz + datareader.GetValue(0) + ",";
                }
            connection.Close();
            string[] listaStr = izlaz.Split(",");

                foreach (var j in listaStr)
                {
                    lista.Add(j);
                    lista.Add(",");
                }

            lista.RemoveAt(lista.Count - 1);
                return lista;

            
        }

        private Dictionary<double,int> VratiOcjenu(bool ocjenjivanje = false)         // vraca mapu gdje prvi atribut predstavlja ocjenu a drugi broj ocjena
        {
            var map = new Dictionary<double, int>();

            var userName = _userService.getUserId();

            var vratiDosadasnjeOcjene = "";
            if(ocjenjivanje == false)
            vratiDosadasnjeOcjene = "SELECT ocjena FROM Ocjena where id=" + ajdi + " AND korisnik_id IS NULL"; // Ako nas zanima samo prosjecna ocjena za datu knjigu 
            else
            vratiDosadasnjeOcjene = "SELECT ocjena FROM Ocjena where id=" + ajdi + " AND korisnik_id IS NOT NULL AND korisnik_id !='" + userName + "'";  // Ako je korisnik_id null, onda je ocjena opca prosjecna, ako nije onda je userova

            MySqlConnection connection = new MySqlConnection(_connectionString);
            connection.Open();
            MySqlCommand command = new MySqlCommand(vratiDosadasnjeOcjene, connection);

            MySqlDataReader datareader = command.ExecuteReader();

            double iznos = 0;
            string izlaz = "";
            int br_ocjena = 0;
            while (datareader.Read())
            {
                izlaz = izlaz + datareader.GetValue(0);
                iznos += Double.Parse(izlaz);
                br_ocjena++;
            //    System.Diagnostics.Debug.WriteLine("MAMA");
                izlaz = "";
            }
            connection.Close();
          //  System.Diagnostics.Debug.WriteLine("Iznos  " + iznos.ToString() + " a broj ocjena " + br_ocjena);

            if (!ocjenjivanje)
            iznos /= br_ocjena;

            map.Add(iznos, br_ocjena);

            if(Double.IsNaN(iznos)) { return new Dictionary<double, int>(); }
            return map;
        }

        public ActionResult Ocijeni(IFormCollection formcollection)
        {
            var userName = _userService.getUserId();
            MySqlConnection connection = new MySqlConnection(_connectionString);

            string valueOcjena = formcollection["ocjena"];

            var upitDodajOcjenu = "INSERT INTO Ocjena(id,ocjena,korisnik_id) Values (@id,@ocjena,@korisnik_id)";
            var provjerausera = "SELECT id from Ocjena WHERE korisnik_id = '" + userName + "'" + " AND id ="+ajdi;
            var DaLiPostojiOcjena = "SELECT ocjena FROM Ocjena where korisnik_id IS NULL and id =" + ajdi;

           

            var trenutna = VratiOcjenu(true);
            double iznos = 0;
            int br_ocjena = 0;
            foreach (KeyValuePair<double, int> kvp in trenutna)
            {
                iznos = kvp.Key;
                br_ocjena = kvp.Value;
            }

            br_ocjena++;

            iznos = (iznos +int.Parse(valueOcjena)) / br_ocjena;


            MySqlCommand command = new MySqlCommand(provjerausera, connection);

            connection.Open();

            MySqlDataReader datareader = command.ExecuteReader();

            if (datareader.Read())
            {
                connection.Close();
                var updateOcjena = "UPDATE Ocjena SET ocjena ='" + int.Parse(valueOcjena) +  "'" + " where korisnik_id = '" + userName + "'" + " AND id=" + ajdi;
                command = new MySqlCommand(updateOcjena, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            else
            {
                connection.Close();
                command = new MySqlCommand(upitDodajOcjenu, connection);
                command.Parameters.AddWithValue("@id", ajdi);
                command.Parameters.AddWithValue("@ocjena", int.Parse(valueOcjena));   // ocjena koju je dati user dao  
                command.Parameters.AddWithValue("@korisnik_id", userName);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            connection.Open();
            command = new MySqlCommand(DaLiPostojiOcjena, connection);

            datareader = command.ExecuteReader();

            if (!datareader.Read())
            {
                connection.Close();
                command = new MySqlCommand(upitDodajOcjenu, connection);
                command.Parameters.AddWithValue("@id", ajdi);
                command.Parameters.AddWithValue("@ocjena", iznos);      // Prosjecna ocjena za knjigu
                command.Parameters.AddWithValue("@korisnik_id", null);    
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            else
            {
                connection.Close();
                var updateOcjena = "UPDATE Ocjena SET ocjena ='" + iznos + "'" + " where korisnik_id IS NULL AND id=" + ajdi;  // updejtovanje prosjecne ocjene za knjigu
                command = new MySqlCommand(updateOcjena, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }

           

            return RedirectToAction("Index");

        }

        public ActionResult RegistrujKnjigu(IFormCollection formCollection)
        {
            string naslov = Request.Form["Naziv"];
            string autor = Request.Form["Autor"];
            string zanr = Request.Form["Zanr"];
            string opis = Request.Form["Opis"];
            string kolicina = Request.Form["Kolicina"];
            string broj_stranica = Request.Form["broj_stranica"];
            string jezik = Request.Form["Jezik"];
            string datum = Request.Form["Date"];
            

            var str = "SELECT Max(id)+1 FROM Knjiga";

            MySqlConnection connection = new MySqlConnection(_connectionString);
            connection.Open();
            MySqlCommand command = new MySqlCommand(str, connection);
            MySqlDataReader datareader = command.ExecuteReader();
            int Id;
            String izlaz = "";
            if (datareader.Read())
            {
                izlaz = izlaz + datareader.GetValue(0);
            }
            connection.Close();
            Id = int.Parse(izlaz);

            var dodaj = "INSERT INTO Knjiga(id,naslov,autor,broj_stranica,datum_izdavanja,kolicina,opis) values (@id,@naslov,@autor,@broj_stranica,@datum_izdavanja,@kolicina,@opis)";

            command = new MySqlCommand(dodaj, connection);

            command.Parameters.AddWithValue("@id", Id);
            command.Parameters.AddWithValue("@naslov", naslov);
            command.Parameters.AddWithValue("@autor", autor);
            command.Parameters.AddWithValue("@broj_stranica", broj_stranica);
            command.Parameters.AddWithValue("@datum_izdavanja",DateTime.Parse(datum));
            command.Parameters.AddWithValue("@kolicina", kolicina);
            command.Parameters.AddWithValue("@opis", opis);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            dodaj = "INSERT INTO Jezik(knjiga_id,naziv) values (@knjiga_id,@naziv)";

            command = new MySqlCommand(dodaj, connection);

            command.Parameters.AddWithValue("@knjiga_id", Id);
            command.Parameters.AddWithValue("@naziv", jezik);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            dodaj = "INSERT INTO Zanr(knjiga_id,naziv) values (@knjiga_id,@naziv)";

            command = new MySqlCommand(dodaj, connection);

            command.Parameters.AddWithValue("@knjiga_id", Id);
            command.Parameters.AddWithValue("@naziv", zanr);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();


            return RedirectToAction("Index");
        }

        [Authorize(Roles ="Korisnik")]
        public ActionResult DodajIznajmljenu()
        {
            var UserName = _userService.getUserId();

          //  System.Diagnostics.Debug.WriteLine("PLEASE " + UserName);

            var dajKorisnikId = "SELECT Id FROM AspNetUsers where Id = '" + UserName + "'";

            var cmd = "INSERT INTO IznajmljeneKnjige(knjiga_id,korisnik_id,datum_vracanja,datum_iznajmljivanja) values (@knjiga_id,@korisnik_id,@datum_vracanja,@datum_iznajmljivanja)";

            var provjeraValidnosti = "SELECT * FROM IznajmljeneKnjige where Korisnik_id= '" + UserName + "'" + " AND knjiga_id= '" + ajdi + "'";
            var provjeraDaLiPrazno = "SELECT * FROM IznajmljeneKnjige";
            MySqlConnection connection = new MySqlConnection(_connectionString);
            connection.Open();
            MySqlCommand command = new MySqlCommand(provjeraDaLiPrazno, connection);
            MySqlDataReader datareader = command.ExecuteReader();
            bool prolaz = false;
            bool prolaz1 = true;
            MySqlDataReader pomocni = datareader;

            if (datareader.Read())        // Provjera da li je prazna tabela, ako jeste provjerava se da li je korisnik vec pozajmio datu knjigu, ako nije odobrava se pozajma
            {
                connection.Close();
                connection.Open();
                command = new MySqlCommand(provjeraValidnosti, connection);
                datareader = command.ExecuteReader();

                if (datareader.Read())
                {
                    prolaz1 = false;
                    connection.Close();
                    TempData["Message"] = "Vec ste pozajmili ovu knjigu!";

                    return RedirectToAction("Greska");
                }
                else
                {
                    prolaz = true;
                }
            }
            if((prolaz && prolaz1) || !pomocni.Read())   // Ako je prazna tabela ili ako je validna pozajma
            {
                connection.Close();
                connection.Open();

                command = new MySqlCommand(dajKorisnikId, connection);

                 datareader = command.ExecuteReader();

                List<String> lista = new List<String>();
                string izlaz = "";
                while (datareader.Read())
                {
                    izlaz = izlaz + datareader.GetValue(0);
                }
                connection.Close();


                command = new MySqlCommand(cmd, connection);

                command.Parameters.AddWithValue("@Knjiga_id", ajdi);
                command.Parameters.AddWithValue("@korisnik_id", izlaz);
                command.Parameters.AddWithValue("@datum_iznajmljivanja", DateTime.Now);
                command.Parameters.AddWithValue("@datum_vracanja", DateTime.Now.AddDays(30));


                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            return RedirectToAction("Index");
        }

        // GET: Knjige/Create
        [Authorize(Roles = "Administrator, Bibliotekar")]
        public IActionResult Create()
        {
          //  KnjigaPage kp = new KnjigaPage();
            return View();
        }

        public IActionResult Greska()
        {
            return View();
        }

        // POST: Knjige/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator, Bibliotekar")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,naslov,autor,broj_stranica,datum_izdavanja,kolicina,opis")] Knjiga knjiga,[Bind("knjiga_id,naziv")] Jezik jezik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(knjiga);
                _context.Add(jezik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(knjiga);
        }

        // GET: Knjige/Edit/5
        [Authorize(Roles = "Administrator, Bibliotekar")]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var knjiga = await _context.Knjiga.FindAsync(id);
            if (knjiga == null)
            {
                return NotFound();
            }
            return View(knjiga);
        }

        // POST: Knjige/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator, Bibliotekar")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,naslov,autor,broj_stranica,datum_izdavanja,kolicina,opis")] Knjiga knjiga)
        {
            if (id != knjiga.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(knjiga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KnjigaExists(knjiga.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(knjiga);
        }

        // GET: Knjige/Delete/5
        [Authorize(Roles = "Administrator, Bibliotekar")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var knjiga = await _context.Knjiga
                .FirstOrDefaultAsync(m => m.id == id);
            if (knjiga == null)
            {
                return NotFound();
            }

            return View(knjiga);
        }

        // POST: Knjige/Delete/5
        [Authorize(Roles = "Administrator, Bibliotekar")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var knjiga = await _context.Knjiga.FindAsync(id);
            _context.Knjiga.Remove(knjiga);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KnjigaExists(int id)
        {
            return _context.Knjiga.Any(e => e.id == id);
        }
    }
}
