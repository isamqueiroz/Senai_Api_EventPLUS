using Event_plus.Domains;
using Microsoft.EntityFrameworkCore;

namespace Event_plus.Context
{
    public class EventoContext : DbContext
    {
        public EventoContext()
        {
        }

        public EventoContext(DbContextOptions<EventoContext> options) : base(options)
        {
        }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<ComentariosEventos> ComentariosEventos { get; set; }
        public DbSet<Eventos> Eventos { get; set; }
        public DbSet<Instituicoes> Instituicoes { get; set; }
        public DbSet<PresencasEventos> PresencasEventos { get; set; }
        public DbSet<TiposEventos> TiposEventos { get; set; }
        public DbSet<TiposUsuarios> TiposUsuario { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-2H1U5TH\\SQLEXPRESS; Database=Event; User Id=sa; Pwd=Senai@134; TrustServerCertificate=true;");
            }
        }
    }
}
