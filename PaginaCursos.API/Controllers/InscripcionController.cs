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
    [Route("/api/inscripciones")]
    public class InscripcionController : ControllerBase
    {
        private readonly DataContext _context;
        public InscripcionController(DataContext context)
        {
            _context = context;
        }

        //Método Get
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Inscripciones.ToListAsync());
        }

        //Metodo Get por id
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var inscripcion = await
                _context.Inscripciones.FirstOrDefaultAsync(x => x.Id == id);

            if (inscripcion == null)
            {
                return NotFound();
            }

            return Ok(inscripcion);

        }


        //Metodo Post
        [HttpPost]
        public async Task<ActionResult> Post(Inscripcion inscripcion)
        {
            _context.Add(inscripcion);
            await _context.SaveChangesAsync();
            return Ok(inscripcion);
        }

        //Metodo Put (Actualizar)
        [HttpPut]
        public async Task<ActionResult> Put(Inscripcion inscripcion)
        {
            _context.Update(inscripcion);
            await _context.SaveChangesAsync();
            return Ok(inscripcion);
        }

        //Metodo Delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var FilasAfectadas = await _context.Inscripciones
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

            return Ok(await _context.Inscripciones.ToListAsync());

        }

        [AllowAnonymous]

        [HttpGet("combo/{InscripcionId:int}")]

        public async Task<ActionResult> GetCombo(int InscripcionId)
        {
            return Ok(await _context.Inscripciones

                .Where(x => x.Id == InscripcionId)

                .ToListAsync());
        }
    }
}
