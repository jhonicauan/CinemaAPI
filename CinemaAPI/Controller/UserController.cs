using CinemaAPI.DTO;
using CinemaAPI.Service;
using Microsoft.AspNetCore.Authorization;
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

    [HttpGet("viewUsers")]
    [Authorize(Roles = "worker")]
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
    
    [Authorize]
    [HttpPost("addUser")]
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
    
}