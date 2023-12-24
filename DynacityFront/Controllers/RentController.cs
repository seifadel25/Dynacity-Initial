//using AutoMapper;
//using DynacityFront.DTO;
//using DynacityFront.Models;
//using DynacityFront.Services.IServices;
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;

//namespace DynacityFront.Controllers
//{
//    public class RentController : Controller
//    {
//        private readonly IRentService _RentService;
//        private readonly IMapper _mapper;
//        public RentController(IRentService RentService, IMapper mapper)
//        {
//            _RentService = RentService;
//            _mapper = mapper;
//        }

//        public async Task<IActionResult> Index()
//        {
//            List<RentShowDTO> list = new();
//            var response = await _RentService.GetAllAsync<APIResponse>();
//            if (response != null && response.IsSuccess)
//            {
//                list = JsonConvert.DeserializeObject<List<RentShowDTO>>(Convert.ToString(response.Result));
//            }

//            return View(list);
//        }
//        public async Task<IActionResult> Create()
//        {

//            return View();
//        }
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(PropertyRentCreateDTO dto)
//        {
//            if (ModelState.IsValid)
//            {

//                var response = await _RentService.CreateAsync<APIResponse>(dto);
//                if (response != null && response.IsSuccess)
//                {
//                    return RedirectToAction(nameof(Index));
//                }
//            }

//            return View(dto);

//        }
//        public async Task<IActionResult> Update(int Rentid)
//        {
//            var response = await _RentService.GetAsync<APIResponse>(Rentid);
//            if (response != null && response.IsSuccess)
//            {
//                RentUpdateDTO model = JsonConvert.DeserializeObject<RentUpdateDTO>(Convert.ToString(response.Result));
//                return View(model);
//            }
//            return NotFound();
//        }
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Update(RentDTO model)
//        {
//            if (ModelState.IsValid)
//            {

//                var response = await _RentService.UpdateAsync<APIResponse>(model);
//                if (response != null && response.IsSuccess)
//                {
//                    return RedirectToAction(nameof(Index));
//                }
//            }
//            return View(model);

//        }
//        public async Task<IActionResult> Delete(int Rentid)
//        {
//            var response = await _RentService.GetAsync<APIResponse>(Rentid);
//            if (response != null && response.IsSuccess)
//            {
//                RentDTO model = JsonConvert.DeserializeObject<RentDTO>(Convert.ToString(response.Result));
//                return View(model);
//            }
//            return NotFound();
//        }
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Delete(RentDTO model)
//        {


//            var response = await _RentService.DeleteAsync<APIResponse>(model.RentId);
//            if (response != null && response.IsSuccess)
//            {
//                return RedirectToAction(nameof(Index));
//            }

//            return View(model);

//        }
//    }
//}
