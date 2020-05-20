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
                var addresses = unitOfWork.Address.GetAll();
                
                Console.WriteLine("==================== TOTAL APARTMENTS ========================== "); 
                Console.WriteLine("Total apartments: "+places.Count());

                
                
                
                Console.WriteLine("==================== TOTAL CITIES ========================== ");

                List<string> cities = new List<string>();
                foreach (var address in addresses)
                {
                    cities.Add(address.City);
                    Console.WriteLine(address.City);
                }
               
                //ΝΑ ΥΠΟΛΟΓΙΣΩ ΠΟΣΑ ΣΠΙΤΙΑ ΕΙΝΑΙ ΣΕ ΚΑΘΕ ΠΟΛΗ

                /*foreach (var city in cities)
                {
                    switch (city)
                    {
                        case "cities[0]":
                        default:
                            break;
                    }
                }*/

                
                






                //------------------------------------- AVERAGE DAYS OF STAYING ------------------------------------------------------------------------------
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
                Console.WriteLine("Reservations per month");
                int Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec;
                Jan = Feb = Mar = Apr = May = Jun = Jul = Aug = Sep = Oct = Nov = Dec = 0;
                foreach (var reservation in reservations)
                {
                    switch (reservation.PaymentDate.Month)
                    {
                        case 1:
                            Jan += 1;  
                            break;
                        case 2:
                            Feb += 1;
                            break;
                        case 3:
                            Mar += 1;
                            break;
                        case 4:
                            Apr += 1;
                            break;
                        case 5:
                            May += 1;
                            break;
                        case 6:
                            Jun += 1;
                            break;
                        case 7:
                            Jul += 1;
                            break;
                        case 8:
                            Aug += 1;
                            break;
                        case 9:
                            Sep += 1;
                            break;
                        case 10:
                            Oct += 1;
                            break;
                        case 11:
                            Nov += 1;
                            break;
                        case 12:
                            Dec += 1;
                            break;
                    }//end switch
                    Console.WriteLine(reservation.PaymentDate.ToString("MMMM")); 
                }//end foreach
                Console.WriteLine("Reservations per month: ");
                Console.WriteLine($"\t January: {Jan}\n\t February: {Feb}\n\t March: {Mar}\n\t April: {Apr}\n\t May: {May}\n\t June: {Jun}\n\t July: {Jul}\n\t August: {Aug}" +
                    $"\n\t September: {Sep}\n\t November: {Nov}\n\t December: {Dec}"); 

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
                //CALCULATES OVERALL AVERAGE RATING PER PLACE IF MULTIPLE REVIEWS EXIST PER APPARTMENT
                Console.WriteLine();
                Console.WriteLine("==================== OVERALL RATING PER PLACE ========================== ");

                foreach (var place in places)
                {
                    var overallSumRatingPlace = 0d;
                    foreach (var review in place.Reviews)
                    {
                        overallSumRatingPlace += review.OverallRating;
                    }
                    double overallRatingPlace = overallSumRatingPlace / place.Reviews.Count();
                    Console.Write(place.ApartmentName + ": ");
                    Console.WriteLine("\ttotal rating: " + overallRatingPlace);
                }
                /*foreach (var rev in reviews)
                {
                    Console.Write(rev.Place.ApartmentName+": ");
                    Console.WriteLine("\ttotal rating: " + rev.OverallRating);

                }*/

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
