using DziennikTreningowy.Core.Interfaces;
using DziennikTreningowy.Core.Models;
using DziennikTreningowy.Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace DziennikTreningowy.Controllers
{
    [Route("api/authorization")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IOAuthService _oAuthService;

        public AuthorizationController(UserManager<User> userManager, SignInManager<User> signInManager, IOAuthService oAuthService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _oAuthService = oAuthService;
        }

        /// <summary>
        /// Loguje użytkownika w systemie
        /// </summary>
        /// <param name="userLoginDto">Dane logowania</param>
        /// <returns>Wygenerowany token JWT</returns>
        /// <response code="200">Pomyślna autoryzacja użytkownika - zwraca wygenerowany JWT Token</response>
        /// <response code="400">Logowanie nie powiodło się - niepoprawne dane logowania</response>
        /// <response code="403">Konto użytkownika jest zablokowane</response>
        /// <response code="500">Wewnętrzny błąd serwera</response>
        [HttpPost, Route("login"), AllowAnonymous]
        public async Task<IActionResult> LoginUserAsync([Required] UserLoginDTO userLoginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(userLoginDto.Username, userLoginDto.Password, false, false);
            if (result.IsLockedOut)
            {
                return Forbid("User Account is locked out!");
            }
            if (!result.Succeeded)
            {
                return BadRequest("Sign in failed!");
            }
            var user = await _userManager.FindByNameAsync(userLoginDto.Username);
            string userToken = _oAuthService.GetUserAuthToken(userLoginDto.Username, user.Id.ToString());
            return new JsonResult(new { token = userToken });
        }
    }
}
