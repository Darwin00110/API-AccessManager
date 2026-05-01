using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_AccessManeger.src.API.Controllers.Admin
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly RegisterUserUseCase _usecase;
        public AdminController(RegisterUserUseCase usecase)
        {
            _usecase = usecase;
        }
        [Authorize(Roles = "ADMIN")]
        [HttpGet]
        public async Task<IActionResult> ReadUserADM()
        {
            try
            {
                var result = await _usecase.ReadUserADM();
                return Ok(new
                {
                    data = result
                });
            }
            catch (Exception e)
            {
                return Ok(new
                {
                    Error = e.Message
                });
            }
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateUserADM(Guid id, [FromBody] UpdateUserRequest request)
        {
            try
            {
                var result = await _usecase.UpdateUserADM(id, request);
                return Ok(new
                {
                    data = result
                });
            }
            catch (Exception e)
            {
                return Ok(new
                {
                    Error = e.Message
                });
            }
        }

        [Authorize(Roles = "ADMIN")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserADM(Guid id)
        {
            try
            {
                await _usecase.DeleteUsersADM(id);
                return Ok(new
                {
                    message = "Usuario deletado com sucesso"
                });
            } catch(Exception e)
            {
                return BadRequest( new
                {
                    error = e.Message 
                });
            }
        }
    }
}
