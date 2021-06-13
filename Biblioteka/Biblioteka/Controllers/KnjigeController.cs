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

namespace Biblioteka.Controllers
{
    public class KnjigeController : Controller
    {
        private readonly BibliotekaContext _context;
        private string _connectionString = @"Server=sql11.freesqldatabase.com;Port=3306;Database=sql11418771;User=sql11418771;Password=bKPA8lMKiq;";


        public IConfiguration Configuration { get; }

        public KnjigeController(BibliotekaContext context)
        {
            _context = context;
        }

        public ActionResult Ddl()
        {
            var segmentList = new List<ListSort>();
            ListSort segmentItem;
            var strArr = new string[] { "Jaipur", "Kota", "Bhilwara", "Udaipur", "Chitorgar", "Ajmer", "Jodhpur" };
            for (int index = 0; index < strArr.Length; index++)
            {
                segmentItem = new ListSort();
                segmentItem.kriterij = strArr[index];
                segmentList.Add(segmentItem);
            }
            return View(segmentList);
        }

        [HttpPost]
        public ActionResult ActionPostData(string Segmentation)
        {
            return RedirectToAction("Ddl");
        }

        // GET: Knjige
        public async Task<IActionResult> Index()
        {
            string[] opcije = { "Cow", "Camel", "Elephant" };
            List<String> options = new List<String>(opcije);


            return View(await _context.Knjiga.ToListAsync());
        }
        /* Ideja za choicebox, izvucem selekotovani item i onda update Index fju na nacin da poredim ako je taj onda sortiraj tako i tako za svaki*/

        /*
        public async Task<IActionResult> Index(string kriterij)
        {

            ViewData["NameSortParm"] = String.IsNullOrEmpty(kriterij) ? "name_desc" : "";
            ViewData["DateSortParm"] = kriterij == "Date" ? "date_desc" : "Date";
            var students = from s in _context.Knjiga
                           select s;
            switch (kriterij)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default:
                    students = students.OrderBy(s => s.LastName);
                    break;
            }
            return View(await students.AsNoTracking().ToListAsync());

            return View(await _context.Knjiga.ToListAsync());
        } */

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

       //     KnjigaPage k = new KnjigaPage(knjiga, vratiListu(str));
            //     k.zanrovi = vratiListu(str1,k.id);
            //    k.komentari = vratiListu(str2,k.id);

            return View(k);
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
                    lista.Add(",");
                }

            lista.RemoveAt(lista.Count - 1);
                return lista;

            
        }

        // GET: Knjige/Create
        public IActionResult Create()
        {
            KnjigaPage kp = new KnjigaPage();
            return View(kp);
        }

        // POST: Knjige/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
