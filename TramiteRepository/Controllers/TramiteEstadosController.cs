using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using TramiteRepository.Data;

namespace TramiteRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TramiteEstadosController : ControllerBase
    {
        private readonly TramiteRepositoryContext _context;

        public TramiteEstadosController(TramiteRepositoryContext context)
        {
            _context = context;
        }

        // GET: api/TramiteEstados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TramiteEstado>>> GetTramiteEstado()
        {
            return await _context.TramiteEstado.ToListAsync();
        }

        // GET: api/TramiteEstados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TramiteEstado>> GetTramiteEstado(int id)
        {
            var tramiteEstado = await _context.TramiteEstado.FindAsync(id);

            if (tramiteEstado == null)
            {
                return NotFound();
            }

            return tramiteEstado;
        }

        // PUT: api/TramiteEstados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTramiteEstado(int id, TramiteEstado tramiteEstado)
        {
            if (id != tramiteEstado.Id)
            {
                return BadRequest();
            }

            _context.Entry(tramiteEstado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TramiteEstadoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TramiteEstados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TramiteEstado>> PostTramiteEstado(TramiteEstado tramiteEstado)
        {
            _context.TramiteEstado.Add(tramiteEstado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTramiteEstado", new { id = tramiteEstado.Id }, tramiteEstado);
        }

        // DELETE: api/TramiteEstados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTramiteEstado(int id)
        {
            var tramiteEstado = await _context.TramiteEstado.FindAsync(id);
            if (tramiteEstado == null)
            {
                return NotFound();
            }

            _context.TramiteEstado.Remove(tramiteEstado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TramiteEstadoExists(int id)
        {
            return _context.TramiteEstado.Any(e => e.Id == id);
        }
    }
}
