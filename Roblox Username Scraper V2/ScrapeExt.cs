using BlackHen.Threading;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Roblox_Username_Scraper_V2.ScraperWorkItem;

namespace Roblox_Username_Scraper_V2.Extension
{
    public static class ScrapeExt
    {
        public static List<Profile> profiles = new List<Profile>();

        public static WorkQueue work;
        public static int ProgID = 1;

        public static void Initialize()
        {
            work = new WorkQueue();
            work.ConcurrentLimit = 1000;
            work.CompletedWorkItem += Work_CompletedWorkItem;
        }

        private static void Work_CompletedWorkItem(object sender, WorkItemEventArgs e)
        {
            Console.WriteLine("Item Completed!\n");
        }

        public static void StartScrape(int Threads, int From, int To)
        {
            ProgID = From;
            lock (work)
            {
                for (int i = 0; i < Threads; ++i)
                    work.Add(new ScraperWorkItem()
                    {
                        To = To,
                        ThreadID = i,
                    });
            }
        }
    }
}