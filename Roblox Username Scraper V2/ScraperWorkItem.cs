using BlackHen.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace Roblox_Username_Scraper_V2
{
    public class ScraperWorkItem : WorkItem
    {
        private int ID = 1;
        public int To = 0;
        public int ThreadID = 0;

        public class Profile
        {
            public string Username { get; set; }
            public string JoinDate { get; set; }

            public string PlaceVisits { get; set; }
        }

        public override void Perform()
        {
            int totalTimes = 0;
            while (ID < To)
            {
                try
                {
                    if (totalTimes == 0)
                    {
                        Extension.ScrapeExt.ProgID = ID;
                        Console.WriteLine("test");
                    }
                    else
                        ID = Extension.ScrapeExt.ProgID + 1;

                    string url = $"https://www.roblox.com/users/{ID}/profile";
                    HtmlDocument doc = new HtmlWeb().Load(url);
                    HtmlNodeCollection col = doc.DocumentNode.SelectNodes("//div[@class='header-title']//h2");

                    if (col.First() != null && Regex.IsMatch(col.First().InnerText, @"^[a-zA-Z0-9_]+$") && !col.First().InnerText.Contains(' '))
                    {
                        Profile user = new Profile()
                        {
                            Username = col.First().InnerText,
                            JoinDate = null,
                            PlaceVisits = null,
                        };

                        if (Extension.ScrapeExt.profiles.Any(x => x.Username == user.Username))
                        {
                            Colorful.Console.WriteLine("Duplicate!", System.Drawing.Color.Red);
                        }
                        else
                        {
                            Extension.ScrapeExt.profiles.Add(user);

                            Colorful.Console.WriteLine(user.Username, System.Drawing.Color.Orange);
                        }
                        Extension.ScrapeExt.ProgID++;
                        totalTimes++;
                    }
                }
                catch
                {
                    Extension.ScrapeExt.ProgID++;
                    totalTimes++;
                }
                Console.Title = ID.ToString();
            }
            Colorful.Console.WriteLine("Thread Finished!", System.Drawing.Color.Lime);
        }
    }
}