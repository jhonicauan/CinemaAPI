using CinemaAPI.Controller;
using CinemaAPI.Database;
using CinemaAPI.DTO;
using CinemaAPI.Enums;
using CinemaAPI.Model;
using CinemaAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Service;

public class SeatService
{
    private readonly ConnectionContext _context;
    private readonly IRepositorySeat _repository;

    public SeatService(ConnectionContext context, IRepositorySeat repository)
    {
        _context = context;
        _repository = repository;
    }
    
    public void AddSeats(AddSeatDto seats)
    {
        int idRoom = seats.IdRoom;
        
        string rowLetter = seats.RowLetter.ToUpper();
        
        int numSeats = CountSeats(seats);

        int quantSeats = seats.numberSeats;

        for (int i = numSeats + 1; i <= quantSeats; i++)
        {
            SeatsModel seat = new SeatsModel(idRoom,rowLetter,i);
            _repository.AddSeats(seat);
        }
    }

    public List<SeatDto> GetSeatsOfRoom(int roomId)
    {
        return _context.Seats.Select(s => new SeatDto(s.RowLetter,s.SeatNumber)).ToList();
    }
    
    public void UpdateType(int seatId, UpdateTypeSeatDto updateType)
    {
        SeatsModel seat = _context.Seats.Find(seatId) ?? throw new InvalidOperationException();

        seat.TypeSeat = (TypeSeats)updateType.NewType;
        
        _repository.UpdateType(seat);
    }

    private int CountSeats(AddSeatDto seats)
    {
        return _context.Seats.Count(s => s.IdRoom == seats.IdRoom && s.RowLetter == seats.RowLetter.ToUpper());
    }
    
    
}