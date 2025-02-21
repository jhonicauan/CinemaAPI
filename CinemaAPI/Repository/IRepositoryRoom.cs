using CinemaAPI.DTO;

namespace CinemaAPI.Repository;

public interface IRepositoryRoom
{
    public void AddRoom();

    public List<RoomDto> GetAllRooms();
}