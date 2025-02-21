using CinemaAPI.Controller;
using CinemaAPI.DTO;
using CinemaAPI.Model;

namespace CinemaAPI.Repository;

public interface IRepositorySeat
{
    public void AddSeats(SeatsModel seats);

    public List<SeatDto> GetSeatsOfRoom(int roomId);

    public void UpdateType(SeatsModel seat);
}

