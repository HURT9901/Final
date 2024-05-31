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
    [Route("/api/integrantes")]
    public class IntegranteController:ControllerBase
    {
        private readonly DataContext _context;
        public IntegranteController(DataContext context) 
        {
            _context = context;
        }

        //Método Get
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Integrantes.ToListAsync());
        }

        //Metodo Get por id
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var integrante = await
                _context.Integrantes.FirstOrDefaultAsync(x => x.Id == id);

            if (integrante == null)
            {
                return NotFound();
            }

            return Ok(integrante);

        }

        //Metodo Post
        [HttpPost]
        public async Task<ActionResult> Post(Integrante integrante)
        {
            _context.Add(integrante);
            await _context.SaveChangesAsync();
            return Ok(integrante);
        }

        //Metodo Put (Actualizar)
        [HttpPut]
        public async Task<ActionResult> Put(Integrante integrante)
        {
            _context.Update(integrante);
            await _context.SaveChangesAsync();
            return Ok(integrante);
        }

        //Metodo Delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var FilasAfectadas = await _context.Integrantes
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

            return Ok(await _context.Integrantes.ToListAsync());

        }

        [AllowAnonymous]

        [HttpGet("combo/{IntegranteId:int}")]

        public async Task<ActionResult> GetCombo(int IntegranteId)
        {
            return Ok(await _context.Integrantes

                .Where(x => x.Id == IntegranteId)

                .ToListAsync());
        }

    }
}
