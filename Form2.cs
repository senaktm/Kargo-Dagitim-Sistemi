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
    public partial class Form2 : Form
    {
        private List<PointLatLng> _points;
        private List<Cargo> cargos;
        Form1 form1;
        public Form2()
        {
            InitializeComponent();
            _points = new List<PointLatLng>();

           cargos = new List<Cargo>();
        }

        

        private void Form2_Load(object sender, EventArgs e)
        {
            GMapProviders.GoogleMap.ApiKey = "";
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            map.CacheLocation = @"cache";
            map.DragButton = MouseButtons.Left;
            map.MapProvider = GMapProviders.GoogleMap;
            map.ShowCenter = false;
            map.SetPositionByKeywords("İzmit, Turkey");
            showCargos();
            form1 = new Form1();
            form1.Show();
        }
        private void showCargos()
        {
            string mysqlConnection = "SERVER=35.224.209.204;DATABASE=cloudDatabase;UID=root;PWD=1234";
            using (var connection = new MySqlConnection(mysqlConnection))
            {
                try
                {
                    connection.Open();
                    
                    MySqlCommand command = new MySqlCommand("SELECT * FROM Cargo_info", connection);
                    DataTable datatable = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.SelectCommand = command;
                    adapter.Fill(datatable);
                    dataGridView1.DataSource = datatable;

                }
                catch (Exception error)
                {
                    MessageBox.Show( error.ToString());
                    throw;
                }

            }
        }
        GMapOverlay markers = new GMapOverlay("markers");
        private void buttonHarita_Click(object sender, EventArgs e)
        {
           



        }
        

       
        GMapOverlay routes = new GMapOverlay("routes");
        
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
        private List<string> GetAddress(PointLatLng point)
        {
            List<Placemark> placemarks = null;
            var statusCode = GMapProviders.GoogleMap.GetPlacemarks(point, out placemarks);
            if (placemarks != null)
            {
                List<string> addresses = new List<string>();
                foreach (var placemark in placemarks)
                {
                    addresses.Add(placemark.Address);
                }
                return addresses;
            }
            return null;
        }

        private void map_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (checkBoxTiklama.Checked == true && e.Button == MouseButtons.Left)
            {
                var point = map.FromLocalToLatLng(e.X, e.Y);
                double lat = point.Lat;
                double lng = point.Lng;
                textBoxX.Text = lat + "";
                textBoxY.Text = lng + "";
                LoadMap(point);
                AddMarker(point);
                var address = GetAddress(point);
                if (address != null)
                {
                    richTextBoxAdres.Text = "address :" + address[0];
                }
                else
                {
                    richTextBoxAdres.Text = "Address couldn't find";
                }
            }
        }

        private void btnAddPoint_Click(object sender, EventArgs e)
        {
            _points.Add(new PointLatLng(Convert.ToDouble(textBoxX.Text), Convert.ToDouble(textBoxY.Text)));
            string mysqlConnection = "SERVER=35.224.209.204;DATABASE=cloudDatabase;UID=root;PWD=1234";
            using (var connection= new MySqlConnection(mysqlConnection))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("insert into Cargo_info (cargo_coordinatX,cargo_coordinatY,isDelivered,cargo_owner) values (@p1,@p2,@p3,@p4)", connection);
                    command.Parameters.AddWithValue("@p1", (Convert.ToDouble(textBoxX.Text)));
                    command.Parameters.AddWithValue("@p2", (Convert.ToDouble(textBoxY.Text)));
                    command.Parameters.AddWithValue("@p3", "undelivered");
                    command.Parameters.AddWithValue("@p4", textBoxKargoSahibi.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("added");
                    var point = new PointLatLng(Convert.ToDouble(textBoxX.Text), Convert.ToDouble(textBoxY.Text));
                    LoadMap(point);
                    AddMarker(point);
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.ToString());
                    throw;
                }
                showCargos();
                form1.Redraw();

            }
        }

        private void btnNoktaGetir_Click(object sender, EventArgs e)
        {
            string mysqlConnection = "SERVER=35.224.209.204;DATABASE=cloudDatabase;UID=root;PWD=1234";
            using (var connection = new MySqlConnection(mysqlConnection))
            {
                try
                {
                    connection.Open();
                    
                    MySqlDataReader read;
                    MySqlCommand command = new MySqlCommand("SELECT cargo_coordinatX,cargo_coordinatY FROM Cargo_info WHERE isDelivered ='undelivered'", connection);
                    read = command.ExecuteReader();
                    while (read.Read())
                    {
                        
                        Cargo cargo = new Cargo();

                        cargo.pointLatLng = new PointLatLng(read.GetDouble(0), read.GetDouble(1));
                        cargos.Add(cargo);
                    }

                }


                catch (Exception error)
                {
                    MessageBox.Show("Disconnected cause of \n " + error.ToString());
                    throw;
                }
                for (int i = 0; i < cargos.Count; i++)
                {
                    AddMarker(cargos[i].pointLatLng);
                }
                ReloadMap();
            }
        }

        private void btnMap_Click_1(object sender, EventArgs e)
        {
            if (!(textBoxX.Text.Trim().Equals("") && textBoxY.Text.Trim().Equals("")))
            {
                double x = Convert.ToDouble(textBoxX.Text);
                double y = Convert.ToDouble(textBoxY.Text);
                PointLatLng point = new PointLatLng(x, y);
                LoadMap(point);
                AddMarker(point);
            }
            else
            {
                if (!(richTextBoxAdres.Text.Trim().Equals("")))
                {
                    GeoCoderStatusCode statusCode;
                    var pointLatLng = GoogleMapProvider.Instance.GetPoint(richTextBoxAdres.Text.Trim(), out statusCode);
                    textBoxX.Text = pointLatLng?.Lat.ToString();
                    textBoxY.Text = pointLatLng?.Lng.ToString();
                    btnMap.PerformClick();
                }
                else
                {
                    MessageBox.Show("Address is empty");
                }
            }

            map.MinZoom = 5;
            map.MaxZoom = 100;
            map.Zoom = 10;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string mysqlConnection = "SERVER=35.224.209.204;DATABASE=cloudDatabase;UID=root;PWD=1234";
            using (var connection = new MySqlConnection(mysqlConnection))
            {
                try
                {
                    connection.Open();
                    

                    MySqlCommand command = new MySqlCommand("DELETE  FROM Cargo_info WHERE cargo_id ='" + dataGridView1.CurrentRow.Cells["cargo_id"].Value.ToString() + "'", connection);
                    command.ExecuteNonQuery();



                }


                catch (Exception error)
                {
                    MessageBox.Show("Disconnected cause of \n " + error.ToString());
                    throw;
                }
                showCargos();
                form1.Redraw();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
