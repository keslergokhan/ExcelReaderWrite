using HttpRequestControl.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequestControl.EppExcel.Abstract
{
    public interface IExcelDataModelConvert<T> where T:class,new()
    {
        IResult<List<T>> ConvertData(IList<string[]> list);
    }
}
