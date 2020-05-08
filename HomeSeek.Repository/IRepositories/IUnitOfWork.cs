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
        IAmenitiesRepository Amenities { get; }
        IAddressRepository Address { get; }
        IPhotoRepository Photo { get; }
        IUserRepository Users { get; }
        IReservationRepository Reservations { get; }
        IReviewRepository Reviews { get; }
        int Complete();
    }
}
