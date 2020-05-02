using HomeSeek.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeSeek.Database
{
    public class MyDatabase : ApplicationDbContext
    {
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}
