using CinemaAPI.DTO;
using CinemaAPI.Service;
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
}