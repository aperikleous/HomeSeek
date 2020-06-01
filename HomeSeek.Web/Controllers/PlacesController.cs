using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using HomeSeek.Database;
using HomeSeek.Entities;
using HomeSeek.Repository;
using PagedList;
using PagedList.Mvc;

namespace HomeSeek.Web.Controllers
{
    public class PlacesController : Controller
    {
        UnitOfWork db = new UnitOfWork(new MyDatabase());

        //GET: Places
        public ActionResult Index(string sortOrder, string searchtitle, string searchcity, DateTime? searchdate,
                                    int? searchminprice, int? searchmaxprice, int? page, int? pSize)
        {
            ViewBag.CurrentTitle = searchtitle;
            ViewBag.CurrentCity = searchcity;
            ViewBag.CurrentDate = searchdate;
            ViewBag.CurrentPrice = searchminprice;
            ViewBag.CurrentPrice = searchmaxprice;
            ViewBag.CurrentSortOrder = sortOrder;
            ViewBag.CurrentpSize = pSize;
            ViewBag.TitleSortParam = String.IsNullOrEmpty(sortOrder) ? "TitleDesc" : "";
            ViewBag.CitySortParam = sortOrder == "CityAsc" ? "CityDesc" : "CityAsc";
            ViewBag.DateSortParam = sortOrder == "DateAsc" ? "DateDesc" : "DateAsc";
            ViewBag.PriceSortParam = sortOrder == "PriceAsc" ? "PriceDesc" : "PriceAsc";
            ViewBag.TView = "badge badge-primary";
            ViewBag.CView = "badge badge-primary";
            ViewBag.DView = "badge badge-primary";
            ViewBag.PView = "badge badge-primary";
            var places = (IEnumerable<Place>)db.Places.GetAll();
            //===================================FILTERS=======================//
            //Filtering by Title
            if (!string.IsNullOrWhiteSpace(searchtitle))
            {
                places = places.Where(x => x.ApartmentName.ToUpper().Contains(searchtitle.ToUpper()));
            }
            //Filtering by City
            if (!string.IsNullOrWhiteSpace(searchcity))
            {
                places = places.Where(x => x.Address.City.ToUpper().Contains(searchcity.ToUpper()));
            }
            //Filtering by Date
            if (!(searchdate is null))
            {
                //places = places.Where(x => x. >= searchmindob);
            }
            //Filtering by Price
            if (!(searchminprice is null) && !(searchmaxprice is null)) //40
            {
                places = places.Where(x => x.PricePerDay <= searchmaxprice && x.PricePerDay >= searchminprice);
            }
            else if ((searchminprice is null) && !(searchmaxprice is null)) //40
            {
                places = places.Where(x => x.PricePerDay <= searchmaxprice);
            }
            else if (!(searchminprice is null) && (searchmaxprice is null)) //40
            {
                places = places.Where(x => x.PricePerDay >= searchminprice);
            }
            //Sorting
            switch (sortOrder)
            {
                case "TitleDesc": places = places.OrderByDescending(x => x.ApartmentName); ViewBag.TView = "badge badge-danger"; break;
                case "CityAsc": places = places.OrderBy(x => x.Address.City); ViewBag.CView = "badge badge-success"; break;
                case "CityDesc": places = places.OrderByDescending(x => x.Address.City); ViewBag.CView = "badge badge-danger"; break;
                case "PriceAsc": places = places.OrderBy(x => x.PricePerDay); ViewBag.PView = "badge badge-success"; break;
                case "PriceDesc": places = places.OrderByDescending(x => x.PricePerDay); ViewBag.PView = "badge badge-danger"; break;
                default: places = places.OrderBy(x => x.ApartmentName); ViewBag.TView = "badge badge-success"; break;
            }
            //Pagination
            int pageSize = pSize ?? 4;
            int pageNumber = page ?? 1; //nullable coalescing operator
            return View(places.ToPagedList(pageNumber, pageSize));
        }

        // GET: Places/Details/5
        [HandleError]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = db.Places.GetById(id);
            var overallSumRatingPlace = 0d;
            var totalValue = 0d;
            var totalAccuracy = 0d;
            var totalCheckin = 0d;
            var totalCleanliness = 0d;
            var totalLocation = 0d;
            var totalReviews = place.Reviews.Count();

            foreach (var review in place.Reviews)
            {
                overallSumRatingPlace += review.OverallRating;
                totalAccuracy += review.Accuracy;
                totalCheckin += review.Checkin;
                totalCleanliness += review.Cleanliness;
                totalLocation += review.Location;
                totalValue += review.Value;
            }
            if (place.Reviews.Count() == 0)
            {
                ViewBag.AvgOverallRating = 0d;
                ViewBag.AvgAccuracy = 0d;
                ViewBag.AvgCheckin = 0d;
                ViewBag.AvgCleanliness = 0d;
                ViewBag.AvgLocation = 0d;
                ViewBag.AvgValue = 0d;

            }
            else
            {
                ViewBag.AvgOverallRating = Math.Round((overallSumRatingPlace / totalReviews), 1);
                ViewBag.AvgAccuracy = Math.Round((totalAccuracy / totalReviews), 1);
                ViewBag.AvgCheckin = Math.Round((totalCheckin / totalReviews), 1);
                ViewBag.AvgCleanliness = Math.Round((totalCleanliness / totalReviews), 1);
                ViewBag.AvgLocation = Math.Round((totalLocation / totalReviews), 1);
                ViewBag.AvgValue = Math.Round((totalValue / totalReviews), 1);
            }
            ViewBag.TotalReviews = totalReviews;
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }



        //++++++++++++++
        public ActionResult CreateAddress()
        {
            return View();
        }

        // POST: GoogleAddress/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAddress([Bind(Include = "AddressId,AddressName,No,ZipCode,Latitude,Longitude,Area,City,State")] Address address)
        {
            if (ModelState.IsValid)
            {
                db.Address.Add(address);
                db.Complete();
                Session["newAddress"] = address;
                return RedirectToAction("CreatePhoto");
            }

            return View(address);
        }


        //================
        // GET: Photos/Create
        public ActionResult CreatePhoto()
        {
            return View();
        }

        // POST: Photos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePhoto([Bind(Include = "PhotoId,PhotoUrl,PrimaryPhoto,PhotoName")] Photo photo, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {

                if (Path.GetExtension(ImageFile.FileName).ToLower() == ".jpg"
                 || Path.GetExtension(ImageFile.FileName).ToLower() == ".png"
                 || Path.GetExtension(ImageFile.FileName).ToLower() == ".jpeg"
                 || Path.GetExtension(ImageFile.FileName).ToLower() == ".gif")
                {


                    string path = Path.Combine(Server.MapPath("~/Content/Images"), Path.GetFileName(ImageFile.FileName));
                    ImageFile.SaveAs(path);
                    ViewBag.UploadStatus = "Photo was uploaded successfully. You can upload another one.";
                    photo.PhotoUrl = "~/Content/Images/" + ImageFile.FileName;
                    db.Photo.Add(photo);
                    db.Complete();
                   

                }
                else
                {
                    return Content("Only files jpg , png , jpeg and gif are acceptable. Please try again");
                }




            }

            return View();
        }

        // GET: Places/Create
        [HandleError]
        public ActionResult CreatePlace()
        {
            ViewBag.AllPhotosIds = db.Photo.GetPhotosCustom().ToList().Where(x => x.Places.Count() == 0).Select(x => new SelectListItem()
            {
                Value = x.PhotoId.ToString(),
                Text = String.Format("{0}", x.PhotoName)

            });
            return View();
        }

        // POST: Places/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePlace([Bind(Include = "PlaceId,ApartmentName,Description,Guests,Bedroom,Bathroom,PricePerDay,CleanCost,IsBooked,Created,Modified,AddressId")] Place place, IEnumerable<int> AllPhotosIds)
        {
            if (ModelState.IsValid)
            {

                var PlacesDB = new PlaceRepository(new MyDatabase());
                PlacesDB.MyDatabase.Places.Attach(place);
                PlacesDB.MyDatabase.Entry(place).Collection(x => x.Photos).Load();
                place.Photos.Clear();

                if (!(AllPhotosIds == null))
                {
                    foreach (var id in AllPhotosIds)
                    {
                        Photo photo = db.Photo.GetById(id);  
                        if (photo != null)
                        {
                            place.Photos.Add(photo);
                        }
                    }
                }


                place.AddressId = ((Address)Session["newAddress"]).AddressId;
                db.Places.Add(place);
                db.Complete();
                return RedirectToAction("Index");
            }
            ViewBag.AllPhotosIds = db.Photo.GetPhotosCustom().ToList().Where(x => x.Places.Count() == 0).Select(x => new SelectListItem()
            {
                Value = x.PhotoId.ToString(),
                Text = String.Format("{0}", x.PhotoName)

            });

            return View(place);
        }

        // GET: Places/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = db.Places.GetById(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlaceId = new SelectList(db.Amenities.GetAll(), "AmenitiesId", "AmenitiesId", place.PlaceId);
            return View(place);
        }

        // POST: Places/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandleError]
        public ActionResult Edit([Bind(Include = "PlaceId,ApartmentName,Description,Guests,Bedroom,Bathroom,PricePerDay,CleanCost,IsBooked,Created,Modified")] Place place)
        {
            if (ModelState.IsValid)
            {
                db.Places.Edit(place);
                db.Complete();
                return RedirectToAction("Index");
            }
            ViewBag.PlaceId = new SelectList(db.Amenities.GetAll(), "AmenitiesId", "AmenitiesId", place.PlaceId);
            return View(place);
        }

        // GET: Places/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = db.Places.GetById(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // POST: Places/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Place place = db.Places.GetById(id);
            db.Places.Remove(place);
            db.Complete();
            return RedirectToAction("Index");
        }
    }
}
