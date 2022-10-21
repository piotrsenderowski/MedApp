using MedApp.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Application.Security
{
    public interface ITokenStorage
    {
        void Set(JwtDto jwt);
        JwtDto Get();
    }
}
