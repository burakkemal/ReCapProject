using Business.Abstract;
using Business.Constants;
using Core.Utilities.FileHelper;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll(int carId)
        {
            var result = _carImageService.GetAll(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById([FromForm(Name = ("Id"))] int id)
        {
            var result = _carImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbycarid")]
        public IActionResult GetByCarId([FromForm(Name = ("CarId"))] int carId)
        {
            var result = _carImageService.GetByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm(Name = ("CarId"))] int carId)
        {
            if (!FileManagament.CheckImageFile(file))
            {
                return BadRequest(Messages.InvalidImagetype);
            }
            string newImageName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var result = _carImageService.Add(new CarImage { CarId = carId, ImagePath = newImageName });
            if (result.Success)
            {
                FileManagament.AddImageFile(file, @"wwwroot\uploads", newImageName);
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete([FromForm(Name = ("Id"))] int id)
        {
            var result = _carImageService.GetById(id);
            if (result.Success)
            {
                FileManagament.DeleteImageFile(@"wwwroot\uploads\", result.Data.ImagePath);
                var deleteImage = _carImageService.Delete(new CarImage { Id = id });
                if (deleteImage.Success)
                {
                    return Ok(deleteImage);
                }
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm(Name = ("Id"))] int carId, int carImageId)
        {
            if (!FileManagament.CheckImageFile(file))
            {
                return BadRequest("Resim formatı hatalı");
            }
            else
            {
                var image = _carImageService.GetAll(carId).Data.Where(x => x.Id == carImageId).FirstOrDefault();
                string fileName = image.ImagePath;
                var result = _carImageService.Update(new CarImage
                {
                    Id = carImageId,
                    CarId = carId,
                    ImagePath = fileName
                });
                if (result.Success)
                {
                    FileManagament.AddImageFile(file, @"wwwroot\uploads", fileName);
                    System.IO.File.Delete(fileName);
                    return Ok(result);
                } 
                return BadRequest(result);
            }
           
        }
    }
}
