using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace League
{
    public partial class Main : Form
    {
        private string[] league = {};
        private string[] year = {};
        private string[] round = {};

        private string leagueVal = "";
        private string yearVal = "";
        private string roundVal = "";

        public int leagueIndex = 0;
        public int yearIndex = 0;
        public int roundIndex = 0;

        private string roundNo = "";

        private string base_url = "https://api3.sanflstats.com";
        private string currentSite_url = "https://sanfl.com.au/league/matches/";

        private string filePath = string.Empty;

        private Dictionary<string, object> teamInfo = new Dictionary<string, object>();
        private string[] TitleRow = { "League", "Year", "Date", "Time", "Rd", "Venue", "Team", "PLAYER", "#", "D", "G.B", "K", "HB", "M", "CM", "T", "HO", "CL", "I 50S", "R 50S", "DT" };

        private List<string[]> scrapedData = new List<string[]>() { };

        private dynamic initalData = new object();

        private List<RoundItem> roundArray = new List<RoundItem>();

        private dynamic TeamData = new Object();


        private class RoundItem
        {
            public string id { get; set; }
            public string name { get; set; }
        }
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.DisableCount();
            this.DisableFormReady();
            initData();
        }

        private void initData()
        {
            this.GetInitData(); // getJsonData for initial list
            this.InitLeague();
        }

        private async Task GetInitData()
        {
            string htmlstring = string.Empty;
            string url = this.currentSite_url + (li_league.Text != "" ? ("?league=" + this.leagueVal) : "") + (li_year.Text != "" ? ("&season=" + this.yearVal) : "" ) + (li_year.Text != "" ? ("&round=" + this.roundVal) : "");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                htmlstring = reader.ReadToEnd();
            }
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlstring);

            foreach (HtmlNode link in htmlDoc.DocumentNode.SelectNodes("//script"))
            {
                if (link.InnerText.Contains("var themeVars ="))
                {
                    string[] strs = new string[] { "var themeVars ="};
                    strs = link.InnerText.Split(strs, StringSplitOptions.RemoveEmptyEntries);
                    this.initalData = JsonConvert.DeserializeObject<dynamic>(strs[1]);
                }
            }
        }

        private void InitLeague()
        {
            var leagueData = this.initalData.leaguesInfo;
            this.league = new string[leagueData.Count];

            for (int i = 0; i < leagueData.Count; i++)
            {
                this.league[i] = leagueData[i].title;
            }

            li_league.DataSource = this.league;
        }

        private void InitYear()
        {
            //this.GetInitData();
            var yearData = this.initalData.leaguesInfo[li_league.SelectedIndex].seasons;
            this.year = new string[yearData.Count];

            for (int i = 0; i < yearData.Count; i++)
            {
                this.year[i] = yearData[i].title;
            }

            li_year.DataSource = this.year;
        }

        private async Task InitRound()
        {
            await this.GetInitRoundData();
            await this.InitRoundData();
        }

        private async Task InitRoundData()
        {
            List<string> roundData = new List<string>() { };

            for (int j = 0; j < this.roundArray.Count; j++)
            {
                roundData.Add(this.roundArray[j].name);
            }

            li_round.DataSource = roundData;
        }

        private async Task GetInitRoundData()
        {
            this.TeamData = new Object();
            string URL = this.base_url + "/fixtures/" + this.yearVal + "/" + this.leagueVal;

            await Task.Run(() => { this.TeamData = JsonConvert.DeserializeObject<dynamic>(GetAllData(URL)); });

            if (this.TeamData != null)
            {
                List<dynamic> TeamInfo = new List<dynamic>(this.TeamData.matches);
                this.roundArray.Clear();

                for (int i = 0; i < TeamInfo.Count; i++)
                {
                    dynamic roundData = false;
                    if (this.TeamData.matches[i].matchNumber == "1")
                    {
                        if (Convert.ToInt32(this.TeamData.matches[i].roundNumber) < 100)
                        {
                            this.roundArray.Add(new RoundItem { id = this.TeamData.matches[i].roundNumber, name = "Round " + this.TeamData.matches[i].roundNumber });
                        }
                        else
                        {
                            roundData = this.initalData.leaguesInfo[this.leagueIndex].seasons[this.yearIndex].finalsRounds;
                            bool hasRounds = !roundData.Equals(new JValue(false));
                            if (hasRounds)
                            {
                                int index = (Convert.ToInt32(this.TeamData.matches[i].roundNumber) - 100);
                                this.roundArray.Add(new RoundItem { id = this.TeamData.matches[i].roundNumber, name = roundData[index - 1].name });
                            }
                            else
                            {
                                this.roundArray.Add(new RoundItem { id = this.TeamData.matches[i].roundNumber, name = "Finals Week " + (Convert.ToInt32(this.TeamData.matches[i].roundNumber) - 100) });
                            }
                        }
                    }
                }
                
            }

        }

        private void BtnFetchResult_Click(object sender, EventArgs e)
        {
            this.filePath = string.Empty;

            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    this.filePath = fbd.SelectedPath;
                    this.GetTeamInfo();
                }
            }
        }

        private async Task GetTeamInfo()
        {
           
            this.DisableFormReady();
            this.DisplayCount();
            this.scrapedData = new List<string[]>() { };
            this.scrapedData.Add(this.TitleRow);

            this.teamInfo = new Dictionary<string, object>();
               
            List<dynamic> TeamInfo = new List<dynamic>(this.TeamData.matches);
            var TeamValue = TeamInfo.Where(t => (string)t["roundNumber"] == this.roundVal).ToList();
            string total_count = (TeamValue.Count).ToString();
            la_total.Text = total_count;

            for (int i = 0; i < TeamValue.Count; i++)
            {
                la_cu_state.Text = (i + 1).ToString();
                string MatchID = "";
                MatchID = TeamValue[i].matchId;
                DateTime UTCStartTime = Convert.ToDateTime(TeamValue[i].localStartTime);

                if (MatchID != null)
                {
                    await this.GetPlayersInfo(MatchID, UTCStartTime);
                }
            }
               
            Console.WriteLine("--------generating Data----------");
            this.GenerateCSV(this.scrapedData);
       
        }

        private void GenerateCSV(List<string[]> output)
        {
            DateTime now = DateTime.Now;
            var nowDay = now.Day + "_" + now.Month + "_" + now.Year + "_" + now.Hour + "_" + now.Minute + "_" + now.Second;
            string generatePath = this.filePath + @"\League_" + nowDay + ".csv";
            string delimiter = ",";

            int length = output.ToArray().GetLength(0);
            StringBuilder sb = new StringBuilder();
            for (int index = 0; index < length; index++)
            {
                sb.AppendLine(string.Join(delimiter, output[index]));
            }
            File.WriteAllText(generatePath, sb.ToString());
            System.Windows.Forms.MessageBox.Show("CSV file creation success!", "Message");
            this.EnableFormReady();
            this.DisableCount();
        }

        private async Task GetPlayersInfo(string matchID, DateTime StartTime)
        {
            int rowAmount = this.TitleRow.Length;
            dynamic PlayDetail = new Object();
            string detailApi = this.base_url + "/fixture/" + matchID;
            await Task.Run(() => { PlayDetail = JsonConvert.DeserializeObject<dynamic>(GetAllData(detailApi)); });
            if (PlayDetail != null)
            {
                string venueName = PlayDetail.matchInfo.venueName;

                // homeTeam Data
                string homeTeamCode = PlayDetail.teamStats.homeTeam.teamCode;
                string homeTeamName = PlayDetail.teamStats.homeTeam.squadName;

                List<dynamic> PlayersInfoA = new List<dynamic>(PlayDetail.playerStats);
                List<dynamic> SortedTeamAValue = PlayersInfoA.Where(t => (string)t["teamCode"] == homeTeamCode).OrderByDescending(x => Convert.ToInt32(x.disposals)).ToList();

                int lenA = SortedTeamAValue.Count;
                for (int i = 0; i < lenA; i++)
                {
                    string[] rowDataA = this.IndividialPlayerInfo(rowAmount, SortedTeamAValue[i], StartTime, venueName, homeTeamName);
                    this.scrapedData.Add(rowDataA);
                }

                // AwayTeam Data
                string awayTeamCode = PlayDetail.teamStats.awayTeam.teamCode;
                string awayTeamName = PlayDetail.teamStats.awayTeam.squadName;

                List<dynamic> PlayersInfoB = new List<dynamic>(PlayDetail.playerStats);
                List<dynamic> SortedTeamBValue = PlayersInfoB.Where(t => (string)t["teamCode"] == awayTeamCode).OrderByDescending(x => Convert.ToInt32(x.disposals)).ToList();

                int lenB = SortedTeamBValue.Count;
                for (int i = 0; i < lenB; i++)
                {
                    string[] rowDataB = this.IndividialPlayerInfo(rowAmount, SortedTeamBValue[i], StartTime, venueName, awayTeamName);
                    this.scrapedData.Add(rowDataB);
                }
            }
        }

        private string[] IndividialPlayerInfo(int rowLen, dynamic Player, DateTime startTime, string Venue, string TeamName)
        {
            string[] newRow = new string[rowLen];

            newRow[0] = li_league.Text;
            newRow[1] = li_year.Text;
            newRow[2] = startTime.ToString("dd/MM/yyyy");
            newRow[3] = startTime.ToString("hh:mm tt");
            newRow[4] = li_round.Text; // TODO round name
            newRow[5] = Venue;
            newRow[6] = TeamName; // TODO team name
            newRow[7] = Player.firstname + " " + Player.surname;
            newRow[8] = Player.jumperNumber;
            newRow[9] = Player.disposals;
            newRow[10] = Player.goals + "." + Player.behinds;
            newRow[11] = Player.kicks;
            newRow[12] = Player.handballs;
            newRow[13] = Player.marks;
            newRow[14] = Player.marksContested;
            newRow[15] = Player.tackles;
            newRow[16] = Player.hitouts;
            newRow[17] = Player.clearances;
            newRow[18] = Player.inside50s;
            newRow[19] = Player.rebound50s;
            newRow[20] = Player.dreamteamPoints;

            return newRow;
        }

        private void Btn_refresh_Click(object sender, EventArgs e)
        {
            this.DisableFormReady();
            Console.WriteLine("--- reload ---");
            this.DisableCount();
            this.initData();
        }

        private void Li_league_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.leagueIndex = li_league.SelectedIndex;
            this.leagueVal = this.initalData.leaguesInfo[this.leagueIndex].key;
            this.InitYear();
        }

        private void Li_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.yearIndex = li_year.SelectedIndex;
            this.yearVal = this.initalData.leaguesInfo[this.leagueIndex].seasons[this.yearIndex].key;
            this.InitRound();
        }

        private void Li_round_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.roundIndex = li_round.SelectedIndex;
            this.roundVal = this.roundArray[this.roundIndex].id;
            this.EnableFormReady();
        }

        private string GetAllData(string Url)
        {
            string result = "";
            try
            {
                // Create a request for the URL.
                WebRequest request = WebRequest.Create(Url);
                // If required by the server, set the credentials.
                request.Credentials = CredentialCache.DefaultCredentials;

                // Get the response.
                WebResponse response = request.GetResponse();
                // Display the status.
                var data = ((HttpWebResponse)response).GetResponseStream();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                result = sr.ReadToEnd();
                sr.Close();
            }
            catch (WebException webExcp)
            {
                // If you reach this point, an exception has been caught.  
                Console.WriteLine("A WebException has been caught.");
                // Write out the WebException message.  
                Console.WriteLine(webExcp.ToString());
                //this.ErrorMsg("Error: A WebException has been caught.");
                // Get the WebException status code.  
                WebExceptionStatus status = webExcp.Status;
                //System.Windows.Forms.MessageBox.Show(status + ". Please press refresh icon!", "Message");
                // If status is WebExceptionStatus.ProtocolError,
                //   there has been a protocol error and a WebResponse
                //   should exist. Display the protocol error.  
                if (status == WebExceptionStatus.ProtocolError)
                {
                    Console.Write("The server returned protocol error ");
                    //this.ErrorMsg("Error: The server returned protocol error.");
                    //System.Windows.Forms.MessageBox.Show("The server returned protocol error. Please press refresh icon!", "Message");
                    // Get HttpWebResponse so that you can check the HTTP status code.  
                    HttpWebResponse httpResponse = (HttpWebResponse)webExcp.Response;
                    Console.WriteLine((int)httpResponse.StatusCode + " - "
                       + httpResponse.StatusCode);
                }
            }
            catch (Exception e)
            {
                // Code to catch other exceptions goes here.  
            }
            return result;
        }

        private void DisableCount()
        {
            la_total.Text = "";
            la_slash.Text = "";
            la_cu_state.Text = "";
            la_team.Text = "";
        }

        private void DisplayCount()
        {
            la_total.Text = "0";
            la_slash.Text = "/";
            la_cu_state.Text = "0";
            la_team.Text = "teams";
        }

        private void EnableFormReady()
        {
            li_league.Enabled = true;
            li_year.Enabled = true;
            li_round.Enabled = true;
            btnFetchResult.Enabled = true;
        }

        private void DisableFormReady()
        {
            li_league.Enabled = false;
            li_year.Enabled = false;
            li_round.Enabled = false;
            btnFetchResult.Enabled = false;
        }

    }
}
