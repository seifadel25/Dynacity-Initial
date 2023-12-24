using AutoMapper;
using DynacityFront.DTO;
using DynacityFront.Models;
using DynacityFront.Services.IServices;
using DynacityFront.ViewModel.PropertyPhotoViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utility;

namespace DynacityFront.Controllers
{
    public class PPVMController : Controller
    {
        private readonly IPropertyService _PropertyService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment webHostEnvironment;
        public PPVMController(IPropertyService PropertyService, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _PropertyService = PropertyService;
            _mapper = mapper;
            this.webHostEnvironment = webHostEnvironment;
        }
        [Authorize]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [Authorize]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PPCreate model)
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
                    Price = model.Property.Price,
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

                var response = await _PropertyService.CreateAsync<APIResponse>(Master, HttpContext.Session.GetString(SD.SessionToken));
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
            //foreach (var i in model.PhotoVM)
            //{
            //    var Detail = new PhotoCreateDTO()
            //    {
            //        //PropertyId=
            //        ImageUrl = i.ImageUrl,
            //        PropertyI = i.PropertyI
            //    };



            //    string wwwRootPath = webHostEnvironment.WebRootPath;
            //    string fileName = Path.GetFileNameWithoutExtension(i.PropertyI.FileName);
            //    string extension = Path.GetExtension(i.PropertyI.FileName);
            //    i.ImageUrl = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            //    string path = Path.Combine(wwwRootPath + "/image/", fileName);
            //    using (var fileStream = new FileStream(path, FileMode.Create))
            //    {
            //        await i.PropertyI.CopyToAsync(fileStream);
            //    }
            //    i.PropertyI = null;


            //    //    var response = await _PropertyService.CreateAsync<APIResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
            //    //    if (response != null && response.IsSuccess)
            //    //    {
            //    //        TempData["success"] = "Property created successfully!";
            //    //        return RedirectToAction(nameof(Index));
            //    //    }
            //    //    else
            //    //    {
            //    //        if (response.ErrorsMessages.Count > 0)
            //    //        {
            //    //            ModelState.AddModelError("ErrorMessages", response.ErrorsMessages.FirstOrDefault());
            //    //        }
            //    //    }
            //    //}
            //    //TempData["error"] = "Error Occured!";
            //}
            return View(model);

        }
    }
}