using GMap.NET.WindowsForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VitebskServices
{
    public partial class Form1 : Form
    {
        private GMapMarker selectedMarker;
        public Form1()
        {
            InitializeComponent();
            gMapControl1.MouseUp += gMapControl1_MouseUp;
            gMapControl1.MouseDown += gMapControl1_MouseDown;
        }
        int hair = 0;
        int prod = 0;
        int ent = 0;
        int del = 0;
        int search = 0;
        int show = 0;
        private void Hair_Click(object sender, EventArgs e)
        {
            hair = 1;
            prod = 0;
            ent = 0;
            show = 1;
            textBox1.Clear();
            MySqlConnection ThisConnection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=is");
            ThisConnection.Open();
            MySqlCommand thisCommand = ThisConnection.CreateCommand();
            thisCommand.CommandText = "SELECT * FROM `side` WHERE `Service` = 'Парикмахерская'";
            MySqlDataReader thisReader = thisCommand.ExecuteReader();
            string res = string.Empty;
            while (thisReader.Read())
            {
                res += ("Название: ") + thisReader["Name"] + Environment.NewLine;
                res += ("Адрес: ") + thisReader["Address"] + Environment.NewLine;
                res += ("Номер телефона: ") + thisReader["Telephone"] + Environment.NewLine;
                res += ("График работы: ") + thisReader["WorkTime"] + Environment.NewLine;
                res += ("Сайт: ") + thisReader["WebSite"] + Environment.NewLine + Environment.NewLine;
                GMapMarker marker = new GMap.NET.WindowsForms.Markers.GMapMarkerGoogleGreen(new GMap.NET.PointLatLng(Convert.ToDouble(thisReader["latitude"]), Convert.ToDouble(thisReader["longtitude"])));
                GMapOverlay markers = new GMapOverlay(gMapControl1, "markers");
                marker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(marker);
                marker.ToolTipText = Convert.ToString(thisReader["Name"]);
                marker.ToolTipMode = MarkerTooltipMode.Always;
                markers.Markers.Add(marker);
                gMapControl1.Overlays.Add(markers);
                if (search > 0 || del > 0)
                {
                    gMapControl1.Overlays.Clear();
                }
            }
            thisReader.Close();
            ThisConnection.Close();
            textBox1.Text += res;
        }

        private void Products_Click(object sender, EventArgs e)
        {
            prod = 1;
            hair = 0;
            ent = 0;
            show = 2;
            textBox1.Clear();
            MySqlConnection ThisConnection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=is");
            ThisConnection.Open();
            MySqlCommand thisCommand = ThisConnection.CreateCommand();
            thisCommand.CommandText = "SELECT * FROM `side` WHERE `Service` = 'Продукты'";
            MySqlDataReader thisReader = thisCommand.ExecuteReader();
            string res = string.Empty;
            while (thisReader.Read())
            {
                res += ("Название: ") + thisReader["Name"] + Environment.NewLine;
                res += ("Адрес: ") + thisReader["Address"] + Environment.NewLine;
                res += ("Номер телефона: ") + thisReader["Telephone"] + Environment.NewLine;
                res += ("График работ: ") + thisReader["WorkTime"] + Environment.NewLine;
                res += ("Сайт: ") + thisReader["WebSite"] + Environment.NewLine + Environment.NewLine;
                GMapMarker marker = new GMap.NET.WindowsForms.Markers.GMapMarkerGoogleGreen(new GMap.NET.PointLatLng(Convert.ToDouble(thisReader["latitude"]), Convert.ToDouble(thisReader["longtitude"])));
                GMapOverlay markers = new GMapOverlay(gMapControl1, "markers");
                marker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(marker);
                marker.ToolTipText = Convert.ToString(thisReader["Name"]);
                marker.ToolTipMode = MarkerTooltipMode.Always;
                markers.Markers.Add(marker);
                gMapControl1.Overlays.Add(markers);
                if (search > 0 || del > 0)
                {
                    gMapControl1.Overlays.Clear();
                }
            }
            thisReader.Close();
            ThisConnection.Close();
            textBox1.Text += res;

        }

        private void Entertainment_Click(object sender, EventArgs e)
        {
            ent = 1;
            hair = 0;
            prod = 0;
            show = 3;
            textBox1.Clear();
            MySqlConnection ThisConnection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=is");
            ThisConnection.Open();
            MySqlCommand thisCommand = ThisConnection.CreateCommand();
            thisCommand.CommandText = "SELECT * FROM `side` WHERE `Service` = 'Развлечения'";
            MySqlDataReader thisReader = thisCommand.ExecuteReader();
            string res = string.Empty;
            while (thisReader.Read())
            {
                res += ("Название: ") + thisReader["Name"] + Environment.NewLine;
                res += ("Адрес: ") + thisReader["Address"] + Environment.NewLine;
                res += ("Номер телефона: ") + thisReader["Telephone"] + Environment.NewLine;
                res += ("График работ: ") + thisReader["WorkTime"] + Environment.NewLine;
                res += ("Сайт: ") + thisReader["WebSite"] + Environment.NewLine + Environment.NewLine;
                GMapMarker marker = new GMap.NET.WindowsForms.Markers.GMapMarkerGoogleGreen(new GMap.NET.PointLatLng(Convert.ToDouble(thisReader["latitude"]), Convert.ToDouble(thisReader["longtitude"])));
                GMapOverlay markers = new GMapOverlay(gMapControl1, "markers");
                marker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(marker);
                marker.ToolTipText = Convert.ToString(thisReader["Name"]);
                marker.ToolTipMode = MarkerTooltipMode.Always;
                markers.Markers.Add(marker);
                gMapControl1.Overlays.Add(markers);
                if (search > 0 || del > 0)
                {
                    gMapControl1.Overlays.Clear();
                }
            }
            thisReader.Close();
            ThisConnection.Close();
            textBox1.Text += res;
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddForm newForm = new AddForm();
            newForm.ShowDialog();
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            gMapControl1.Bearing = 0;
            gMapControl1.CanDragMap = true;
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.GrayScaleMode = true;
            gMapControl1.MarkersEnabled = true;
            gMapControl1.MaxZoom = 18;
            gMapControl1.MinZoom = 2;
            gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            gMapControl1.NegativeMode = false;
            gMapControl1.PolygonsEnabled = true;
            gMapControl1.RoutesEnabled = true;
            gMapControl1.ShowTileGridLines = false;
            gMapControl1.Zoom = 12;
            gMapControl1.Position = new GMap.NET.PointLatLng(55.16746667924418, 30.189753648571844);

            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMapControl1.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleMap;

        }

        private void gMapControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (selectedMarker is null)
            {
                return;
            }
            var latlng = gMapControl1.FromLocalToLatLng(e.X, e.Y);
            selectedMarker.Position = latlng;
            selectedMarker = null;
        }

        private void gMapControl1_MouseDown(object sender, MouseEventArgs e)
        {
            selectedMarker = gMapControl1.Overlays
            .SelectMany(o => o.Markers)
            .FirstOrDefault(m => m.IsMouseOver == true);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            search = 1;
            string name = textBox2.Text;
            string address = textBox2.Text;
            MySqlConnection ThisConnection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=is");
            ThisConnection.Open();
            MySqlCommand thisCommand = ThisConnection.CreateCommand();
            thisCommand.CommandText = String.Format("SELECT * FROM `side` WHERE `Name` = '{0}' OR `Address` LIKE '{1}%'", name,address);
            MySqlDataReader thisReader = thisCommand.ExecuteReader();
            string res = string.Empty;
            while (thisReader.Read())
            {
                res += ("Название: ") + thisReader["Name"] + Environment.NewLine;
                res += ("Адрес: ") + thisReader["Address"] + Environment.NewLine;
                res += ("Номер телефона: ") + thisReader["Telephone"] + Environment.NewLine;
                res += ("График работ: ") + thisReader["WorkTime"] + Environment.NewLine;
                res += ("Сайт: ") + thisReader["WebSite"] + Environment.NewLine + Environment.NewLine;
                GMapMarker marker = new GMap.NET.WindowsForms.Markers.GMapMarkerGoogleGreen(new GMap.NET.PointLatLng(Convert.ToDouble(thisReader["latitude"]), Convert.ToDouble(thisReader["longtitude"])));
                GMapOverlay markers = new GMapOverlay(gMapControl1, "markers");
                marker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(marker);
                marker.ToolTipText = Convert.ToString(thisReader["Name"]);
                marker.ToolTipMode = MarkerTooltipMode.Always;
                markers.Markers.Add(marker);
                gMapControl1.Overlays.Add(markers);
            }
            thisReader.Close();
            ThisConnection.Close();
            textBox1.Clear();
            textBox1.Text += res;
            search = 0;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            DeleteForm newForm = new DeleteForm();
            newForm.ShowDialog();
        }

        private void buttonDelMark_Click(object sender, EventArgs e)
        {
            del = 1;
            if (hair > 0)
            {
                Hair_Click(sender, e);
                show = 1;
            }
            if (prod > 0)
            {
                Products_Click(sender, e);
                show = 2;
            }
            if (ent > 0)
            {
                Entertainment_Click(sender, e);
                show = 3;
            }
            hair = 0;
            prod = 0;
            ent = 0;
            del = 0;
        }

        private void buttonShowMark_Click(object sender, EventArgs e)
        {
            if (show == 1)
            {
                Hair_Click(sender, e);
                hair = 1;
                prod = 0;
                ent = 0;
            }
            if (show == 2)
            {
                Products_Click(sender, e);
                hair = 0;
                prod = 1;
                ent = 0;
            }
            if (show == 3)
            {
                Entertainment_Click(sender, e);
                hair = 0;
                prod = 0;
                ent = 1;
            }
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            EditForm newForm = new EditForm();
            newForm.ShowDialog();
        }
    }
}

