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
    public class PropertyController : Controller
    {
        private readonly IPropertyService _PropertyService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment webHostEnvironment;
        public PropertyController(IPropertyService PropertyService, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _PropertyService = PropertyService;
            _mapper = mapper;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<ViewResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
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

            List<PropertyDTO> list = new();

            var response = await _PropertyService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<PropertyDTO>>(Convert.ToString(response.Result));
            }

            var students = from s in list
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.City.Contains(searchString));

            }
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.Price);
                    break;

                default:  // Name ascending 
                    students = students.OrderBy(s => s.Price);
                    break;
            }

            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View(students.ToPagedList(pageNumber, pageSize));
        }
        [Authorize]
        public async Task<IActionResult> Create()
        {

            return View();
        }
        [Authorize]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PropertyCreateDTO model)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = webHostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(model.PropertyMainImage.FileName);
                string extension = Path.GetExtension(model.PropertyMainImage.FileName);
                model.PropertyMainImageURL = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await model.PropertyMainImage.CopyToAsync(fileStream);
                }
                model.PropertyMainImage = null;



                var response = await _PropertyService.CreateAsync<APIResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
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
            TempData["error"] = "Error Occured!";
            return View(model);

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Update(int Propertyid)
        {
            var response = await _PropertyService.GetAsync<APIResponse>(Propertyid, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                PropertyDTO model = JsonConvert.DeserializeObject<PropertyDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(PropertyDTO model)
        {
            if (ModelState.IsValid)
            {
                TempData["success"] = "Property Updated successfully!";
                var response = await _PropertyService.UpdateAsync<APIResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            TempData["error"] = "Error Occured!";
            return View(model);
        }

        public async Task<IActionResult> Delete(int Propertyid)
        {
            var response = await _PropertyService.GetAsync<APIResponse>(Propertyid, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                PropertyDTO model = JsonConvert.DeserializeObject<PropertyDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(PropertyDTO model)
        {


            var response = await _PropertyService.DeleteAsync<APIResponse>(model.PropertyId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Property Deleted successfully!";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "Error Occured!";
            return View(model);

        }
        public async Task<IActionResult> Details(int Propertyid)
        {
            //PropertyDTO dto = new();
            var response = await _PropertyService.GetAsync<APIResponse>(Propertyid, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                PropertyDTO model = JsonConvert.DeserializeObject<PropertyDTO>(Convert.ToString(response.Result));
                return View(model);
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
