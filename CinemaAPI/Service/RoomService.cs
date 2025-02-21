using CinemaAPI.DTO;
using CinemaAPI.Model;
using CinemaAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Service;

public class RoomService
{
    private readonly IRepositoryRoom _repository;

    public RoomService(IRepositoryRoom repository)
    {
        _repository = repository;
    }

    public void AddRoom()
    {
      _repository.AddRoom();
    }

    public List<RoomDto> GetAllRooms()
    {
     return _repository.GetAllRooms();
    }
}