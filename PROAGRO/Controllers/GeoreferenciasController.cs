using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROAGRO.Data;
using PROAGRO.Modelos;
using PROAGRO.Modelos.FrontModels;

namespace PROAGRO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeoreferenciasController : ControllerBase
    {
        private readonly Context _context;

        public GeoreferenciasController(Context context)
        {
            _context = context;
        }

        // GET: api/Georeferencias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Georeferencias>>> GetGeoreferencias()
        {
            return await _context.Georeferencias.ToListAsync();
        }

        // GET: api/Georeferencias/5
        [HttpGet("{id}")]
        public async Task<JsonResult> GetGeoreferencias(Guid id)
        {
            JsonResult response;
            List<CoordinatesState> GeoreferenciasC = new List<CoordinatesState>();
            try
            {
                List< Georeferencias> temp = await _context.Georeferencias
                    .Include(g => g.Estado)
                    .Where(g => g.IdEstado == id).ToListAsync();

                foreach (Georeferencias georef in temp)
                {
                    GeoreferenciasC.Add(new CoordinatesState()
                    {
                        IdCoordinate = georef.Id.ToString(),
                        StateName = georef.Estado.NombreLargo,
                        Lat = georef.Latitud,
                        Lng = georef.Longitud
                    });
                }

                if (GeoreferenciasC == null)
                {
                    response = new JsonResult(
                        new Response
                        {
                            Code = 404,
                            Message = "Usuario o contraseña son incorrectos"
                        });
                }

                response = new JsonResult(
                    new Response
                    {
                        Code = 200,
                        Value = new { GeoreferenciasC }
                });
            }
            catch (Exception ex)
            {
                response = new JsonResult(
                    new Response
                    {
                        Code = 500,
                        Message = ex.InnerException != null ? ex.InnerException.Message : ex.Message
                    });
            }
            return response;
        }

        // PUT: api/Georeferencias/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeoreferencias(Guid id, Georeferencias Georeferencias)
        {
            if (id != Georeferencias.Id)
            {
                return BadRequest();
            }

            _context.Entry(Georeferencias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeoreferenciasExists(id))
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

        // POST: api/Georeferencias
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Georeferencias>> PostGeoreferencias(Georeferencias Georeferencias)
        {
            _context.Georeferencias.Add(Georeferencias);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGeoreferencias", new { id = Georeferencias.Id }, Georeferencias);
        }

        // DELETE: api/Georeferencias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Georeferencias>> DeleteGeoreferencias(Guid id)
        {
            var Georeferencias = await _context.Georeferencias.FindAsync(id);
            if (Georeferencias == null)
            {
                return NotFound();
            }

            _context.Georeferencias.Remove(Georeferencias);
            await _context.SaveChangesAsync();

            return Georeferencias;
        }

        private bool GeoreferenciasExists(Guid id)
        {
            return _context.Georeferencias.Any(e => e.Id == id);
        }
    }
}
