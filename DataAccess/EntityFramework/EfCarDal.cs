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

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (CarDbContext context = new CarDbContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.CarBrandName equals b.BrandName
                             join co in context.Colors on c.CarColorName equals co.ColorName
                             join br in context.Brands on c.CarBrandId equals br.BrandId
                             join col in context.Colors on c.CarColorId equals col.ColorId
                             select new CarDetailDto
                             {
                                 CarId=c.CarId,
                                 BrandId=br.BrandId,
                                 ColorId=col.ColorId,
                                 BrandName = b.BrandName,
                                 CarName = c.CarName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.CarDailyPrice,
                                 CarImage = (from i in context.CarImages
                                            where (c.CarId == i.CarId)
                                             select new CarImage { CarId = i.CarId, Date = i.Date, Id = i.Id, ImagePath = i.ImagePath }).ToList()
                             };
            return filter == null ? result.ToList() : result.Where(filter).ToList();
        }
        }
    }
}
