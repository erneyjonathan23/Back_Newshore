using Microsoft.EntityFrameworkCore;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Domain.Common;
using OP.Prueba.Domain.Entities;
using OP.Prueba.Persistence.Configuration;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace OP.Prueba.Persistence.Context
{ 
    public class ApplicationDbContext : DbContext
    {
        private readonly IDateTimeService _dateTime;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTime) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTime = dateTime;
        }
        public DbSet<ContactoEmergencia> ContactoEmergencia { get; set; }
        public DbSet<Generos> Generos { get; set; }
        public DbSet<MetodosPago> MetodosPago { get; set; }
        public DbSet<Personas> Personas { get; set; }
        public DbSet<ReservaPersonas> ReservaPersonas { get; set; }
        public DbSet<Reservas> Reservas { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<TiposDocumento> TiposDocumento { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

        public Task<int> SaveChangeAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.FeRegistro = _dateTime.NowUtc;
                        break;
                    case EntityState.Added:
                        entry.Entity.FeBaja = _dateTime.NowUtc;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Seed();
        }
    }
}
