using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskConsoleApp.Classes
{
    public class Content
    {
        public string Site { get; set; }
        public int Length { get; set; }

        public static async Task<Content> GetContentAsync(string url)
        {
            Content content = new Content();
            var data = await new HttpClient().GetStringAsync(url);
            content.Site = url;
            content.Length = data.Length;

            Console.WriteLine($"GetContentAsync thread: {Thread.CurrentThread.ManagedThreadId}");
            return content;
        }
    }
}
