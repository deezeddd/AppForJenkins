using System.Threading.Tasks;
using AppForJenkins.Model;
using AppForJenkins.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppForJenkins.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] ProfileModel model)
        {
            var user = await _profileService.LoginAsync(model.Email, model.Password);
            if (user != null)
            {
                return Ok($"Welcome, {user.Email}!");
            }
            else
            {
                return BadRequest("Invalid email or password.");
            }
        }
    }
}
