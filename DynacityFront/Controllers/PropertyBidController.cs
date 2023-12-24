using AutoMapper;
using DynacityFront.DTO;
using DynacityFront.Models;
using DynacityFront.Services.IServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PagedList;
using Utility;

namespace DynacityFront.Controllers
{
    public class PropertyBidController : Controller
    {
        private readonly IBidService _bidService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment webHostEnvironment;
        public PropertyBidController(IBidService bidService, IMapper mapper, IWebHostEnvironment webHost)
        {
            _bidService = bidService;
            _mapper = mapper;
            this.webHostEnvironment = webHost;
        }
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            List<BidShowDTO> list = new();
            var response = await _bidService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<BidShowDTO>>(Convert.ToString(response.Result));
            }
            var students = from s in list
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.Property.City.Contains(searchString));

            }
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.Property.Price);
                    break;

                default:  // Price ascending 
                    students = students.OrderBy(s => s.Property.Price);
                    break;
            }

            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View(students.ToPagedList(pageNumber, pageSize));
        }
        public async Task<IActionResult> Create()
        {
            PropertyBidCreateDTO bothVM = new PropertyBidCreateDTO();

            return View(bothVM);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PropertyBidCreateDTO model)
        {
            if (ModelState.IsValid)
            {

                var Master = new PropertyCreateDTO()
                {

                    Title = model.Property.Title,
                    Description = model.Property.Description,
                    Bedrooms = model.Property.Bedrooms,
                    Bathrooms = model.Property.Bathrooms,
                    Area = model.Property.Area,
                    StreetAddress = model.Property.StreetAddress,
                    Country = model.Property.Country,
                    City = model.Property.City,
                    Price = model.bid.StartingPrice,
                    PropertyType = model.Property.PropertyType,
                    PropertyMainImageURL = model.Property.PropertyMainImageURL,
                    PropertyMainImage = model.Property.PropertyMainImage,
                    PropertyImageURL1 = model.Property.PropertyImageURL1,
                    PropertyImage1 = model.Property.PropertyImage1,
                    PropertyImageURL2 = model.Property.PropertyImageURL2,
                    PropertyImage2 = model.Property.PropertyImage2,
                    PropertyImageURL3 = model.Property.PropertyImageURL3,
                    PropertyImage3 = model.Property.PropertyImage3,
                    PropertyImageURL4 = model.Property.PropertyImageURL4,
                    PropertyImage4 = model.Property.PropertyImage4,
                    PropertyImageURL5 = model.Property.PropertyImageURL5,
                    PropertyImage5 = model.Property.PropertyImage5,

                };
                var Master2 = new BidsCreateDTO()
                {

                    StartDate = model.bid.StartDate,
                    EndDate = model.bid.EndDate,
                    UserBidAmount = model.bid.UserBidAmount,
                    StartingPrice = model.bid.StartingPrice,
                    Description = model.bid.Description,
                    CurrentBidAmount = model.bid.CurrentBidAmount,
                    IsAccepted = model.bid.IsAccepted


                };

                string wwwRootPath = webHostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(Master.PropertyMainImage.FileName);
                string extension = Path.GetExtension(Master.PropertyMainImage.FileName);
                Master.PropertyMainImageURL = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await Master.PropertyMainImage.CopyToAsync(fileStream);
                }
                Master.PropertyMainImage = null;



                string fileName1 = Path.GetFileNameWithoutExtension(Master.PropertyImage1.FileName);
                string extension1 = Path.GetExtension(Master.PropertyImage1.FileName);
                Master.PropertyImageURL1 = fileName1 = fileName1 + DateTime.Now.ToString("yymmssfff") + extension;
                string path1 = Path.Combine(wwwRootPath + "/image/", fileName1);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await Master.PropertyImage1.CopyToAsync(fileStream);
                }
                Master.PropertyImage1 = null;

                string fileName2 = Path.GetFileNameWithoutExtension(Master.PropertyImage2.FileName);
                string extension2 = Path.GetExtension(Master.PropertyImage2.FileName);
                Master.PropertyImageURL2 = fileName2 = fileName2 + DateTime.Now.ToString("yymmssfff") + extension;
                string path2 = Path.Combine(wwwRootPath + "/image/", fileName2);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await model.Property.PropertyImage2.CopyToAsync(fileStream);
                }
                Master.PropertyImage2 = null;

                string fileName3 = Path.GetFileNameWithoutExtension(Master.PropertyImage3.FileName);
                string extension3 = Path.GetExtension(Master.PropertyImage3.FileName);
                Master.PropertyImageURL3 = fileName3 = fileName3 + DateTime.Now.ToString("yymmssfff") + extension;
                string path3 = Path.Combine(wwwRootPath + "/image/", fileName3);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await Master.PropertyImage3.CopyToAsync(fileStream);
                }
                Master.PropertyImage3 = null;

                string fileName4 = Path.GetFileNameWithoutExtension(Master.PropertyImage4.FileName);
                string extension4 = Path.GetExtension(Master.PropertyImage4.FileName);
                Master.PropertyImageURL4 = fileName4 = fileName4 + DateTime.Now.ToString("yymmssfff") + extension;
                string path4 = Path.Combine(wwwRootPath + "/image/", fileName4);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await Master.PropertyImage4.CopyToAsync(fileStream);
                }
                Master.PropertyImage4 = null;

                string fileName5 = Path.GetFileNameWithoutExtension(Master.PropertyImage5.FileName);
                string extension5 = Path.GetExtension(Master.PropertyImage5.FileName);
                Master.PropertyImageURL5 = fileName5 = fileName5 + DateTime.Now.ToString("yymmssfff") + extension;
                string path5 = Path.Combine(wwwRootPath + "/image/", fileName5);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await Master.PropertyImage5.CopyToAsync(fileStream);
                }
                Master.PropertyImage5 = null;



                var Master3 = new PropertyBidCreateDTO()
                {
                    Property = Master,
                    bid = Master2


                };


                var response = await _bidService.CreateAsync<APIResponse>(Master3, HttpContext.Session.GetString(SD.SessionToken));

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Property created successfully!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    if (response.ErrorsMessages.Count > 0)
                    {
                        ModelState.AddModelError("ErrorMessages", response.ErrorsMessages.FirstOrDefault());
                    }
                }
            }
            return View(model);
        }
        public async Task<IActionResult> Update(int BidId)
                {
            var response = await _bidService.GetAsync<APIResponse>(BidId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                BidsUpdateDTO model = JsonConvert.DeserializeObject<BidsUpdateDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(BidsUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                TempData["success"] = "Rent Updated successfully!";
                var response = await _bidService.UpdateAsync<APIResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            TempData["error"] = "Error Occured!";
            return View(model);
        }
        public async Task<IActionResult> Delete(int BidId)
        {
            var response = await _bidService.GetAsync<APIResponse>(BidId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                BidsDTO model = JsonConvert.DeserializeObject<BidsDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(BidsDTO model)
        {


            var response = await _bidService.DeleteAsync<APIResponse>(model.BidId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Property Deleted successfully!";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "Error Occured!";
            return View(model);

        }
        public async Task<IActionResult> Details(int BidId)
        {
            BidShowDTO dto = new();
            var response = await _bidService.GetAsync<APIResponse>(BidId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                dto = JsonConvert.DeserializeObject<BidShowDTO>(Convert.ToString(response.Result));
                return View(dto);
            }
            else
            {
                if (response.ErrorsMessages.Count > 0)
                {
                    ModelState.AddModelError("ErrorMessages", response.ErrorsMessages.FirstOrDefault());
                }
                else
                {
                    ModelState.AddModelError("ErrorMessages", "Error");
                }
                TempData["error"] = response.ErrorsMessages.FirstOrDefault();
            }
            return NotFound();
        }
    }
}