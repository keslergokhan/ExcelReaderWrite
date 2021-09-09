using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HttpRequestControl.Result.Abstract;

namespace HttpRequestControl.Result.Concrete
{
    public class Result<T> : IResult<T>
    {
        public bool Status { get; }
        public string Message { get; }
        public T Data { get; }

        public Result(bool status)
        {
            this.Status = status;
        }

        public Result(string message)
        {
            this.Message = message;
        }

        public Result(bool status, string message) : this(status)
        {
            this.Message = message;
        }

        public Result(bool status, string message, T Data) : this(status)
        {
            this.Message = message;
            this.Data = Data;
        }

       
    }
}
