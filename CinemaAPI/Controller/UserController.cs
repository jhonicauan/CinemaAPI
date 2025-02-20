using CinemaAPI.DTO;
using CinemaAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controller;

[ApiController]
[Route("api/users")]
public class UserController
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Route("viewUsers")]
    public IActionResult GetUsers()
    {
        try
        {
            return new OkObjectResult(_userService.GetUsers());
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
            _userService.AddUser(userDto);
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
            if (_userService.LoginIsCorrect(loginDto))
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