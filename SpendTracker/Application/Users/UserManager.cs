using AutoMapper;
using CSharpFunctionalExtensions;
using SpendTracker.Application.Contracts;
using SpendTracker.Application.Dtos;
using SpendTracker.Domain.Users;
using System.Collections.Immutable;

namespace SpendTracker.Application.Users
{
    public class UserManager(IUserRepository userRepository,IMapper mapper) : IUserManager
    {
        public async Task<Result> AddUserAsync(UserForAddDto userForAddDto)
        {

            await userRepository.CreateAsync(new(  userForAddDto.Name,   userForAddDto.UserName,  userForAddDto.Password));
            return Result.Success();

        }

        public async Task<Result<UserDto>> GetUserByIdAsync(Guid Id)
        {
          var result =  await userRepository.GetByIdAsync(Id);
            var maped = mapper.Map<UserDto>(result);
          return  Result.Success(maped);
        }

        public async Task<Result<IEnumerable<UserDto>>> GetUsersAsync()
        {
            var users = await userRepository.GetAllAsync();
            List<UserDto> result = new List<UserDto>();
            foreach (var user in users)
            {
                result.Add(new( user.UserName, user.Name) );
            }
            var ss = result.AsEnumerable();
            return Result.Success(ss);
        }

        public async Task<Result> UpdateProductAsync(Guid userId, UserForUpdateDto usertForUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
