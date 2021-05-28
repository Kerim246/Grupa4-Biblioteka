using Biblioteka.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteka.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

    //    public DbSet<Administrator> Administrator { get; set; }
        public DbSet<BibliotekaM> BibliotekaM { get; set; }
        public DbSet<KnjigeBiblioteke> KnjigeBiblioteke { get; set; }
   //     public DbSet<Bibliotekar> Bibliotekar { get; set; }
        public DbSet<Grad> Grad { get; set; }
        public DbSet<IznajmljeneKnjige> IznajmljeneKnjige { get; set; }
        public DbSet<Jezik> Jezik { get; set; }
        public DbSet<Knjiga> Knjiga { get; set; }
        public DbSet<Komentar> Komentar { get; set; }
        public DbSet<Ocjena> Ocjena { get; set; }
        public DbSet<Osoba> Osoba { get; set; }
        public DbSet<Zanr> Zanr { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder.Entity<Osoba>().ToTable("Osoba");

          //  modelBuilder.Entity<Administrator>().ToTable("Administrator");
            modelBuilder.Entity<BibliotekaM>().ToTable("BibliotekaM");
            modelBuilder.Entity<Knjiga>().ToTable("Knjiga");
            modelBuilder.Entity<KnjigeBiblioteke>(builder =>
                {
                    builder.HasNoKey();
                    builder.ToTable("KnjigeBiblioteke");
                });
          //  modelBuilder.Entity<Bibliotekar>().ToTable("Bibliotekar");
            modelBuilder.Entity<Grad>().ToTable("Grad");
            modelBuilder.Entity<IznajmljeneKnjige>(builder =>
                {
                    builder.HasNoKey();
                    builder.ToTable("IznajmljeneKnjige");
                });
            modelBuilder.Entity<Jezik>(builder =>
            {
                builder.HasNoKey();
                builder.ToTable("Jezik");
            });
            
            modelBuilder.Entity<Komentar>(builder =>
            {
                builder.HasNoKey();
                builder.ToTable("Komentar");
            });
            modelBuilder.Entity<Ocjena>(builder =>
            {
                builder.HasNoKey();
                builder.ToTable("Ocjena");
            });
            modelBuilder.Entity<Zanr>(builder =>
            {
                builder.HasNoKey();
                builder.ToTable("Zanr");
            });
        }

    }
}
