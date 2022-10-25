using MedApp.Application.Abstractions;
using MedApp.Application.Commands;
using MedApp.Application.DTO;
using MedApp.Application.Queries;
using MedApp.Application.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace MedApp.Api.Apis
{
    internal static class UsersApi
    {
        private const string MeRoute = "me";
        public static WebApplication UseUsersApi(this WebApplication app)
        {
            app.MapGet("users", async (IQueryHandler<GetUsers, IEnumerable<UserDto>> handler) =>
            {
                var query = new GetUsers();
                var usersDto = await handler.HandleAsync(query);

                return usersDto is null ? Results.NotFound() : Results.Ok(usersDto);

            }).RequireAuthorization("is-admin");


            app.MapGet("users/me", async (HttpContext context, IQueryHandler<GetUser, UserDto> handler) =>
            {
                var userId = context.User.Identity?.Name ?? string.Empty;
                var query = new GetUser { UserId = Guid.Parse(userId) };
                var userDto = await handler.HandleAsync(query);

                return userDto is null ? Results.NotFound() : Results.Ok(userDto);

            }).RequireAuthorization().WithName(MeRoute);


            app.MapGet("users/{userId:guid}", async (Guid userId, IQueryHandler<GetUser, UserDto> handler) =>
            {
                var query = new GetUser { UserId = userId };
                var userDto = await handler.HandleAsync(query);

                return userDto is null ? Results.NotFound() : Results.Ok(userDto);

            }).RequireAuthorization("is-admin")
                //.SwaggerOperation("Get single by user ID if exists")
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status401Unauthorized)
                .Produces(StatusCodes.Status403Forbidden)
                .Produces(StatusCodes.Status404NotFound);


            app.MapPost("users", async (SignUp command, ICommandHandler<SignUp> handler) =>
            {
                command = command with { UserId = Guid.NewGuid() };
                await handler.HandleAsync(command);

                return Results.CreatedAtRoute(MeRoute, new { command.UserId }, null);

            }).RequireAuthorization("is-admin");


            app.MapPost("users/sign-in", async (SignIn command, ICommandHandler<SignIn> handler, ITokenStorage tokenStorage) =>
            {
                await handler.HandleAsync(command);
                var jwt = tokenStorage.Get();

                return Results.Ok(jwt);

            });

            app.MapDelete("users/{userId:guid}", async (Guid userId, ICommandHandler<DeleteUser> handler) =>
            {
                var command = new DeleteUser(userId);
                await handler.HandleAsync(command);
                return Results.NoContent();
            });

            return app;

        }
    }
}
