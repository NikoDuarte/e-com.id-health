using e_com.id_health.Database.Collection.Tienda;
using e_com.id_health.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_com.id_health.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TiendasController : Controller
    {
        private ITiendasCollection _tiendasCollectiondb = new TiendasCollection();

        [HttpGet]
        public async Task<IActionResult> GetTiendas()
        {
            return Ok(await _tiendasCollectiondb.GetAllTiendas());
        }

        [HttpGet("unique/{id}")]
        public async Task<IActionResult> GetUniqueTiendasById(string id)
        {
            return Ok(await _tiendasCollectiondb.GetTiendasById(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTienda([FromBody] Tiendas tienda)
        {
            if (tienda == null)
                return BadRequest();
            await _tiendasCollectiondb.InsertTienda(tienda);
            return Created("Creado", true);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateTienda([FromBody] Tiendas tienda, string id)
        {
            if (tienda == null)
                return BadRequest();
            tienda.Id = new MongoDB.Bson.ObjectId(id);
            await _tiendasCollectiondb.UpdateTienda(tienda);

            return Created("Update", true);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteTienda(string id)
        {
            await _tiendasCollectiondb.DeleteTienda(id);

            return Ok();
        }
    }
}
