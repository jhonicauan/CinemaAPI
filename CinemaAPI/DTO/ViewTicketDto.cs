namespace CinemaAPI.DTO;

public record ViewTicketDto(string UserName,string RoomName,string RowLetter,int SeatNumber,string MovieName,DateTime SessionDate);