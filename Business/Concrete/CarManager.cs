using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.CarDescription.Length>2 && car.CarDailyPrice>0)
            {
                _carDal.Add(car);
                Console.WriteLine("Araç sisteme eklendi.");
            }
            else
            {
                Console.WriteLine("Sisteme eklenecek aracın açıklaması ve fiyatı geçersizdir.");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("Araç sistemden silindi.");
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<ProductDetailDto> GetAllDetails()
        {
            return _carDal.GetAllDetails();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.CarBrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.CarColorId == colorId);
        }

        public List<Car> GetCarsByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(c => c.CarDailyPrice > 0);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
