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

    public void ChangeStatusMovie(int movieId)
    {
        _repository.ChangeStatusMovie(movieId);
    }

    public List<MovieDto> GetMovies()
    {
        return _repository.GetAllMovies();
    }

    public List<MovieDto> GetActiveMovies()
    {
        return _repository.GetActiveMovies();
    }

    public List<MovieDto> FindMovies(string search)
    {
        return _repository.FindMovies(search);
    }
}