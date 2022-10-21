using MedApp.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Application.Security
{
    public interface IAuthenticator
    {
        JwtDto CreateToken(Guid userId, string role);
    }
}
