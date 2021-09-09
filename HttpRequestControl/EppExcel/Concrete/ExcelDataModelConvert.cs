using HttpRequestControl.EppExcel.Abstract;
using HttpRequestControl.Models;
using HttpRequestControl.Result.Abstract;
using HttpRequestControl.Result.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequestControl.EppExcel.Concrete
{
    public class ExcelDataModelConvert<T> : IExcelDataModelConvert<T> where T : class, new()
    {

        
        public IResult<List<T>> ConvertData(IList<string[]> list)
        {

            List<T> DataList = new List<T>();
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));

            try
            {
                foreach (var row in list)
                {
                    int i = 0;
                    T Data = new T();
                    foreach (PropertyDescriptor p in properties)
                    {

                        PropertyDescriptorCollection d = TypeDescriptor.GetProperties(Data);

                        d[p.Name].SetValue(Data, Convert.ChangeType(row[i], p.PropertyType));
                        i++;

                    }
                    DataList.Add(Data);
                }

                return new Result<List<T>>(status: true,"Dönüştürme işlemi başarılı",Data:DataList);
            }
            catch (Exception exception)
            {

                return new Result<List<T>>(status:false,"Teknik bir problem oluştu = "+exception.Message);
            }


        }
    }
}
