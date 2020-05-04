namespace HomeSeek.Database.Migrations
{
    using HomeSeek.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HomeSeek.Database.MyDatabase>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(HomeSeek.Database.MyDatabase context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //================= Seeding Amenities =================
            //Amenities template = new Amenities() { Title = "", Duration = 0, PhotoUrl = "", Price = 0, ProductionYear = new DateTime(1, 1, 1), Rating = 0D, TrailerUrl = "", Watched = false ,Country=Country.United_States_of_America};
            Amenities a2 = new Amenities() { Count = 1, Wifi = false, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = true, FreeParking = true, HotWater = true, PrivateΕntrance = true };
            Amenities a3 = new Amenities() { Count = 2, Wifi = true, Heating = false, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = true, FreeParking = true, HotWater = true, PrivateΕntrance = true };
            Amenities a1 = new Amenities() { Count = 3, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = true, FreeParking = true, HotWater = true, PrivateΕntrance = true };

            //================= Seeding Places =================
            //Place template = new Place() { Title = "", Duration = 0, PhotoUrl = "", Price = 0, ProductionYear = new DateTime(1, 1, 1), Rating = 0D, TrailerUrl = "", Watched = false ,Country=Country.United_States_of_America};
            Place p1 = new Place() { ApartmentName = "Apartment in Psichiko", PricePerDay = 50M, Description = "O,ti kalytero se spiti uparxei, mpravo sta paidia.", Guests = 2, Bedroom = 3, Bathroom = 1, CleanCost = 10M, IsBooked = false, Created = new DateTime(2020, 05, 02), Modified = new DateTime(2020, 05, 05) };
            Place p2 = new Place() { ApartmentName = "Nea Makri Exohiko", PricePerDay = 60M, Description = "Foveri thea, einai monadiko meros gia na meinete.", Guests = 3, Bedroom = 2, Bathroom = 2, CleanCost = 15M, IsBooked = false, Created = new DateTime(2020, 05, 01), Modified = new DateTime(2020, 05, 10) };
            Place p3 = new Place() { ApartmentName = "Villa in Mykonos", PricePerDay = 250M, Description = "Fthines potares, to kalutero meros gia na sprwkseis!", Guests = 6, Bedroom = 5, Bathroom = 3, CleanCost = 40M, IsBooked = false, Created = new DateTime(2020, 04, 28), Modified = new DateTime(2020, 04, 30) };

            //================= Seeding Reservations =================
            //Reservation template = new Reservation() { Title = "", Duration = 0, PhotoUrl = "", Price = 0, ProductionYear = new DateTime(1, 1, 1), Rating = 0D, TrailerUrl = "", Watched = false ,Country=Country.United_States_of_America};
            Reservation r1 = new Reservation() { CheckInDate = new DateTime(2020, 6, 1), CheckOutDate = new DateTime(2020, 6, 5), DaysOfStaying = 4, TotalAmount = 210M, PaymentDate = new DateTime(2020, 5, 4), TotalFees = 21M };
            Reservation r2 = new Reservation() { CheckInDate = new DateTime(2020, 7, 11), CheckOutDate = new DateTime(2020, 7, 22), DaysOfStaying = 11, TotalAmount = 675M,PaymentDate = new DateTime(2020, 6, 15), TotalFees = 67.5M };
            Reservation r3 = new Reservation() { CheckInDate = new DateTime(2020, 8, 21), CheckOutDate = new DateTime(2020, 8, 30), DaysOfStaying = 9, TotalAmount = 2290M,PaymentDate = new DateTime(2020, 7, 25), TotalFees = 229M };

            //================= Seeding Reviews =================
            //Review template = new Review() { Title = "", Duration = 0, PhotoUrl = "", Price = 0, ProductionYear = new DateTime(1, 1, 1), Rating = 0D, TrailerUrl = "", Watched = false ,Country=Country.United_States_of_America};
            Review rev1 = new Review() { Accuracy = 10, Checkin = 9, Cleanliness = 10, Location = 10, Value = 10, SubDate = new DateTime(2020, 6, 6), OverallRating = 9.1, Comment = "ola teleia" };
            Review rev2 = new Review() { Accuracy = 9, Checkin = 10, Cleanliness = 9, Location = 10, Value = 10, SubDate = new DateTime(2020, 7, 23), OverallRating = 9.1, Comment = "apisteuto service" };
            Review rev3 = new Review() { Accuracy = 8, Checkin = 9, Cleanliness = 8, Location = 10, Value = 10, SubDate = new DateTime(2020, 8, 31), OverallRating = 9.5, Comment = "Super" };

            //================= Seeding Application User =================
            //ApplicationUser template = new ApplicationUser() { UserName = "", LastName = "", FirstName = "", City = "", DateOfBirth = new DateTime(1989, 08, 01) };
            ApplicationUser ap1 = new ApplicationUser() { UserName = "xenos", LastName = "Vlaxos", FirstName = "Xenos", City = "Athens", DateOfBirth = new DateTime(1989, 08, 01) };
            ApplicationUser ap2 = new ApplicationUser() { UserName = "thanos", LastName = "Kontos", FirstName = "Thanos", City = "Thessaloniki", DateOfBirth = new DateTime(1990, 05, 12) };
            ApplicationUser ap3 = new ApplicationUser() { UserName = "alex", LastName = "Perikle", FirstName = "Alex", City = "Crete", DateOfBirth = new DateTime(1994, 04, 22) };

            //================= Seeding Address =================
            //Address template = new Address() { AddressLine = "", City = "", Counties = CountiesOfGreece.Attica, Countries = Countries.Greece };
            Address ad1 = new Address() { AddressLine = "Aleksandou 33", City = "Psichiko", Counties = CountiesOfGreece.Attica, Countries = Countries.Greece };
            Address ad2 = new Address() { AddressLine = "Palaiologou 76", City = "Nea Makri", Counties = CountiesOfGreece.Attica, Countries = Countries.Greece };
            Address ad3 = new Address() { AddressLine = "Psarou 2", City = "Mykonos", Counties = CountiesOfGreece.Cyclades, Countries = Countries.Greece };

            //================= Seeding Photo =================
            //Photo template = new Photo() { PhotoUrl = "#" };
            Photo ph1 = new Photo() { PhotoUrl = "#" };
            Photo ph2 = new Photo() { PhotoUrl = "##" };
            Photo ph3 = new Photo() { PhotoUrl = "###" };


            //================Create Relations ==================
            p1.Amenities = a1;
            p2.Amenities = a2;
            p3.Amenities = a3;

            p1.Address = ad1;
            p2.Address = ad2;
            p3.Address = ad3;

            p1.Photos = new List<Photo>() { ph1 };
            p2.Photos = new List<Photo>() { ph2 };
            p3.Photos = new List<Photo>() { ph3 };

            p1.Reviews = new List<Review>() { rev1 };
            p2.Reviews = new List<Review>() { rev2 };
            p3.Reviews = new List<Review>() { rev3 };

            rev1.ApplicationUser = ap1;
            rev2.ApplicationUser = ap2;
            rev3.ApplicationUser = ap3;

            r1.Place = p1;
            r2.Place = p2;
            r3.Place = p3;

            r1.ApplicationUser = ap1;
            r2.ApplicationUser = ap2;
            r3.ApplicationUser = ap3;


            context.Reviews.AddOrUpdate(x => x.Accuracy, rev1, rev2, rev3);
            context.Amenities.AddOrUpdate(x => x.Count, a1, a2, a3);
            context.Places.AddOrUpdate(x => x.ApartmentName, p1, p2, p3);
            context.Reservations.AddOrUpdate(x => x.DaysOfStaying, r1, r2, r3);
            context.Users.AddOrUpdate(x => x.LastName, ap1, ap2, ap3);
            context.Photos.AddOrUpdate(x => x.PhotoUrl, ph1, ph2, ph3);

            context.SaveChanges();
        }
    }
}
