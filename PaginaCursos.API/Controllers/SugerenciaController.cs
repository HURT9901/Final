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
    [Route("/api/sugerencias")]
    public class SugerenciaController : ControllerBase
    {
        private readonly DataContext _context;
        public SugerenciaController(DataContext context)
        {
            _context = context;
        }

        //Método Get
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Sugerencias.ToListAsync());
        }

        //Metodo Get por id
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var sugerencia = await
                _context.Sugerencias.FirstOrDefaultAsync(x => x.Id == id);

            if (sugerencia == null)
            {
                return NotFound();
            }

            return Ok(sugerencia);

        }

        //Metodo Post
        [HttpPost]
        public async Task<ActionResult> Post(Sugerencia sugerencia)
        {
            _context.Add(sugerencia);
            await _context.SaveChangesAsync();
            return Ok(sugerencia);
        }

        //Metodo Put (Actualizar)
        [HttpPut]
        public async Task<ActionResult> Put(Sugerencia sugerencia)
        {
            _context.Update(sugerencia);
            await _context.SaveChangesAsync();
            return Ok(sugerencia);
        }

        //Metodo Delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var FilasAfectadas = await _context.Sugerencias
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

            return Ok(await _context.Sugerencias.ToListAsync());

        }


        [AllowAnonymous]

        [HttpGet("combo/{SugerenciaId:int}")]

        public async Task<ActionResult> GetCombo(int SugerenciaId)
        {
            return Ok(await _context.Sugerencias

                .Where(x => x.Id == SugerenciaId)

                .ToListAsync());
        }

    }
}
