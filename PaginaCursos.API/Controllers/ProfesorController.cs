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
    [Route("/api/profesores")]
    public class ProfesorController : ControllerBase
    {
        private readonly DataContext _context;
        public ProfesorController(DataContext context)
        {
            _context = context;
        }

        //Método Get
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Profesores.ToListAsync());
        }

        //Metodo Get por id
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var profesor = await
                _context.Profesores.FirstOrDefaultAsync(x => x.Id == id);

            if (profesor == null)
            {
                return NotFound();
            }

            return Ok(profesor);

        }

        //Metodo Post
        [HttpPost]
        public async Task<ActionResult> Post(Profesor profesor)
        {
            _context.Add(profesor);
            await _context.SaveChangesAsync();
            return Ok(profesor);
        }

        //Metodo Put (Actualizar)
        [HttpPut]
        public async Task<ActionResult> Put(Profesor profesor)
        {
            _context.Update(profesor);
            await _context.SaveChangesAsync();
            return Ok(profesor);
        }

        //Metodo Delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var FilasAfectadas = await _context.Profesores
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

            return Ok(await _context.Profesores.ToListAsync());

        }


        [AllowAnonymous]

        [HttpGet("combo/{ProfesorId:int}")]

        public async Task<ActionResult> GetCombo(int ProfesorId)
        {
            return Ok(await _context.Profesores

                .Where(x => x.Id == ProfesorId)

                .ToListAsync());
        }


    }
}
