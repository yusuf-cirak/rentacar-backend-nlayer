using Business.Abstract;
using Entities.Concrete;
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
    public class RentalsController : ControllerBase
    {
        IRentalsService _rentalService;

        public RentalsController(IRentalsService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("Add")]

        public IActionResult Add(Rentals rent)
        {
            var result = _rentalService.Add(rent);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("Update")]

        public IActionResult Update(Rentals rent)
        {
            var result = _rentalService.Update(rent);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("Delete")]

        public IActionResult Delete(Rentals rent)
        {
            var result = _rentalService.Delete(rent);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAll")]

        public IActionResult GetAll()
        {
            Thread.Sleep(3);
            var result = _rentalService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetByBrandName")]

        public IActionResult GetByBrandName(int brandName)
        {
            var result = _rentalService.GetByBrandName(brandName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
