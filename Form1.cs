using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using MySql.Data.MySqlClient;

namespace YazLab11
{

    public partial class Form1 : Form
    {
        private List<PointLatLng> _points;

        private List<Cargo> cargos;
        public Form1()
        {
            InitializeComponent();

            _points = new List<PointLatLng>();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            GMapProviders.GoogleMap.ApiKey = "";
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            map.CacheLocation = @"cache";
            map.DragButton = MouseButtons.Left;
            map.MapProvider = GMapProviders.GoogleMap;
            map.ShowCenter = false;
            map.SetPositionByKeywords("İzmit, Turkey");
            cargos = new List<Cargo>();
           SendCargosToGui2();
            DrawRoute();
        }
        GMapOverlay markers = new GMapOverlay("markers");
        GMapOverlay routes = new GMapOverlay("routes");
       

        private void btnDeleteRoute_Click(object sender, EventArgs e)
        {
            if (routes.Routes.Count()>0)
            {
            routes.Routes.RemoveAt(0);
            markers.Markers.RemoveAt(0);
            }
            
        }
        private void ReloadMap()
        {
            map.Zoom++;
            map.Zoom--;
        }

       
        private void LoadMap(PointLatLng point)
        {
            map.Position = point;
        }
        private void AddMarker(PointLatLng point)
        {
            var marker = new GMarkerGoogle(point, GMarkerGoogleType.red);
            markers.Markers.Add(marker);
            map.Overlays.Add(markers);
        }
        
        private void SendCargosToGui2()
        {
            string mysqlConnection = "SERVER=35.224.209.204;DATABASE=cloudDatabase;UID=root;PWD=1234";
            using (var connection = new MySqlConnection(mysqlConnection))
            {
                try
                {
                    connection.Open();

                    MySqlDataReader read;
                    MySqlCommand command = new MySqlCommand("SELECT cargo_coordinatX , cargo_coordinatY FROM Cargo_info WHERE isDelivered ='undelivered'", connection);
                    read = command.ExecuteReader();
                    while (read.Read())
                    {

                        Cargo cargo= new Cargo();

                        cargo.pointLatLng = new PointLatLng(read.GetDouble(0), read.GetDouble(1));
                        cargos.Add(cargo);
                    }

                }


                catch (Exception error)
                {
                    MessageBox.Show(" Dissconnected cause of  \n " + error.ToString());
                    throw;
                }
                for (int i = 0; i < cargos.Count; i++)
                {
                    AddMarker(cargos[i].pointLatLng);
                }
                ReloadMap();
            }
        }
        private void DrawRoute()
        {
            for (int i = 0; i < cargos.Count-1;i++)
            {


                var route = GoogleMapProvider.Instance.GetRoute(cargos[i].pointLatLng, cargos[i+1].pointLatLng, false, false, 14);
                var r = new GMapRoute(route.Points, "my route")
                {
                    Stroke = new Pen(Color.Red, 5)
                };

                routes.Routes.Add(r);
                map.Overlays.Add(routes);
            }
            ReloadMap();
        }
        public void Redraw()
        {
            cargos.Clear();
            routes.Routes.Clear();
            markers.Markers.Clear();
            ReloadMap();
            SendCargosToGui2();
            DrawRoute();
        }
    }
}
