using HttpRequestControl.EppExcel.Abstract;
using HttpRequestControl.Result.Abstract;
using HttpRequestControl.Result.Concrete;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequestControl.EppExcel.Concrete
{
    public class EppExcelSev : IEppExcelSeve
    {
        public async Task<IResult<List<string[]>>> ESeveExcelFileStartupAsync(List<string[]> models, string path)
        {
            try
            {

                IResult<FileInfo> resultCreate = await this.CreateExcelFileAsync(path);

                if (resultCreate.Status == false)
                {
                    throw new Exception(resultCreate.Message);
                }

                IResult<List<string[]>> resultSeve = await this.SeveExcelFileAsync(models, resultCreate.Data);

                if (resultSeve.Status == false)
                {
                    throw new Exception(resultCreate.Message);
                }

                return new Result<List<string[]>>(true, resultSeve.Message, models);
            }
            catch (Exception exception)
            {
                return new Result<List<string[]>>(false, exception.Message, models);
            }
        }


        public async Task<IResult<List<string[]>>> SeveExcelFileAsync(List<string[]> models, FileInfo fileInfo)
        {
            try
            {
                using (ExcelPackage package = new ExcelPackage(fileInfo))
                {
                    int rows = models.Count();
                    int columns = models[0].Count();

                    var ws = package.Workbook.Worksheets.Add("workbook");

                    var range = ws.Cells["A1"].LoadFromArrays(models);
                    range.AutoFitColumns();

                    await package.SaveAsync();
                }

                return new Result<List<string[]>>(true, "Kayıt işlemi başarılı !",models);

            }
            catch (Exception exception)
            {
                return new Result<List<string[]>>(false, exception.Message,models);
            }
        }

        

        public async Task<IResult<FileInfo>> CreateExcelFileAsync(string path)
        {
            try
            {
                if (string.IsNullOrEmpty(path))
                {
                    throw new Exception("Lütfen biz dosya adı giriniz !");
                }

                path.Replace(@"\", "/");
                string[] newFileName = path.Split('.');
                var newPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + newFileName[0]+".xlsx";
                FileInfo file = new FileInfo(newPath);

                if (file.Exists == true)
                {
                    file.Delete();
                    Console.WriteLine("Dosya zaten var eski dosya silindi !");

                }

                return new Result<FileInfo>(true, path + "- Dosya oluşturuldu", file);


            }
            catch (Exception exception)
            {
                return new Result<FileInfo>(false, exception.Message);
            }
        }

       
    }
}
