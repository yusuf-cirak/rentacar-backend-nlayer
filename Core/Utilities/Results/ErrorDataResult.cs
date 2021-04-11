using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T>:DataResult<T>
    {
        public ErrorDataResult(T data, string message): base (data,false,message)
        {
            // Data ver, mesaj ver
        }
        public ErrorDataResult(T data):base(data,false)
        {
            // Sadece data ver
        }

        public ErrorDataResult(string message):base(default,false,message)
        {
            // Sadece mesaj ver
        }
        public ErrorDataResult(): base (default,false)
        {
            // İstersen hiçbir şey verme
        }
        // default dataya karşılık gelir. örneğin int'in default'u
    }
}
