using HttpRequestControl.EppExcel.Abstract;
using HttpRequestControl.EppExcel.Concrete;
using HttpRequestControl.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequestControl
{
    public class ExcelReadFileMain
    {
        public async Task SetupAsync() {

            Console.Write("Okunacak dosya : ");
            var read = Console.ReadLine();
            IEppExcelReader eppExcelReader = new EppExcelReader();
            IResult<List<string[]>> resultRender = await eppExcelReader.EppExcelRenderStartupAsync(read);

            Console.WriteLine(resultRender.Message);
        }
    }
}
