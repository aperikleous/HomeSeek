using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeSeek.Entities;
using System.Data.Entity;
using HomeSeek.Database;

namespace HomeSeek.Repository
{
    public class AddressRepository : Repository<Address>,IAddressRepository
    {
        public AddressRepository(MyDatabase context) : base(context)
        {
        }

        public MyDatabase MyDatabase
        {
            get { return Context as MyDatabase; }
        }
    }
}
