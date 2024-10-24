using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Request;

namespace Application.Interfaces
{
    public interface IAuthenticationService
    {
        string Autenticar(AuthenticationRequest request);
    }
}
