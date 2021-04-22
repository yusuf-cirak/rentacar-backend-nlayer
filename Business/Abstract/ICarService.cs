using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<Car> GetCarsByBrandId(int brandId);
        IDataResult<Car> GetCarsByColorId(int colorId);
        IDataResult<Car> GetCarsByDailyPrice(decimal min, decimal max);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<ProductDetailDto>> GetAllDetails();
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IResult AddTransactionalTest(Car car); // Uygulamalarda tutarlılığı korumak için kullanılan yöntem.
    }
}
