using HomeSeek.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeSeek.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly MyDatabase _context;


        public UnitOfWork(MyDatabase context)
        {
            _context = context;
            Places = new PlaceRepository(_context);
            Amenities = new AmenitiesRepository(_context);
            Address = new AddressRepository(_context);
            Photo = new PhotoRepository(_context);
            Users = new UserRepository(_context);
            Reservations = new ReservationRepository(_context);
            Reviews = new ReviewRepository(_context);
        }

        public IPlaceRepository Places { get; private set; }
        public IAmenitiesRepository Amenities { get; private set; }
        public IAddressRepository Address { get; private set; }
        public IPhotoRepository Photo { get; private set; }
        public IUserRepository Users { get; private set; }

        public IReservationRepository Reservations { get; private set; }

        public IReviewRepository Reviews { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
