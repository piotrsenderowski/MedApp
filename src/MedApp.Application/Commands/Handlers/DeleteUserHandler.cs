using MedApp.Application.Abstractions;
using MedApp.Application.Exceptions;
using MedApp.Core.Repositories;
using MedApp.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Application.Commands.Handlers
{
    namespace MedApp.Application.Commands.Handlers
    {
        internal sealed class DeleteUserHandler : ICommandHandler<DeleteUser>
        {
            private readonly IUserRepository _userRepository;

            public DeleteUserHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task HandleAsync(DeleteUser command)
            {
                var userId = new UserId(command.UserId);
                var user = await _userRepository.GetByIdAsync(userId);
                if (user is null)
                {
                    throw new UserNotFoundException(userId);
                }
                await _userRepository.DeleteAsync(user);
            }
        }
    }

}
