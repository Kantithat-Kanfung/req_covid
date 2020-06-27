using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace req_covid19
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }
        
        private void MainScreen_Load(object sender, EventArgs e)
        {
            // Creadit : Open Government Data of Thailand
            // Devolopment By : www.kidkarnmai.com
            // Source : https:covid19.th-stat.com
            // SeverBy":"https:smilehost.asia

            string getConfirmedJan = "";
            string getConfirmedFeb = "";
            string getConfirmedMar = "";
            string getConfirmedApr = "";
            string getConfirmedMay = "";
            //string getConfirmedJun = "";
            //string getConfirmedJul = "";
            //string getConfirmedAug = "";
            //string getConfirmedSep = "";
            //string getConfirmedOct = "";
            //string getConfirmedNov = "";
            //string getConfirmedDEm = "";

            string[] Provinces = {
                "Amnat Charoen",
                "Ang Thong",
                "Bangkok Metropolis",
                "Bueng Kan",
                "Buri Ram",
                "Chachoengsao",
                "Chai Nat",
                "Chaiyaphum",
                "Chanthaburi",
                "Chiang Mai",
                "Chiang Rai",
                "Chon Buri",
                "Chumphon",
                "Kalasin",
                "Kamphaeng Phet",
                "Kanchanaburi",
                "Khon Kaen",
                "Krabi",
                "Lampang",
                "Lamphun",
                "Loei",
                "Lop Buri",
                "Mae Hong Son",
                "Maha Sarakham",
                "Mukdahan",
                "Nakhon Nayok",
                "Nakhon Pathom",
                "Nakhon Phanom",
                "Nakhon Ratchasima",
                "Nakhon Sawan",
                "Nakhon Si Thammarat",
                "Nan",
                "Narathiwat",
                "Nong Bua Lam Phu",
                "Nong Khai",
                "Nonthaburi",
                "Pathum Thani",
                "Pattani",
                "Phangnga",
                "Phatthalung",
                "Phayao",
                "Phetchabun",
                "Phetchaburi",
                "Phichit",
                "Phitsanulok",
                "Phrae",
                "Phra Nakhon Si Ayutthaya",
                "Phuket",
                "Prachin Buri",
                "Prachuap Khiri Khan",
                "Ranong",
                "Ratchaburi",
                "Rayong",
                "Roi Et",
                "Sa Kaeo",
                "Sakon Nakhon",
                "Samut Prakan",
                "Samut Sakhon",
                "Samut Songkhram",
                "Saraburi",
                "Satun",
                "Sing Buri",
                "Si Sa Ket",
                "Songkhla",
                "Sukhothai",
                "Suphan Buri",
                "Surat Thani",
                "Surin",
                "Tak",
                "Trang",
                "Trat",
                "Ubon Ratchathani",
                "Udon Thani",
                "Uthai Thani",
                "Uttaradit",
                "Yala",
                "Yasothon"
            };

            for (int i = 0; i < Provinces.Length - 1; i++)
            {
                CbxProvinces.Items.Add(Provinces[i]);
            }

            var json_covid_today = "";
            var json_covid_timeline = "";
            var json_covid_sum_case = "";

            using (WebClient wc = new WebClient())
            {
                json_covid_today = wc.DownloadString("https://covid19.th-stat.com/api/open/today");
                json_covid_timeline = wc.DownloadString("https://covid19.th-stat.com/api/open/timeline");
                json_covid_sum_case = wc.DownloadString("https://covid19.th-stat.com/api/open/cases/sum");
            }

            JObject dataToday = JObject.Parse(json_covid_today);
            JObject dataTimeline = JObject.Parse(json_covid_timeline);
            JObject dataSumCases = JObject.Parse(json_covid_sum_case);

            lbConfirmed.Text = (string)dataToday["Confirmed"];
            lbNewConfirmed.Text = (string)dataToday["NewConfirmed"];
            lbRecovered.Text = (string)dataToday["Recovered"];
            lbNewRecovered.Text = (string)dataToday["NewRecovered"];
            lbHospitalized.Text = (string)dataToday["Hospitalized"];
            lbNewHospitalized.Text = (string)dataToday["NewHospitalized"];
            lbDeaths.Text = (string)dataToday["Deaths"];
            lbNewDeaths.Text = (string)dataToday["NewDeaths"];

            lbMale.Text = (string)dataSumCases["Gender"]["Male"].ToString();
            lbFemale.Text = (string)dataSumCases["Gender"]["Female"].ToString();

            lbCfrmProvince.Text = (string)dataSumCases["Province"]["Bangkok"].ToString();

            var postDataSumCases = from jan in dataTimeline["Data"] select (string)jan["Date"] == "01/01/2020";

            // Jan
            foreach (var item in postDataSumCases)
            {
                if (item)
                {
                    DateTime startDay = new DateTime(2020, 01, 01);
                    DateTime endDay = new DateTime(2020, 01, 31);

                    double numOfDay = startDay.Subtract(endDay).TotalDays;

                    getConfirmedJan = (string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Confirmed"].ToString();
                    
                    //Console.WriteLine((string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Date"].ToString());
                    //Console.WriteLine((string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Confirmed"].ToString());
                    //Console.WriteLine((string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Deaths"].ToString());
                }
            }

            // Feb
            foreach (var item in postDataSumCases)
            {
                if (item)
                {
                    DateTime startDay = new DateTime(2020, 01, 01);
                    DateTime endDay = new DateTime(2020, 02, 29);

                    double numOfDay = startDay.Subtract(endDay).TotalDays;

                    getConfirmedFeb = (string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Confirmed"].ToString();
                   
                    //Console.WriteLine((string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Date"].ToString());
                    //Console.WriteLine((string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Confirmed"].ToString());
                    //Console.WriteLine((string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Deaths"].ToString());
                }
            }

            // Mar
            foreach (var item in postDataSumCases)
            {
                if (item)
                {
                    DateTime startDay = new DateTime(2020, 01, 01);
                    DateTime endDay = new DateTime(2020, 03, 31);

                    double numOfDay = startDay.Subtract(endDay).TotalDays;

                    getConfirmedMar = (string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Confirmed"].ToString();
                    
                    //Console.WriteLine((string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Date"].ToString());
                    //Console.WriteLine((string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Confirmed"].ToString());
                    //Console.WriteLine((string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Deaths"].ToString());
                }
            }

            // Apr
            foreach (var item in postDataSumCases)
            {
                if (item)
                {
                    DateTime startDay = new DateTime(2020, 01, 01);
                    DateTime endDay = new DateTime(2020, 04, 30);

                    double numOfDay = startDay.Subtract(endDay).TotalDays;

                    getConfirmedApr = (string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Confirmed"].ToString();
                    
                    //Console.WriteLine((string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Date"].ToString());
                    //Console.WriteLine((string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Confirmed"].ToString());
                    //Console.WriteLine((string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Deaths"].ToString());
                }
            }

            // May
            foreach (var item in postDataSumCases)
            {
                if (item)
                {
                    DateTime startDay = new DateTime(2020, 01, 01);
                    DateTime endDay = new DateTime(2020, 05, 31);

                    double numOfDay = startDay.Subtract(endDay).TotalDays;

                    getConfirmedMay = (string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Confirmed"].ToString();
                    
                    //Console.WriteLine((string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Date"].ToString());
                    //Console.WriteLine((string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Confirmed"].ToString());
                    //Console.WriteLine((string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Deaths"].ToString());
                }
            }

            //// Jun
            //foreach (var item in postDataSumCases)
            //{
            //    if (item)
            //    {
            //        DateTime startDay = new DateTime(2020, 01, 01);
            //        DateTime endDay = new DateTime(2020, 06, 30);
            //
            //        double numOfDay = startDay.Subtract(endDay).TotalDays;
            //
            //        Console.WriteLine((string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Date"].ToString());
            //        Console.WriteLine((string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Confirmed"].ToString());
            //        Console.WriteLine((string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Deaths"].ToString());
            //    }
            //}
            //
            //// Jul
            //foreach (var item in postDataSumCases)
            //{
            //    if (item)
            //    {
            //        DateTime startDay = new DateTime(2020, 01, 01);
            //        DateTime endDay = new DateTime(2020, 07, 31);
            //
            //        double numOfDay = startDay.Subtract(endDay).TotalDays;
            //
            //        Console.WriteLine((string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Date"].ToString());
            //        Console.WriteLine((string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Confirmed"].ToString());
            //        Console.WriteLine((string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Deaths"].ToString());
            //    }
            //}
            //
            //// Aug
            //foreach (var item in postDataSumCases)
            //{
            //    if (item)
            //    {
            //        DateTime startDay = new DateTime(2020, 01, 01);
            //        DateTime endDay = new DateTime(2020, 08, 31);
            //
            //        double numOfDay = startDay.Subtract(endDay).TotalDays;
            //
            //        Console.WriteLine((string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Date"].ToString());
            //        Console.WriteLine((string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Confirmed"].ToString());
            //        Console.WriteLine((string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Deaths"].ToString());
            //    }
            //}
            //
            //// Sep
            //foreach (var item in postDataSumCases)
            //{
            //    if (item)
            //    {
            //        DateTime startDay = new DateTime(2020, 01, 01);
            //        DateTime endDay = new DateTime(2020, 09, 30);
            //
            //        double numOfDay = startDay.Subtract(endDay).TotalDays;
            //
            //        Console.WriteLine((string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Date"].ToString());
            //        Console.WriteLine((string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Confirmed"].ToString());
            //        Console.WriteLine((string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Deaths"].ToString());
            //    }
            //}
            //
            //// Oct
            //foreach (var item in postDataSumCases)
            //{
            //    if (item)
            //    {
            //        DateTime startDay = new DateTime(2020, 01, 01);
            //        DateTime endDay = new DateTime(2020, 10, 31);
            //
            //        double numOfDay = startDay.Subtract(endDay).TotalDays;
            //
            //        Console.WriteLine((string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Date"].ToString());
            //        Console.WriteLine((string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Confirmed"].ToString());
            //        Console.WriteLine((string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Deaths"].ToString());
            //    }
            //}
            //
            //// Nov
            //foreach (var item in postDataSumCases)
            //{
            //    if (item)
            //    {
            //        DateTime startDay = new DateTime(2020, 01, 01);
            //        DateTime endDay = new DateTime(2020, 11, 30);
            //
            //        double numOfDay = startDay.Subtract(endDay).TotalDays;
            //
            //        Console.WriteLine((string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Date"].ToString());
            //        Console.WriteLine((string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Confirmed"].ToString());
            //        Console.WriteLine((string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Deaths"].ToString());
            //    }
            //}
            //
            //// Dec
            //foreach (var item in postDataSumCases)
            //{
            //    if (item)
            //    {
            //        DateTime startDay = new DateTime(2020, 01, 01);
            //        DateTime endDay = new DateTime(2020, 12, 31);
            //
            //        double numOfDay = startDay.Subtract(endDay).TotalDays;
            //
            //        Console.WriteLine((string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Date"].ToString());
            //        Console.WriteLine((string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Confirmed"].ToString());
            //        Console.WriteLine((string)dataTimeline["Data"][Convert.ToInt32(Math.Abs(numOfDay))]["Deaths"].ToString());
            //    }
            //}

            ChartReport.Titles.Add("New Confirmed Per Month");
            ChartReport.Series["Patients"].Points.AddXY("Jan", Convert.ToInt16(getConfirmedJan));
            ChartReport.Series["Patients"].Points.AddXY("Feb", Convert.ToInt16(getConfirmedFeb) - Convert.ToInt16(getConfirmedJan));
            ChartReport.Series["Patients"].Points.AddXY("Mar", Convert.ToInt16(getConfirmedMar) - Convert.ToInt16(getConfirmedFeb));
            ChartReport.Series["Patients"].Points.AddXY("Apr", Convert.ToInt16(getConfirmedApr) - Convert.ToInt16(getConfirmedMar));
            ChartReport.Series["Patients"].Points.AddXY("May", Convert.ToInt16(getConfirmedMay) - Convert.ToInt16(getConfirmedApr));
            //ChartReport.Series["Comfirmed"].Points.AddXY("Jun", Convert.ToInt16(getComfirmedJun) - Convert.ToInt16(getConfirmedMay));
            //ChartReport.Series["Comfirmed"].Points.AddXY("Jul", Convert.ToInt16(getComfirmedJul) - Convert.ToInt16(getConfirmedJun));
            //ChartReport.Series["Comfirmed"].Points.AddXY("Aug", Convert.ToInt16(getComfirmedAug) - Convert.ToInt16(getConfirmedJul));
            //ChartReport.Series["Comfirmed"].Points.AddXY("Sep", Convert.ToInt16(getComfirmedSep) - Convert.ToInt16(getConfirmedAug));
            //ChartReport.Series["Comfirmed"].Points.AddXY("Oct", Convert.ToInt16(getComfirmedOct) - Convert.ToInt16(getConfirmedSep));
            //ChartReport.Series["Comfirmed"].Points.AddXY("Nov", Convert.ToInt16(getComfirmedNov) - Convert.ToInt16(getConfirmedOct));
            //ChartReport.Series["Comfirmed"].Points.AddXY("Dec", Convert.ToInt16(getComfirmedDem) - Convert.ToInt16(getConfirmedNov));
        }

        private void CbxProvinces_SelectedValueChanged(object sender, EventArgs e)
        {
            var json_covid_sum_case = "";

            using (WebClient wc = new WebClient())
            {

                json_covid_sum_case = wc.DownloadString("https://covid19.th-stat.com/api/open/cases/sum");
            }

            JObject dataSumCases = JObject.Parse(json_covid_sum_case);

            lbProvince.Text = CbxProvinces.SelectedItem.ToString();

            if (string.IsNullOrEmpty((string)dataSumCases["Province"][lbProvince.Text]))
            {
                lbCfrmProvince.Text = "0";
            }
            else
            {
                lbCfrmProvince.Text = (string)dataSumCases["Province"][lbProvince.Text].ToString();
            }
        }

        private void MainScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }
    }
}
