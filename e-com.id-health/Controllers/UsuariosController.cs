using BCrypt.Net;
using e_com.id_health.Database.Collection.Usuario;
using e_com.id_health.Models;
using e_com.id_health.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace e_com.id_health.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private IUsuarioCollection _usuariosdb = new UsuarioCollection();
        private string secretKey;

        public UsuariosController(IConfiguration configuration)
        {
            secretKey = configuration.GetSection("Jwt").GetSection("Key").ToString();
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] Usuarios usuario)
        {
            if (usuario == null)
                return BadRequest();
            // |-> Encriptamos la contraseña del usuario con el paquete bcrypt
            string encript_password = BCrypt.Net.BCrypt.HashPassword(usuario.password);
            // |-> Remplazamos el valor anterior por el hash nuevo generado con bcrypt
            usuario.password = encript_password;
            // |-> Continuamos la funcionalidad de almacenamiento
            await _usuariosdb.InsertUser(usuario);  
            return Ok(new { success = true, msg = "Se creo correctamente el usuario" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] ILoginDto datos_login)
        {

            if(datos_login == null)
                return BadRequest();

            var user_filter = await _usuariosdb.GetUserEmail(datos_login.email);

            if (user_filter == null)
                return BadRequest();

            bool is_correct_password = BCrypt.Net.BCrypt.Verify(datos_login.password, user_filter.password);

            if (!is_correct_password)
                return Unauthorized();

            var keyBytes = Encoding.ASCII.GetBytes(secretKey.ToString());
            var claims = new ClaimsIdentity();

            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, datos_login.email));

            var token_descript = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var configToken = tokenHandler.CreateToken(token_descript);

            var token_writhe = tokenHandler.WriteToken(configToken);

            return Ok(token_writhe);

        }
    }
}
