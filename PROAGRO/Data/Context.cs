using Microsoft.EntityFrameworkCore;
using PROAGRO.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROAGRO.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Estados> Estados { get; set; }
        public DbSet<Georeferencias> Georeferencias { get; set; }
        public DbSet<Permisos> Permisos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Llaves
            modelBuilder.Entity<Usuarios>().HasKey(r => r.Id);
            modelBuilder.Entity<Estados>().HasKey(r => r.Id);
            modelBuilder.Entity<Georeferencias>().HasKey(r => r.Id);
            modelBuilder.Entity<Permisos>().HasKey(r => new { r.IdUsuario, r.IdEstado });

            //Relaciones
            modelBuilder.Entity<Permisos>()
                .HasOne(p => p.Usuario)
                .WithMany(b => b.Permisos)
                .HasForeignKey(bc => bc.IdUsuario);
            modelBuilder.Entity<Permisos>()
                .HasOne(p => p.Estado)
                .WithMany(b => b.Permisos)
                .HasForeignKey(bc => bc.IdEstado);

            modelBuilder.Entity<Georeferencias>()
                .HasOne(g => g.Estado)
                .WithMany(e => e.GeoReferencias)
                .HasForeignKey(g => g.IdEstado);

            modelBuilder.Entity<Estados>()
                .HasMany(g => g.GeoReferencias)
                .WithOne(e => e.Estado);
        }
    }
}
