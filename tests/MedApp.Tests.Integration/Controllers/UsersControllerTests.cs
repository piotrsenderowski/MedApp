using MedApp.Application.Commands;
using MedApp.Application.DTO;
using MedApp.Core.Entities;
using MedApp.Core.Repositories;
using MedApp.Core.ValueObjects;
using MedApp.Infrastructure.Security;
using MedApp.Infrastructure.Time;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MedApp.Tests.Integration.Controllers
{
    [Collection("api")]
    public class UsersControllerTests : ControlerTests, IDisposable
    {

        [Fact]
        public async Task post_users_should_return_created_201_status_code()
        {
            var command = new SignUp(Guid.Empty, "test-user1@medapp.com",
                            "secret", "JohnTest", "DoeTest", Role.Assistant());

            var response = await Client.PostAsJsonAsync("users", command);

            response.StatusCode.ShouldBe(HttpStatusCode.Created);
            response.Headers.Location.ShouldNotBeNull();
        }

        [Fact]
        public async Task post_sign_in_should_return_ok_200_ok_status_code_and_jwt()
        {
            var user = await CreateUserAsync();

            var command = new SignIn(user.Email, Password);
            var response = await Client.PostAsJsonAsync("users/sign-in", command);

            response.StatusCode.ShouldBe(HttpStatusCode.OK);
            var jwt = await response.Content.ReadFromJsonAsync<JwtDto>();
            jwt.ShouldNotBeNull();
            jwt.AccessToken.ShouldNotBeNullOrWhiteSpace();
        }

        [Fact]
        public async Task get_users_me_should_return_ok_200_status_code_and_user()
        {
            var user = await CreateUserAsync();
            
            Authorize(user.Id, user.Role);

            var userDto = await Client.GetFromJsonAsync<UserDto>("users/me");
            userDto.ShouldNotBeNull();
            userDto.Id.ShouldBe(user.Id.Value);
        }

        private async Task<User> CreateUserAsync()
        {
            var now = new Clock().Current();
            var passwordManager = new PasswordManager(new PasswordHasher<User>());
            var user = new User(Guid.NewGuid(), "test-ser1@medapp.com",
                        passwordManager.Secure(Password), "JohnTest", "DoeTest", Role.Assistant(), now, now);
            await _userRepository.AddAsync(user);
            //await _testDatabase.Context.Users.AddAsync(user);
            //await _testDatabase.Context.SaveChangesAsync();

            return user;
        }

        private const string Password = "secret";
        private readonly TestDatabase _testDatabase;
        private IUserRepository _userRepository;

        public UsersControllerTests(OptionsProvider optionsProvider) : base(optionsProvider)
        {
            _testDatabase = new TestDatabase();
        }
        public void Dispose()
        {
            _testDatabase?.Dispose();
        }

        protected override void ConfigureServices(IServiceCollection services)
        {
            _userRepository = new TestUserRepository();
            services.AddSingleton(_userRepository);
        }
    }
}
