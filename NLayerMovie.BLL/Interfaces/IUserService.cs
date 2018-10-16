using NLayerMovie.BLL.DTO;
using NLayerMovie.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NLayerMovie.BLL.Interfaces
{
    //Через объекты данного интерфейса уровень представления будет взаимодействовать с уровнем доступа к данным
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> Create(UserDTO userDto);
        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        Task SetInitialData(UserDTO adminDto, List<string> roles);
    }
}
