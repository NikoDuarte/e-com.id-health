using e_com.id_health.Database.Collection.Producto;
using e_com.id_health.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_com.id_health.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProductosController : Controller
    {
        private IProductosCollection _productosdb = new ProductosCollection();

        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            return Ok(await _productosdb.GetAllProductos());
        }

        [HttpGet("unique/{id}")]
        public async Task<IActionResult> GetUniqueProductoById(string id)
        {
            return Ok(await _productosdb.GetProductosById(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProducto([FromBody] Productos producto)
        {
            if (producto == null)
                return BadRequest();

            await _productosdb.InsertProductos(producto);
            return Created("Creado", true);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateProducto([FromBody] Productos producto, string id)
        {
            if (producto == null)
                return BadRequest();
            if (id == null)
                return BadRequest();
            producto.Id = new MongoDB.Bson.ObjectId(id);
            await _productosdb.UpdateProductos(producto);

            return Created("Update", true);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProducto(string id)
        {
            await _productosdb.DeleteProductos(id);

            return Ok("Delete");
        }
    }
}
