using HomeSeek.Database;
using HomeSeek.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeSeek.Desktop
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var unitOfWork = new UnitOfWork(new MyDatabase()))
            {
                // Example1
                var reservations = unitOfWork.Reservations.GetAll();
                var places = unitOfWork.Places.GetAll() ;
                var reviews= unitOfWork.Reviews.GetAll();
                var users = unitOfWork.Users.GetAll();

                Console.WriteLine("==================== TOTAL APARTMENTS ========================== "); 
                Console.WriteLine("Total apartments: "+places.Count());
                
                //AVERAGE DAYS OF STAYING
                Console.WriteLine("==================== AVERAGE DAYS OF STAYING OVERALL ========================== ");
                int totalDays=0;
                for (int i=0; i<reservations.Count(); i++)
                {
                    totalDays += reservations[i].DaysOfStaying;
                }
                double avgDays = totalDays / reservations.Count();
                Console.WriteLine("Average days of staying in all apartments: "+avgDays+" days");

                
                //total reviews
                Console.WriteLine("==================== TOTAL REVIEWS ========================== ");
                Console.WriteLine("Total Reviews:" + reviews.Count());
                
                //total reservations
                Console.WriteLine("==================== TOTAL RESERVATIONS ========================== ");
                Console.WriteLine("Total reservations:" + reservations.Count());

                /*
                foreach (var item in places)
                {

                    Console.WriteLine(item.ApartmentName);
                    Console.WriteLine("Reservations " + item.Reviews.Count());
                    foreach (var review in item.Reviews)
                    {
                        Console.WriteLine(review.Comment);
                    }
                }*/
                Console.WriteLine("==================== RESERVATIONS PER PLACE ========================== ");
                var reservationsCount = 0;
                foreach (var place in places)
                {
                    reservationsCount = place.Reservations.Count();
                    Console.WriteLine(place.ApartmentName + " has " + reservationsCount + " reservations.");
                  
                }
                //------------------------------ Reviews per reservation ---------------------------------------------
                Console.WriteLine("==================== RESERVATIONS PER PLACE ========================== ");
                
                foreach (var rev in reviews)
                {
                    Console.WriteLine("total rating: " + rev.OverallRating );

                }

                // Example2
                //var courses = unitOfWork.Courses.GetCoursesWithAuthors(1, 4);

                // Example3
                //var author = unitOfWork.Authors.GetAuthorWithCourses(1);
                // unitOfWork.Courses.RemoveRange(author.Courses);
                // unitOfWork.Authors.Remove(author);
                //unitOfWork.Complete();
            }

        }
    }
}
