using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
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

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            if (DateTime.Now.Hour==22)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }

        public IDataResult<List<ProductDetailDto>> GetAllDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_carDal.GetAllDetails());
        }

        public IDataResult<Car> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.CarBrandId == brandId));
        }

        public IDataResult<Car> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarColorId == colorId));
        }

        public IDataResult<Car> GetCarsByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarDailyPrice > 0));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            if (DateTime.Now.Hour==22)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            return new SuccessResult(Messages.CarUpdated);

        }
    }
}
