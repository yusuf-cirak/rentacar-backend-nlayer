using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.InMemoryConcrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1,CarBrandName="Hyundai",CarColorName="Mavi",CarModelYear=2020,CarDailyPrice=200000,CarDescription="Hyundai i20"},
                new Car{CarId=2,CarBrandName="Hyundai",CarColorName ="Mavi",CarModelYear=2018,CarDailyPrice=150000,CarDescription="Hyundai i10"},
                new Car{CarId=3,CarBrandName="Volkswagen",CarColorName="Mavi",CarModelYear=2016,CarDailyPrice=250000,CarDescription="Volkswagen Passat"},
                new Car{CarId=4,CarBrandName="KIA",CarColorName="Kırmızı",CarModelYear=2015,CarDailyPrice=230000,CarDescription="KIA Sportage"},
                new Car{CarId=5,CarBrandName="Seat",CarColorName="Kırmızı",CarModelYear=2010,CarDailyPrice=120000,CarDescription="Seat Leon"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetAllDetails()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int CarId)
        {
            return _cars.Where(c => c.CarId == CarId).ToList();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.CarBrandName = car.CarBrandName;
            carToUpdate.CarColorName = car.CarColorName;
            carToUpdate.CarModelYear = car.CarModelYear;
            carToUpdate.CarDailyPrice = car.CarDailyPrice;
            carToUpdate.CarDescription = car.CarDescription;
        }

        Car IEntityRepository<Car>.Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
