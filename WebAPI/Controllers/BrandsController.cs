using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        //Loosely coupled = Gevşek (soyuta) bağımlılık. Manager'ımızı değiştirirsek herhangi bir sorunla karşılaşmayız.
        // IoC Container = Inversion of Controller = Değişimin kontrol edilmesi
        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("GetAll")] // "GetAll" işlemi sayesinde Postman'de linkin yanına /GetAll ekleyip istediğimiz parametreyi çalıştırabiliyoruz.
        
        public IActionResult GetAll()
        {
            Thread.Sleep(3);
            var result = _brandService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetBrandById")]
        public IActionResult GetBrandById(int id)
        {
            var result = _brandService.GetBrandById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }
    }
}
