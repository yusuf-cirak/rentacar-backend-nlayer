﻿using Business.Abstract;
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
    public class RentalsManager : IRentalsService
    {
        IRentalsDal _rentalDal;

        public RentalsManager(IRentalsDal rentalDal)
        {
            _rentalDal = rentalDal;
        }


        [ValidationAspect(typeof(RentalsValidator))]
        public IResult Add(Rentals rent)
        {
            _rentalDal.Add(rent);
            return new SuccessResult(Messages.CarRented);
        }

        public IResult Delete(Rentals rent)
        {
            _rentalDal.Delete(rent);
            return new SuccessResult(Messages.RentDeleted);
        }

        public IDataResult<List<Rentals>> GetAll()
        {

            return new SuccessDataResult<List<Rentals>>(_rentalDal.GetAll(),Messages.CarRentsListed);
        }

        public IDataResult<Rentals> GetByBrandName(int brandName)
        {
            return new SuccessDataResult<Rentals>(_rentalDal.Get(r => r.BrandName == brandName));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(),Messages.RentDetailsListed);
        }

        public IResult Update(Rentals rent)
        {
            _rentalDal.Update(rent);
            return new SuccessResult(Messages.RentUpdated);
        }
    }
}
