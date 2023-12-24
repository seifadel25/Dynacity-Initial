using AutoMapper;
using DynacityFront.DTO;
using DynacityFront.Models;
using DynacityFront.Services.IServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Utility;

namespace DynacityFront.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _EventService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment webHostEnvironment;

        public EventController(IEventService EventService, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _EventService = EventService;
            _mapper = mapper;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            List<EventDTO> list = new();
            var response = await _EventService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<EventDTO>>(Convert.ToString(response.Result));
            }

            return View(list);
        }
        public async Task<IActionResult> Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventCreateDTO dto)
        {
            if (ModelState.IsValid)
            {
                var Master = new EventCreateDTO()
                {
                    EventName = dto.EventName,
                    StartDate = dto.StartDate,
                    EndDate = dto.EndDate,
                    Description = dto.Description,
                    Address = dto.Address,
                    EventUrl = dto.EventUrl,
                    EventPhotoURL = dto.EventPhotoURL,
                    EventPhoto = dto.EventPhoto
                };
                string wwwRootPath = webHostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(Master.EventPhoto.FileName);
                string extension = Path.GetExtension(Master.EventPhoto.FileName);
                Master.EventPhotoURL = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await Master.EventPhoto.CopyToAsync(fileStream);
                }
                Master.EventPhoto = null;

                var response = await _EventService.CreateAsync<APIResponse>(Master);
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

            return View(dto);

        }
        public async Task<IActionResult> Update(int Eventid)
        {
            var response = await _EventService.GetAsync<APIResponse>(Eventid);
            if (response != null && response.IsSuccess)
            {
                EventUpdateDTO model = JsonConvert.DeserializeObject<EventUpdateDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(EventUpdateDTO model)
        {
            if (ModelState.IsValid)
            {

                var response = await _EventService.UpdateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);

        }
        public async Task<IActionResult> Delete(int Eventid)
        {
            var response = await _EventService.GetAsync<APIResponse>(Eventid);
            if (response != null && response.IsSuccess)
            {
                EventUpdateDTO model = JsonConvert.DeserializeObject<EventUpdateDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(EventUpdateDTO model)
        {


            var response = await _EventService.DeleteAsync<APIResponse>(model.EventId);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(model);

        }
        public async Task<IActionResult> Details(int Eventid)
        {
            //PropertyDTO dto = new();
            var response = await _EventService.GetAsync<APIResponse>(Eventid);
            if (response != null && response.IsSuccess)
            {
                EventDTO model = JsonConvert.DeserializeObject<EventDTO>(Convert.ToString(response.Result));
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
