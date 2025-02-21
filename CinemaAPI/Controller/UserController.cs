using CinemaAPI.DTO;
using CinemaAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controller;

[ApiController]
[Route("api/users")]
public class UserController
{
    private readonly UserService _service;

    public UserController(UserService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("viewUsers")]
    public IActionResult GetUsers()
    {
        try
        {
            return new OkObjectResult(_service.GetUsers());
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }

    [HttpPost]
    [Route("addUser")]
    public IActionResult AddUser([FromBody] AddUsersDto userDto)
    {
        try
        {
            _service.AddUser(userDto);
            return new OkObjectResult("Usuario adicionado com sucesso");
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }

    [HttpPost]
    [Route("login")]
    public IActionResult Login([FromBody] LoginDto loginDto)
    {
        try
        {
            if (_service.LoginIsCorrect(loginDto))
            {
                return new OkObjectResult("Login efetuado com sucesso");
            }
            
            return new BadRequestObjectResult("Login invalido");
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }
}