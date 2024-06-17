using AutoMapper;
using SpendTracker.Application.Dtos;
using SpendTracker.Presentation.Request.User;

namespace SpendTracker.Presentation.Mapper
{
    public class UserRequestMapper : Profile
    {
        public UserRequestMapper()
        {
            CreateMap<UserForCreateRequest, UserForAddDto>();
           
        }
    }
}
