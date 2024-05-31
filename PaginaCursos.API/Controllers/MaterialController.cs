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
    [Route("/api/materiales")]
    public class MaterialController : ControllerBase
    {
        private readonly DataContext _context;
        public MaterialController(DataContext context)
        {
            _context = context;
        }

        //Método Get
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Materiales.ToListAsync());
        }

        //Metodo Get por id
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var material = await
                _context.Materiales.FirstOrDefaultAsync(x => x.Id == id);

            if (material == null)
            {
                return NotFound();
            }

            return Ok(material);

        }


        //Metodo Post
        [HttpPost]
        public async Task<ActionResult> Post(Material material)
        {
            _context.Add(material);
            await _context.SaveChangesAsync();
            return Ok(material);
        }

        //Metodo Put (Actualizar)
        [HttpPut]
        public async Task<ActionResult> Put(Material material)
        {
            _context.Update(material);
            await _context.SaveChangesAsync();
            return Ok(material);
        }

        //Metodo Delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var FilasAfectadas = await _context.Materiales
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

            return Ok(await _context.Materiales.ToListAsync());

        }

        [AllowAnonymous]

        [HttpGet("combo/{MaterialId:int}")]

        public async Task<ActionResult> GetCombo(int MaterialId)
        {
            return Ok(await _context.Materiales

                .Where(x => x.Id == MaterialId)

                .ToListAsync());
        }
    }
}
