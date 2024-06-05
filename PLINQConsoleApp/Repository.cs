using PLINQConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLINQConsoleApp
{
    public class Repository
    {
        public static void GetNames()
        {
            AdventureWorks2022Context context = new AdventureWorks2022Context();

            var products = from p in context.Products.AsParallel()
                           where p.ListPrice > 100
                           select p;


            products.ForAll((item) =>
            {
                Console.WriteLine(item.Name);
            });
        }

        public static void GetNamesForAll()
        {
            AdventureWorks2022Context context = new AdventureWorks2022Context();

            context.Products.AsParallel().ForAll((item) =>
            {
                Console.WriteLine(item.Name);
            });
        }

        public static void GetNamesForAll(int islemciSayisi)
        {
            AdventureWorks2022Context context = new AdventureWorks2022Context();

            context.Products.AsParallel().WithDegreeOfParallelism(islemciSayisi).ForAll((item) =>
            {
                Console.WriteLine(item.Name);
            });
        }

        public static void GetNamesForAll(ParallelExecutionMode mode)
        {
            AdventureWorks2022Context context = new AdventureWorks2022Context();

            context.Products.AsParallel().WithExecutionMode(mode).ForAll((item) =>
            {
                Console.WriteLine($"ThreadId :{Thread.CurrentThread.ManagedThreadId}");
                Console.WriteLine(item.Name);
            });
        }

        public static void ExceptionHandle()
        {
            try
            {

                AdventureWorks2022Context context = new AdventureWorks2022Context();

                var products = context.Products.Take(100).ToArray();

                products[3].Name = "##";
                products[5].Name = "##";

                var query = products.AsParallel().Where(IsControl); //exception handle edildi ve işlem devam etti


                query.ForAll(x =>
                {
                    Console.WriteLine($"{x.Name}");
                });
            }
            catch (AggregateException ex)
            {
                ex.InnerExceptions.ToList().ForEach(x =>
                {
                    if (x is IndexOutOfRangeException)
                        Console.WriteLine($"Hata: Array sınırları dışına çıkıldı - {x.Message}");
                    else
                        Console.WriteLine($"Hata: {x.Message}");

                });
            }

        }

        public static bool IsControl(Product p)
        {
            try
            {
                return p.Name[2] == 'a';
            }
            catch (Exception ex)
            {
                Console.WriteLine("Dizi sınırları aşıldı");
                return false;
            }
        }
    }
}
