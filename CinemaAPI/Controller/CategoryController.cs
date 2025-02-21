using CinemaAPI.DTO;
using CinemaAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controller;

[ApiController]
[Route("api/category")]
public class CategoryController
{
    
    private readonly CategoryService _service;

    public CategoryController(CategoryService service)
    {
        _service = service;
    }

    [HttpGet("viewAllCategories")]
    public IActionResult GetAllCategories()
    {
        try
        {
            return new OkObjectResult(_service.GetAllCategories());
        }
        catch (Exception ex)
        {
          return new BadRequestObjectResult(ex.Message);
        }
    }

    [HttpPost("addCategory")]
    public IActionResult AddCategory(CategoryDto categoryDto)
    {
        try
        {
            _service.AddCategory(categoryDto);
            return new OkObjectResult("Categoria adicionada com sucesso!");
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }
}