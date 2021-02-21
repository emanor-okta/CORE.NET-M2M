using System.Collections.Generic;
using System.Threading.Tasks;
using M2MCaller.Models;

namespace M2MCaller.Services
{
    public interface IApiService
    {
        Task<IList<Message>> GetValues();
    }
}
