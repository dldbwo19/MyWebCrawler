using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WebScraper
{
    class Program
    {
        public enum ColName
        {
            NUMBER = 0,
            NAME,
            POSITION,
            NATIONALITY,
            APPEARANCES,
            CLEANSHEETS,
            GOALS,
            ASSISTS
        };

        static void Main(string[] args)
        {
            ExtractAllMenu2();
        }
        static void ExtractAllMenu()
        {
            HtmlDocument document = new HtmlWeb().Load("https://www.premierleague.com/clubs");

            string xPath = "//*[@id='mainContent']/div[2]/div/div/div[1]/div/ul/li[*]";
            var nodes = document.DocumentNode.SelectNodes(xPath).ToArray();

            var RankItems = new Dictionary<string, string>();


            foreach (HtmlNode node in nodes)
            {
                HtmlNode nodeLink = node.SelectSingleNode("./a");
                string link = nodeLink.Attributes["href"].Value;

                nodeLink = nodeLink.SelectSingleNode("./div[3]/div[2]");
                string team = nodeLink.SelectSingleNode("./h4").InnerText;
                string homeField = nodeLink.SelectSingleNode("./div").InnerText;

                Console.WriteLine(team + " : " + homeField + " : " + link);

                RankItems.Add(node.InnerText, link);
            }

            Console.ReadLine();


        }

        static void ExtractAllMenu2()
        {
            HtmlDocument document = new HtmlWeb().Load("https://www.premierleague.com/clubs/131/Brighton-and-Hove-Albion/squad");

            string xPath = "//*[@id='mainContent']/div[3]/div/ul/li[*]";
            var nodes = document.DocumentNode.SelectNodes(xPath).ToArray();
            var teamPlayers = new List<Dictionary<string, string>>();
            string result = string.Empty;

            foreach (HtmlNode node in nodes)
            {
                var playerInfo = new Dictionary<string, string>();
                string output = "0" + node.InnerText.Trim().Replace("View Player", string.Empty);
                result = string.Empty;
                Regex regex = new Regex(@"\b[\S]*[\s]{0,1}[\S]*[\s]{0,1}[\S]*[\s]{0,1}[\S]*\b");

                Match m = regex.Match(output);
                int count = 0;


                while (m.Success)
                {
                    result = m.Value;

                    if (result != "" && result != "Nationality" && result != "Appearances" && result != "Clean sheets" && result != "Goals" && result != "Assists")
                    {
                        ColName colStr = (ColName)count;

                        if (count <= 4)
                        {
                            playerInfo.Add(colStr.ToString(), result);
                        }
                        else
                        {
                            switch (playerInfo["POSITION"])
                            {
                                case "Goalkeeper":
                                    if (count == 6 || count == 7)
                                    {
                                        playerInfo.Add(colStr.ToString(), string.Empty);
                                        colStr = (ColName)(++count);
                                        playerInfo.Add(colStr.ToString(), result);
                                    }
                                    else
                                    {
                                        playerInfo.Add(colStr.ToString(), result);
                                    }
                                    break;
                                case "Defender":
                                    if (count == 7)
                                    {
                                        playerInfo.Add(colStr.ToString(), string.Empty);
                                        colStr = (ColName)(++count);
                                        playerInfo.Add(colStr.ToString(), result);
                                    }
                                    else
                                    {
                                        playerInfo.Add(colStr.ToString(), result);
                                    }
                                    break;
                                case "Midfielder":
                                    if (count == 5)
                                    {
                                        playerInfo.Add(colStr.ToString(), string.Empty);
                                        colStr = (ColName)(++count);
                                        playerInfo.Add(colStr.ToString(), result);
                                    }
                                    else
                                    {
                                        playerInfo.Add(colStr.ToString(), result);
                                    }
                                    break;
                                case "Forward":
                                    if (count == 5)
                                    {
                                        playerInfo.Add(colStr.ToString(), string.Empty);
                                        colStr = (ColName)(++count);
                                        playerInfo.Add(colStr.ToString(), result);
                                    }
                                    else
                                    {
                                        playerInfo.Add(colStr.ToString(), result);
                                    }
                                    break;
                            }
                        }
                        count++;
                    }
                    m = m.NextMatch();
                }
                teamPlayers.Add(playerInfo);
            }
            foreach (var item in teamPlayers)
            {
                foreach (var item2 in item)
                {
                    Console.WriteLine(item2.Key + " : " + item2.Value);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
            //return teamPlayers;
        }
    }
}
 