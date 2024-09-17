using InvoiceManagementWebApiCore.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Text;

namespace InvoiceManagementWebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IMG_CoreContext _context;
        
        public AuthenticationController(IConfiguration config, IMG_CoreContext context)
        {
            _config = config;
            _context = context;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLogin userLogin)
        {
            //For demo purpose we accept any username/password
            try
            {
                var result = await _context.Users.Where(u => u.UserName == userLogin.UserName && u.Password == userLogin.Password).FirstOrDefaultAsync();
                if(result == null) return NotFound();
                var token = GenerateJwtToken(userLogin.UserName, userLogin.Password);
                return Ok(token);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private string GenerateJwtToken(string userName, string pwd)
        {
            try
            {
                var keyByteArray = Encoding.ASCII.GetBytes(_config.GetSection("Jwt:SaltKey").Value);
                // we are registering user information to register information in claims for future use
                var claims = new Claim[]
                    {
                        new Claim(JwtRegisteredClaimNames.Email, userName),
                        new Claim(JwtRegisteredClaimNames.Name, pwd),
                        new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1).ToUniversalTime()).ToString()) 
                    };

                var token = new JwtSecurityToken(
                    new JwtHeader(new SigningCredentials(
                        new SymmetricSecurityKey(keyByteArray), SecurityAlgorithms.HmacSha256Signature
                        )), new JwtPayload(claims)
                    );

                return new JwtSecurityTokenHandler().WriteToken(token);


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //private string GenerateJwtToken()
        //{
        //    var jwtSettings = _config.GetSection("Jwt");
        //    var key = SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
        //    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(
        //        issuer: jwtSettings["Issuer"],
        //        audience: jwtSettings["Audience"],
        //        expires: DateTime.Now.AddMinutes(30),
        //        signingCredentials: credentials
        //    );

        //    return new JwtSecurityTokenHandler().WriteToken(token);

        //}

    }

}
