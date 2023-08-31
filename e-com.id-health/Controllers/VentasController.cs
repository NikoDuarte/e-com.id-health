using e_com.id_health.Database.Collection.Venta;
using e_com.id_health.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_com.id_health.Controllers
{
    [Route("/api/[controller]")]
    [Authorize]
    [ApiController]
    public class VentasController : Controller
    {
        private IVentasCollection _ventasdb = new VentasCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllVentas()
        {
            return Ok(await _ventasdb.GetAllVentas());
        }

        [HttpGet("unique/{id}")]
        public async Task<IActionResult> GetUniqueVentasById(string id)
        {
            return Ok(await _ventasdb.GetVentasById(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateVenta([FromBody] Ventas venta)
        {
            if (venta == null)
                return BadRequest();

            await _ventasdb.InsertVentas(venta);
            return Created("Creado", true);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateVenta([FromBody] Ventas venta, string id)
        {
            if (venta == null)
                return BadRequest();
            venta.Id = new MongoDB.Bson.ObjectId(id);
            await _ventasdb.UpdateVentas(venta);

            return Created("Update", true);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteVentas(string id)
        {
            await _ventasdb.DeleteVentas(id);

            return Ok();
        }
    }
}
