using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequestControl.Result.Abstract
{
    public interface IResult<T>
    {
        bool Status { get; }
        string Message { get; }
        T Data { get; }

    }
}
