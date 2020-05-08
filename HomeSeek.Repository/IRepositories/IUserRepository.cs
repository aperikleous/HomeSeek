using HomeSeek.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeSeek.Repository
{
    public interface IUserRepository:IRepository<ApplicationUser>
    {
        ApplicationUser GetByUserId(string id);
    }
}
