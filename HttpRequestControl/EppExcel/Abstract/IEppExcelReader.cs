using HttpRequestControl.Result.Abstract;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequestControl.EppExcel.Abstract
{
    public interface IEppExcelReader
    {
        Task<IResult<FileInfo>> OpenExcelFileAsync(string path);
        Task<IResult<List<string[]>>> GetExcelDataAsync(FileInfo fileInfo);
        Task<IResult<List<string[]>>> EppExcelRenderStartupAsync(string path = null);
    }
}
