using CinemaAPI.Database;
using CinemaAPI.DTO;
using CinemaAPI.Model;

namespace CinemaAPI.Repository;

public class RoomRepository : IRepositoryRoom
{
    private readonly ConnectionContext _context;

    public RoomRepository(ConnectionContext context)
    {
        _context = context;
    }

    public void AddRoom()
    {
        RoomsModel room = new RoomsModel();
        room.Name += (_context.Rooms.Count() + 1).ToString();
        _context.Add(room);
        _context.SaveChanges();
    }

    public List<RoomDto> GetAllRooms()
    {
        return _context.Rooms.Select(r => new RoomDto(r.Name)).ToList();
    }
}