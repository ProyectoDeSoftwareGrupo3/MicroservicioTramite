using Application.Exceptions;
using Application.Interfaces.ITramite;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Infrastructure.Query
{
    public class TramiteQuery : ITramiteQuery
    {
        private readonly TramiteDbContext _context;
        public TramiteQuery(TramiteDbContext context)
        {
            _context = context;
        }

        public async Task<CabeceraTramite> GetTramiteById(int id)
        {
            try
            {
                return await _context.CabeceraTramites
                    .Include(ct => ct.TramiteTransito)
                    .Include(ct => ct.TramiteAdopcion)
                    .Include(ct => ct.Estado)
                    .FirstOrDefaultAsync(t => t.Id == id);

            }
            catch (DbException)
            {
                throw new Conflict("Hubo un error en la base de datos");
            }
        }
        // public async Task<CabeceraTramite> GetTramiteByAnimalId(int id)
        // {
        //     try
        //     {
        //         return await _context.CabeceraTramites
        //             .Include(t => t.TramiteTransito)
        //             .Include(t => t.TramiteAdopcion)
        //             .Include(ct => ct.Estado)
        //             .FirstOrDefaultAsync(t => t.AnimalId == id);

        //     }
        //     catch (DbException)
        //     {
        //         throw new Conflict("Hubo un error en la base de datos");
        //     }
        // }
        public async Task<List<CabeceraTramite>> GetTramitesFilters(int? tramiteEstado, int? animalId)
        {
            try
            {
                if(animalId > 0 && tramiteEstado > 0)
                {
                    return await _context.CabeceraTramites
                                .Include(cta => cta.TramiteAdopcion)
                                .Where(cta => cta.TramiteAdopcion.AnimalId == animalId)
                                .Include(cte => cte.Estado)
                                .Where(ce => ce.EstadoId == tramiteEstado)
                                .ToListAsync();
                }
                if(animalId > 0)
                {
                    return await _context.CabeceraTramites
                                .Include(cta => cta.TramiteAdopcion)
                                .Include(cte => cte.Estado)
                                .Where(cta => cta.TramiteAdopcion.AnimalId == animalId)
                                .ToListAsync();
                }
                if(tramiteEstado > 0)
                {
                    return await _context.CabeceraTramites
                                .Include(cta => cta.TramiteAdopcion)
                                .Include(ctt => ctt.TramiteTransito)
                                .Include(cte => cte.Estado)
                                .Where(ce => ce.EstadoId == tramiteEstado)
                                .ToListAsync();
                }
                return await _context.CabeceraTramites
                                .Include(cta => cta.TramiteAdopcion)
                                .Include(ctt => ctt.TramiteTransito)
                                .Include(cte => cte.Estado)
                                .ToListAsync();
            }
            catch (DbException)
            {
                throw new Conflict("Hubo un error en la base de datos");
            }
        }

        // public async Task<List<CabeceraTramite>> GetTramitesFilters(int? tramiteEstado, int? animalId)
        // {
        //     try
        //     {
        //         if (tramiteEstado == null && animalId == null)
        //         {
        //             return await _context.CabeceraTramites
        //                 .Include(ct => ct.Estado)
        //                 .Include(t => t.TramiteTransito)
        //                 .Include(t => t.TramiteAdopcion)
        //                 .ToListAsync();
        //         }
        //         if (tramiteEstado == null)
        //         {
        //             return await _context.CabeceraTramites
        //                 .Where(t => t.AnimalId == animalId)
        //                 .Include(t => t.Estado)
        //                 .Include(t => t.TramiteTransito)
        //                 .Include(t => t.TramiteAdopcion)
        //                 .ToListAsync();
        //         }

        //         return await _context.CabeceraTramites
        //                 .Where(t => t.EstadoId == tramiteEstado)
        //                 .Include(t => t.Estado)
        //                 .Include(t => t.TramiteTransito)
        //                 .Include(t => t.TramiteAdopcion)
        //                 .ToListAsync();
        //     }
        //     catch (DbException)
        //     {
        //         throw new Conflict("Hubo un error en la base de datos");
        //     }
        // }

        public async Task<List<CabeceraTramiteDto>> GetTramites()
        {
            try
            {
                var tramite = await _context.CabeceraTramites
                    .Include(t => t.Estado)
                    .Include(t => t.TramiteTransito)
                    .Include(t => t.TramiteAdopcion)
                    .ToListAsync();

                var tramiteDtos = tramite.Select(tramite => new CabeceraTramiteDto(tramite)).ToList();
                // List<CabeceraTramiteDto> dtos = new List<CabeceraTramiteDto>();
                // foreach(var tramite in tramites)                
                // {
                //     CabeceraTramiteDto dto = new CabeceraTramiteDto 
                //     {
                //         Id = tramite.Id,
                //         AnimalId = tramite.TramiteAdopcion.AnimalId,
                //         UsuarioId = tramite.UsuarioId,
                //         UsuarioSolicitanteId = tramite.UsuarioSolicitanteId,                              
                //         FechaInicio = tramite.FechaInicio,
                //         FechaFinal = tramite.FechaFinal,
                //         Estado = tramite.Estado,
                //         EstadoId = tramite.EstadoId,
                //         TramiteAdopcion = tramite.TramiteAdopcion,
                //         TramiteTransito = tramite.TramiteTransito,
                //     };                    
                //     dtos.Add(dto);
                // }
                // return dtos;
                return tramiteDtos;
            }
            catch (DbException)
            {
                throw new Conflict("Hubo un error en la base de datos");
            }
        }

     
        public async Task<IEnumerable<CabeceraTramite>> GetAllAsync()
        {
            return await _context.CabeceraTramites.ToListAsync();
        }
    }
}
