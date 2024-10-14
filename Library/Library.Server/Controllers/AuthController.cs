using Library.Server.Models.Identity;
using Library.Server.ViewModels.AuthViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Library.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private IConfiguration _configuration { get; set; }
        private SignInManager<AppUser> _signInManager;
        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _roleManager;

        public AuthController(
            IConfiguration configuration,
            SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager
            )
        {
            _configuration = configuration;
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        /// <summary>
        /// User Login endpoint
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                if (result.Succeeded)
                {
                    var roleName = User.IsInRole("Librarian") ? "Librarian" : "Customer";
                    var token = GenerateJwtToken(model.UserName);
                    return Ok(new { Token = token, Role = roleName });
                }
            }
            return BadRequest(model);
        }

        /// <summary>
        /// User Register endpoint
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = model.UserName,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var role = _roleManager.FindByIdAsync(model.RoleId.ToString()).Result;
                    if (role != null)
                    {
                        IdentityResult roleresult = await _userManager.AddToRoleAsync(user, role.Name);
                        var token = GenerateJwtToken(model.UserName);
                        return Ok(new { Token = token, Role = role.Name});
                    }
                }
            }
            return BadRequest(model);
        }

        /// <summary>
        /// User Logout endpoint
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpPost("LogOut")]
        public IActionResult LogOut()
        {
            //Todo InValidate the token
            return Ok();
        }

        private string GenerateJwtToken(string username)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username),
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtConfig:Secret"] ?? throw new InvalidOperationException("JWT Secret not found.")));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "Issuer",
                audience: "Audience",
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
