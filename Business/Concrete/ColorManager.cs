using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.BusinessAspects.Autofac;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour == 06)
            {
                return new ErrorDataResult<List<Color>>(_colorDal.GetAll(), Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorsListed);
        }


        public IDataResult<Color> GetColorById(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c=> c.ColorId==colorId));
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            if (DateTime.Now.Hour == 06)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            return new SuccessResult(Messages.ColorUpdated);

        }

        //[SecuredOperation("color.add.auth,admin")]
        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("color.getall")]// Yeni ürün eklendiğinde cache siliniyor yani önceden getall işlemini cache'den yaparken
        // yeni bir ürün eklemesi yapıldıktan sonra getall işleminin bile tekrardan cache'ye eklenmesi gerekir.
        public IResult Add(Color color)
        {

            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);

        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            if (DateTime.Now.Hour == 06)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            return new SuccessResult(Messages.ColorDeleted);
        }

    }
}
