using CinemaAPI.DTO;
using CinemaAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controller;

[ApiController]
[Route("/api/movies")]
public class MovieController
{
    private readonly MovieService _service;

    public MovieController(MovieService service)
    {
        _service = service;
    }
    
    [HttpGet("viewAllMovies")]
    [Authorize(Roles = "worker")]
    public IActionResult GetMovies()
    {
        try
        {
            return new OkObjectResult(_service.GetMovies());
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }
    
    [HttpGet("viewActiveMovies")]
    [Authorize]
    public IActionResult GetActiveMovies()
    {
        try
        {
            return new OkObjectResult(_service.GetActiveMovies());
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }

    [HttpPost("addMovie")]
    [Authorize(Roles = "worker")]
    public IActionResult AddMovie([FromBody] MovieDto movie)
    {
        try
        {
            _service.AddMovie(movie);
            return new OkObjectResult("Filme adicionado com sucesso!");
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }

    [HttpPut("changeStatusMovie/{id}")]
    [Authorize(Roles = "worker")]
    public IActionResult ChangeStatusMovie(int id)
    {
        try
        {
            _service.ChangeStatusMovie(id);
            return new OkObjectResult("Filme atualizado com sucesso!");
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }

    [HttpGet("findMovie/{name}")]
    [Authorize]
    public IActionResult FindMovie(string name)
    {
        try
        {
            return new OkObjectResult(_service.FindMovies(name));
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }
}