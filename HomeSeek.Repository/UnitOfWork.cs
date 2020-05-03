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
            //Courses = new CourseRepository(_context);
            //Authors = new AuthorRepository(_context);
        }

        public IPlaceRepository Places { get; private set; }


        //public ICourseRepository Courses { get; private set; }
        //public IAuthorRepository Authors { get; private set; }

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
