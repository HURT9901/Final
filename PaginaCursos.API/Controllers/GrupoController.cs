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
    [Route("/api/grupos")]
    public class GrupoController : ControllerBase
    {
        private readonly DataContext _context;
        public GrupoController(DataContext context)
        {
            _context = context;
        }

        //Método Get
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Grupos.ToListAsync());
        }

        //Metodo Get por id
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var grupo = await
                _context.Grupos.FirstOrDefaultAsync(x => x.Id == id);

            if (grupo == null)
            {
                return NotFound();
            }

            return Ok(grupo);

        }

        //Metodo Post
        [HttpPost]
        public async Task<ActionResult> Post(Grupo grupo)
        {
            _context.Add(grupo);
            await _context.SaveChangesAsync();
            return Ok(grupo);
        }

        //Metodo Put (Actualizar)
        [HttpPut]
        public async Task<ActionResult> Put(Grupo grupo)
        {
            _context.Update(grupo);
            await _context.SaveChangesAsync();
            return Ok(grupo);
        }

        //Metodo Delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var FilasAfectadas = await _context.Grupos
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

            return Ok(await _context.Grupos.ToListAsync());

        }

        [AllowAnonymous]

        [HttpGet("combo/{GrupoId:int}")]

        public async Task<ActionResult> GetCombo(int GrupoId)
        {
            return Ok(await _context.Grupos

                .Where(x => x.Id == GrupoId)

                .ToListAsync());
        }
    }
}
