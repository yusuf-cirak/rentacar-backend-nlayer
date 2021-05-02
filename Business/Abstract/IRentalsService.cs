using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalsService
    {
        IResult Add(Rentals rent);
        IResult Update(Rentals rent);
        IResult Delete(Rentals rent);
        IDataResult<List<Rentals>> GetAll();
        IDataResult<Rentals> GetByBrandName(int brandName);
    }
}
