using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWebCrawler
{
    public partial class Form1 : Form
    {
        private Dictionary<string, Dictionary<string, string>> CmbTeamList = null;
        private List<Dictionary<string, string>> TeamPlayers = null;
        private string LogoUrl = @"http://mblogthumb2.phinf.naver.net/20160529_45/parkshvgb_1464519929129lHpWj_PNG/barclays_premiere_league.png?type=w800";


        public Form1()
        {
            InitializeComponent(); 
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            RenderLogo();
            cmbTeams.SelectedItem = null;
            CmbTeamList = Scrapper.GetAllMenu();

            foreach (var item in CmbTeamList)
            {
                cmbTeams.Items.Add(item.Key);
            }

            this.Cursor = Cursors.Default;

        }

        private void cmbRanks_SelectedValueChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            
            this.Cursor = Cursors.WaitCursor;
            Select_TeamList.Text = cmbTeams.SelectedItem.ToString();
            var team = CmbTeamList[cmbTeams.SelectedItem.ToString()];
            string url = team["TEAM PAGE"];
            LogoUrl = Scrapper.GetLogoUrl(url);
            TeamPlayers = Scrapper.GetActress(url);

            foreach (var playerInfo in TeamPlayers)
            {
                var obj = new List<object>();
                foreach (var info in playerInfo)
                {
                    obj.Add(info.Value);
                }
                dataGridView1.Rows.Add(obj.ToArray());
            }

            RenderLogo();
            this.Cursor = Cursors.Default;
        }

        private void RenderLogo()
        {
            
            WebRequest request = WebRequest.Create(LogoUrl);
            using (var response = request.GetResponse())
            {
                using (var str = response.GetResponseStream())
                {

                    Image image = Bitmap.FromStream(str);
                    pictureBox1.Image = image;
                }
            }
            
        }
    }
}
