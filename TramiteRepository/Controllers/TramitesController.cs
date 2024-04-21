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
    public class TramitesController : ControllerBase
    {
        private readonly TramiteRepositoryContext _context;

        public TramitesController(TramiteRepositoryContext context)
        {
            _context = context;
        }

        // GET: api/Tramites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tramite>>> GetTramite()
        {
            return await _context.Tramite.ToListAsync();
        }

        // GET: api/Tramites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tramite>> GetTramite(int id)
        {
            var tramite = await _context.Tramite.FindAsync(id);

            if (tramite == null)
            {
                return NotFound();
            }

            return tramite;
        }

        // PUT: api/Tramites/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTramite(int id, Tramite tramite)
        {
            if (id != tramite.Id)
            {
                return BadRequest();
            }

            _context.Entry(tramite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TramiteExists(id))
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

        // POST: api/Tramites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tramite>> PostTramite(Tramite tramite)
        {
            _context.Tramite.Add(tramite);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTramite", new { id = tramite.Id }, tramite);
        }

        // DELETE: api/Tramites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTramite(int id)
        {
            var tramite = await _context.Tramite.FindAsync(id);
            if (tramite == null)
            {
                return NotFound();
            }

            _context.Tramite.Remove(tramite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TramiteExists(int id)
        {
            return _context.Tramite.Any(e => e.Id == id);
        }
    }
}
