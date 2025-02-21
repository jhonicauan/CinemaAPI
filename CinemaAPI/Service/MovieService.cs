using CinemaAPI.Database;
using CinemaAPI.DTO;
using CinemaAPI.Model;
using CinemaAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Service;

public class MovieService
{
    private readonly ConnectionContext _context;
    private readonly IRepositoryMovie _repository;

    public MovieService(ConnectionContext context, IRepositoryMovie repository)
    {
        _context = context;
        _repository = repository;
    }

    public  void AddMovie(MovieDto movieDto)
    { 
        MoviesModel movie = new MoviesModel(movieDto.Name, movieDto.Description, movieDto.ImageUrl);
        _repository.AddMovie(movie);
    }

    public List<MovieDto> GetMovies()
    {
        return _repository.GetAllMovies();
    }

    public List<MovieDto> GetActiveMovies()
    {
        return _repository.GetActiveMovies();
    }
}