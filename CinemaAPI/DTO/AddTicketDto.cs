using CinemaAPI.Enums;

namespace CinemaAPI.DTO;

public record AddTicketDto(int IdUser,int IdSession,int IdSeat,TypeTicket TypeTicket);