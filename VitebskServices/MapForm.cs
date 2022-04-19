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
    public partial class MapForm : Form
    {
        private GMap.NET.WindowsForms.GMapMarker selectedMarker;
        public MapForm()
        {
            InitializeComponent();

            gMapControl1.MouseUp += gMapControl1_MouseUp;
            gMapControl1.MouseDown += gMapControl1_MouseDown;
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

            gMapControl1.MouseWheelZoomType =
                GMap.NET.MouseWheelZoomType.MousePositionAndCenter;


            gMapControl1.NegativeMode = false;


            gMapControl1.PolygonsEnabled = true;


            gMapControl1.RoutesEnabled = true;


            gMapControl1.ShowTileGridLines = false;

            gMapControl1.Zoom = 12;

            gMapControl1.Dock = DockStyle.Fill;
            gMapControl1.Position = new GMap.NET.PointLatLng(55.16746667924418,30.189753648571844);

            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMapControl1.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleMap;

            //первый маркер
            GMap.NET.WindowsForms.GMapMarker marker1 = new GMap.NET.WindowsForms.Markers.GMapMarkerGoogleGreen(new GMap.NET.PointLatLng(55.180043903445664, 30.22275030612946));
            marker1.Tag = 1;

            GMap.NET.WindowsForms.GMapOverlay markers = new GMap.NET.WindowsForms.GMapOverlay(gMapControl1, "markers");
            markers.Markers.Add(marker1);
            gMapControl1.Overlays.Add(markers);
        }

        private void gMapControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (selectedMarker is null)
                return;

            //переводим координаты курсора мыши в долготу и широту на карте
            var latlng = gMapControl1.FromLocalToLatLng(e.X, e.Y);
            //присваиваем новую позицию для маркера
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
