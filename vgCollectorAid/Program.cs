using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace vgCollectorAid
{
    class Program
    {
        class Sites
        {
            public string Site { get; set; }
            public int NoOfEntries { get; set; }
            public Regex RxString { get; set; }
        }

        static void Main(string[] args)
        {
            
            Regex gogRX = new Regex(
                @"(?<=product.title\"">)[\w\d\s:,\[\]\u2122\-\+\(\)\'\""]*(?=<\/span>)", 
                RegexOptions.Compiled);
            Regex steamRX = new Regex(
                @"(?<=>)(.*)(?=<)", 
                RegexOptions.Compiled);
            Regex originRX = new Regex(
                @"(?<=alt=\"")(.*)(?=\""\sng-src)", 
                RegexOptions.Compiled);

            Sites site1 = new Sites { Site = "GOG", RxString = gogRX };
            Sites site2 = new Sites { Site = "Steam", RxString = steamRX };
            Sites site3 = new Sites { Site = "Origin", RxString = originRX };
            List<Sites> listOfSites = new List<Sites>
            {
                site1,
                site2,
                site3
            };


            foreach (Sites site in listOfSites)
            {
               // Console.WriteLine("Now processing page from {0} using regex\n{1}",
               //     site.Site,site.RxString);

                site.NoOfEntries = SearchThing(site.Site,site.RxString);
                Console.WriteLine("You have {0} entries on {1}",site.NoOfEntries,site.Site);
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to exit this window");
            Console.Read();
        }

        static int SearchThing(string site, Regex rxPattern)
        {
            string searchString = null;

            if (site == "GOG")
            {
                searchString = "product-title__text";
            }
            else if (site == "Steam")
            {
                searchString = "gameListRowItemName";
            }
            else if (site == "Origin")
            {
                searchString = "tealium-gametile-img";
            }
            else
            {
                Console.WriteLine("This is not supposed to show up, " +
                    "something horrible went wrong!");
                return 0;
            }
            try
            {   
                using (StreamReader sr = new StreamReader(
                    String.Format("{0}.html",site.ToLower())))
                {
                    using (StreamWriter sw = new StreamWriter(
                        String.Format("{0}List.txt", site.ToLower())))
                    {
                        Console.WriteLine("Now reading " + String.Format("{0}.html", site.ToLower()));
                        string line = "";
                        int i = 0;
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (line.Contains(searchString))
                            {
                                sw.WriteLine(rxPattern.Match(line).Value);
                                i++;
                           }
                        }
                        return i;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);

                return 0;
            }
        }
    }
}
