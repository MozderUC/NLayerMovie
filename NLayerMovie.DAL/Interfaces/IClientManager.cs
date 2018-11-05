using NLayerMovie.DAL.Entities;
using System;

namespace NLayerMovie.DAL.Interfaces
{
    public interface IClientManager : IDisposable
    {
        void Create(ClientProfile item);
    }
}
