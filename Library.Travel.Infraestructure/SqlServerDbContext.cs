using Library.Travel.Domain.Aggregates.LibraryTravel;
using Library.Travel.Transverse.Entities;
using Microsoft.EntityFrameworkCore;


namespace Library.Travel.Infraestructure
{
    public class SqlServerDbContext : DbContext
    {
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options)
        : base(options)
        {
        }
        public DbSet<Autor>? Autores { get; set; }
        public DbSet<Libro>? Libros { get; set; }
        public DbSet<Autores_Has_Libros>? Autores_Has_Libros { get; set; }
        public DbSet<Editorial>? Editoriales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autores_Has_Libros>()
                .HasKey(a => new { a.Autores_Id, a.Libros_ISBN });

            modelBuilder.Entity<Autores_Has_Libros>()
                .HasOne(a => a.Autor)
                .WithMany(b => b.AutoresHasLibros)
                .HasForeignKey(a => a.Autores_Id);

            modelBuilder.Entity<Autores_Has_Libros>()
                .HasOne(a => a.Libro)
                .WithMany(b => b.Autores_Has_Libros)
                .HasForeignKey(a => a.Libros_ISBN);

            modelBuilder.Entity<Libro>()
                .HasOne(a => a.Editorial)
                .WithMany(b => b.Libros)
                .HasForeignKey(a => a.Editoriales_Id);
        }

    }
}
