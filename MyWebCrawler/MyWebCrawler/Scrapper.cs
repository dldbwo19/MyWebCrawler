using HtmlAgilityPack;
using Svg;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace MyWebCrawler
{
    class Scrapper
    {
        public enum ColName
        {
            NUMBER = 0,
            NAME,
            POSITION,
            NATIONALITY,
            APPEARANCES,
            CLEANSHEETS,
            GOALS
        };

        private const string _FURL = "https://www.premierleague.com";

        public static Dictionary<string, Dictionary<string, string>> GetAllMenu()
        {
            var document = new HtmlWeb().Load(_FURL + "/clubs");
            var xPath = "//*[@id='mainContent']/div[2]/div/div/div[1]/div/ul/li[*]";
            var nodes = document.DocumentNode.SelectNodes(xPath).ToArray();

            var team = new Dictionary<string, Dictionary<string, string>>();

            foreach (var node in nodes)
            {
                HtmlNode nodeLink = node.SelectSingleNode("./a");
                string link = (nodeLink.Attributes["href"].Value).Replace("overview", "squad");

                nodeLink = nodeLink.SelectSingleNode("./div[3]/div[2]");
                string teamName = nodeLink.SelectSingleNode("./h4").InnerText;
                string homeField = nodeLink.SelectSingleNode("./div").InnerText;

                var teamItems = new Dictionary<string, string>();

                teamItems.Add("HOME FIELD", homeField);
                teamItems.Add("TEAM PAGE", link);

                team.Add(teamName, teamItems);
            }
            return team;
        }

        public static string GetLogoUrl(string bUrl)
        {
            HtmlDocument httpDocument = new HtmlWeb().Load(_FURL + bUrl);
            string xPath = "//*[@id='mainContent']/header/div[2]/div/div/div[1]/picture/img";
            string logoUrl = "https:" + httpDocument.DocumentNode.SelectSingleNode(xPath).Attributes["src"].Value;

            return logoUrl;
        }

        public static List<Dictionary<string, string>> GetActress(string bUrl)
        {
            HtmlDocument document = new HtmlWeb().Load(_FURL + bUrl);

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

                        if (count == 0)
                        {
                            result = String.Format($"{Convert.ToInt32(result):D2}");
                        }

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
            return teamPlayers;
        }
    }
}
