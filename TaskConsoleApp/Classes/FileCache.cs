using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskConsoleApp.Classes
{
    public class FileCache
    {
        public static string CacheData { get; set; }

        public static Task<string> GetDataAsync()
        {
            if (string.IsNullOrEmpty(CacheData))
            {
                return File.ReadAllTextAsync("dosya.txt");
            }
            else
            {
                return Task.FromResult<string>(CacheData);
            }
        }
    }
}
