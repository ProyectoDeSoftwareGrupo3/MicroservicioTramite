using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Query
{
    public class TramiteEstadoQuery: ITramiteEstadoQuery
    {
        private readonly TramiteDbContext _context;
        public TramiteEstadoQuery (TramiteDbContext context)
        {
            _context = context;
        }

        public async Task<List<TramiteEstado>> GetAllTramiteEstado()
        {
            try
            {
                return await _context.TramiteEstados.ToListAsync();
            }
            catch (DbException)
            {

                throw;
            }
        }
    }
}
