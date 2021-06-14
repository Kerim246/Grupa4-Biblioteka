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

namespace Biblioteka.Controllers
{
    public class KnjigeController : Controller
    {
        private readonly BibliotekaContext _context;
        private string _connectionString = @"Server=sql11.freesqldatabase.com;Port=3306;Database=sql11418771;User=sql11418771;Password=bKPA8lMKiq;";
        public static int ajdi;

        public IConfiguration Configuration { get; }

        public KnjigeController(BibliotekaContext context)
        {
            _context = context;
        }


        // GET: Knjige
        public async Task<IActionResult> Index(string searching)
        {
            var knjige = from k in _context.Knjiga select k;

            if (!String.IsNullOrEmpty(searching))
            {
                knjige = knjige.Where(k => k.naslov.Contains(searching) || k.autor.Contains(searching));

            }

            return View(await knjige.ToListAsync());
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
              var str = "select naziv from Jezik where knjiga_id = '" + knjiga.id + "'";
           // var str = "select naziv from Jezik where knjiga_id = @id";

            var str1 = "SELECT naziv from Zanr where knjiga_id=" + k.id;
            var str2 = "SELECT komentar from Komentar where knjiga_id=" + k.id;
            // var idParamtear = new SqlParameter("@id", k.id);
            //var jezici = _context.Jezik.FromSql("SELECT naziv from Jezik where id = @id", idParamtear);
            //k.jezici = jezici;

            k.jezici = vratiListu(str);
            k.zanrovi = vratiListu(str1);
            k.komentari = vratiListu(str2);

            ajdi = k.id;
       //     KnjigaPage k = new KnjigaPage(knjiga, vratiListu(str));
            //     k.zanrovi = vratiListu(str1,k.id);
            //    k.komentari = vratiListu(str2,k.id);

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

        public List<String> vratiListu(String str)
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
                    lista.Add("\n");
                }

            lista.RemoveAt(lista.Count - 1);
                return lista;

            
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


        public ActionResult DodajIznajmljenu()
        {
            var cmd = "INSERT INTO IznajmljeneKnjige(knjiga_id,korisnik_id,datum_vracanja,datum_iznajmljivanja) values (@knjiga_id,@korisnik_id,@datum_vracanja,@datum_iznajmljivanja)";

            MySqlConnection connection = new MySqlConnection(_connectionString);

            MySqlCommand command = new MySqlCommand(cmd, connection);
            command.Parameters.AddWithValue("@Knjiga_id", ajdi);
            command.Parameters.AddWithValue("@korisnik_id", 1);
            command.Parameters.AddWithValue("@datum_iznajmljivanja", DateTime.Now);
            command.Parameters.AddWithValue("@datum_vracanja", DateTime.Now.AddDays(30));


            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            return RedirectToAction("Index");
        }

        // GET: Knjige/Create
        [Authorize(Roles = "Administrator, Bibliotekar")]
        public IActionResult Create()
        {
          //  KnjigaPage kp = new KnjigaPage();
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
