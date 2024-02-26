using DataBaseModel.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseModel
{
    public class DbContext_Foro: DbContext
    {
        public DbContext_Foro()
        {

        }

        public DbContext_Foro(DbContextOptions<DbContext_Foro>options): base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(x =>
            {
                x.HasNoKey();
                x.Property(o => o.nombreUsuario).HasColumnName("nombreUsuario");
            });

            modelBuilder.Entity<Preguntas>(x =>
            {
                x.HasNoKey();
                x.Property(o => o.pregunta).HasColumnName("pregunta");
            });

            modelBuilder.Entity<Respuesta>(x =>
            {
                x.HasNoKey();
                x.Property(o => o.idPregunta).HasColumnName("idPregunta");
                x.Property(o => o.nombreUsuario).HasColumnName("nombreUsuario");
            });
        }
    }
}