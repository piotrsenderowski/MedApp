using MedApp.Application.Abstractions;
using MedApp.Application.Exceptions;
using MedApp.Application.Security;
using MedApp.Core.Abstractions;
using MedApp.Core.Entities;
using MedApp.Core.Repositories;
using MedApp.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Application.Commands.Handlers
{
    internal sealed class SignUpHandler : ICommandHandler<SignUp>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordManager _passwordManager;
        private readonly IClock _clock;
        public SignUpHandler(IUserRepository userRepository, IPasswordManager passwordManager, IClock clock)
        {
            _userRepository = userRepository;
            _passwordManager = passwordManager;
            _clock = clock;
        }

        public async Task HandleAsync(SignUp command)
        {
            var userId = new UserId(command.UserId);
            var email = new Email(command.Email);
            var password = new Password(command.Password);
            var firstName = new FirstName(command.FirstName);
            var lastName = new LastName(command.LastName);
            var role = string.IsNullOrWhiteSpace(command.Role) ? Role.Doctor() : new Role(command.Role);
            if (await _userRepository.GetByEmailAsync(email) is not null)
            {
                throw new EmailAlreadyInUseException(email);
            }

            var securedPassword = _passwordManager.Secure(password);
            var dateTimeNow = _clock.Current();
            var user = new User(userId, email, securedPassword, firstName, lastName, role, dateTimeNow, dateTimeNow);
            
            await _userRepository.AddAsync(user);

        }
    }
}
