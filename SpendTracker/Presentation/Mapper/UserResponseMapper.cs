using AutoMapper;
using SpendTracker.Application.Dtos;
using SpendTracker.Presentation.Response.User;

namespace SpendTracker.Presentation.Mapper
{
    public class UserResponseMapper:Profile
    {
        public UserResponseMapper() {

            CreateMap<UserDto,UserForReadResponse>();
        }
    }
}
