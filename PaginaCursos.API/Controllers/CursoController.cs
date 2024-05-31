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
    [Route("/api/cursos")]
    public class CursoController : ControllerBase
    {
        private readonly DataContext _context;
        public CursoController(DataContext context)
        {
            _context = context;
        }

        //Método Get
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Cursos.ToListAsync());
        }

        //Metodo Get por id
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var curso = await
                _context.Cursos.FirstOrDefaultAsync(x => x.Id == id);

            if (curso == null)
            {
                return NotFound();
            }

            return Ok(curso);

        }

        //Metodo Post
        [HttpPost]
        public async Task<ActionResult> Post(Curso curso)
        {
            _context.Add(curso);
            await _context.SaveChangesAsync();
            return Ok(curso);
        }

        //Metodo Put (Actualizar)
        [HttpPut]
        public async Task<ActionResult> Put(Curso curso)
        {
            _context.Update(curso);
            await _context.SaveChangesAsync();
            return Ok(curso);
        }

        //Metodo Delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var FilasAfectadas = await _context.Cursos
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

            return Ok(await _context.Cursos.ToListAsync());

        }

        [AllowAnonymous]

        [HttpGet("combo/{CursoId:int}")]

        public async Task<ActionResult> GetCombo(int CursoId)
        {
            return Ok(await _context.Cursos

                .Where(x => x.Id == CursoId)

                .ToListAsync());
        }
    }
}
