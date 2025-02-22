using CinemaAPI.DTO;
using CinemaAPI.Model;
using CinemaAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controller;

[ApiController]
[Route("api/seats")]
public class SeatController
{

    private readonly SeatService _service;

    public SeatController(SeatService service)
    {
        _service = service;
    }

    [HttpGet("viewSeats/{idRoom}")]
    [Authorize]
    public  IActionResult GetSeatsOfRoom(int idRoom)
    {
        try
        {
            return new OkObjectResult(_service.GetSeatsOfRoom(idRoom));
        }
        catch (Exception ex)
        {
           return new BadRequestObjectResult(ex.Message);
        }
    }

    [HttpPost("addSeat")]
    [Authorize(Roles = "worker")]
    public IActionResult AddSeat(AddSeatDto seat)
    {
        try
        {
            _service.AddSeats(seat);
            return new OkObjectResult("Assentos adicionados com sucesso");
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }

    [HttpPut("updateSeat/{idSeat}")]
    [Authorize(Roles = "worker")]
    public IActionResult UpdateTypeSeat(int idSeat, [FromBody]  UpdateTypeSeatDto updateType)
    {
        try
        {
            _service.UpdateType(idSeat, updateType);
            return new OkObjectResult("Assento atualizado com sucesso");
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }
}