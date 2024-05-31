using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaginaCursos.API.Data;
using PaginaCursos.Shared.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace PaginaCursos.API.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("/api/estudiantes")]
    public class EstudianteController:ControllerBase
    {
        private readonly DataContext _context;
        public EstudianteController(DataContext context)
        {
            _context = context;
        }

        //Método Get
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Estudiantes.ToListAsync());
        }

        //Metodo Get por id
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var estudiante = await
                _context.Estudiantes.FirstOrDefaultAsync(x => x.Id == id);

            if (estudiante == null)
            {
                return NotFound();
            }

            return Ok(estudiante);
                
        }


        //Metodo Post
        [HttpPost]
        public async Task<ActionResult>Post(Estudiante estudiante)
        {
            _context.Add(estudiante);
            await _context.SaveChangesAsync();
            return Ok(estudiante);
        }

        //Metodo Put (Actualizar)
        [HttpPut]
        public async Task<ActionResult>Put(Estudiante estudiante)
        {
            _context.Update(estudiante);
            await _context.SaveChangesAsync();
            return Ok(estudiante);
        }

        //Metodo Delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var FilasAfectadas = await _context.Estudiantes
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if(FilasAfectadas == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        [AllowAnonymous]

        [HttpGet("combo")]

        public async Task<ActionResult> GetCombo()

        {

            return Ok(await _context.Estudiantes.ToListAsync());

        }

        [AllowAnonymous]

        [HttpGet("combo/{EstudianteId:int}")]

        public async Task<ActionResult> GetCombo(int EstudianteId)
        {
            return Ok(await _context.Estudiantes

                .Where(x => x.Id == EstudianteId)

                .ToListAsync());
        }

    }
}
