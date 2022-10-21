using MedApp.Application.Abstractions;
using MedApp.Application.DTO;

namespace MedApp.Application.Queries
{
    public class GetUsers: IQuery<IEnumerable<UserDto>>
    {
    }
}
