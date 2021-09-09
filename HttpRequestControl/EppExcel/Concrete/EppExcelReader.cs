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
    public class EppExcelReader : IEppExcelReader
    {

        public async Task<IResult<List<string[]>>> EppExcelRenderStartupAsync(string path = null)
        {
            IResult<List<string[]>> resultData;

            if (string.IsNullOrEmpty(path))
            {
                Console.WriteLine("-- EppExcelRender --\n");
                Console.Write("- Excel File Path = ");
                path = Console.ReadLine();
            }
           

            try
            {
                IResult<FileInfo> resultOpenExcel = await OpenExcelFileAsync(path);

                if (resultOpenExcel.Status == false)
                {
                    throw new Exception(resultOpenExcel.Message);
                }
                
                resultData = await GetExcelDataAsync(resultOpenExcel.Data);

                if (resultData.Status == false)
                {
                    throw new Exception(resultOpenExcel.Message);
                }

                return new Result<List<string[]>>(resultData.Status, resultData.Message,resultData.Data);
            }
            catch (Exception exception)
            {
                return new Result<List<string[]>>(false, exception.Message);
            }

        }


        public async Task<IResult<List<string[]>>> GetExcelDataAsync(FileInfo fileInfo)
        {
            try
            {
                List<string[]> table = new List<string[]>();
                

                using (ExcelPackage package = new ExcelPackage(fileInfo))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
                    int rows = worksheet.Dimension.Rows;
                    int columns = worksheet.Dimension.Columns;
                    Console.WriteLine(string.Format("{0}:Satır -- {1}:Sutun",rows,columns));

                    for (int i = 1; i <= rows; i++)
                    {
                        string datarow = "";
                        string[] columnsList = new string[columns];
                        for (int j = 1; j <= columns; j++)
                        {
                            columnsList[j - 1] = worksheet.Cells[i, j].Value.ToString();
                            datarow += columnsList[j - 1] + "|";
                        }
                        Console.WriteLine(datarow);
                        table.Add(columnsList);
                        
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    }

                }

                return new Result<List<string[]>>(true,"Okuma işlemi bitti !",table);

            }
            catch (Exception exception)
            {
                return new Result<List<string[]>>(false, exception.Message.ToString());
            }
        }

        
        public async Task<IResult<FileInfo>> OpenExcelFileAsync(string path)
        {
            
            try
            {
                if (string.IsNullOrEmpty(path))
                {
                    throw new Exception("Lütfen biz dosya yolu giriniz !");
                }

                path.Replace(@"\","/");
                FileInfo file = new FileInfo(path);

                if (file.Exists != true)
                {
                    string newPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" +path;
                    file = new FileInfo(newPath);
                    if (file.Exists != true)
                    {
                        throw new Exception("Dosya bulunamadı ! = " + path);
                    }
                    
                }else if (file.Extension != ".xlsx" || file.Extension != ".XLSX")
                {
                    throw new Exception("Dosya Uzantısı excel formatında değil ! = " + path);
                }

                return new Result<FileInfo>(true, path + "- Open", file);
               

            }
            catch (Exception exception)
            {
                return new Result<FileInfo>(false, exception.Message);
            }

        }



    }
}
