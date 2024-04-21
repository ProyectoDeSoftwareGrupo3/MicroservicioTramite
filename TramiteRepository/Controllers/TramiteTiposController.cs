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
    public class TramiteTiposController : ControllerBase
    {
        private readonly TramiteRepositoryContext _context;

        public TramiteTiposController(TramiteRepositoryContext context)
        {
            _context = context;
        }

        // GET: api/TramiteTipos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TramiteTipo>>> GetTramiteTipo()
        {
            return await _context.TramiteTipo.ToListAsync();
        }

        // GET: api/TramiteTipos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TramiteTipo>> GetTramiteTipo(int id)
        {
            var tramiteTipo = await _context.TramiteTipo.FindAsync(id);

            if (tramiteTipo == null)
            {
                return NotFound();
            }

            return tramiteTipo;
        }

        // PUT: api/TramiteTipos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTramiteTipo(int id, TramiteTipo tramiteTipo)
        {
            if (id != tramiteTipo.Id)
            {
                return BadRequest();
            }

            _context.Entry(tramiteTipo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TramiteTipoExists(id))
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

        // POST: api/TramiteTipos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TramiteTipo>> PostTramiteTipo(TramiteTipo tramiteTipo)
        {
            _context.TramiteTipo.Add(tramiteTipo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTramiteTipo", new { id = tramiteTipo.Id }, tramiteTipo);
        }

        // DELETE: api/TramiteTipos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTramiteTipo(int id)
        {
            var tramiteTipo = await _context.TramiteTipo.FindAsync(id);
            if (tramiteTipo == null)
            {
                return NotFound();
            }

            _context.TramiteTipo.Remove(tramiteTipo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TramiteTipoExists(int id)
        {
            return _context.TramiteTipo.Any(e => e.Id == id);
        }
    }
}
