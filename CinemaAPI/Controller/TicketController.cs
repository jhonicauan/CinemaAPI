using CinemaAPI.DTO;
using CinemaAPI.Model;
using CinemaAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controller;

[ApiController]
[Route("api/ticket")]
public class TicketController
{
    
    private readonly TicketService _service;

    public TicketController(TicketService service)
    {
        _service = service;
    }

    [HttpPost("addTicket")]
    [Authorize]
    public IActionResult AddTicket(AddTicketDto ticketDto)
    {
        try
        {
            _service.AddTicket(ticketDto);
            return new OkObjectResult("Ingresso comprado com sucesso!");
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }

    [HttpGet("viewTickets/{id}")]
    [Authorize]
    public IActionResult ViewMyTickets(int id)
    {
        try
        {
            return new OkObjectResult(_service.ViewAllMyTickets(id));
        }
        catch (Exception ex)
        {
           return new BadRequestObjectResult(ex.Message);
        }
    }
    
    [HttpGet("viewActiveTickets/{id}")]
    [Authorize]
    public IActionResult ViewMyActiveTickets(int id)
    {
        try
        {
            return new OkObjectResult(_service.ViewMyActiveTickets(id));
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }
}