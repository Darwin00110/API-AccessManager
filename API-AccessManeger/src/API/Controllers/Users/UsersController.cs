using System.Collections;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using API_AccessManeger.src.Application.DTOs.User.Create;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_AccessManeger.src.API.Controllers.Users
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly RegisterUserUseCase _usecase;
        public UsersController(RegisterUserUseCase usecase)
        {
            _usecase = usecase;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            try
            {
                var result = await _usecase.CreateUser(request);
                return Ok(new
                {
                    message = "Usuario criado com sucesso",
                    data = result
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    error = e.InnerException?.Message ?? e.Message
                });
            }
        }
        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> ReadUser()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!Guid.TryParse(userIdClaim, out var authenticatedUserId))
            {
                return Unauthorized();
            }

            var content = new ReadUsersRequest
            {
                ID_user = authenticatedUserId
            };
            var result = await _usecase.ReadUser(content);

            if (result == null)
                return NotFound(new { error = "Usuario não existe" });

            return Ok(new
            {
                data = result
            });
        }
        [Authorize]
        [HttpPut("me")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UpdateUserRequest request)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!Guid.TryParse(userIdClaim, out var authenticatedUserId))
            {
                return Unauthorized();
            }

            if (authenticatedUserId != id)
            {
                return Forbid();
            }

            var result = await _usecase.UpdateUser(authenticatedUserId, request);

            if (result == null)
            {
                return NotFound(new
                {
                    message = "Usuário não encontrado"
                });
            }

            return Ok(new
            {
                message = "Usuário atualizado com sucesso",
                data = result
            });
        }
        [Authorize]
        [HttpDelete("me")]
        public async Task<IActionResult> DeleteUser()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!Guid.TryParse(userIdClaim, out var userId))
            {
                return Unauthorized();
            }

            await _usecase.DeleteUser(userId);

            return NoContent();
        }


        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserRequest request)
        {
            try
            {
                var result = await _usecase.LoginUser(request);
                   return Ok(new
                {
                    message = result
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    error = e.Message
                });
            }
        }
    }
}
