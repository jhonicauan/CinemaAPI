using CinemaAPI.DTO;
using CinemaAPI.Enums;
using CinemaAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controller;

[ApiController]
[Route("api/auth")]
public class AuthController
{
    private readonly JwtService _service;
    private readonly UserService _userService;
    
    
    public AuthController(JwtService service, UserService userService)
    {
        _service = service;
        _userService = userService;
    }
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto loginDto)
    {
        try
        {
            if (_userService.LoginIsCorrect(loginDto))
            {
                UserRoles role = _userService.GetRole(loginDto.username);
                string token;
                if (role == UserRoles.Client)
                {
                     token = _service.GenerateToken(loginDto.username, "client");
                }
                else
                {
                     token = _service.GenerateToken(loginDto.username, "worker");
                }
                return new OkObjectResult("Login efetuado com sucesso!\nBearer Token: "+token);
            }

            return new UnauthorizedObjectResult("Login invalido!");
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }
}