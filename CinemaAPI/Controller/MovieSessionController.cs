using CinemaAPI.DTO;
using CinemaAPI.Model;
using CinemaAPI.Repository;
using CinemaAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controller;

[ApiController]
[Route("movieSession")]
public class MovieSessionController
{

    private readonly MovieSessionService _service;

    public MovieSessionController(MovieSessionService service)
    {
        _service = service;
    }

    [HttpPost("addMovieSession")]
    [Authorize(Roles = "worker")]
    public IActionResult AddMovieSession(AddSessionDto movieSessionDto)
    {
        try
        {
            _service.AddMovieSession(movieSessionDto);
            return new OkObjectResult("Sessão do filme cadastrada com sucesso!");
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }

    [HttpGet("viewMovieSessions")]
    [Authorize]
    public IActionResult GetActiveMovieSessions()
    {
        try
        {
            return new OkObjectResult(_service.GetActiveSessions());
        }
        catch (Exception ex)
        {
           return new BadRequestObjectResult(ex.Message);
        }
    }

    [HttpGet("viewAllMovieSessions")]
    [Authorize(Roles = "worker")]
    public IActionResult GetAllMovieSessions()
    {
        try
        {
            return new OkObjectResult(_service.GetAllSessions());
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }
}