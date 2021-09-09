using HttpRequestControl.Result.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequestControl.EppExcel.Abstract
{
    public interface IEppExcelSeve
    {
        Task<IResult<FileInfo>> CreateExcelFileAsync(string path);
        Task<IResult<List<string[]>>> SeveExcelFileAsync(List<string[]> models, FileInfo fileInfo);
        Task<IResult<List<string[]>>> ESeveExcelFileStartupAsync(List<string[]> models, string path);
    }
}
