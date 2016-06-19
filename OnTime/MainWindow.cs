﻿using System;
using System.Windows.Forms;
using System.Xml;

namespace OnTime
{
    public partial class MainWindow : Form
    {
        private readonly Api _api;
        private XmlDocument _data;
        private readonly GuiControl _guiControl;

        public MainWindow()
        {
            InitializeComponent();
            _api = new Api();
            _guiControl = new GuiControl(this);

            //Set datetimepickers to current date
            boxDate.Value = DateTime.Now;
            boxTime.Value = DateTime.Now;
        }

        private void btnTravelAdvice_Click(object sender, EventArgs e)
        {
            ShowTravelAdvice();
        }

        public void ShowTravelAdvice()
        {
            var rawDate = DateTime.Parse(boxDate.Text);
            var time = boxTime.Text;
            var date = rawDate.ToString("yyyy-MM-dd") + "T" + time;

            _data = _api.TravelAdvice("Amsterdam", "emmen", null, date, false, 0, 3);
            int i = 1;
            XmlNodeList nodeList = _data.SelectNodes("ReisMogelijkheden/ReisMogelijkheid");

            if (nodeList != null)
                foreach (XmlNode data in nodeList)
                {
                    string departureTime = data["ActueleVertrekTijd"]?.InnerText;
                    string arivalTime = data["ActueleAankomstTijd"]?.InnerText;

                    switch (i)
                    {
                        case 1:
                            dptLBL1.Text = departureTime?.Substring(11, 5) + @" ➜ " + arivalTime?.Substring(11, 5);
                            swLBL1.Text = data["AantalOverstappen"]?.InnerText;
                            trtLBL1.Text = data["ActueleReisTijd"]?.InnerText;
                            break;
                        case 2:
                            dptLBL2.Text = departureTime?.Substring(11, 5) + @" ➜ " + arivalTime?.Substring(11, 5);
                            swLBL2.Text = data["AantalOverstappen"]?.InnerText;
                            trtLBL2.Text = data["ActueleReisTijd"]?.InnerText;
                            break;
                        case 3:
                            dptLBL3.Text = departureTime?.Substring(11, 5) + @" ➜ " + arivalTime?.Substring(11, 5);
                            swLBL3.Text = data["AantalOverstappen"]?.InnerText;
                            trtLBL3.Text = data["ActueleReisTijd"]?.InnerText;
                            break;
                        case 4:
                            dptLBL4.Text = departureTime?.Substring(11, 5) + @" ➜ " + arivalTime?.Substring(11, 5);
                            swLBL4.Text = data["AantalOverstappen"]?.InnerText;
                            trtLBL4.Text = data["ActueleReisTijd"]?.InnerText;
                            break;
                    }
                    i++;
                }
        }

        private void info1_Click(object sender, EventArgs e)
        {
            _guiControl.ColorSwitch(1);
        }

        private void info2_Click(object sender, EventArgs e)
        {
            _guiControl.ColorSwitch(2);
        }
        private void info3_Click(object sender, EventArgs e)
        {
            _guiControl.ColorSwitch(3);
        }
        private void info4_Click(object sender, EventArgs e)
        {
            _guiControl.ColorSwitch(4);
        }


        public void GetTravelInfo(int i)
        {
            XmlNodeList nodeList = _data.SelectNodes("ReisMogelijkheden/ReisMogelijkheid");
            if (nodeList != null)
                foreach (XmlNode data in nodeList)
                {
                    if (i == 1)
                    {
                        
                    }
                }
        }
    }
}