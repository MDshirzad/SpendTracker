using AutoMapper;
using Carter;
using Microsoft.AspNetCore.Mvc;
using SpendTracker.Application.Contracts;
using SpendTracker.Application.Dtos;
using SpendTracker.Presentation.Request.User;
using SpendTracker.Presentation.Response.User;
using IResult = Microsoft.AspNetCore.Http.IResult;


namespace SpendTracker.Presentation.Endpoints
{
    public class UserEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var appBl = app.MapGroup("user").WithTags("User");
            appBl.MapGet("/{Id}", GetUserById);
            appBl.MapPost("create", CreateUser);
            appBl.MapPost("get-all", GetAll);
            appBl.MapPut("update/{id}", UpdateUser);
        }

        private async Task<IResult> GetAll([FromServices] IUserManager userManager, [FromServices] IMapper mapper)
        {
            var result = await userManager.GetUsersAsync();
            if (result.IsSuccess)
            {

            var mapped = mapper.Map<IEnumerable<UserForReadResponse>>(result.Value);
                return TypedResults.Ok(mapped);
            }
            return Results.BadRequest(UpdateUser);
            
        }

        private async Task UpdateUser([FromRoute] string id, [FromBody] UserForCreateRequest data)
        {
            throw new NotImplementedException();
        }

        private async Task<IResult> GetUserById([FromRoute] Guid id, [FromServices] IUserManager userManager, [FromServices] IMapper mapper)
        {
            var result = await userManager.GetUserByIdAsync(id);
            if (result.IsSuccess)
            {

                var mapped = mapper.Map<UserForReadResponse>(result.Value);
                return TypedResults.Ok(mapped);
            }
            else
            {
                return Results.BadRequest();
            }


        }

        private async Task<IResult> CreateUser([FromBody] UserForCreateRequest userData, [FromServices] IUserManager userManager, [FromServices] IMapper mapper)
        {
            var mappedUser = mapper.Map<UserForAddDto>(userData);
            var result = await userManager.AddUserAsync(mappedUser);
            if (result.IsSuccess)
            {
                return TypedResults.Ok();

            }
            return Results.BadRequest();
        }
    }
}
