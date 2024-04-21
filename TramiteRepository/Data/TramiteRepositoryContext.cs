using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace TramiteRepository.Data
{
    public class TramiteRepositoryContext : DbContext
    {
        public TramiteRepositoryContext (DbContextOptions<TramiteRepositoryContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.Entities.Tramite> Tramite { get; set; }
        public DbSet<Domain.Entities.TramiteEstado> TramiteEstado { get; set; }
        public DbSet<Domain.Entities.TramiteTipo> TramiteTipo { get; set; }
    }
}
