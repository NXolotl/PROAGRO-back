using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    public class UsuariosController : ControllerBase
    {
        private readonly Context _context;

        public UsuariosController(Context context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuarios>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios>> GetUsuarios(Guid id)
        {
            var usuarios = await _context.Usuarios.FindAsync(id);

            if (usuarios == null)
            {
                return NotFound();
            }

            return usuarios;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarios(Guid id, Usuarios usuarios)
        {
            if (id != usuarios.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuarios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariosExists(id))
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

        // POST: api/Usuarios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<JsonResult> PostUsuarios(NewUser usuario)
        {
            JsonResult response;
            try
            {
                string msg = "";
                if (usuario != null)
                {
                    Usuarios usuarios = new Usuarios();
                    usuarios.Nombre = usuario.Nombre;
                    usuarios.RFC = usuario.RFC;
                    usuarios.Contrasena = usuario.Contrasena;
                    usuarios.FechaCreacion = usuario.FechaNacimiento;

                    _context.Usuarios.Add(usuarios);
                    var result = await _context.SaveChangesAsync();
                    if (result != null)
                    {
                        msg = "ok";
                    }
                    response = new JsonResult(
                    new Response
                    {
                        Code = 200,
                        Value = new { msg }
                    });
                }
                else
                {
                    response = new JsonResult(
                        new Response
                        {
                            Code = 500,
                            Message = "No se envió información"
                        });
                }
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

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuarios>> DeleteUsuarios(Guid id)
        {
            var usuarios = await _context.Usuarios.FindAsync(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuarios);
            await _context.SaveChangesAsync();

            return usuarios;
        }

        private bool UsuariosExists(Guid id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }

        [HttpPost]
        [Route("LoginUser")]
        [AllowAnonymous]
        public async Task<JsonResult> LoginUser(UserLogin user)
        {
            JsonResult response;
            try
            {
                Usuarios usuario = await _context.Usuarios.Where(
                    u => u.Nombre == user.Nombre
                    && u.Contrasena == user.Contrasena).Include(u => u.Permisos).FirstOrDefaultAsync();
                if (usuario != null)
                {
                    List<Estados> permisosEstado = new List<Estados>();
                    if (usuario.Permisos.Count > 0)
                    {
                        foreach (Permisos permiso in usuario.Permisos)
                        {
                            permisosEstado.Add(await _context.Estados.Where(e => e.Id == permiso.IdEstado).FirstOrDefaultAsync());
                        }
                    }
                    response = new JsonResult(
                        new Response
                        {
                            Code = 200,
                            Value = new { permisos = permisosEstado }
                        });
                }
                else
                {
                    response = new JsonResult(
                        new Response
                        {
                            Code = 400,
                            Message = "Usuario o Contrasena son incorrectos"
                        });
                }
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
            //response.SerializerSettings = JsonResult.
            return response;

        }
    }
}
