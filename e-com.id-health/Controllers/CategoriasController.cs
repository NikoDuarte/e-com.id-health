using e_com.id_health.Database.Collection.Categoria;
using e_com.id_health.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_com.id_health.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CategoriasController : Controller
    {
        private ICategoriaCollection _categoriasdb = new CategoriasCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllCategorias()
        {
            return Ok(await _categoriasdb.GetAllCategorias());
        }

        [HttpGet("unique/{id}")]
        public async Task<IActionResult> GetUniqueCategoriaById(string id)
        {
            return Ok(await _categoriasdb.GetCategoriasById(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCategoria([FromBody] Categorias categoria)
        {
            if (categoria == null)
                return BadRequest();

            await _categoriasdb.InsertCategorias(categoria);
            return Created("Creado", true);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCategorias([FromBody] Categorias categoria, string id)
        {
            if (categoria == null)
                return BadRequest();
            categoria.Id = new MongoDB.Bson.ObjectId(id);
            await _categoriasdb.UpdateCategorias(categoria);

            return Created("Update", true);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCategorias(string id)
        {
            await _categoriasdb.DeleteCategorias(id);

            return Ok("Delete");
        }
    }
}
