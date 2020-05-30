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
                var user = new ApplicationUser() { LastName = "Zak", FirstName = "Zakkk", City = "Athens", DateOfBirth = new DateTime(1989, 08, 01), UserName = "admin@hol.net", Email = "admin@hol.net", PasswordHash = PasswordHash.HashPassword("Admin1!") };  //passwordhass ->κρυπτογραφημένο κωδικό
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
            Amenities a1 = new Amenities() { Count = 1, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = true, FreeParking = true, HotWater = true, PrivateΕntrance = true };
            Amenities a2 = new Amenities() { Count = 2, Wifi = false, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = true, FreeParking = true, HotWater = true, PrivateΕntrance = true };
            Amenities a3 = new Amenities() { Count = 3, Wifi = true, Heating = false, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = true, FreeParking = true, HotWater = true, PrivateΕntrance = true };
            Amenities a4 = new Amenities() { Count = 4, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = true, FreeParking = true, HotWater = true, PrivateΕntrance = true };
            Amenities a5 = new Amenities() { Count = 5, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = false, FreeParking = true, HotWater = true, PrivateΕntrance = true };
            Amenities a6 = new Amenities() { Count = 6, Wifi = false, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = false, FreeParking = true, HotWater = true, PrivateΕntrance = true };
            Amenities a7 = new Amenities() { Count = 7, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = false, FreeParking = true, HotWater = true, PrivateΕntrance = true };
            Amenities a8 = new Amenities() { Count = 8, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = false, FreeParking = true, HotWater = true, PrivateΕntrance = true };
            Amenities a9 = new Amenities() { Count = 9, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = false, FreeParking = false, HotWater = true, PrivateΕntrance = true };
            Amenities a10 = new Amenities() { Count = 10, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = false, FreeParking = true, HotWater = true, PrivateΕntrance = true };
            Amenities a11 = new Amenities() { Count = 11, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = true, FreeParking = false, HotWater = true, PrivateΕntrance = true };
            Amenities a12 = new Amenities() { Count = 12, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = true, FreeParking = false, HotWater = true, PrivateΕntrance = true };
            Amenities a13 = new Amenities() { Count = 13, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = true, FreeParking = false, HotWater = true, PrivateΕntrance = true };
            Amenities a14 = new Amenities() { Count = 14, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = true, FreeParking = false, HotWater = true, PrivateΕntrance = true };
            Amenities a15 = new Amenities() { Count = 15, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = true, FreeParking = false, HotWater = true, PrivateΕntrance = true };
            Amenities a16 = new Amenities() { Count = 16, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = true, FreeParking = false, HotWater = true, PrivateΕntrance = true };
            Amenities a17 = new Amenities() { Count = 17, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = true, FreeParking = false, HotWater = true, PrivateΕntrance = true };
            Amenities a18 = new Amenities() { Count = 18, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = true, FreeParking = false, HotWater = true, PrivateΕntrance = true };
            Amenities a19 = new Amenities() { Count = 19, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = true, FreeParking = false, HotWater = true, PrivateΕntrance = true };
            Amenities a20 = new Amenities() { Count = 20, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = true, FreeParking = false, HotWater = true, PrivateΕntrance = true };
            Amenities a21 = new Amenities() { Count = 21, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = true, FreeParking = false, HotWater = true, PrivateΕntrance = true };
            Amenities a22 = new Amenities() { Count = 22, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = true, FreeParking = false, HotWater = true, PrivateΕntrance = true };
            Amenities a23 = new Amenities() { Count = 23, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = true, FreeParking = false, HotWater = true, PrivateΕntrance = true };
            Amenities a24 = new Amenities() { Count = 24, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = true, FreeParking = false, HotWater = true, PrivateΕntrance = true };
            Amenities a25 = new Amenities() { Count = 25, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = true, FreeParking = false, HotWater = true, PrivateΕntrance = true };
            Amenities a26 = new Amenities() { Count = 26, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = true, FreeParking = false, HotWater = true, PrivateΕntrance = true };
            Amenities a27 = new Amenities() { Count = 27, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = true, FreeParking = false, HotWater = true, PrivateΕntrance = true };
            Amenities a28 = new Amenities() { Count = 28, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = true, FreeParking = false, HotWater = true, PrivateΕntrance = true };
            Amenities a29 = new Amenities() { Count = 29, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = true, FreeParking = false, HotWater = true, PrivateΕntrance = true };
            Amenities a30 = new Amenities() { Count = 30, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = true, FreeParking = false, HotWater = true, PrivateΕntrance = true };
            Amenities a31 = new Amenities() { Count = 31, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = true, FreeParking = false, HotWater = true, PrivateΕntrance = true };
            Amenities a32 = new Amenities() { Count = 32, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = true, FreeParking = false, HotWater = true, PrivateΕntrance = true };
            Amenities a33 = new Amenities() { Count = 33, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = true, FreeParking = false, HotWater = true, PrivateΕntrance = true };
            Amenities a34 = new Amenities() { Count = 34, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = true, FreeParking = false, HotWater = true, PrivateΕntrance = true };
            Amenities a35 = new Amenities() { Count = 35, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = true, FreeParking = false, HotWater = true, PrivateΕntrance = true };
            Amenities a36 = new Amenities() { Count = 36, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = true, FreeParking = false, HotWater = true, PrivateΕntrance = true };
            Amenities a37 = new Amenities() { Count = 37, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = true, FreeParking = false, HotWater = true, PrivateΕntrance = true };
            Amenities a38 = new Amenities() { Count = 38, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = true, FreeParking = false, HotWater = true, PrivateΕntrance = true };
            Amenities a39 = new Amenities() { Count = 39, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = true, FreeParking = false, HotWater = true, PrivateΕntrance = true };
            Amenities a40 = new Amenities() { Count = 40, Wifi = true, Heating = true, Tv = true, AirConditioning = true, FirstAidKit = true, Elevator = true, FreeParking = false, HotWater = true, PrivateΕntrance = true };

            //================= Seeding Places =================
            //Place template = new Place() { Title = "", Duration = 0, PhotoUrl = "", Price = 0, ProductionYear = new DateTime(1, 1, 1), Rating = 0D, TrailerUrl = "", Watched = false ,Country=Country.United_States_of_America};
            Place p1 = new Place() { ApartmentName = "Apartment in Psichiko", PricePerDay = 50M, Description = "O,ti kalytero se spiti uparxei, mpravo sta paidia.", Guests = 2, Bedroom = 3, Bathroom = 1, CleanCost = 10M, IsBooked = false, Created = new DateTime(2020, 05, 02), Modified = new DateTime(2020, 05, 05) };
            Place p2 = new Place() { ApartmentName = "Nea Makri Exohiko", PricePerDay = 60M, Description = "Foveri thea, einai monadiko meros gia na meinete.", Guests = 3, Bedroom = 2, Bathroom = 2, CleanCost = 15M, IsBooked = false, Created = new DateTime(2020, 05, 01), Modified = new DateTime(2020, 05, 10) };
            Place p3 = new Place() { ApartmentName = "Villa in Mykonos", PricePerDay = 250M, Description = "Fthines potares, to kalutero meros gia na sprwkseis!", Guests = 6, Bedroom = 5, Bathroom = 3, CleanCost = 40M, IsBooked = false, Created = new DateTime(2020, 04, 28), Modified = new DateTime(2020, 04, 30) };

            Place p4 = new Place() { ApartmentName = "Sunny attic Acropolis amazing view by the roof", PricePerDay = 19M, Guests = 5, Bedroom = 3, Bathroom = 1, CleanCost = 20M, IsBooked = false, Created = new DateTime(2020, 05, 28), Modified = new DateTime(2020, 05, 29), Description = "A cozy unique 30sqm ATTIC with a unique balcony and view of all Athenian center.Decorated with love and passion. Situated in METS the most cultural and peaceful neighborhood in Athens. Acropolis metro station is 400 meters far and plenty of public bus are going around the city just 30 meters far of the apartment. In the same street you can find supermarket,coffee-bar,bakery,pharmacy,jazz-club,tavern" };
            Place p5 = new Place() { ApartmentName = "Gina's cozy apartment", PricePerDay = 28M, Guests = 2, Bedroom = 1, Bathroom = 1, CleanCost = 20M, IsBooked = false, Created = new DateTime(2020, 03, 28), Modified = new DateTime(2020, 05, 29), Description = "Newly renovated, one-bedroom apartment with king-size bed and fully equipped bathroom and kitchen. It provides everything you need for your stay and is quiet though centrally located." };
            Place p6 = new Place() { ApartmentName = "Urban shiny studios2@ 50m Acropolis museum+metro", PricePerDay = 25M, Guests = 2, Bedroom = 1, Bathroom = 1, CleanCost = 20M, IsBooked = false, Created = new DateTime(2020, 03, 28), Modified = new DateTime(2020, 05, 29), Description = "It is a newly renovated 55sqm apartment, 2nd floor in a 2-storey building, with a balcony overlooking a picturesque street of Plaka with a fully equipped kitche", };
            Place p7 = new Place() { ApartmentName = "Athens Heart Design Studio", PricePerDay = 60M, Guests = 2, Bedroom = 1, Bathroom = 1, CleanCost = 20M, IsBooked = false, Created = new DateTime(2020, 04, 14), Modified = new DateTime(2020, 04, 28), Description = "The Design studio has just been renewed and it’s ready to welcome up to 2 guests. The studio is fully equipped with 1 air condition and WI-FI.It's full equipped kitchen,with cooker,kettle,toaster,fridge,freezer,Coffee,tea," };
            Place p8 = new Place() { ApartmentName = "Quiet, Minimalist Base with Balcony near Metro", PricePerDay = 70M, Guests = 2, Bedroom = 1, Bathroom = 1, CleanCost = 20M, IsBooked = false, Created = new DateTime(2020, 02, 14), Modified = new DateTime(2020, 03, 28), Description = "This upscale 50m2, one-bedroom apartment is located in Petralona. Newly renovated, minimal-chic decor with a touch of velvet make it the perfect getaway in central Athens. A fully equipped kitchen, airconditioning and smart-tv meet the demands of the seasoned traveller." };
            Place p9 = new Place() { ApartmentName = "Majestic home Penthouse in the heart of Plaka", PricePerDay = 30M, Guests = 2, Bedroom = 1, Bathroom = 1, CleanCost = 20M, IsBooked = false, Created = new DateTime(2020, 01, 14), Modified = new DateTime(2020, 02, 28), Description = "Penthouse with 360 view of Athens! It is located in Syntagma square and it offers the most amazing view of Athens. A luxury newly renovated top floor apartment with a king bed and a couch, can host up to 3 people . There is a jacuzzi in the room and sitting place on the huge terrace." };
            Place p10 = new Place() { ApartmentName = "Gina's modern and stylish studio", PricePerDay = 40M, Guests = 4, Bedroom = 1, Bathroom = 2, CleanCost = 30M, IsBooked = false, Created = new DateTime(2020, 04, 15), Modified = new DateTime(2020, 05, 25), Description = "Recently renovated apartment, with double bed and fully equipped bathroom and kitchen. It provides everything you need for your stay and is quiet even in a central location." };
            Place p11 = new Place() { ApartmentName = "Luxury Studio 6-min walk from Metro Attiki", PricePerDay = 90M, Guests = 5, Bedroom = 3, Bathroom = 2, CleanCost = 30M, IsBooked = false, Created = new DateTime(2020, 04, 25), Modified = new DateTime(2020, 05, 05), Description = "Happy to offer you my 2019 renovated apartment on 3rd floor in the center of Athens!! Located in a safe and quiet area." };
            Place p12 = new Place() { ApartmentName = "Athens in old historic neighborhood", PricePerDay = 90M, Guests = 5, Bedroom = 3, Bathroom = 2, CleanCost = 30M, IsBooked = false, Created = new DateTime(2020, 04, 25), Modified = new DateTime(2020, 05, 05), Description = "This beautiful apartment, is located in the suburb of Kolonos, a historical neighbourhood near the Archaeological park of Akadimia Platonos where the ancient philosopher used to teach." };
            Place p13 = new Place() { ApartmentName = "Downtown apartment 5' from Archeological Museum", PricePerDay = 38M, Guests = 4, Bedroom = 1, Bathroom = 1, CleanCost = 20M, IsBooked = false, Created = new DateTime(2020, 04, 28), Modified = new DateTime(2020, 05, 05), Description = "The space consists of one main living area that includes a conversation area with a TV and sofa that can open into a double bed and an open, fully equipped kitchen, a bedroom with double doors, a bathroom with a shower, and a balcony." };
            Place p14 = new Place() { ApartmentName = "Relaxing small studio near Acropolis ", PricePerDay = 35M, Guests = 2, Bedroom = 1, Bathroom = 1, CleanCost = 20M, IsBooked = false, Created = new DateTime(2020, 04, 28), Modified = new DateTime(2020, 05, 05), Description = "The studio is at the 1 floor and it's 18 square meters. Inside the room is located the double-bed, as well as the kitchen. The shower is located inside the bathroom. It has a nice balcony that can direct you at the building's garden." };
            Place p15 = new Place() { ApartmentName = "3 mins walking from Acropolis ", PricePerDay = 25M, Guests = 3, Bedroom = 1, Bathroom = 1, CleanCost = 20M, IsBooked = false, Created = new DateTime(2020, 04, 28), Modified = new DateTime(2020, 05, 05), Description = "This fully renovated ( February 2019) and full equipped 50 s.q.m modern, cosy and stylish apartment is the perfect choice for 2-4 people, and it is located in one of the most beautiful streets of Koukaki." };
            Place p16 = new Place() { ApartmentName = "Studio in Athens heart", PricePerDay = 34M, Guests = 4, Bedroom = 1, Bathroom = 1, CleanCost = 20M, IsBooked = false, Created = new DateTime(2020, 04, 28), Modified = new DateTime(2020, 05, 05), Description = "Our apartment is a fully renovated 29m2 studio, just 250 meters from Omonoia square and the subway. It is in a very accessible neighborhood of Athens with direct access to traditional shops, bookstores, cafes and restaurants." };
            Place p17 = new Place() { ApartmentName = "Modern Apartment - Syntvtagma Square", PricePerDay = 23M, Guests = 2, Bedroom = 1, Bathroom = 1, CleanCost = 20M, IsBooked = false, Created = new DateTime(2020, 04, 28), Modified = new DateTime(2020, 05, 05), Description = "A lovely space to unwind and relax after a busy day whether it is work or play. Awake refreshed and ready for a day exploring the city via this clean and sunny apartment. Head out and wander through the numerous cafes and restaurants that are just minutes walking distance in every direction!" };
            Place p18 = new Place() { ApartmentName = "Sunny cozy apt,Acropolis & Filopappoy balcony view", PricePerDay = 35M, Guests = 2, Bedroom = 1, Bathroom = 1, CleanCost = 20M, IsBooked = false, Created = new DateTime(2020, 04, 28), Modified = new DateTime(2020, 05, 05), Description = "Enjoy a fully renovated and cozy apartment in the center of Athens. The house has vintage atmosphere combined with modern elements. It is located in the heart of the city, which allows you to visit all the high spots on foot. Filoppapou hill is two blocks ahead and Acropolis is 10 minutes on foot!" };
            Place p19 = new Place() { ApartmentName = "Boutique Apt in Lively Area. Walk to Acropolis", PricePerDay = 41M, Guests = 4, Bedroom = 1, Bathroom = 1, CleanCost = 20M, IsBooked = false, Created = new DateTime(2020, 04, 28), Modified = new DateTime(2020, 05, 05), Description = "Light one of the complimentary candles and sense the charming bohemian vibe. Fun details abound, from the classic hats on the walls through to the animal motif cushions. Throw open the doors to make the most of the city views." };
            Place p20 = new Place() { ApartmentName = "ATHENStay Loft", PricePerDay = 30M, Guests = 2, Bedroom = 1, Bathroom = 1, CleanCost = 20M, IsBooked = false, Created = new DateTime(2020, 04, 28), Modified = new DateTime(2020, 05, 05), Description = "Ideally located between the vibrant centre and the exclusive northern suburbs of Athens, this Loft offers magnificent views of Athens and the surrounding mountains. WiFi, bedsheets and towels are available." };
            Place p21 = new Place() { ApartmentName = "Deluxe Acropoli View Suite in Monastiraki", PricePerDay = 41M, Guests = 3, Bedroom = 1, Bathroom = 1, CleanCost = 20M, IsBooked = false, Created = new DateTime(2020, 04, 28), Modified = new DateTime(2020, 05, 05), Description = "Enjoy a little more space and luxury in one of our cozy Deluxe Suites. We offer five-star quality comfort paired with a modern design." };
            Place p22 = new Place() { ApartmentName = "Retro chic 1-bdrm in lively Koukaki near Acropolis", PricePerDay = 30M, Guests = 1, Bedroom = 1, Bathroom = 1, CleanCost = 20M, IsBooked = false, Created = new DateTime(2020, 04, 28), Modified = new DateTime(2020, 05, 05), Description = "Centrally located 1-bedroom apartment just 12 minutes walking from the Acropolis. Spacious 63m2 home in walking distance between Acropolis and Filopapou Hill in the quiet part of the amazing Koukaki area." };
            Place p23 = new Place() { ApartmentName = "Ermou Acropolis View Spacious Suite by Living-Space", PricePerDay = 51M, Guests = 4, Bedroom = 1, Bathroom = 1, CleanCost = 20M, IsBooked = false, Created = new DateTime(2020, 04, 28), Modified = new DateTime(2020, 05, 05), Description = "This big suite is located between Monastiraki & Syntagma square just above the Byzantine Church of Kapnikarea, one of the oldest churches in Athens. Enjoy the famous Greek hospitality and high quality services with the spectacular view." };
            Place p24 = new Place() { ApartmentName = "Sunny studio Acropolis & Lykavitos beautiful view", PricePerDay = 29M, Guests = 2, Bedroom = 1, Bathroom = 1, CleanCost = 20M, IsBooked = false, Created = new DateTime(2020, 04, 28), Modified = new DateTime(2020, 05, 05), Description = "Enjoy this beautiful sunny studio,decorated with passion and love from Kseniia and Thomas (your hosts). Situated in METS the most cultural and peaceful neighborhood in Athens." };
            Place p25 = new Place() { ApartmentName = "urban luxury studios for5 -Amazing Acropolis View", PricePerDay = 35M, Guests = 5, Bedroom = 2, Bathroom = 1, CleanCost = 20M, IsBooked = false, Created = new DateTime(2020, 04, 28), Modified = new DateTime(2020, 05, 05), Description = "5th floor apartment, penthouse, with great views to Acropolis-Kalimarmaro-Lycabettus, fully renovated, in one of the most beautiful and safest areas of the historic center of Athens." };
            Place p26 = new Place() { ApartmentName = "Spectacular Pool Apartment in the Heart of Athens", PricePerDay = 110M, Guests = 3, Bedroom = 2, Bathroom = 1, CleanCost = 20M, IsBooked = false, Created = new DateTime(2020, 04, 28), Modified = new DateTime(2020, 05, 05), Description = "Our modern design apartment is on a roof terrace, full of light, and perfectly located to explore the unique history and bustling life of Athens. It is 3 minutes walk to Syntagma Square (and the metro), 7 minutes to the old town of Plaka, and 10 minutes to the Acropolis." };
            Place p27 = new Place() { ApartmentName = "Charming 102m² home flat next to the Acropolis 2bd", PricePerDay = 59M, Guests = 6, Bedroom = 2, Bathroom = 1, CleanCost = 20M, IsBooked = false, Created = new DateTime(2020, 04, 28), Modified = new DateTime(2020, 05, 05), Description = "A beautiful apartment located in Koukaki,a central area in the shadow of the Acropolis. Easy access to the metro system,the Acropolis,the Acropolis museum and all other touristic sites." };
            Place p28 = new Place() { ApartmentName = "Walk to Syntagma Square from a Characterful Apartment", PricePerDay = 49M, Guests = 4, Bedroom = 1, Bathroom = 1, CleanCost = 20M, IsBooked = false, Created = new DateTime(2020, 04, 28), Modified = new DateTime(2020, 05, 05), Description = "Step onto the sunlit wooden decking and kick back on the stylish rattan furniture, surrounded by green plants. This apartment has a cool, neutral palette with pops of vibrant color and eye-catching artwork." };
            Place p29 = new Place() { ApartmentName = "Acropolis Dream Apartment", PricePerDay = 47M, Guests = 5, Bedroom = 2, Bathroom = 1, CleanCost = 20M, IsBooked = false, Created = new DateTime(2020, 04, 28), Modified = new DateTime(2020, 05, 05), Description = "The apartment is spacious,renovated in 2017- everything is completely new. There is a steamshower (hamam) and a sauna in the bathroom for you to relax free of charge. It is sound proof so you will not hear the distractions from the busy Athens." };
            Place p30 = new Place() { ApartmentName = "Sunny apartment with a view to Acropolis", PricePerDay = 47M, Guests = 4, Bedroom = 2, Bathroom = 1, CleanCost = 20M, IsBooked = false, Created = new DateTime(2020, 04, 28), Modified = new DateTime(2020, 05, 05), Description = "Unique grand balcony with a fantastic view of Acropolis and the Parthenon, Filopappou hill on your left and Lykavetos hill on your right, the apartment is in the heart of the city, right up of Neos kosmos metro station" };
            Place p31 = new Place() { ApartmentName = "Romantic Island-style hideaway in lively Koukaki", PricePerDay = 39M, Guests = 4, Bedroom = 2, Bathroom = 1, CleanCost = 20M, IsBooked = false, Created = new DateTime(2020, 04, 28), Modified = new DateTime(2020, 05, 05), Description = "Balcony views & fresh air abound in this spacious 55m2 island style 1-bedroom just 1 block from the Acropolis Museum & 8 min walk to Acropolis! Enjoy urban amenities & freshness in the homey living area & street facing patio." };
            Place p32 = new Place() { ApartmentName = "City Lux2Modern Apartment next to Kerameikos Metro", PricePerDay = 22M, Guests = 3, Bedroom = 2, Bathroom = 1, CleanCost = 20M, IsBooked = false, Created = new DateTime(2020, 04, 28), Modified = new DateTime(2020, 05, 05), Description = "A modern and comfortable studio of 40m2. We designed an independent studio under our loft 4 minutes walk from the Kerameikos Metro Station." };
            Place p33 = new Place() { ApartmentName = "X & P apartment koukaki a perfect place to stay", PricePerDay = 25M, Guests = 2, Bedroom = 1, Bathroom = 1, CleanCost = 20M, IsBooked = false, Created = new DateTime(2020, 04, 28), Modified = new DateTime(2020, 05, 05), Description = "It is a warm, friendly and cozy nine-room villa with electric kitchenette, washing machine, iron, ironing board, hair dryer, ionizer, dehumidification system, TV, refrigerator, wifi, air conditioning, air conditioning system It also has a double bed with bed linen as well as body and face towels." };
            Place p34 = new Place() { ApartmentName = "D16 Central Athens cosy apartment by Acropolis", PricePerDay = 40M, Guests = 4, Bedroom = 1, Bathroom = 1, CleanCost = 20M, IsBooked = false, Created = new DateTime(2020, 04, 28), Modified = new DateTime(2020, 05, 05), Description = "Our cosy & loved apartment is in a quiet and historic neighborhood in Athens (Ano Petralona). Come and enjoy our original lifestyle." };
            Place p35 = new Place() { ApartmentName = "Luminous apartment near Acropolis", PricePerDay = 30M, Guests = 4, Bedroom = 1, Bathroom = 1, CleanCost = 20M, IsBooked = false, Created = new DateTime(2020, 04, 28), Modified = new DateTime(2020, 05, 05), Description = "This is a newly renovated apartment located in Koukaki, a nice region full of choices, in a walking distance from the Acropolis, Plaka and the city center." };
            Place p36 = new Place() { ApartmentName = "Casavathel2 Athens Center Apartment", PricePerDay = 32M, Guests = 6, Bedroom = 2, Bathroom = 1, CleanCost = 20M, IsBooked = false, Created = new DateTime(2020, 04, 28), Modified = new DateTime(2020, 05, 05), Description = "Apartment new and modern style ,bright and clean in a classic neighborhood of Athens with free parking place." };
            Place p37 = new Place() { ApartmentName = "Island in the sky! Acropolis and city views!", PricePerDay = 44M, Guests = 2, Bedroom = 1, Bathroom = 1, CleanCost = 20M, IsBooked = false, Created = new DateTime(2020, 04, 28), Modified = new DateTime(2020, 05, 05), Description = "Sunny studio, island in the Athenian skies! Amazing Acropolis and city views from this 19m2 rooftop studio. Located near metro stop and the American embassy. Just a few stops from Syntagma square." };
            Place p38 = new Place() { ApartmentName = "Stylish 2bd Apartment above Attiki Metro Station", PricePerDay = 35M, Guests = 4, Bedroom = 2, Bathroom = 1, CleanCost = 20M, IsBooked = false, Created = new DateTime(2020, 04, 28), Modified = new DateTime(2020, 05, 05), Description = "The apartment is 50sqm, on 1st floor and has been totally renovated in April 2019!!! The location is ideal due to the distance of the metro station Attiki which is only 30 meters away" };
            Place p39 = new Place() { ApartmentName = "Awarded Loft in the Center of Athens", PricePerDay = 58M, Guests = 4, Bedroom = 1, Bathroom = 1, CleanCost = 20M, IsBooked = false, Created = new DateTime(2020, 04, 28), Modified = new DateTime(2020, 05, 05), Description = "this home's exquisite industrial aesthetic was designed by the building's architect. Exposed brick, woods, and metal are highlighted by the huge glass doors which lead out onto a stunning private balcony." };
            Place p40 = new Place() { ApartmentName = "A Lovely Bright Home with Balcony Comfort & style", PricePerDay = 25M, Guests = 2, Bedroom = 1, Bathroom = 1, CleanCost = 20M, IsBooked = false, Created = new DateTime(2020, 04, 28), Modified = new DateTime(2020, 05, 05), Description = "The apartment is located in the City Center of Athens , on a quiet street ( just a few step away from Sepolia train / metro station ." };

            //================= Seeding Reservations =================
            ////Reservation template = new Reservation() { Title = "", Duration = 0, PhotoUrl = "", Price = 0, ProductionYear = new DateTime(1, 1, 1), Rating = 0D, TrailerUrl = "", Watched = false ,Country=Country.United_States_of_America};
            //Reservation r1 = new Reservation() { CheckInDate = new DateTime(2020, 6, 1), CheckOutDate = new DateTime(2020, 6, 5), DaysOfStaying = 4, TotalAmount = (4 * 50 + 10), PaymentDate = new DateTime(2020, 5, 4), TotalFees = (4 * 50 + 10) / 10 };
            //Reservation r1b = new Reservation() { CheckInDate = new DateTime(2020, 7, 5), CheckOutDate = new DateTime(2020, 7, 15), DaysOfStaying = 10, TotalAmount = (10 * 50 + 10), PaymentDate = new DateTime(2020, 3, 4), TotalFees = (10 * 50 + 10) / 10 };
            //Reservation r1c = new Reservation() { CheckInDate = new DateTime(2020, 8, 1), CheckOutDate = new DateTime(2020, 8, 6), DaysOfStaying = 5, TotalAmount = (5 * 50 + 10), PaymentDate = new DateTime(2020, 4, 4), TotalFees = (5 * 50 + 10) / 10 };
            //Reservation r2 = new Reservation() { CheckInDate = new DateTime(2020, 7, 11), CheckOutDate = new DateTime(2020, 7, 22), DaysOfStaying = 11, TotalAmount = (11 * 60 + 15), PaymentDate = new DateTime(2020, 5, 12), TotalFees = (11 * 60 + 15) / 10 };
            //Reservation r2b = new Reservation() { CheckInDate = new DateTime(2020, 8, 3), CheckOutDate = new DateTime(2020, 8, 20), DaysOfStaying = 17, TotalAmount = (7 * 60 + 15), PaymentDate = new DateTime(2020, 5, 17), TotalFees = (7 * 60 + 15) / 10 };
            //Reservation r2c = new Reservation() { CheckInDate = new DateTime(2020, 8, 11), CheckOutDate = new DateTime(2020, 8, 25), DaysOfStaying = 14, TotalAmount = (14 * 60 + 15), PaymentDate = new DateTime(2020, 5, 3), TotalFees = (14 * 60 + 15) / 10 };
            //Reservation r3 = new Reservation() { CheckInDate = new DateTime(2020, 8, 21), CheckOutDate = new DateTime(2020, 8, 30), DaysOfStaying = 9, TotalAmount = (9 * 250 + 40), PaymentDate = new DateTime(2020, 5, 25), TotalFees = (9 * 250 + 40) / 10 };
            //Reservation r3b = new Reservation() { CheckInDate = new DateTime(2020, 6, 7), CheckOutDate = new DateTime(2020, 6, 10), DaysOfStaying = 3, TotalAmount = (3 * 250 + 40), PaymentDate = new DateTime(2020, 5, 12), TotalFees = (3 * 250 + 40) / 10 };
            //Reservation r3c = new Reservation() { CheckInDate = new DateTime(2020, 7, 17), CheckOutDate = new DateTime(2020, 7, 30), DaysOfStaying = 13, TotalAmount = (13 * 250 + 40), PaymentDate = new DateTime(2020, 5, 14), TotalFees = (13 * 250 + 40) / 10 };
            //Reservation r5 = new Reservation() { CheckInDate = new DateTime(2020, 6, 19), CheckOutDate = new DateTime(2020, 6, 25), DaysOfStaying = 6, TotalAmount = (6 * 50 + 20), PaymentDate = new DateTime(2020, 5, 10), TotalFees = (6 * 50 + 20) / 10 };
            //Reservation r5b = new Reservation() { CheckInDate = new DateTime(2020, 6, 5), CheckOutDate = new DateTime(2020, 6, 6), DaysOfStaying = 1, TotalAmount = (3 * 50 + 20), PaymentDate = new DateTime(2020, 5, 5), TotalFees = (3 * 50 + 20) / 10 };
            //Reservation r5c = new Reservation() { CheckInDate = new DateTime(2020, 8, 28), CheckOutDate = new DateTime(2020, 8, 30), DaysOfStaying = 2, TotalAmount = (7 * 50 + 20), PaymentDate = new DateTime(2020, 7, 10), TotalFees = (7 * 50 + 20) / 10 };
            //Reservation r6 = new Reservation() { CheckInDate = new DateTime(2020, 7, 13), CheckOutDate = new DateTime(2020, 7, 21), DaysOfStaying = 8, TotalAmount = (8 * 80 + 20), PaymentDate = new DateTime(2020, 6, 9), TotalFees = (8 * 80 + 20) / 10 };
            //Reservation r6b = new Reservation() { CheckInDate = new DateTime(2020, 8, 2), CheckOutDate = new DateTime(2020, 8, 17), DaysOfStaying = 15, TotalAmount = (14 * 80 + 20), PaymentDate = new DateTime(2020, 5, 14), TotalFees = (14 * 80 + 20) / 10 };
            //Reservation r6c = new Reservation() { CheckInDate = new DateTime(2020, 8, 17), CheckOutDate = new DateTime(2020, 8, 24), DaysOfStaying = 7, TotalAmount = (4 * 80 + 20), PaymentDate = new DateTime(2020, 4, 12), TotalFees = (4 * 80 + 20) / 10 };
            //Reservation r7 = new Reservation() { CheckInDate = new DateTime(2020, 6, 3), CheckOutDate = new DateTime(2020, 6, 15), DaysOfStaying = 12, TotalAmount = (6 * 60 + 20), PaymentDate = new DateTime(2020, 4, 24), TotalFees = (6 * 60 + 20) / 10 };
            //Reservation r8 = new Reservation() { CheckInDate = new DateTime(2020, 7, 9), CheckOutDate = new DateTime(2020, 7, 25), DaysOfStaying = 16, TotalAmount = (8 * 70 + 20), PaymentDate = new DateTime(2020, 5, 27), TotalFees = (8 * 70 + 20) / 10 };

            Reservation r1 = new Reservation() { CheckInDate = new DateTime(2020, 6, 1), CheckOutDate = new DateTime(2020, 6, 5), DaysOfStaying = 4, TotalAmount = (4 * 50 + 10), PaymentDate = new DateTime(2020, 5, 4), TotalFees = (4 * 50 + 10) / 10 };
            Reservation r1b = new Reservation() { CheckInDate = new DateTime(2020, 7, 5), CheckOutDate = new DateTime(2020, 7, 15), DaysOfStaying = 10, TotalAmount = (10 * 50 + 10), PaymentDate = new DateTime(2020, 3, 4), TotalFees = (10 * 50 + 10) / 10 };
            Reservation r1c = new Reservation() { CheckInDate = new DateTime(2020, 8, 1), CheckOutDate = new DateTime(2020, 8, 6), DaysOfStaying = 5, TotalAmount = (5 * 50 + 10), PaymentDate = new DateTime(2020, 4, 4), TotalFees = (5 * 50 + 10) / 10 };
            Reservation r2 = new Reservation() { CheckInDate = new DateTime(2020, 7, 11), CheckOutDate = new DateTime(2020, 7, 22), DaysOfStaying = 11, TotalAmount = (11 * 60 + 15), PaymentDate = new DateTime(2020, 5, 12), TotalFees = (11 * 60 + 15) / 10 };
            Reservation r2b = new Reservation() { CheckInDate = new DateTime(2020, 8, 3), CheckOutDate = new DateTime(2020, 8, 20), DaysOfStaying = 17, TotalAmount = (7 * 60 + 15), PaymentDate = new DateTime(2020, 6, 17), TotalFees = (7 * 60 + 15) / 10 };
            Reservation r2c = new Reservation() { CheckInDate = new DateTime(2020, 8, 11), CheckOutDate = new DateTime(2020, 8, 25), DaysOfStaying = 14, TotalAmount = (14 * 60 + 15), PaymentDate = new DateTime(2020, 7, 3), TotalFees = (14 * 60 + 15) / 10 };
            Reservation r3 = new Reservation() { CheckInDate = new DateTime(2020, 8, 21), CheckOutDate = new DateTime(2020, 8, 30), DaysOfStaying = 9, TotalAmount = (9 * 250 + 40), PaymentDate = new DateTime(2020, 8, 25), TotalFees = (9 * 250 + 40) / 10 };
            Reservation r3b = new Reservation() { CheckInDate = new DateTime(2020, 6, 7), CheckOutDate = new DateTime(2020, 6, 10), DaysOfStaying = 3, TotalAmount = (3 * 250 + 40), PaymentDate = new DateTime(2020, 8, 12), TotalFees = (3 * 250 + 40) / 10 };
            Reservation r3c = new Reservation() { CheckInDate = new DateTime(2020, 7, 17), CheckOutDate = new DateTime(2020, 7, 30), DaysOfStaying = 13, TotalAmount = (13 * 250 + 40), PaymentDate = new DateTime(2020, 7, 14), TotalFees = (13 * 250 + 40) / 10 };
            Reservation r5 = new Reservation() { CheckInDate = new DateTime(2020, 6, 19), CheckOutDate = new DateTime(2020, 6, 25), DaysOfStaying = 6, TotalAmount = (6 * 50 + 20), PaymentDate = new DateTime(2020, 6, 10), TotalFees = (6 * 50 + 20) / 10 };
            Reservation r5b = new Reservation() { CheckInDate = new DateTime(2020, 6, 5), CheckOutDate = new DateTime(2020, 6, 6), DaysOfStaying = 1, TotalAmount = (3 * 50 + 20), PaymentDate = new DateTime(2020, 7, 5), TotalFees = (3 * 50 + 20) / 10 };
            Reservation r5c = new Reservation() { CheckInDate = new DateTime(2020, 8, 28), CheckOutDate = new DateTime(2020, 8, 30), DaysOfStaying = 2, TotalAmount = (7 * 50 + 20), PaymentDate = new DateTime(2020, 7, 10), TotalFees = (7 * 50 + 20) / 10 };
            Reservation r6 = new Reservation() { CheckInDate = new DateTime(2020, 7, 13), CheckOutDate = new DateTime(2020, 7, 21), DaysOfStaying = 8, TotalAmount = (8 * 80 + 20), PaymentDate = new DateTime(2020, 6, 9), TotalFees = (8 * 80 + 20) / 10 };
            Reservation r6b = new Reservation() { CheckInDate = new DateTime(2020, 8, 2), CheckOutDate = new DateTime(2020, 8, 17), DaysOfStaying = 15, TotalAmount = (14 * 80 + 20), PaymentDate = new DateTime(2020, 12, 14), TotalFees = (14 * 80 + 20) / 10 };
            Reservation r6c = new Reservation() { CheckInDate = new DateTime(2020, 8, 17), CheckOutDate = new DateTime(2020, 8, 24), DaysOfStaying = 7, TotalAmount = (4 * 80 + 20), PaymentDate = new DateTime(2020, 3, 12), TotalFees = (4 * 80 + 20) / 10 };
            Reservation r7 = new Reservation() { CheckInDate = new DateTime(2020, 6, 3), CheckOutDate = new DateTime(2020, 6, 15), DaysOfStaying = 12, TotalAmount = (6 * 60 + 20), PaymentDate = new DateTime(2020, 11, 24), TotalFees = (6 * 60 + 20) / 10 };
            Reservation r8 = new Reservation() { CheckInDate = new DateTime(2020, 7, 9), CheckOutDate = new DateTime(2020, 7, 25), DaysOfStaying = 16, TotalAmount = (8 * 70 + 20), PaymentDate = new DateTime(2020, 4, 27), TotalFees = (8 * 70 + 20) / 10 };
            Reservation r9 = new Reservation() { CheckInDate = new DateTime(2020, 7, 9), CheckOutDate = new DateTime(2020, 7, 25), DaysOfStaying = 18, TotalAmount = (8 * 70 + 20), PaymentDate = new DateTime(2020, 4, 27), TotalFees = (8 * 70 + 20) / 10 };

            //Reservation r9 = new Reservation() { CheckInDate = new DateTime(2020, 6, 1), CheckOutDate = new DateTime(2020, 6, 5), DaysOfStaying = 4, TotalAmount = (4 * 50 + 10), PaymentDate = new DateTime(2020, 5, 4), TotalFees = (4 * 50 + 10) / 10 };
            //Reservation r9b = new Reservation() { CheckInDate = new DateTime(2020, 7, 5), CheckOutDate = new DateTime(2020, 7, 15), DaysOfStaying = 10, TotalAmount = (10 * 50 + 10), PaymentDate = new DateTime(2020, 3, 4), TotalFees = (10 * 50 + 10) / 10 };
            //Reservation r9c = new Reservation() { CheckInDate = new DateTime(2020, 8, 1), CheckOutDate = new DateTime(2020, 8, 6), DaysOfStaying = 5, TotalAmount = (5 * 50 + 10), PaymentDate = new DateTime(2020, 4, 4), TotalFees = (5 * 50 + 10) / 10 };
            //Reservation r10 = new Reservation() { CheckInDate = new DateTime(2020, 7, 11), CheckOutDate = new DateTime(2020, 7, 22), DaysOfStaying = 11, TotalAmount = (11 * 60 + 15), PaymentDate = new DateTime(2020, 10, 12), TotalFees = (11 * 60 + 15) / 10 };
            //Reservation r10b = new Reservation() { CheckInDate = new DateTime(2020, 8, 3), CheckOutDate = new DateTime(2020, 8, 20), DaysOfStaying = 17, TotalAmount = (7 * 60 + 15), PaymentDate = new DateTime(2020, 6, 17), TotalFees = (7 * 60 + 15) / 10 };
          
            //================= Seeding Reviews =================
            //Review template = new Review() { Accuracy = 5, Checkin = 4, Cleanliness = 5, Location = 4, Value = 5, SubDate = new DateTime(2020, 6, 6),  Comment = "ola teleia" };
            Review rev1 = new Review() { Identifier = 1, Accuracy = 5, Checkin = 4, Cleanliness = 5, Location = 4, Value = 5, SubDate = new DateTime(2020, 6, 6), Comment = "ola teleia" };
            Review rev1b = new Review() { Identifier = 2, Accuracy = 5, Checkin = 5, Cleanliness = 5, Location = 4, Value = 4, SubDate = new DateTime(2020, 7, 17), Comment = "Great hospitality" };
            Review rev1c = new Review() { Identifier = 3, Accuracy = 4, Checkin = 4, Cleanliness = 5, Location = 3, Value = 3, SubDate = new DateTime(2020, 8, 9), Comment = "Could be better" };
            Review rev2 = new Review() { Identifier = 4, Accuracy = 2, Checkin = 5, Cleanliness = 4, Location = 4, Value = 5, SubDate = new DateTime(2020, 7, 23), Comment = "Bad communication" };
            Review rev2b = new Review() { Identifier = 5, Accuracy = 5, Checkin = 5, Cleanliness = 5, Location = 5, Value = 5, SubDate = new DateTime(2020, 8, 11), Comment = "Perfect Choice" };
            Review rev2c = new Review() { Identifier = 6, Accuracy = 4, Checkin = 5, Cleanliness = 4, Location = 4, Value = 5, SubDate = new DateTime(2020, 8, 28), Comment = "Awesome" };
            Review rev3 = new Review() { Identifier = 7, Accuracy = 4, Checkin = 4, Cleanliness = 5, Location = 5, Value = 5, SubDate = new DateTime(2020, 8, 31), Comment = "Unbelievable experience" };
            Review rev3b = new Review() { Identifier = 8, Accuracy = 3, Checkin = 4, Cleanliness = 3, Location = 2, Value = 5, SubDate = new DateTime(2020, 6, 15), Comment = "Difficult to find" };
            Review rev3c = new Review() { Identifier = 9, Accuracy = 3, Checkin = 4, Cleanliness = 3, Location = 5, Value = 5, SubDate = new DateTime(2020, 8, 2), Comment = "Super" };
            Review rev5 = new Review() { Identifier = 10, Accuracy = 4, Checkin = 4, Cleanliness = 5, Location = 4, Value = 4, SubDate = new DateTime(2020, 6, 27), Comment = "Superb" };
            Review rev5b = new Review() { Identifier = 11, Accuracy = 4, Checkin = 4, Cleanliness = 5, Location = 5, Value = 4, SubDate = new DateTime(2020, 6, 10), Comment = "Η καλυτερη επιλογη για Κρητη" };
            Review rev5c = new Review() { Identifier = 12, Accuracy = 3, Checkin = 4, Cleanliness = 5, Location = 4, Value = 4, SubDate = new DateTime(2020, 9, 7), Comment = "Πεντακάθαρο" };
            Review rev6 = new Review() { Identifier = 13, Accuracy = 3, Checkin = 4, Cleanliness = 5, Location = 5, Value = 1, SubDate = new DateTime(2020, 7, 25), Comment = "Πολυ ακριβό" };
            Review rev6b = new Review() { Identifier = 14, Accuracy = 2, Checkin = 4, Cleanliness = 5, Location = 4, Value = 4, SubDate = new DateTime(2020, 8, 20), Comment = "Μικρο μπανιο" };
            Review rev6c = new Review() { Identifier = 15, Accuracy = 3, Checkin = 4, Cleanliness = 5, Location = 4, Value = 4, SubDate = new DateTime(2020, 8, 31), Comment = "Πολυ καλη φιλοξενια" };
            Review rev7 = new Review() { Identifier = 16, Accuracy = 4, Checkin = 5, Cleanliness = 5, Location = 5, Value = 5, SubDate = new DateTime(2020, 6, 30), Comment = "Perfect" };
            Review rev8 = new Review() { Identifier = 17, Accuracy = 4, Checkin = 5, Cleanliness = 5, Location = 5, Value = 5, SubDate = new DateTime(2020, 7, 28), Comment = "Excellent" };

            Review rev9 = new Review() { Identifier = 18, Accuracy = 5, Checkin = 4, Cleanliness = 5, Location = 4, Value = 5, SubDate = new DateTime(2020, 4, 10), Comment = "ola teleia" };
            Review rev90 = new Review() { Identifier = 19, Accuracy = 5, Checkin = 5, Cleanliness = 5, Location = 4, Value = 4, SubDate = new DateTime(2020, 3, 17), Comment = "Great hospitality" };
            Review rev91 = new Review() { Identifier = 20, Accuracy = 4, Checkin = 4, Cleanliness = 5, Location = 3, Value = 3, SubDate = new DateTime(2020, 3, 9), Comment = "Could be better" };
            Review rev10 = new Review() { Identifier = 21, Accuracy = 2, Checkin = 5, Cleanliness = 4, Location = 4, Value = 5, SubDate = new DateTime(2020, 10, 23), Comment = "Bad communication" };
            Review rev100 = new Review() { Identifier = 22, Accuracy = 5, Checkin = 5, Cleanliness = 5, Location = 5, Value = 5, SubDate = new DateTime(2020, 7, 11), Comment = "Perfect Choice" };
            Review rev101 = new Review() { Identifier = 23, Accuracy = 4, Checkin = 5, Cleanliness = 4, Location = 4, Value = 5, SubDate = new DateTime(2020, 12, 28), Comment = "Awesome" };
            Review rev11 = new Review() { Identifier = 24, Accuracy = 4, Checkin = 4, Cleanliness = 5, Location = 5, Value = 5, SubDate = new DateTime(2020, 12, 31), Comment = "Unbelievable experience" };
            Review rev110 = new Review() { Identifier = 25, Accuracy = 3, Checkin = 4, Cleanliness = 3, Location = 2, Value = 5, SubDate = new DateTime(2020, 5, 15), Comment = "Difficult to find" };
            Review rev111 = new Review() { Identifier = 26, Accuracy = 3, Checkin = 4, Cleanliness = 3, Location = 5, Value = 5, SubDate = new DateTime(2020, 9, 2), Comment = "Super" };
            Review rev12 = new Review() { Identifier = 27, Accuracy = 4, Checkin = 4, Cleanliness = 5, Location = 4, Value = 4, SubDate = new DateTime(2020, 4, 27), Comment = "Superb" };
            Review rev120 = new Review() { Identifier = 28, Accuracy = 4, Checkin = 4, Cleanliness = 5, Location = 5, Value = 4, SubDate = new DateTime(2020, 4, 10), Comment = "Η καλυτερη επιλογη για Κρητη" };
            Review rev121 = new Review() { Identifier = 29, Accuracy = 3, Checkin = 4, Cleanliness = 5, Location = 4, Value = 4, SubDate = new DateTime(2020, 6, 7), Comment = "Πεντακάθαρο" };
            Review rev13 = new Review() { Identifier = 30, Accuracy = 3, Checkin = 4, Cleanliness = 5, Location = 5, Value = 1, SubDate = new DateTime(2020, 5, 25), Comment = "Πολυ ακριβό" };
            Review rev130 = new Review() { Identifier = 31, Accuracy = 2, Checkin = 4, Cleanliness = 5, Location = 4, Value = 4, SubDate = new DateTime(2020, 3, 20), Comment = "Μικρο μπανιο" };
            Review rev131 = new Review() { Identifier = 32, Accuracy = 3, Checkin = 4, Cleanliness = 5, Location = 4, Value = 4, SubDate = new DateTime(2020, 11, 22), Comment = "Πολυ καλη φιλοξενια" };
            Review rev14 = new Review() { Identifier = 33, Accuracy = 4, Checkin = 5, Cleanliness = 5, Location = 5, Value = 5, SubDate = new DateTime(2020, 12, 30), Comment = "Perfect" };
            Review rev15 = new Review() { Identifier = 34, Accuracy = 4, Checkin = 5, Cleanliness = 5, Location = 5, Value = 5, SubDate = new DateTime(2020, 7, 28), Comment = "Excellent" };

            Review rev16 = new Review() { Identifier = 35, Accuracy = 5, Checkin = 4, Cleanliness = 5, Location = 4, Value = 5, SubDate = new DateTime(2020, 6, 6), Comment = "ola teleia" };
            Review rev160 = new Review() { Identifier = 36, Accuracy = 5, Checkin = 5, Cleanliness = 5, Location = 4, Value = 4, SubDate = new DateTime(2020, 7, 17), Comment = "Great hospitality" };
            Review rev161 = new Review() { Identifier = 37, Accuracy = 4, Checkin = 4, Cleanliness = 5, Location = 3, Value = 3, SubDate = new DateTime(2020, 8, 9), Comment = "Could be better" };
            Review rev17 = new Review() { Identifier = 38, Accuracy = 2, Checkin = 5, Cleanliness = 4, Location = 4, Value = 5, SubDate = new DateTime(2020, 7, 23), Comment = "Bad communication" };
            Review rev170 = new Review() { Identifier = 39, Accuracy = 5, Checkin = 5, Cleanliness = 5, Location = 5, Value = 5, SubDate = new DateTime(2020, 4, 11), Comment = "Perfect Choice" };
            Review rev171 = new Review() { Identifier = 40, Accuracy = 4, Checkin = 5, Cleanliness = 4, Location = 4, Value = 5, SubDate = new DateTime(2020, 5, 28), Comment = "Awesome" };
            Review rev18 = new Review() { Identifier = 41, Accuracy = 4, Checkin = 4, Cleanliness = 5, Location = 5, Value = 5, SubDate = new DateTime(2020, 7, 31), Comment = "Unbelievable experience" };
            Review rev180 = new Review() { Identifier = 42, Accuracy = 3, Checkin = 4, Cleanliness = 3, Location = 2, Value = 5, SubDate = new DateTime(2020, 7, 15), Comment = "Difficult to find" };
            Review rev181 = new Review() { Identifier = 43, Accuracy = 3, Checkin = 4, Cleanliness = 3, Location = 5, Value = 5, SubDate = new DateTime(2020, 9, 2), Comment = "Super" };
            Review rev19 = new Review() { Identifier = 44, Accuracy = 4, Checkin = 4, Cleanliness = 5, Location = 4, Value = 4, SubDate = new DateTime(2020, 8, 27), Comment = "Superb" };
            Review rev190 = new Review() { Identifier = 45, Accuracy = 4, Checkin = 4, Cleanliness = 5, Location = 5, Value = 4, SubDate = new DateTime(2020, 9, 10), Comment = "Η καλυτερη επιλογη για Κρητη" };
            Review rev191 = new Review() { Identifier = 46, Accuracy = 3, Checkin = 4, Cleanliness = 5, Location = 4, Value = 4, SubDate = new DateTime(2020, 5, 7), Comment = "Πεντακάθαρο" };
            Review rev20 = new Review() { Identifier = 47, Accuracy = 3, Checkin = 4, Cleanliness = 5, Location = 5, Value = 1, SubDate = new DateTime(2020, 11, 25), Comment = "Πολυ ακριβό" };
            Review rev21 = new Review() { Identifier = 48, Accuracy = 2, Checkin = 4, Cleanliness = 5, Location = 4, Value = 4, SubDate = new DateTime(2020, 12, 20), Comment = "Μικρο μπανιο" };
            Review rev22 = new Review() { Identifier = 49, Accuracy = 3, Checkin = 4, Cleanliness = 5, Location = 4, Value = 4, SubDate = new DateTime(2020, 11, 20), Comment = "Πολυ καλη φιλοξενια" };
            Review rev23 = new Review() { Identifier = 50, Accuracy = 4, Checkin = 5, Cleanliness = 5, Location = 5, Value = 5, SubDate = new DateTime(2020, 12, 5), Comment = "Perfect" };
            Review rev24 = new Review() { Identifier = 51, Accuracy = 4, Checkin = 5, Cleanliness = 5, Location = 5, Value = 5, SubDate = new DateTime(2020, 5, 28), Comment = "Excellent" };
            //================= Seeding Application User =================
            //ApplicationUser template = new ApplicationUser() { UserName = "", LastName = "", FirstName = "", City = "", DateOfBirth = new DateTime(1989, 08, 01) };
            ApplicationUser ap1 = new ApplicationUser() { UserName = "xenos", LastName = "Vlaxos", FirstName = "Xenos", City = "Athens", DateOfBirth = new DateTime(1989, 08, 01) };
            ApplicationUser ap2 = new ApplicationUser() { UserName = "thanos", LastName = "Kontos", FirstName = "Thanos", City = "Thessaloniki", DateOfBirth = new DateTime(1990, 05, 12) };
            ApplicationUser ap3 = new ApplicationUser() { UserName = "alex", LastName = "Perikle", FirstName = "Alex", City = "Crete", DateOfBirth = new DateTime(1994, 04, 22) };
            //ApplicationUser ap4 = new ApplicationUser() { UserName = "zach", LastName = "dr", FirstName = "Zach", City = "Heraklion", DateOfBirth = new DateTime(1993, 12, 11) };


            //================= Seeding Address =================
            //Address template = new Address() { AddressLine = "", City = "", Counties = CountiesOfGreece.Attica, Countries = Countries.Greece };
            Address ad1 = new Address() { AddressName = "Ανδρέα Κάλβου", No = "8", ZipCode = "17455", Latitude = "37.9160632", Longitude = "23.7258564", City = "Αθήνα", Area = "Άλιμος" };
            Address ad2 = new Address() { AddressName = "Αδάμων", No = "21", ZipCode = "14564", Latitude = "38.0918513", Longitude = "23.8019882", City = "Αθήνα", Area = "Κηφισιά" };
            Address ad3 = new Address() { AddressName = "Δράμας", No = "5", ZipCode = "18648", Latitude = "37.946975", Longitude = "23.623853", City = "Αθήνα", Area = "Μαρούσι" };
            Address ad4 = new Address() { AddressName = "Αριστοφάνους", No = "21", ZipCode = "16674", Latitude = "37.8742167", Longitude = "23.759905,17", City = "Αθήνα", Area = "Γλυφάδα" };
            Address ad5 = new Address() { AddressName = "Γυθείου", No = "12", ZipCode = "16342", Latitude = "37.9234159", Longitude = "23.7631328", City = "Αθήνα", Area = "Ηλιούπολη" };
            Address ad6 = new Address() { AddressName = "Υμηττού", No = "130", ZipCode = "11634", Latitude = "37.9659734", Longitude = "23.7451387", City = "Αθήνα", Area = "Παγκράτι" };
            Address ad7 = new Address() { AddressName = "Σταδίου", No = "2", ZipCode = "10564", Latitude = "37.976445", Longitude = "23.7323298", City = "Αθήνα", Area = "Κέντρο Αθήνας" };
            Address ad8 = new Address() { AddressName = "Πανεπιστημίου", No = "12", ZipCode = "10564", Latitude = "37.9778266", Longitude = "23.7332016", City = "Αθήνα", Area = "Κέντρο Αθήνας" };
            Address ad9 = new Address() { AddressName = "Τσιμισκή", No = "34", ZipCode = "54623", Latitude = "40.6329694", Longitude = "22.9401955", City = "Θεσσαλονίκη", Area = "Κέντρο Θεσσαλονίκη" };
            Address ad10 = new Address() { AddressName = "Εθ.Αντιστάσεως", No = "173", ZipCode = "18648", Latitude = "37.9474722", Longitude = "23.6240855", City = "Πειραιάς", Area = "Δραπετσώνα" };
            Address ad11 = new Address() { AddressName = "Παπαφλεσσα", No = "25", ZipCode = "58768", Latitude = "38.0523321", Longitude = "23.8091868", City = "Πειραιάς", Area = "Δραπετσώνα" };
            Address ad12 = new Address() { AddressName = "Αριστοτέλους", No = "16", ZipCode = "17455", Latitude = "37.9126442", Longitude = "23.7099781", City = "Αθήνα", Area = "Άλιμος" };


            #region SEEDPHOTOS
            //================= Seeding Photo =================
            //Photo template = new Photo() { PhotoUrl = "#" };
            Photo ph1 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/71f24b8f-dc7f-431d-bd59-15378e23cc6e.jpg?aki_policy=x_large" };
            Photo ph2 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/ff671d4d-68c9-41e4-ab20-05674da69d71.jpg?aki_policy=x_large" };
            Photo ph3 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/64c72abb-a1de-44bf-aa05-46a6c64122e3.jpg?aki_policy=x_large" };
            Photo ph4 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/57aaaa8f-2637-4497-9b64-465533d5aa1a.jpg?aki_policy=x_large" };
            Photo ph5 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/c34b09b7-9905-492a-9652-191af82c4c38.jpg?aki_policy=x_large" };

            Photo ph6 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/642ae27f-678d-4fac-9300-9d1682f26dfd.jpg?aki_policy=x_large" };
            Photo ph7 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/33567ddd-d43a-422b-b997-b094fcb207df.jpg?aki_policy=x_large" };
            Photo ph8 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/67904654-e5a0-4291-bd2f-b1d019818508.jpg?aki_policy=x_large" };
            Photo ph9 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/bffd6e3e-ade8-4347-ada3-2631452e4283.jpg?aki_policy=x_large" };

            Photo ph10 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/9070fe04-63a0-4bb7-8746-0ffaa949c4ba.jpg?aki_policy=x_large" };
            Photo ph11 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/1a184508-3ab5-4e00-8477-119f4e2a749d.jpg?aki_policy=x_large" };
            Photo ph12 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/6a2a66ae-3ef5-4564-bde9-10b668af1d9b.jpg?aki_policy=x_large" };
            Photo ph13 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/ad224b9a-e67f-4115-9122-407006dbc4c7.jpg?aki_policy=x_large" };
            Photo ph14 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/7f131031-a050-4118-82a8-54fc4ad8133b.jpg?aki_policy=x_large" };
            Photo ph15 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/0aea30d2-abf4-40eb-b956-92dd3258e815.jpg?aki_policy=x_large" };

            Photo ph16 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/eac49f11-521a-4dd3-ac02-08e6e9205ff9.jpg?aki_policy=x_large" };
            Photo ph17 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/485584bf-927b-4262-a3c7-0e479db6c425.jpg?aki_policy=x_large" };
            Photo ph18 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/039f2013-184e-4b3f-9597-1c0080f3b8a6.jpg?aki_policy=x_large" };
            Photo ph19 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/7cbafd26-0a93-4c03-8a6f-108af33ea216.jpg?aki_policy=x_large" };
            Photo ph20 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/0f8e307a-7722-4ce1-9b79-bc139e0b6395.jpg?aki_policy=x_large" };

            Photo ph21 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/5abc9da6-16e6-40b6-a23a-527d0c1b3095.jpg?aki_policy=x_large" };
            Photo ph22 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/35ffdb12-adae-4239-a0df-4ca2030cd2d9.jpg?aki_policy=x_large" };
            Photo ph23 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/1d11ff25-9b7c-44a0-ab23-e6ca1587c9c8.jpg?aki_policy=x_large" };
            Photo ph24 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/4b5b8a32-1673-42a7-a9d5-a2ed1e7b02de.jpg?aki_policy=x_large" };
            Photo ph25 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/08d2a746-1aa1-422a-a080-8a4edd2511a0.jpg?aki_policy=x_large" };

            Photo ph26 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/0799a4d4-e2fa-4767-ac69-5af712ffc437.jpg?aki_policy=xx_large" };
            Photo ph27 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/5c3e5333-e8e1-4413-806a-afdad3b882c0.jpg?aki_policy=xx_large" };
            Photo ph28 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/bc87511d-cc67-40cf-aecd-ea248c8f3637.jpg?aki_policy=xx_large" };
            Photo ph29 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/21cb0887-b59e-4656-ba4d-31ef135665b2.jpg?aki_policy=xx_large" };
            Photo ph30 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/31862637-00a7-47eb-a0d3-d8644a8cccf0.jpg?aki_policy=xx_large" };

            Photo ph31 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/0b4c78d2-37f9-422a-95c6-1aa24823846a.jpg?aki_policy=x_large" };
            Photo ph32 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/cc9427b3-5030-4b09-85ad-d6d2e272fab3.jpg?aki_policy=x_large" };
            Photo ph33 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/0e43b9f6-683a-414a-a104-797b7bb365ef.jpg?aki_policy=x_large" };
            Photo ph34 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/2fba8737-bbed-45f1-9402-737e280ee6b0.jpg?aki_policy=x_large" };
            Photo ph35 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/1d53a216-e8d5-44de-b3b6-1806cb6db063.jpg?aki_policy=x_large" };

            Photo ph36 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/f1131d5b-089f-4383-898d-2f800493541a.jpg?aki_policy=x_large" };
            Photo ph37 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/3842b47e-c3ea-4c1f-9c63-fd018e608dea.jpg?aki_policy=x_large" };
            Photo ph38 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/5621b4f9-8c09-44bc-b3f9-c0995f82574f.jpg?aki_policy=x_large" };
            Photo ph39 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/6f6d01c1-033d-4875-98d4-5df11569c33f.jpg?aki_policy=x_large" };
            Photo ph40 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/e66146d8-cce7-4760-ae8e-e51d24d674ea.jpg?aki_policy=x_large" };

            Photo ph41 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/4fee6974-5ddc-4e7d-9d3e-167030b00edd.jpg?aki_policy=x_large" };
            Photo ph42 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/d409b637-457b-4715-b030-1d74aabe2dde.jpg?aki_policy=x_large" };
            Photo ph43 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/72cbdf2c-19b6-4352-bf79-949b8d70aa85.jpg?aki_policy=x_large" };
            Photo ph44 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/b4d6c6e2-1170-41fe-8cd1-6d8f03346381.jpg?aki_policy=x_large" };
            Photo ph45 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/601fdd99-2e29-467e-8f7a-21306e5b99d4.jpg?aki_policy=x_large" };

            Photo ph46 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/6b4ff92d-32c6-4054-b8ac-85a454a27214.jpg?aki_policy=xx_large" };
            Photo ph47 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/5a90e7ce-02d4-4040-ae3e-b8e36bdf9432.jpg?aki_policy=xx_large" };
            Photo ph48 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/4a8315ea-b8d2-48d6-b946-18d226e7c6fc.jpg?aki_policy=xx_large" };
            Photo ph49 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/e2cf0e2c-b257-41b8-aa15-660cedbcca20.jpg?aki_policy=xx_large" };
            Photo ph50 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/26e64445-13e5-4860-9c7b-676da7e446c9.jpg?aki_policy=xx_large" };

            Photo ph51 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/578f8225-8d06-4ec8-91af-46dbae6b87ec.jpg?aki_policy=x_large" };
            Photo ph52 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/f9cf5fea-cb6f-4fac-ab20-5d97c0f821d9.jpg?aki_policy=x_large" };
            Photo ph53 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/4fe00ad5-e393-4853-842f-ef23c764b634.jpg?aki_policy=x_large" };
            Photo ph54 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/4732560d-5bf6-44ad-8b72-827d8f1b99fe.jpg?aki_policy=x_large" };
            Photo ph55 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/43cc10d0-4f73-416d-8555-adcd23c1b505.jpg?aki_policy=x_large" };

            Photo ph56 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/ba5d4336-ff6a-4974-948e-8b165e8157b4.jpg?aki_policy=x_large" };
            Photo ph57 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/359ecb38-3ae9-452a-a6f6-e02170aec9fb.jpg?aki_policy=x_large" };
            Photo ph58 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/72e9f16e-a4d6-424a-a3b4-61eab56908ac.jpg?aki_policy=x_large" };
            Photo ph59 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/92fd1669-ca11-40ff-b8eb-a4e1a1a95810.jpg?aki_policy=x_large" };
            Photo ph60 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/381846ec-bb08-47d3-a228-1e9fa9c1f8e4.jpg?aki_policy=x_large" };

            Photo ph61 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/008bc46f-a295-45b5-9d9f-8afc806dfa1c.jpg?aki_policy=x_large" };
            Photo ph62 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/286a757c-cb61-4f2b-a70f-258290f1086e.jpg?aki_policy=x_large" };
            Photo ph63 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/fdacc94e-9c98-4fcc-8b97-97068e15147f.jpg?aki_policy=x_large" };
            Photo ph64 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/f7dbb173-46a2-41dc-b156-a85290f3ae78.jpg?aki_policy=x_large" };
            Photo ph65 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/2d620ba1-fa3f-452d-9e1e-36594a4ee82e.jpg?aki_policy=x_large" };

            Photo ph66 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/f25f09d4-4c66-4cea-932b-e2181edb3a4a.jpg?aki_policy=x_large" };
            Photo ph67 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/c6aeeffb-70bb-4721-badd-d3d68fc51f65.jpg?aki_policy=x_large" };
            Photo ph68 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/f3c6ac53-97f1-48bb-8819-0b95c34a4a0e.jpg?aki_policy=x_large" };
            Photo ph69 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/fc014720-a9c0-4f9a-9b3b-8e2bb81d1dc0.jpg?aki_policy=x_large" };
            Photo ph70 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/95564a6c-0046-4e66-a93c-7d21c7ad5a50.jpg?aki_policy=x_large" };

            Photo ph71 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/2643f930-4ac2-43d4-b9c4-62a2a3ab8a1a.jpg?aki_policy=x_large" };
            Photo ph72 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/2f02d464-53c3-4664-b6a5-b551ed793ed7.jpg?aki_policy=x_large" };
            Photo ph73 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/fc15c4af-27e2-4434-bf73-7d8030f28e8c.jpg?aki_policy=x_large" };
            Photo ph74 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/90519520-e4ef-46de-ac84-2c732f4a38bf.jpg?aki_policy=x_large" };
            Photo ph75 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/353f3912-002b-4c26-b256-4528d003d3ec.jpg?aki_policy=x_large" };

            Photo ph76 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/pro_photo_tool/Hosting-20083273-unapproved/original/ad4cec4b-9bfe-4a48-b497-5833483210aa.JPEG?aki_policy=x_large" };
            Photo ph77 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/pro_photo_tool/Hosting-20083273-unapproved/original/afd31705-0296-4aac-b346-b938625c98dd.JPEG?aki_policy=x_large" };
            Photo ph78 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/pro_photo_tool/Hosting-20083273-unapproved/original/a7a4c858-5b9f-4dd0-9012-32f9b52ecb0c.JPEG?aki_policy=x_large" };
            Photo ph79 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/pro_photo_tool/Hosting-20083273-unapproved/original/b0f1c33d-7d4c-435b-a975-6cdc5f58e273.JPEG?aki_policy=x_large" };
            Photo ph80 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/pro_photo_tool/Hosting-20083273-unapproved/original/50704a0a-6f48-4b2e-bf9e-21dcd03c2a28.JPEG?aki_policy=x_large" };

            Photo ph81 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/be53ed45-0879-4c31-b259-501886145203.jpg?aki_policy=x_large" };
            Photo ph82 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/4af6c369-deae-444c-a70c-c3d951130b79.jpg?aki_policy=x_large" };
            Photo ph83 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/c6d36c17-4f1e-4460-b2d4-4612b93f1de7.jpg?aki_policy=x_large" };
            Photo ph84 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/7a65e5d9-bd58-414e-8990-e81a8856eee9.jpg?aki_policy=x_large" };
            Photo ph85 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/2c0f6019-2626-4dd6-93fc-e0864ecf1ff8.jpg?aki_policy=x_large" };

            Photo ph86 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/1cda85aa-7b44-487e-8af1-efe96f046064.jpg?aki_policy=x_large" };
            Photo ph87 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/fe26ebd1-75fd-4424-af16-1f103a26ca57.jpg?aki_policy=x_large" };
            Photo ph88 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/da80dd0b-cc43-410c-af10-773eba72ce7d.jpg?aki_policy=x_large" };
            Photo ph89 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/bb88a7d4-3f3a-439e-8124-6a77218a54a4.jpg?aki_policy=x_large" };
            Photo ph90 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/3c8470a2-cabd-4d61-b330-c1490116bd26.jpg?aki_policy=x_large" };

            Photo ph91 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/ddafd674-b8c5-489b-958a-546c84d3b720.jpg?aki_policy=x_large" };
            Photo ph92 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/35753b6b-f75c-4063-b0da-2a243297a41d.jpg?aki_policy=x_large" };
            Photo ph93 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/5093e1a4-668b-490f-a7f2-a538049bc475.jpg?aki_policy=x_large" };
            Photo ph94 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/88d41922-0f37-4cf6-9b4a-2bf4390a12c4.jpg?aki_policy=x_large" };
            Photo ph95 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/ce704e16-2074-44fc-b90a-239c97edd58b.jpg?aki_policy=x_large" };

            Photo ph96 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/d542ef7f-1051-4a36-b936-5cf790622766.jpg?aki_policy=x_large" };
            Photo ph97 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/a9533acf-cc10-4b01-93b4-841e87e19e0a.jpg?aki_policy=x_large" };
            Photo ph98 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/2431c316-1a92-4c76-9eae-55407b8dc652.jpg?aki_policy=x_large" };
            Photo ph99 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/51c3dd3f-cb2c-4647-bd2d-d81a3d757977.jpg?aki_policy=x_large" };
            Photo ph100 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/44f38092-c90d-4a77-872f-bb051980f8a8.jpg?aki_policy=x_large" };

            Photo ph101 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/ea3e9b7c-354d-415e-bea1-42ab9f764c54.jpg?aki_policy=x_large" };
            Photo ph102 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/ba3db253-c4ce-4327-9f96-03c377b69f05.jpg?aki_policy=x_large" };
            Photo ph103 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/d26ef0f5-09e6-482f-ae86-d2406ab38178.jpg?aki_policy=x_large" };
            Photo ph104 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/803873b5-69d3-456a-845c-24aebbccf57b.jpg?aki_policy=x_large" };
            Photo ph105 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/c14544eb-a178-4c32-8585-c6a8d47ae15f.jpg?aki_policy=x_large" };

            Photo ph106 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/d5cc6176-4ecb-4ba3-9a97-e3351a86d7a3.jpg?aki_policy=x_large" };
            Photo ph107 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/23d375bb-ab41-4a41-82a2-8386d6e7d5e3.jpg?aki_policy=x_large" };
            Photo ph108 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/a69af2f5-73dc-41bf-abe3-7b069a3346af.jpg?aki_policy=x_large" };
            Photo ph109 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/00efb58f-276d-49b4-ad10-d2db15aa3426.jpg?aki_policy=x_large" };
            Photo ph110 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/7bc65e62-dca1-478c-8856-ec3bbdd60c45.jpg?aki_policy=x_large" };

            Photo ph111 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/5d84a088-7977-4f02-86b5-a57afb5884af.jpg?aki_policy=x_large" };
            Photo ph112 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/cca2a298-ba4a-4e0f-98fe-32fd67026098.jpg?aki_policy=x_large" };
            Photo ph113 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/0dcb439c-6e78-4423-9627-6938cd4639d4.jpg?aki_policy=x_large" };
            Photo ph114 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/6054c18a-d53a-4c01-a626-243de62bd641.jpg?aki_policy=x_large" };
            Photo ph115 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/f74a187e-0b03-4571-a760-555c2e6ae87d.jpg?aki_policy=x_large" };

            Photo ph116 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/304f77f4-9ef2-4c90-8284-123efca767c3.jpg?aki_policy=x_large" };
            Photo ph117 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/fde54e7e-e09d-4596-acfd-b5703b61f9a0.jpg?aki_policy=x_large" };
            Photo ph118 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/0ff20919-ea3d-4874-b809-1f1a6ae0936e.jpg?aki_policy=x_large" };
            Photo ph119 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/5c55f36d-2ee0-4158-b40e-5a178cf1288f.jpg?aki_policy=x_large" };
            Photo ph120 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/dd5dba24-0e19-4f54-ba2f-69b7823189d1.jpg?aki_policy=x_large" };

            Photo ph121 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/f420c58c-1ce9-415f-9c12-458e135a0c60.jpg?aki_policy=x_large" };
            Photo ph122 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/981324ed-cec2-4290-876f-84afa02cea10.jpg?aki_policy=x_large" };
            Photo ph123 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/b3df9123-124b-4b44-b468-659366d64066.jpg?aki_policy=x_large" };
            Photo ph124 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/0c78afa0-5157-4a69-a55e-0dc3dea01e23.jpg?aki_policy=x_large" };
            Photo ph125 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/8bef6bb1-14f0-406c-8995-1ef8bf9b2b53.jpg?aki_policy=x_large" };

            Photo ph126 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/71f24b8f-dc7f-431d-bd59-15378e23cc6e.jpg?aki_policy=x_large" };
            Photo ph127 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/ff671d4d-68c9-41e4-ab20-05674da69d71.jpg?aki_policy=x_large" };
            Photo ph128 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/64c72abb-a1de-44bf-aa05-46a6c64122e3.jpg?aki_policy=x_large" };
            Photo ph129 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/57aaaa8f-2637-4497-9b64-465533d5aa1a.jpg?aki_policy=x_large" };
            Photo ph130 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/c34b09b7-9905-492a-9652-191af82c4c38.jpg?aki_policy=x_large" };

            Photo ph131 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/642ae27f-678d-4fac-9300-9d1682f26dfd.jpg?aki_policy=x_large" };
            Photo ph132 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/33567ddd-d43a-422b-b997-b094fcb207df.jpg?aki_policy=x_large" };
            Photo ph133 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/67904654-e5a0-4291-bd2f-b1d019818508.jpg?aki_policy=x_large" };
            Photo ph134 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/bffd6e3e-ade8-4347-ada3-2631452e4283.jpg?aki_policy=x_large" };
            Photo ph135 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/9070fe04-63a0-4bb7-8746-0ffaa949c4ba.jpg?aki_policy=x_large" };

            Photo ph136 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/1a184508-3ab5-4e00-8477-119f4e2a749d.jpg?aki_policy=x_large" };
            Photo ph137 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/6a2a66ae-3ef5-4564-bde9-10b668af1d9b.jpg?aki_policy=x_large" };
            Photo ph138 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/ad224b9a-e67f-4115-9122-407006dbc4c7.jpg?aki_policy=x_large" };
            Photo ph139 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/7f131031-a050-4118-82a8-54fc4ad8133b.jpg?aki_policy=x_large" };
            Photo ph140 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/0aea30d2-abf4-40eb-b956-92dd3258e815.jpg?aki_policy=x_large" };

            Photo ph141 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/a269a34b-ca6a-48c6-9bbd-19ab2b837f42.jpg?aki_policy=x_large" };
            Photo ph142 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/4a7ea8ba-66d9-46fd-ac27-d277e0737faa.jpg?aki_policy=x_large" };
            Photo ph143 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/0ab985fc-ee8b-4d9a-b1d4-dc4b3e5729e3.jpg?aki_policy=x_large" };
            Photo ph144 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/84e8dca5-bc53-4a41-920f-36246e71c0c3.jpg?aki_policy=x_large" };
            Photo ph145 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/aefe30ee-7105-4b87-bb24-977f69b007f5.jpg?aki_policy=x_large" };

            Photo ph146 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/f094688d-7e58-4b54-bc94-0de3f97cf4c5.jpg?aki_policy=x_large" };
            Photo ph147 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/9c26631e-3c36-4276-98ee-d0220aebfb0d.jpg?aki_policy=x_large" };
            Photo ph148 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/883e45c9-7aef-4459-81a2-3a3ce6473086.jpg?aki_policy=x_large" };
            Photo ph149 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/06428b12-d947-4e35-800a-fdb373a3c10c.jpg?aki_policy=x_large" };
            Photo ph150 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/3998ec4a-843f-41c5-b9d7-f18b75a7d142.jpg?aki_policy=x_large" };

            Photo ph151 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/00317866-d845-4dd0-b99c-b1361e49f436.jpg?aki_policy=x_large" };
            Photo ph152 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/889bdc82-a88e-4ea2-aa6c-f5852f77cd76.jpg?aki_policy=x_large" };
            Photo ph153 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/e3d23b3e-ed3d-4e94-bef5-2be3b4ef3fc5.jpg?aki_policy=x_large" };
            Photo ph154 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/5c5ced82-c1b1-49c9-9a57-dbd81783b786.jpg?aki_policy=x_large" };
            Photo ph155 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/47ac18ec-6d75-493b-983b-d832d6616b4d.jpg?aki_policy=x_large" };

            Photo ph156 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/82d106d1-24d6-482e-975c-b3f61c8eba5a.jpg?aki_policy=x_large" };
            Photo ph157 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/629e00c2-d22e-4232-96b6-2b9ee7450100.jpg?aki_policy=x_large" };
            Photo ph158 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/e1fa9a72-5e6b-43db-860e-f609a06f7fc1.jpg?aki_policy=x_large" };
            Photo ph159 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/f5ec3f14-c1ec-4720-8418-f4aea996764d.jpg?aki_policy=x_large" };
            Photo ph160 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/5432c020-2fdc-4655-86df-9b7efa49bd46.jpg?aki_policy=x_large" };

            Photo ph161 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/664f7224-c087-4e7b-9f82-4f7d0895b390.jpg?aki_policy=x_large" };
            Photo ph162 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/d2546397-020f-4d9a-9e6d-68ded55d89ab.jpg?aki_policy=x_large" };
            Photo ph163 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/fa808f27-ae11-41c2-a354-e62af27990dc.jpg?aki_policy=x_large" };
            Photo ph164 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/ce12ca4e-795d-466c-9e3b-a7cce12befd9.jpg?aki_policy=x_large" };
            Photo ph165 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/515660da-fccd-48af-bfaa-3f1f619fd2bf.jpg?aki_policy=x_large" };

            Photo ph166 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/e9e60723-a073-482d-af86-593c3185f863.jpg?aki_policy=x_large" };
            Photo ph167 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/71f41906-8bac-40b8-8405-6c73cd5fc585.jpg?aki_policy=x_large" };
            Photo ph168 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/abe68f09-d28e-4821-8186-d1a4d636dac5.jpg?aki_policy=x_large" };
            Photo ph169 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/bda1864d-eec6-40e8-a68e-d0404f2b7cda.jpg?aki_policy=x_large" };
            Photo ph170 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/bc4837ff-cea3-46c5-a4e5-d63ee3e01609.jpg?aki_policy=x_large" };

            Photo ph171 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/a0aa89d2-7fad-48cc-ac51-c95474dd966f.jpg?aki_policy=x_large" };
            Photo ph172 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/4c3f36f6-ea12-49dc-ab1a-551d2aceac7c.jpg?aki_policy=x_large" };
            Photo ph173 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/db931423-5dbd-47b7-8f5d-29446b535ef8.jpg?aki_policy=x_large" };
            Photo ph174 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/978be843-dda2-42c1-a080-bdc7c0bde435.jpg?aki_policy=x_large" };
            Photo ph175 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/b49f1f41-9383-41a7-9767-d78b3ad8f4ae.jpg?aki_policy=x_large" };

            Photo ph176 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/21689821/2d6d0e46_original.jpg?aki_policy=x_large" };
            Photo ph177 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/21689624/b38407ea_original.jpg?aki_policy=x_large" };
            Photo ph178 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/21689448/f568bf99_original.jpg?aki_policy=x_large" };
            Photo ph179 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/21690540/eac277fc_original.jpg?aki_policy=x_large" };
            Photo ph180 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/21689523/4949e0b7_original.jpg?aki_policy=x_large" };

            Photo ph181 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/3ca8a136-7506-48e5-8c12-819d0c8ef718.jpg?aki_policy=x_large" };
            Photo ph182 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/586ab56f-f21d-44be-84a9-6c5744b87fae.jpg?aki_policy=x_large" };
            Photo ph183 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/562d6dd1-8885-4d5e-bda7-a3aee9f6ab8f.jpg?aki_policy=x_large" };
            Photo ph184 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/1a060c53-58e5-414e-a993-8ef2e38c31c5.jpg?aki_policy=x_large" };
            Photo ph185 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/1babb5c0-e867-4f96-aea4-fe5484878398.jpg?aki_policy=x_large" };

            Photo ph186 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/5aa2e39d-d635-43ec-8292-2664758e73eb.jpg?aki_policy=x_large" };
            Photo ph187 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/c85f082a-4ccc-4143-94ea-baf822e0b0f9.jpg?aki_policy=x_large" };
            Photo ph188 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/a58a3f55-d12d-4096-9016-bd4fe11f3daa.jpg?aki_policy=x_large" };
            Photo ph189 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/12b801d3-d837-47ef-a660-3b0c94adfe9e.jpg?aki_policy=x_large" };
            Photo ph190 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/602d3bb4-0fd0-44f3-9f24-42eb8016f57d.jpg?aki_policy=x_large" };

            Photo ph191 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/16de4687-cb14-43c8-874a-340a1ef78a2d.jpg?aki_policy=x_large" };
            Photo ph192 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/e8b35afc-c4ac-43fa-95ec-e45a43c9e389.jpg?aki_policy=x_large" };
            Photo ph193 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/574847f7-fbf7-46a6-a7cf-93bcd21f188f.jpg?aki_policy=x_large" };
            Photo ph194 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/816d7ba8-b676-4311-a4d8-5a90223b2dc9.jpg?aki_policy=x_large" };
            Photo ph195 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/60f29385-c6af-4fe8-8174-bdc709f14f88.jpg?aki_policy=x_large" };

            Photo ph196 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/3d95b15e-44e7-44c9-9e8f-e8159ec86188.jpg?aki_policy=x_large" };
            Photo ph197 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/6230f939-5515-4770-b6a9-93c49aa024b6.jpg?aki_policy=x_large" };
            Photo ph198 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/77eb9f0b-bf70-4548-a93d-adc5e1e00314.jpg?aki_policy=x_large" };
            Photo ph199 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/e138a908-2837-4fca-b5b4-0b62ccae897e.jpg?aki_policy=x_large" };
            Photo ph200 = new Photo() { PhotoUrl = "https://a0.muscache.com/im/pictures/958bdf84-02b1-4e3c-a09b-a1889cbe01bf.jpg?aki_policy=x_large" };

            //Photo ph4 = new Photo() { PhotoUrl = "####" };
            #endregion

            //================Create Relations ==================
            

            p1.Amenities = a1;
            p2.Amenities = a2;
            p3.Amenities = a3;
            p4.Amenities = a4;
            p5.Amenities = a5;
            p6.Amenities = a6;
            p7.Amenities = a7;
            p8.Amenities = a8;
            p9.Amenities = a9;
            p10.Amenities = a10;
            p11.Amenities = a11;
            p12.Amenities = a12;
            p13.Amenities = a13;
            p14.Amenities = a14;
            p15.Amenities = a15;
            p16.Amenities = a16;
            p17.Amenities = a17;
            p18.Amenities = a18;
            p19.Amenities = a19;
            p20.Amenities = a20;
            p21.Amenities = a21;
            p22.Amenities = a22;
            p23.Amenities = a23;
            p24.Amenities = a24;
            p25.Amenities = a25;
            p26.Amenities = a26;
            p27.Amenities = a27;
            p28.Amenities = a28;
            p29.Amenities = a29;
            p30.Amenities = a30;
            p31.Amenities = a31;
            p32.Amenities = a32;
            p33.Amenities = a33;
            p34.Amenities = a34;
            p35.Amenities = a35;
            p36.Amenities = a36;
            p37.Amenities = a37;
            p38.Amenities = a38;
            p39.Amenities = a39;
            p40.Amenities = a40;

            p1.Address = ad1;
            p2.Address = ad2;
            p3.Address = ad3;
            p4.Address = ad5;
            p5.Address = ad11;
            p6.Address = ad6;
            p7.Address = ad7;
            p8.Address = ad8;
            p9.Address = ad9;
            p10.Address = ad10;
            p11.Address = ad11;
            p12.Address = ad1;
            p13.Address = ad2;
            p14.Address = ad3;
            p15.Address = ad5;
            p16.Address = ad6;
            p17.Address = ad7;
            p18.Address = ad8;
            p19.Address = ad9;
            p20.Address = ad10;
            p21.Address = ad11;
            p22.Address = ad1;
            p23.Address = ad2;
            p24.Address = ad3;
            p25.Address = ad5;
            p26.Address = ad6;
            p27.Address = ad7;
            p28.Address = ad8;
            p29.Address = ad9;
            p30.Address = ad10;
            p31.Address = ad11;
            p32.Address = ad1;
            p33.Address = ad2;
            p34.Address = ad3;
            p35.Address = ad5;
            p36.Address = ad6;
            p37.Address = ad7;
            p38.Address = ad8;
            p39.Address = ad9;
            p40.Address = ad10;

            p1.Photos = new List<Photo>() { ph1, ph2, ph3, ph4, ph5 };
            p2.Photos = new List<Photo>() { ph6, ph7, ph8, ph9, ph10 };
            p3.Photos = new List<Photo>() { ph11, ph12, ph13, ph14, ph15 };
            p4.Photos = new List<Photo>() { ph16, ph17, ph18, ph19, ph20 };
            p5.Photos = new List<Photo>() { ph21, ph22, ph23, ph24, ph25 };
            p6.Photos = new List<Photo>() { ph26, ph27, ph28, ph29, ph30 };
            p7.Photos = new List<Photo>() { ph31, ph32, ph33, ph34, ph35 };
            p8.Photos = new List<Photo>() { ph36, ph37, ph38, ph39, ph40 };
            p9.Photos = new List<Photo>() { ph41, ph42, ph43, ph44, ph45 };
            p10.Photos = new List<Photo>() { ph46, ph47, ph48, ph49, ph50 };
            p11.Photos = new List<Photo>() { ph51, ph52, ph53, ph54, ph55 };
            p12.Photos = new List<Photo>() { ph56, ph57, ph58, ph59, ph60 };
            p13.Photos = new List<Photo>() { ph61, ph62, ph63, ph64, ph65 };
            p14.Photos = new List<Photo>() { ph66, ph67, ph68, ph69, ph70 };
            p15.Photos = new List<Photo>() { ph71, ph72, ph73, ph74, ph75 };
            p16.Photos = new List<Photo>() { ph76, ph77, ph78, ph79, ph80 };
            p17.Photos = new List<Photo>() { ph81, ph82, ph83, ph84, ph85 };
            p18.Photos = new List<Photo>() { ph86, ph87, ph88, ph89, ph90 };
            p19.Photos = new List<Photo>() { ph91, ph92, ph93, ph94, ph95 };
            p20.Photos = new List<Photo>() { ph96, ph97, ph98, ph99, ph100 };
            p21.Photos = new List<Photo>() { ph101, ph102, ph103, ph104, ph105 };
            p22.Photos = new List<Photo>() { ph106, ph107, ph108, ph109, ph110 };
            p23.Photos = new List<Photo>() { ph111, ph112, ph113, ph114, ph115 };
            p24.Photos = new List<Photo>() { ph116, ph117, ph118, ph119, ph120 };
            p25.Photos = new List<Photo>() { ph121, ph122, ph123, ph124, ph125 };
            p26.Photos = new List<Photo>() { ph126, ph127, ph128, ph129, ph130 };
            p27.Photos = new List<Photo>() { ph131, ph132, ph133, ph134, ph135 };
            p28.Photos = new List<Photo>() { ph136, ph137, ph138, ph139, ph140 };
            p29.Photos = new List<Photo>() { ph141, ph142, ph143, ph144, ph145 };
            p30.Photos = new List<Photo>() { ph146, ph147, ph148, ph149, ph150 };
            p31.Photos = new List<Photo>() { ph151, ph152, ph153, ph154, ph155 };
            p32.Photos = new List<Photo>() { ph156, ph157, ph158, ph159, ph160 };
            p33.Photos = new List<Photo>() { ph161, ph162, ph163, ph164, ph165 };
            p34.Photos = new List<Photo>() { ph166, ph167, ph168, ph169, ph170 };
            p35.Photos = new List<Photo>() { ph171, ph172, ph173, ph174, ph175 };
            p36.Photos = new List<Photo>() { ph176, ph177, ph178, ph179, ph180 };
            p37.Photos = new List<Photo>() { ph181, ph182, ph183, ph184, ph185 };
            p38.Photos = new List<Photo>() { ph186, ph187, ph188, ph189, ph190 };
            p39.Photos = new List<Photo>() { ph191, ph192, ph193, ph194, ph195 };
            p40.Photos = new List<Photo>() { ph196, ph197, ph198, ph199, ph200 };

            p1.Reviews = new List<Review>() { rev1, rev1b, rev1c };
            p2.Reviews = new List<Review>() { rev2, rev2b, rev2c };
            p3.Reviews = new List<Review>() { rev3, rev3b, rev3c };
            p4.Reviews = new List<Review>() { rev5, rev5b, rev5c };
            p5.Reviews = new List<Review>() { rev5, rev5b, rev5c };
            p6.Reviews = new List<Review>() { rev6, rev6b, rev6c };
            p7.Reviews = new List<Review>() { rev7 };
            p8.Reviews = new List<Review>() { rev8 };
           
            p9.Reviews = new List<Review>() { rev9 };
            p10.Reviews = new List<Review>() { rev90 };
            p11.Reviews = new List<Review>() { rev91 };
            p12.Reviews = new List<Review>() { rev10 };
            p13.Reviews = new List<Review>() { rev100 };
            p14.Reviews = new List<Review>() { rev101 };
            p15.Reviews = new List<Review>() { rev11 };
            p16.Reviews = new List<Review>() { rev110 };
            p17.Reviews = new List<Review>() { rev111 };
            p18.Reviews = new List<Review>() { rev12 };
            p19.Reviews = new List<Review>() { rev120 };
            p20.Reviews = new List<Review>() { rev121 };
            p21.Reviews = new List<Review>() { rev13 };
            p22.Reviews = new List<Review>() { rev130 };
            p23.Reviews = new List<Review>() { rev131 };
            p24.Reviews = new List<Review>() { rev14 };
            p25.Reviews = new List<Review>() { rev15 };
            p26.Reviews = new List<Review>() { rev16 };
            p27.Reviews = new List<Review>() { rev160 };
            p28.Reviews = new List<Review>() { rev161 };
            p29.Reviews = new List<Review>() { rev17};
            p30.Reviews = new List<Review>() { rev170 };
            p31.Reviews = new List<Review>() { rev171 };
            p32.Reviews = new List<Review>() { rev18 };
            p33.Reviews = new List<Review>() { rev180 };
            p34.Reviews = new List<Review>() { rev181 };
            p35.Reviews = new List<Review>() { rev19 };
            p36.Reviews = new List<Review>() { rev190};
            p37.Reviews = new List<Review>() { rev191 };
            p38.Reviews = new List<Review>() { rev20 };
            p39.Reviews = new List<Review>() { rev21,rev22 };
            p40.Reviews = new List<Review>() { rev23};



            rev1.ApplicationUser = ap1;
            rev1b.ApplicationUser = ap2;
            rev1c.ApplicationUser = ap3;
            rev2.ApplicationUser = ap1;
            rev2b.ApplicationUser = ap2;
            rev2c.ApplicationUser = ap3;
            rev3.ApplicationUser = ap1;
            rev3b.ApplicationUser = ap2;
            rev3c.ApplicationUser = ap3;
            rev5.ApplicationUser = ap1;
            rev5b.ApplicationUser = ap2;
            rev5c.ApplicationUser = ap3;
            rev6.ApplicationUser = ap1;
            rev6b.ApplicationUser = ap2;
            rev6c.ApplicationUser = ap3;
            rev7.ApplicationUser = ap1;
            rev8.ApplicationUser = ap2;
           
            rev9.ApplicationUser = ap1;
            rev90.ApplicationUser = ap2;
            rev91.ApplicationUser = ap3;
            rev10.ApplicationUser = ap1;
            rev100.ApplicationUser = ap2;
            rev100.ApplicationUser = ap3;
            rev11.ApplicationUser = ap1;
            rev110.ApplicationUser = ap2;
            rev111.ApplicationUser = ap3;
            rev12.ApplicationUser = ap1;
            rev120.ApplicationUser = ap2;
            rev121.ApplicationUser = ap3;
            rev13.ApplicationUser = ap1;
            rev130.ApplicationUser = ap2;
            rev131.ApplicationUser = ap3;
            rev14.ApplicationUser = ap1;
            rev15.ApplicationUser = ap2;
            rev16.ApplicationUser = ap1;
            rev160.ApplicationUser = ap2;
            rev161.ApplicationUser = ap3;
            rev17.ApplicationUser = ap1;
            rev170.ApplicationUser = ap2;
            rev171.ApplicationUser = ap3;
            rev18.ApplicationUser = ap1;
            rev180.ApplicationUser = ap2;
            rev181.ApplicationUser = ap3;
            rev19.ApplicationUser = ap1;
            rev190.ApplicationUser = ap2;
            rev191.ApplicationUser = ap3;
            rev20.ApplicationUser = ap1;
            rev21.ApplicationUser = ap1;
            rev22.ApplicationUser = ap2;
            rev23.ApplicationUser = ap2;
            rev24.ApplicationUser = ap2;



            r1.Place = p1;
            r1b.Place = p1;
            r1c.Place = p1;
            r2.Place = p2;
            r2b.Place = p2;
            r2c.Place = p2;
            r3.Place = p3;
            r3b.Place = p3;
            r3c.Place = p3;
            r5.Place = p4;
            r5b.Place = p4;
            r5c.Place = p4;
            r6.Place = p6;
            r6b.Place = p6;
            r6c.Place = p6;
            r7.Place = p7;
            r8.Place = p8;
           

            r1.ApplicationUser = ap1;
            r1b.ApplicationUser = ap2;
            r1c.ApplicationUser = ap3;
            r2.ApplicationUser = ap1;
            r2b.ApplicationUser = ap2;
            r2c.ApplicationUser = ap3;
            r3.ApplicationUser = ap1;
            r3b.ApplicationUser = ap2;
            r3c.ApplicationUser = ap3;
            r5.ApplicationUser = ap1;
            r5b.ApplicationUser = ap2;
            r5c.ApplicationUser = ap3;
            r6.ApplicationUser = ap1;
            r6b.ApplicationUser = ap2;
            r6c.ApplicationUser = ap3;
            r7.ApplicationUser = ap1;
            r8.ApplicationUser = ap2;

            context.Reviews.AddOrUpdate(x => x.Identifier, rev1, rev1b, rev1c, rev2, rev2b, rev2c, rev3, rev3b, rev3c, rev5, rev5b, rev5c, rev6, rev6b, rev6c, rev7, rev8, rev9, rev90, rev91,
            rev10, rev100, rev101, rev11, rev110, rev111, rev12, rev120, rev121, rev13, rev130, rev131, rev14, rev15, rev16,rev160, rev161, rev17,rev170,rev171,rev18,rev180, rev181, rev19, rev190, rev191, rev20, /*rev20b, rev20c,*/ rev21,
           rev22,rev23,rev24);
            context.Amenities.AddOrUpdate(x => x.Count, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16, a17,                                       
                                                        a18, a19, a20, a21, a22, a23, a24, a25, a26, a27, a28, a29, a30, a31, a32,                                       
                                                        a33, a34, a35, a36, a37, a38, a39, a40);                                                                           
            context.Places.AddOrUpdate(x => x.ApartmentName, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18,                             
                                                            p19, p20, p21, p22, p23, p24, p25, p26, p27, p28, p29, p30, p31, p32, p33, p34,                               
                                                            p35, p36, p37, p38, p39, p40);                                                                                 
            context.Reservations.AddOrUpdate(x => x.DaysOfStaying, r1, r1b, r1c, r2, r2b, r2c, r3, r3b, r3c, r5, r5b, r5c, r6, r6b, r6c, r7, r8);                         
            context.Users.AddOrUpdate(x => x.LastName, ap1, ap2, ap3);                                                                                                    
            context.Photos.AddOrUpdate(x => x.PhotoId, ph1, ph2, ph3, ph4, ph5, ph6, ph7, ph8, ph9, ph10, ph11, ph12, ph13, ph14, ph15, ph16, ph17, ph18, ph19, ph20, ph21 , ph22, ph23, ph24, ph25,
                                                        ph26, ph27, ph28, ph29, ph30, ph31, ph32, ph33, ph34, ph35, ph36, ph37, ph38,                                     
                                                        ph39, ph40, ph41, ph42, ph43, ph44, ph45, ph46, ph47, ph48, ph49, ph50, ph51,                                     
                                                        ph52, ph53, ph54, ph55, ph56, ph57, ph58, ph59, ph60, ph61, ph62, ph63, ph64,                                      
                                                        ph65, ph66, ph67, ph68, ph69, ph70, ph71, ph72, ph73, ph74, ph75, ph76, ph77,                                     
                                                        ph78, ph79, ph80, ph81, ph82, ph83, ph84, ph85, ph86, ph87, ph88, ph89, ph90,                                     
                                                        ph91, ph92, ph93, ph94, ph95, ph96, ph97, ph98, ph99, ph100, ph101, ph102, ph103,                                  
                                                        ph104, ph105, ph106, ph107, ph108, ph109, ph110, ph111, ph112, ph113, ph114, ph115,                                
                                                        ph116, ph117, ph118, ph119, ph120, ph121, ph122, ph123, ph124, ph125, ph126, ph127,
                                                        ph128, ph129, ph130, ph131, ph132, ph133, ph134, ph135, ph136, ph137, ph138, ph139,                                
                                                        ph140, ph141, ph142, ph143, ph144, ph145, ph146, ph147, ph148, ph149, ph150, ph151,                               
                                                        ph152, ph153, ph154, ph155, ph156, ph157, ph158, ph159, ph160, ph161, ph162, ph163,                               
                                                        ph164, ph165, ph166, ph167, ph168, ph169, ph170, ph171, ph172, ph173, ph174, ph175,                                
                                                        ph176, ph177, ph178, ph179, ph180, ph181, ph182, ph183, ph184, ph185, ph186, ph187,                               
                                                        ph188, ph189, ph190, ph191, ph192, ph193, ph194, ph195, ph196, ph197, ph198, ph199,                               
                                                        ph200);                                                                                                            
                                                                                                                                                                          
                                                                                                                                                                          
            context.SaveChanges();                                                                                                                                         
        }                                                                                                                                                                 
    }                                                                                                                                                                     
}                                                                                                                                                                          
                                                                                                                                                                          
                                                                                                                                                                          
                                                                                                                                                                           
                                                                                                                                                                           