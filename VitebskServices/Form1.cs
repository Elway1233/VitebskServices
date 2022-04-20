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

namespace VitebskServices
{
    public partial class Form1 : Form
    {
        private GMap.NET.WindowsForms.GMapMarker selectedMarker;
        public static bool flag = false;
        public static bool flag1 = false;
        public static bool flag2 = false;
        public static string latitude = string.Empty;
        public static string longtitude = string.Empty;
        public static double longtitude1 = 0;
        public Form1()
        {
            InitializeComponent();
            gMapControl1.MouseUp += gMapControl1_MouseUp;
            gMapControl1.MouseDown += gMapControl1_MouseDown;
        }
        private void Head_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            MySqlConnection ThisConnection = new MySqlConnection("server=localhost;port=3307;username=root;password=root;database=is");
            ThisConnection.Open();
            MySqlCommand thisCommand = ThisConnection.CreateCommand();
            thisCommand.CommandText = "SELECT * FROM `hairdressing` WHERE `Service` = 'Парикмахерская'";
            MySqlDataReader thisReader = thisCommand.ExecuteReader();
            string res = string.Empty;
            string cx = string.Empty;
            while (thisReader.Read())
            {
                res += ("Название: ") + thisReader["Name"] + Environment.NewLine;
                res += ("Адрес: ") + thisReader["Address"] + Environment.NewLine;
                res += ("Номер телефона: ") + thisReader["Telephone"] + Environment.NewLine;
                res += ("График работ: ") + thisReader["WorkTime"] + Environment.NewLine;
                res += ("Сайт: ") + thisReader["WebSite"] + Environment.NewLine + Environment.NewLine;
               GMap.NET.WindowsForms.GMapMarker marker = new GMap.NET.WindowsForms.Markers.GMapMarkerGoogleGreen(new GMap.NET.PointLatLng(Convert.ToDouble(thisReader["latitude"]), Convert.ToDouble(thisReader["longtitude"])));
                GMap.NET.WindowsForms.GMapOverlay markers = new GMap.NET.WindowsForms.GMapOverlay(gMapControl1, "markers");
                marker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(marker);
                marker.ToolTipText = Convert.ToString(thisReader["Name"]);
                marker.ToolTipMode = GMap.NET.WindowsForms.MarkerTooltipMode.Always;
                markers.Markers.Add(marker);
                gMapControl1.Overlays.Add(markers);
            }       
            thisReader.Close();
            ThisConnection.Close();
            textBox1.Text += res;
            flag = true;
            flag1 = false;
            flag2 = false;
        }

        private void Products_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            MySqlConnection ThisConnection = new MySqlConnection("server=localhost;port=3307;username=root;password=root;database=is");
            ThisConnection.Open();
            MySqlCommand thisCommand = ThisConnection.CreateCommand();
            thisCommand.CommandText = "SELECT * FROM `Products` WHERE `Service` = 'Продукты'";
            MySqlDataReader thisReader = thisCommand.ExecuteReader();
            string res = string.Empty;
            while (thisReader.Read())
            {
                res += ("Название: ") + thisReader["Name"] + Environment.NewLine;
                res += ("Адрес: ") + thisReader["Address"] + Environment.NewLine;
                res += ("Номер телефона: ") + thisReader["Telephone"] + Environment.NewLine;
                res += ("График работ: ") + thisReader["WorkTime"] + Environment.NewLine;
                res += ("Сайт: ") + thisReader["WebSite"] + Environment.NewLine + Environment.NewLine;
            }
            thisReader.Close();
            ThisConnection.Close();
            textBox1.Text += res;
            flag = false;
            flag1 = true;
            flag2 = false;

        }

        private void Entertainment_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            MySqlConnection ThisConnection = new MySqlConnection("server=localhost;port=3307;username=root;password=root;database=is");
            ThisConnection.Open();
            MySqlCommand thisCommand = ThisConnection.CreateCommand();
            thisCommand.CommandText = "SELECT * FROM `Entertainment` WHERE `Service` = 'Развлечения'";
            MySqlDataReader thisReader = thisCommand.ExecuteReader();
            string res = string.Empty;
            while (thisReader.Read())
            {
                res += ("Название: ") + thisReader["Name"] + Environment.NewLine;
                res += ("Адрес: ") + thisReader["Address"] + Environment.NewLine;
                res += ("Номер телефона: ") + thisReader["Telephone"] + Environment.NewLine;
                res += ("График работ: ") + thisReader["WorkTime"] + Environment.NewLine;
                res += ("Сайт: ") + thisReader["WebSite"] + Environment.NewLine + Environment.NewLine;
            }
            thisReader.Close();
            ThisConnection.Close();
            textBox1.Text += res;
            flag = false;
            flag1 = false;
            flag2 = true;
        }

       
        private void buttonMap_Click(object sender, EventArgs e)
        {
            if (flag1 == true)
            {
                GMap.NET.WindowsForms.GMapMarker marker1 = new GMap.NET.WindowsForms.Markers.GMapMarkerGoogleGreen(new GMap.NET.PointLatLng(longtitude1, 30.22275030612946));
                marker1.Tag = 1;
                marker1.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(marker1);
                marker1.ToolTipText = "Евроопт";
                marker1.ToolTipMode = GMap.NET.WindowsForms.MarkerTooltipMode.Always;
                GMap.NET.WindowsForms.GMapOverlay markers = new GMap.NET.WindowsForms.GMapOverlay(gMapControl1, "markers");
                markers.Markers.Add(marker1);
                gMapControl1.Overlays.Add(markers);
            }
            if (flag == true)
            {
                GMap.NET.WindowsForms.GMapMarker marker = new GMap.NET.WindowsForms.Markers.GMapMarkerGoogleGreen(new GMap.NET.PointLatLng(55.180043903445664, 30.22275030612946));
                marker.Tag = 1;
                marker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(marker);
                marker.ToolTipText = "Евроопт";
                marker.ToolTipMode = GMap.NET.WindowsForms.MarkerTooltipMode.Always;
            }
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
    }
}
