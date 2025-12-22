using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RackConfigurationn.Repositories;
using RackConfigurationn.Shared.Models;

namespace RackConfigurationn.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public AccountController(RepositoryContext context)
        {
            _context = context;
        }

    
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == loginDto.Email && u.Password == loginDto.Password);

            if (user == null)
                return Unauthorized(new { message = "E-posta veya şifre hatalı!" });

            return Ok(new
            {
                id = user.Id,
                username = user.Username,
                fullName = $"{user.FirstName} {user.LastName}",
                role = user.Role
            });
        }

        // --- KAYIT OL METODU ---
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            var existingUser = await _context.Users.AnyAsync(u => u.Email == user.Email);
            if (existingUser)
                return BadRequest(new { message = "Bu e-posta adresi zaten kayıtlı!" });

            
            user.Role = "Customer"; // Varsayılan rol
            user.CreatedDate = DateTime.UtcNow; // Kayıt tarihi

            // 3. Veritabanına ekle
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Kayıt başarıyla tamamlandı! Giriş yapabilirsiniz." });
        }
    }

    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}