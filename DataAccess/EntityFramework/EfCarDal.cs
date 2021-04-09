using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarDbContext>, ICarDal
    {
        public List<ProductDetailDto> GetAllDetails()
        {
            using (CarDbContext context=new CarDbContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.CarBrandId equals b.BrandId
                             join co in context.Colors on c.CarColorId equals co.ColorId
                             select new ProductDetailDto
                             {
                                 BrandName = b.BrandName,
                                 CarName = c.CarName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.CarDailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
