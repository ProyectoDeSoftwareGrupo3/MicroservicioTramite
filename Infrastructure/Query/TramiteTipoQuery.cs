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
    public class TramiteTipoQuery : ITramiteTipoQuery
    {
        private readonly TramiteDbContext _context;
        public TramiteTipoQuery(TramiteDbContext context)
        {
            _context = context;
        }

        public async Task<List<TramiteTipo>> GetAllTramiteTipo()
        {
            try
            {
                return await _context.TramiteTipos.ToListAsync();
            }
            catch (DbException)
            {

                throw;
            }
        }
    }
}
