using CinemaAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controller;

[ApiController]
[Route("api/rooms")]
public class RoomController
{
    private readonly RoomService _service;

    public RoomController(RoomService service)
    {
        _service = service;
    }
    
    [HttpPost("addRoom")]
    [Authorize(Roles = "worker")]
    public IActionResult AddRoom()
    {
        try
        {
            _service.AddRoom();
            return new OkObjectResult("Sala adicionada com sucesso!");
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }
    
    [HttpGet("getRooms")]
    [Authorize]
    public IActionResult GetAllRooms()
    {
        try
        {
            return new OkObjectResult(_service.GetAllRooms());
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }
}