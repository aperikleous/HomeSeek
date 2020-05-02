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
    public class AddressRepository : Repository<Address>
    {
        public AddressRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
