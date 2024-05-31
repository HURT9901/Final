using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaginaCursos.API.Data;
using PaginaCursos.Shared.Entities;
using System.Threading.Tasks;

namespace PaginaCursos.API.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("/api/actividades")]
    public class ActividadController : ControllerBase
    {
        private readonly DataContext _context;
        public ActividadController(DataContext context)
        {
            _context = context;
        }

        //Método Get
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Actividades.ToListAsync());
        }

        //Metodo Get por id
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var actividad = await
                _context.Actividades.FirstOrDefaultAsync(x => x.Id == id);

            if (actividad == null)
            {
                return NotFound();
            }

            return Ok(actividad);

        }

        //Metodo Post
        [HttpPost]
        public async Task<ActionResult> Post(Actividad actividad)
        {
            _context.Add(actividad);
            await _context.SaveChangesAsync();
            return Ok(actividad);
        }

        //Metodo Put (Actualizar)
        [HttpPut]
        public async Task<ActionResult> Put(Actividad actividad)
        {
            _context.Update(actividad);
            await _context.SaveChangesAsync();
            return Ok(actividad);
        }

        //Metodo Delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var FilasAfectadas = await _context.Actividades
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (FilasAfectadas == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        [AllowAnonymous]

        [HttpGet("combo")]

        public async Task<ActionResult> GetCombo()

        {

            return Ok(await _context.Actividades.ToListAsync());

        }

        [AllowAnonymous]

        [HttpGet("combo/{ActividadId:int}")]

        public async Task<ActionResult> GetCombo(int ActividadId)
        {
            return Ok(await _context.Actividades

                .Where(x => x.Id == ActividadId)

                .ToListAsync());
        }

    }
}
