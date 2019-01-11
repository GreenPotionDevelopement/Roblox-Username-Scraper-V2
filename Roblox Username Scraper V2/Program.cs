using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roblox_Username_Scraper_V2.Extension;
using System.Threading;

namespace Roblox_Username_Scraper_V2
{
    internal class Program
    {
        public static List<Thread> threads = new List<Thread>();

        private static void Main(string[] args)
        {
            string p = "asd";
            string s = $"{p}";
            Colorful.Console.Title = "asd";
            ScrapeExt.Initialize();
            ScrapeExt.StartScrape(300, 3000, 3500);
            Colorful.Console.ReadLine();
        }
    }
}