using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success, string message):this(success)
        {
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }
        // Overload yaparak 2 ctor yazdık. this(success) komutu ile 11. satırdaki ctor çalıştıktan hemen sonra diğerinin de çalışmasını sağlamış oluyoruz.
        public bool Success { get; }

        public string Message { get; }
    }
}
