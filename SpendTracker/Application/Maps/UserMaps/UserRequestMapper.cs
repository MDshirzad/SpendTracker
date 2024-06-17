using AutoMapper;
using SpendTracker.Application.Dtos;
using SpendTracker.Domain.Users;

namespace SpendTracker.Application.Maps.UserMaps
{
    public class UserRequestMapper:Profile
    {
        public UserRequestMapper()
        {
            CreateMap<User, UserDto>();
        }
    }
}
