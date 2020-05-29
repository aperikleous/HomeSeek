namespace HomeSeek.Database.Migrations
{
    using HomeSeek.Entities;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
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
            if (!context.Roles.Any(x => x.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };
                manager.Create(role);
            }

            //create role spectator
            if (!context.Roles.Any(x => x.Name == "Spectator"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Spectator" };
                manager.Create(role);
            }
            //create role Host
            if (!context.Roles.Any(x => x.Name == "Host"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Host" };
                manager.Create(role);
            }
            //create role Registered user/member
            if (!context.Roles.Any(x => x.Name == "Member"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Member" };
                manager.Create(role);
            }

            //Φτιάχνω νέο χρήστη
            var PasswordHash = new PasswordHasher();
            if (!context.Users.Any(x => x.UserName == "admin@hol.net"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store); //dependancy injection
                var user = new ApplicationUser() {LastName = "Zak", FirstName = "Zakkk", City = "Athens", DateOfBirth = new DateTime(1989, 08, 01), UserName = "admin@hol.net", Email = "admin@hol.net", PasswordHash = PasswordHash.HashPassword("Admin1!") };  //passwordhass ->κρυπτογραφημένο κωδικό
                manager.Create(user);
                //αναθέτω ρόλο στο χρήστη
                manager.AddToRole(user.Id, "Admin");
            }

            
            if (!context.Users.Any(x => x.UserName == "member@member.net"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store); 
                var user = new ApplicationUser() { LastName = "Yvves", FirstName = "Jean", City = "Athens", DateOfBirth = new DateTime(1982, 10, 05), UserName = "member@member.net", Email = "member@member.net", PasswordHash = PasswordHash.HashPassword("Member1!") };
                manager.Create(user);
                //αναθέτω ρόλο στο χρήστη
                manager.AddToRole(user.Id, "Member");
            }

            if (!context.Users.Any(x => x.UserName == "host@host.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store); 
                var user = new ApplicationUser() { LastName = "Sun", FirstName = "Yi", City = "Larissa", DateOfBirth = new DateTime(1970, 6, 15), UserName = "host@host.com", Email = "host@host.com", PasswordHash = PasswordHash.HashPassword("Member1!") };
                manager.Create(user);
                //αναθέτω ρόλο στο χρήστη
                manager.AddToRole(user.Id, "Host");
            }

            //if (!context.Users.Any(u => u.UserName == "founder"))
            //{
            //    var store = new UserStore<ApplicationUser>(context);
            //    var manager = new UserManager<ApplicationUser>(store);
            //    var user = new ApplicationUser { UserName = "founder" };

            //    manager.Create(user, "ChangeItAsap!");
            //    manager.AddToRole(user.Id, "AppAdmin");
            //}

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
           // Place p4 = new Place() { ApartmentName = "Villa in Mykonos1", PricePerDay = 251M, Description = "Fthino faghto, to kalutero meros gia masa!", Guests = 3, Bedroom = 5, Bathroom = 3, CleanCost = 40M, IsBooked = false, Created = new DateTime(2020, 04, 28), Modified = new DateTime(2020, 04, 30) };

            //================= Seeding Reservations =================
            //Reservation template = new Reservation() { Title = "", Duration = 0, PhotoUrl = "", Price = 0, ProductionYear = new DateTime(1, 1, 1), Rating = 0D, TrailerUrl = "", Watched = false ,Country=Country.United_States_of_America};
            Reservation r1 = new Reservation() { CheckInDate = new DateTime(2020, 6, 1), CheckOutDate = new DateTime(2020, 6, 5), DaysOfStaying = 4, TotalAmount = 210M, PaymentDate = new DateTime(2020, 5, 4), TotalFees = 21M };
            Reservation r2 = new Reservation() { CheckInDate = new DateTime(2020, 7, 11), CheckOutDate = new DateTime(2020, 7, 22), DaysOfStaying = 11, TotalAmount = 675M,PaymentDate = new DateTime(2020, 6, 15), TotalFees = 67.5M };
            Reservation r3 = new Reservation() { CheckInDate = new DateTime(2020, 8, 21), CheckOutDate = new DateTime(2020, 8, 30), DaysOfStaying = 9, TotalAmount = 2290M,PaymentDate = new DateTime(2020, 7, 25), TotalFees = 229M };

            //================= Seeding Reviews =================
            //Review template = new Review() { Accuracy = 5, Checkin = 4, Cleanliness = 5, Location = 4, Value = 5, SubDate = new DateTime(2020, 6, 6),  Comment = "ola teleia" };
            Review rev1 = new Review() { Accuracy = 5, Checkin = 4, Cleanliness = 5, Location = 4, Value = 5, SubDate = new DateTime(2020, 6, 6),  Comment = "ola teleia" };
            Review rev2 = new Review() { Accuracy = 4, Checkin = 5, Cleanliness = 4, Location = 4, Value = 5, SubDate = new DateTime(2020, 7, 23), Comment = "apisteuto service" };
            Review rev3 = new Review() { Accuracy = 3, Checkin = 4, Cleanliness = 3, Location = 5, Value = 5, SubDate = new DateTime(2020, 8, 31), Comment = "Super" };
            Review rev4 = new Review() { Accuracy = 2, Checkin = 4, Cleanliness = 4, Location = 4, Value = 4, SubDate = new DateTime(2020, 8, 18), Comment = "SuperSuperSuperSuperSuperSuper" };

            //================= Seeding Application User =================
            //ApplicationUser template = new ApplicationUser() { UserName = "", LastName = "", FirstName = "", City = "", DateOfBirth = new DateTime(1989, 08, 01) };
            ApplicationUser ap1 = new ApplicationUser() { UserName = "xenos", LastName = "Vlaxos", FirstName = "Xenos", City = "Athens", DateOfBirth = new DateTime(1989, 08, 01) };
            ApplicationUser ap2 = new ApplicationUser() { UserName = "thanos", LastName = "Kontos", FirstName = "Thanos", City = "Thessaloniki", DateOfBirth = new DateTime(1990, 05, 12) };
            ApplicationUser ap3 = new ApplicationUser() { UserName = "alex", LastName = "Perikle", FirstName = "Alex", City = "Crete", DateOfBirth = new DateTime(1994, 04, 22) };

            //================= Seeding Address =================
            //Address template = new Address() { AddressLine = "", City = "", Counties = CountiesOfGreece.Attica, Countries = Countries.Greece };
            Address adr1 = new Address() { AddressName = "Ανδρέα Κάλβου", No = "8", ZipCode = "17455", Latitude = "37.9160632", Longitude = "23.7258564", City = "Αθήνα", Area = "Άλιμος" };
            Address adr2 = new Address() { AddressName = "Αδάμων", No = "21", ZipCode = "14564", Latitude = "38.0918513", Longitude = "23.8019882", City = "Αθήνα", Area = "Κηφισιά" };
            Address adr3 = new Address() { AddressName = "Δράμας", No = "5", ZipCode = "18648", Latitude = "37.946975", Longitude = "23.623853", City = "Αθήνα", Area = "Μαρούσι" };
            Address adr4 = new Address() { AddressName = "Αριστοφάνους", No = "21", ZipCode = "16674", Latitude = "37.8742167", Longitude = "23.759905,17", City = "Αθήνα", Area = "Γλυφάδα" };
            Address adr5 = new Address() { AddressName = "Γυθείου", No = "12", ZipCode = "16342", Latitude = "37.9234159", Longitude = "23.7631328", City = "Αθήνα", Area = "Ηλιούπολη" };
            Address adr6 = new Address() { AddressName = "Υμηττού", No = "130", ZipCode = "11634", Latitude = "37.9659734", Longitude = "23.7451387", City = "Αθήνα", Area = "Παγκράτι" };
            Address adr7 = new Address() { AddressName = "Σταδίου", No = "2", ZipCode = "10564", Latitude = "37.976445", Longitude = "23.7323298", City = "Αθήνα", Area = "Κέντρο Αθήνας" };
            Address adr8 = new Address() { AddressName = "Πανεπιστημίου", No = "12", ZipCode = "10564", Latitude = "37.9778266", Longitude = "23.7332016", City = "Αθήνα", Area = "Κέντρο Αθήνας" };
            Address adr9 = new Address() { AddressName = "Τσιμισκή", No = "34", ZipCode = "54623", Latitude = "40.6329694", Longitude = "22.9401955", City = "Θεσσαλονίκη", Area = "Κέντρο Θεσσαλονίκη" };
            Address adr10 = new Address() { AddressName = "Εθ.Αντιστάσεως", No = "173", ZipCode = "18648", Latitude = "37.9474722", Longitude = "23.6240855", City = "Πειραιάς", Area = "Δραπετσώνα" };
            Address adr11 = new Address() { AddressName = "Παπαφλεσσα", No = "25", ZipCode = "58768", Latitude = "38.0523321", Longitude = "23.8091868", City = "Πειραιάς", Area = "Δραπετσώνα" };
            Address adr12 = new Address() { AddressName = "Αριστοτέλους", No = "16", ZipCode = "17455", Latitude = "37.9126442", Longitude = "23.7099781", City = "Αθήνα", Area = "Άλιμος" };

            //================= Seeding Photo =================
            //Photo template = new Photo() { PhotoUrl = "#" };
            //Photo home1out1 = new Photo() { PhotoUrl = "/Content/Images/home1/1-out1.jpg", PhotoName = "Εξωτερική 1" };
            Photo ph1 = new Photo() { PhotoUrl = "#" };
            Photo ph2 = new Photo() { PhotoUrl = "##" };
            Photo ph3 = new Photo() { PhotoUrl = "###" };


            //================Create Relations ==================
            p1.Amenities = a1;
            p2.Amenities = a2;
            p3.Amenities = a3;


            p1.Address = adr1;
            p2.Address = adr2;
            p3.Address = adr3;
            //adr1.Places = new List<Place>() { p1 };
            //adr2.Places = new List<Place>() { p2 };
            //adr3.Places = new List<Place>() { p3 };
            //adr4.Products = new List<Product>() { commercial5 };
            //adr5.Products = new List<Product>() { home6 };
            //adr6.Products = new List<Product>() { commercial3 };
            //adr7.Products = new List<Product>() { commercial4 };  //kentro athina
            //adr8.Products = new List<Product>() { home3 };         //kentro athina
            //adr9.Products = new List<Product>() { home4 };       //kentro thessalonikh
            //adr10.Products = new List<Product>() { commercial1 }; //peiraias
            //adr11.Products = new List<Product>() { commercial2 }; //peiraias
            //adr12.Products = new List<Product>() { field2 };
            //p4.Address = ad3;

            p1.Photos = new List<Photo>() { ph1 };
            p2.Photos = new List<Photo>() { ph2 };
            p3.Photos = new List<Photo>() { ph3 };

            p1.Reviews = new List<Review>() { rev1,rev4 };
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


            context.Reviews.AddOrUpdate(x => x.Accuracy, rev1, rev2, rev3, rev4);
            context.Amenities.AddOrUpdate(x => x.Count, a1, a2, a3);
            context.Places.AddOrUpdate(x => x.ApartmentName, p1, p2, p3);
            context.Reservations.AddOrUpdate(x => x.DaysOfStaying, r1, r2, r3);
            context.Users.AddOrUpdate(x => x.LastName, ap1, ap2, ap3);
            context.Photos.AddOrUpdate(x => x.PhotoUrl, ph1, ph2, ph3);

            context.SaveChanges();
        }
    }
}
