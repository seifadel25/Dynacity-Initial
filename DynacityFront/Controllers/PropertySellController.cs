using AutoMapper;
using DynacityFront.DTO;
using DynacityFront.Models;
using DynacityFront.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PagedList;
using Utility;

namespace DynacityFront.Controllers
{
    public class PropertySellController : Controller
    {
        private readonly ISellService _sellService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment webHostEnvironment;

        public PropertySellController(ISellService sellService, IMapper mapper, IWebHostEnvironment webHost)
        {
            _sellService = sellService;
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
            List<SellShow> list = new();
            var response = await _sellService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<SellShow>>(Convert.ToString(response.Result));
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
        [Authorize]
        public async Task<IActionResult> Create()
        {
            PropertySellDTO bothVM = new PropertySellDTO();

            return View(bothVM);

        }
        [Authorize]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PropertySellDTO model)
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
                    Price = model.Sell.SellPrice,
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

                

            var Master2 = new SellCreateDTO()
                {

                    SellPrice = model.Sell.SellPrice,
                    DatePosted = model.Sell.DatePosted,
                    IsActive = model.Sell.IsActive,
                    SellDiscription = model.Sell.SellDiscription,


                };



                var Master3 = new PropertySellDTO()
                {
                    Property = Master,
                    Sell = Master2


                };


                var response = await _sellService.CreateAsync<APIResponse>(Master3, HttpContext.Session.GetString(SD.SessionToken));
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
        public async Task<IActionResult> Update(int SellId)
        {
            var response = await _sellService.GetAsync<APIResponse>(SellId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                SellUpdateDTO model = JsonConvert.DeserializeObject<SellUpdateDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(SellUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                TempData["success"] = "Rent Updated successfully!";
                var response = await _sellService.UpdateAsync<APIResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            TempData["error"] = "Error Occured!";
            return View(model);
        }
        public async Task<IActionResult> Delete(int SellId)
        {
            var response = await _sellService.GetAsync<APIResponse>(SellId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                SellDTO model = JsonConvert.DeserializeObject<SellDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(SellDTO model)
        {


            var response = await _sellService.DeleteAsync<APIResponse>(model.SellId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Property Deleted successfully!";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "Error Occured!";
            return View(model);

        }
        public async Task<IActionResult> Details(int SellId)
        {
            //SellShow dto = new();
            var response = await _sellService.GetAsync<APIResponse>(SellId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                PropertySellDTO dto = JsonConvert.DeserializeObject<PropertySellDTO>(Convert.ToString(response.Result));
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
