using CSharpFunctionalExtensions;
using SpendTracker.Application.Dtos;
 

namespace SpendTracker.Application.Contracts
{
    public interface IUserManager
    {
        Task<Result<IEnumerable<UserDto>>> GetUsersAsync();
        Task<Result<UserDto>> GetUserByIdAsync(Guid Id);
        Task<Result> AddUserAsync(UserForAddDto userForAddDto);
        Task<Result> UpdateProductAsync(Guid userId, UserForUpdateDto usertForUpdateDto);
    }
}
