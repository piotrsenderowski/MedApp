using MedApp.Application.Abstractions;
using MedApp.Application.Security;
using MedApp.Core.Repositories;
using MedApp.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Application.Commands.Handlers
{
    internal sealed class SignInHandler : ICommandHandler<SignIn>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticator _authenticator;
        private readonly IPasswordManager _passwordManager;
        private readonly ITokenStorage _tokenStorage;

        public SignInHandler(IUserRepository userRepository, 
            IAuthenticator authenticator, IPasswordManager passwordManager, ITokenStorage tokenStorage)
        {
            _userRepository = userRepository;
            _authenticator = authenticator;
            _passwordManager = passwordManager;
            _tokenStorage = tokenStorage;
        }
        public async Task HandleAsync(SignIn command)
        {
            var user = await _userRepository.GetByEmailAsync(command.Email);
            if (user == null)
            {
                throw new InvalidCredentialException();
            }

            if (!_passwordManager.Validate(command.Password, user.Password))
            {
                throw new InvalidCredentialException();
            }

            var jwt = _authenticator.CreateToken(user.Id, user.Role);
            _tokenStorage.Set(jwt);
        }
    }
}
