using AutoMapper;
using DynacityFront.DTO;
using DynacityFront.Models;
using DynacityFront.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PagedList;
using System.Diagnostics;
using Utility;

namespace DynacityFront.Controllers
{
    public class HomeController : Controller
    {

        private readonly IPropertyService _PropertyService;
        private readonly IMapper _mapper;
        public HomeController(IPropertyService PropertyService, IMapper mapper)
        {
            _PropertyService = PropertyService;
            _mapper = mapper;
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
                students = students.Where(s => s.City.Equals(searchString));

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

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(students.ToPagedList(pageNumber, pageSize));
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Services()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}