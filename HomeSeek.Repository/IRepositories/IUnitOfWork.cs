using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeSeek.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IPlaceRepository Places { get; }
        int Complete();
    }
}
