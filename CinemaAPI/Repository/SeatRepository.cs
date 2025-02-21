using CinemaAPI.Controller;
using CinemaAPI.Database;
using CinemaAPI.DTO;
using CinemaAPI.Enums;
using CinemaAPI.Model;

namespace CinemaAPI.Repository;

public class SeatRepository : IRepositorySeat
{
    private readonly ConnectionContext _context;

    public SeatRepository(ConnectionContext context)
    {
        _context = context;
    }

    public void AddSeats(SeatsModel seats)
    {
        _context.Add(seats);
        _context.SaveChanges();
    }

    public List<SeatDto> GetSeatsOfRoom(int roomId)
    {
        return _context.Seats.Select(s => new SeatDto(s.RowLetter,s.SeatNumber)).ToList();
    }

    public void UpdateType(int seatId, UpdateTypeSeatDto updateType)
    {
        SeatsModel seat = _context.Seats.Find(seatId) ?? throw new InvalidOperationException();

        seat.TypeSeat = (TypeSeats)updateType.NewType;
        _context.Update(seat);
        _context.SaveChanges();
    }
}