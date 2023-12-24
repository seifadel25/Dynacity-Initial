using AutoMapper;
using DynacityFront.DTO;
using DynacityFront.Models;
using DynacityFront.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DynacityFront.Controllers
{
    public class UserController : Controller
    {
        private readonly IDynacityService _dynacityService;
        private readonly IMapper _mapper;
        public UserController(IDynacityService dynacityService, IMapper mapper)
        {
            _dynacityService = dynacityService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<UserDTO> list = new();
            var response = await _dynacityService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<UserDTO>>(Convert.ToString(response.Result));
            }

            return View(list);
        }
        public async Task<IActionResult> Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCreateDTO model)
        {
            if (ModelState.IsValid)
            {

                var response = await _dynacityService.CreateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);

        }
        public async Task<IActionResult> Update(int Userid)
        {
            var response = await _dynacityService.GetAsync<APIResponse>(Userid);
            if (response != null && response.IsSuccess)
            {
                UserDTO model = JsonConvert.DeserializeObject<UserDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UserDTO model)
        {
            if (ModelState.IsValid)
            {

                var response = await _dynacityService.UpdateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);

        }
    }
}
