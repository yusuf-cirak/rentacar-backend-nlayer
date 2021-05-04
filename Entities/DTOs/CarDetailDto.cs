using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarDetailDto: IDto
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public int CarBrandId { get; set; }
        public string CarBrandName { get; set; }
        public int CarColorId { get; set; }
        public string CarColorName { get; set; }
        public int CarModelYear { get; set; }
        public decimal CarDailyPrice { get; set; }
        public string CarDescription { get; set; }
        public List<CarImage> CarImage { get; set; }
    }
}
