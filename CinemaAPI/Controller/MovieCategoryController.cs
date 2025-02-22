using CinemaAPI.DTO;
using CinemaAPI.Model;
using CinemaAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controller;

[ApiController]
[Route("api/movieCategory")]
public class MovieCategoryController
{
    
    private readonly MovieCategoryService _service;

    public MovieCategoryController(MovieCategoryService service)
    {
        _service = service;
    }
    
    
    [HttpGet("getMoviesByCategory/{idCategory}")]
    [Authorize]
    public IActionResult GetMoviesByCategory(int idCategory)
    {
        try
        {
            return new OkObjectResult(_service.GetMoviesByCategory(idCategory));
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }

    [HttpPost("addMovieCategory")]
    [Authorize(Roles = "worker")]
    public IActionResult AddMovieCategory([FromBody] AddMovieCategoryDto movieCategoryDto)
    {
        try
        {
            _service.AddMovieCategory(movieCategoryDto);
            return new OkObjectResult("Categoria relacionada ao filme com sucesso");
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }
}