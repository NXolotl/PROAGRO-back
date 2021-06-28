using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROAGRO.Data;
using PROAGRO.Modelos;

namespace PROAGRO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisosController : ControllerBase
    {
        private readonly Context _context;

        public PermisosController(Context context)
        {
            _context = context;
        }

        // GET: api/Permisos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Permisos>>> GetPermisos()
        {
            return await _context.Permisos.ToListAsync();
        }

        // GET: api/Permisos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Permisos>> GetPermisos(Guid id)
        {
            var permisos = await _context.Permisos.FindAsync(id);

            if (permisos == null)
            {
                return NotFound();
            }

            return permisos;
        }

        // PUT: api/Permisos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPermisos(Guid id, Permisos permisos)
        {
            if (id != permisos.IdUsuario)
            {
                return BadRequest();
            }

            _context.Entry(permisos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PermisosExists(id))
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

        // POST: api/Permisos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Permisos>> PostPermisos(Permisos permisos)
        {
            _context.Permisos.Add(permisos);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PermisosExists(permisos.IdUsuario))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPermisos", new { id = permisos.IdUsuario }, permisos);
        }

        // DELETE: api/Permisos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Permisos>> DeletePermisos(Guid id)
        {
            var permisos = await _context.Permisos.FindAsync(id);
            if (permisos == null)
            {
                return NotFound();
            }

            _context.Permisos.Remove(permisos);
            await _context.SaveChangesAsync();

            return permisos;
        }

        private bool PermisosExists(Guid id)
        {
            return _context.Permisos.Any(e => e.IdUsuario == id);
        }
    }
}
