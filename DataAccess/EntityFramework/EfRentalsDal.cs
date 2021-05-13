using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfRentalsDal : EfEntityRepositoryBase<Rentals, CarDbContext>, IRentalsDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarDbContext context= new CarDbContext())
            {
                var result= from r in context.Rentals
                            join c in context.Cars on r.CarId equals c.CarId
                            join co in context.Colors on c.CarColorId equals co.ColorId
                            join b in context.Brands on c.CarBrandId equals b.BrandId
                            join cu in context.Customers on r.CustomerId equals cu.UserId
                            join u in context.Users on r.CustomerId equals u.Id

                            select new RentalDetailDto {
                            Id = r.Id,
                                 DailyPrice = c.CarDailyPrice,
                                 CarName = c.CarDescription,
                                 ColorName = co.ColorName,
                                 BrandName = b.BrandName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 CustomerFirstName = u.FirstName,
                                 CustomerLastName = u.LastName,
                                 CustomerCompanyName = cu.CompanyName


                             };
            return result.ToList();

        }
        }
    }
}
