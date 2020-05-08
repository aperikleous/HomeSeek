using HomeSeek.Database;
using HomeSeek.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeSeek.Repository
{
    public class PhotoRepository : Repository<Photo>,IPhotoRepository
    {
        public PhotoRepository(MyDatabase context) : base(context)
        {
        }

        public MyDatabase MyDatabase
        {
            get { return Context as MyDatabase; }
        }
    }
    
}
