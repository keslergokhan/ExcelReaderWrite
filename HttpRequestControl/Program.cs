using HttpRequestControl.EppExcel.Abstract;
using HttpRequestControl.EppExcel.Concrete;
using HttpRequestControl.Models;
using HttpRequestControl.Result.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequestControl
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Excel dosya oku      = o");
            Console.WriteLine("Yeniden başlat       = y");
            Console.WriteLine("Çıkış                = c");

            Console.Write("islem :");
            string a = Console.ReadLine();

            if (a.ToLower().Equals("o"))
            {
                ExcelReadFileMain excelReadFileMain = new ExcelReadFileMain();
                await excelReadFileMain.SetupAsync();
            }
            else if (a.ToLower().Equals("y"))
            {
                System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
            }
            else if (a.ToLower().Equals("c"))
            {
                Environment.Exit(0);
            }
            else
            {
                System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                Environment.Exit(0);
            }

            Console.ReadLine();
        }
    }
}
