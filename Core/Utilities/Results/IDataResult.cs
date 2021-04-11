using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult
    {
        T Data { get; }
        // Interface implementasyonu işleyişi, IDataResult IResult'ın bütün işlemlerini yapar, ek olarak bu sayfada yazılı olanları da yapar.
    }
}
