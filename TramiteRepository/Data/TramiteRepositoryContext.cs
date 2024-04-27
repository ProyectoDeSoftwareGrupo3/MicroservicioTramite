using Microsoft.EntityFrameworkCore;

namespace TramiteRepository.Data
{
    public class TramiteRepositoryContext : DbContext
    {
        public TramiteRepositoryContext (DbContextOptions<TramiteRepositoryContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.Entities.TramiteTipo> TramiteTipo { get; set; } = default!;
    }
}
