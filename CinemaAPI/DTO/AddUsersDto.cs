using CinemaAPI.Enums;

namespace CinemaAPI.DTO;

public record AddUsersDto(string Name,string Username, string Password,UserRoles Role);