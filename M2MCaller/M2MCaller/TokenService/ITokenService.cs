using System;
using System.Threading.Tasks;

namespace M2MCaller.TokenService
{
    public interface ITokenService
    {
        Task<string> GetToken();
    }
}
