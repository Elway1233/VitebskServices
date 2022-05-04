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
        public Form1()
        {
            InitializeComponent();
            gMapControl1.MouseUp += gMapControl1_MouseUp;
            gMapControl1.MouseDown += gMapControl1_MouseDown;
        }
        int del = 0;
        int search = 0;
        private void Hair_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            MySqlConnection ThisConnection = new MySqlConnection("server=localhost;port=3307;username=root;password=root;database=is");
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
                GMap.NET.WindowsForms.GMapMarker marker = new GMap.NET.WindowsForms.Markers.GMapMarkerGoogleGreen(new GMap.NET.PointLatLng(Convert.ToDouble(thisReader["latitude"]), Convert.ToDouble(thisReader["longtitude"])));
                GMap.NET.WindowsForms.GMapOverlay markers = new GMap.NET.WindowsForms.GMapOverlay(gMapControl1, "markers");
                marker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(marker);
                marker.ToolTipText = Convert.ToString(thisReader["Name"]);
                marker.ToolTipMode = GMap.NET.WindowsForms.MarkerTooltipMode.Always;
                markers.Markers.Add(marker);
                gMapControl1.Overlays.Add(markers);
                if(search > 0 || del > 0)
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
            textBox1.Clear();
            MySqlConnection ThisConnection = new MySqlConnection("server=localhost;port=3307;username=root;password=root;database=is");
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
                GMap.NET.WindowsForms.GMapMarker marker = new GMap.NET.WindowsForms.Markers.GMapMarkerGoogleGreen(new GMap.NET.PointLatLng(Convert.ToDouble(thisReader["latitude"]), Convert.ToDouble(thisReader["longtitude"])));
                GMap.NET.WindowsForms.GMapOverlay markers = new GMap.NET.WindowsForms.GMapOverlay(gMapControl1, "markers");
                marker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(marker);
                marker.ToolTipText = Convert.ToString(thisReader["Name"]);
                marker.ToolTipMode = GMap.NET.WindowsForms.MarkerTooltipMode.Always;
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
            textBox1.Clear();
            MySqlConnection ThisConnection = new MySqlConnection("server=localhost;port=3307;username=root;password=root;database=is");
            ThisConnection.Open();
            MySqlCommand thisCommand = ThisConnection.CreateCommand();
            thisCommand.CommandText = "SELECT * FROM `side` WHERE `Service` = 'Развлечения'";
            MySqlDataReader thisReader = thisCommand.ExecuteReader();
            string res = string.Empty;           
            while (thisReader.Read())
            {
                if (del < 0)
                {
                    res += ("Название: ") + thisReader["Name"] + Environment.NewLine;
                    res += ("Адрес: ") + thisReader["Address"] + Environment.NewLine;
                    res += ("Номер телефона: ") + thisReader["Telephone"] + Environment.NewLine;
                    res += ("График работ: ") + thisReader["WorkTime"] + Environment.NewLine;
                    res += ("Сайт: ") + thisReader["WebSite"] + Environment.NewLine + Environment.NewLine;
                }
                GMap.NET.WindowsForms.GMapMarker marker = new GMap.NET.WindowsForms.Markers.GMapMarkerGoogleGreen(new GMap.NET.PointLatLng(Convert.ToDouble(thisReader["latitude"]), Convert.ToDouble(thisReader["longtitude"])));
                GMap.NET.WindowsForms.GMapOverlay markers = new GMap.NET.WindowsForms.GMapOverlay(gMapControl1, "markers");
                marker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(marker);
                marker.ToolTipText = Convert.ToString(thisReader["Name"]);
                marker.ToolTipMode = GMap.NET.WindowsForms.MarkerTooltipMode.Always;
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
            MySqlConnection ThisConnection = new MySqlConnection("server=localhost;port=3307;username=root;password=root;database=is");
            ThisConnection.Open();
            MySqlCommand thisCommand = ThisConnection.CreateCommand();
            thisCommand.CommandText = String.Format("SELECT * FROM `side` WHERE `Name` = '{0}'", name);
            MySqlDataReader thisReader = thisCommand.ExecuteReader();
            string res = string.Empty;
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
                Hair_Click(sender, e);
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
            Hair_Click(sender, e);
            Products_Click(sender, e);
            Entertainment_Click(sender, e);
            del = 0;
        }
    }
}

