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
                var places = unitOfWork.Places.GetAll() ;
                foreach (var item in places)
                {
                    Console.WriteLine(item.ApartmentName);
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
