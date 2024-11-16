using database_app3;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Data.SQLite;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.Diagnostics;

namespace database_app3
{
    public partial class Form1 : Form
    {
        private String connstring = "Data Source=database1.db";

        public Form1()
        {
            InitializeComponent();
        }

        private void OnForm_Load(object sender, EventArgs e)
        {
            this.MainMenuStrip = new MenuStrip();
        }

        private void LoadTickets()
        {
            using (var conn = new SQLiteConnection(connstring))
            {
                conn.Open();
                string query = "SELECT * FROM Ticket;";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn);
                DataTable TicketsTable = new DataTable();
                adapter.Fill(TicketsTable);
            }
        }

        private void LoadFlights()
        {
            using (var conn = new SQLiteConnection(connstring))
            {
                conn.Open();
                string query = "SELECT * FROM Flight;";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn);
                DataTable TicketsTable = new DataTable();
                adapter.Fill(TicketsTable);
            }
        }

        private void LoadCountries()
        {
            using (var conn = new SQLiteConnection(connstring))
            {
                conn.Open();
                string query = "SELECT * FROM Country;";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn);
                DataTable TicketsTable = new DataTable();
                adapter.Fill(TicketsTable);
            }
        }

        private void LoadPilots()
        {
            using (var conn = new SQLiteConnection(connstring))
            {
                conn.Open();
                string query = "SELECT * FROM Pilot;";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn);
                DataTable TicketsTable = new DataTable();
                adapter.Fill(TicketsTable);
            }
        }

        private void LoadAirplane()
        {
            using (var conn = new SQLiteConnection(connstring))
            {
                conn.Open();
                string query = "SELECT * FROM Plane;";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn);
                DataTable TicketsTable = new DataTable();
                adapter.Fill(TicketsTable);
            }
        }

        private void LoadManufacturers()
        {
            using (var conn = new SQLiteConnection(connstring))
            {
                conn.Open();
                string query = "SELECT * FROM Manufacturers;";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn);
                DataTable TicketsTable = new DataTable();
                adapter.Fill(TicketsTable);
            }
        }

        private void LoadTypes()
        {
            using (var conn = new SQLiteConnection(connstring))
            {
                conn.Open();
                string query = "SELECT * FROM PlaneType;";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn);
                DataTable TicketsTable = new DataTable();
                adapter.Fill(TicketsTable);
            }
        }

        private void LoadPassengers()
        {
            using (var conn = new SQLiteConnection(connstring))
            {
                conn.Open();
                string query = "SELECT * FROM Passenger;";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn);
                DataTable TicketsTable = new DataTable();
                adapter.Fill(TicketsTable);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Cascad_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void Horizontal_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void Vertical_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Countries_Click(object sender, EventArgs e)
        {
            ToTable(sender);
        }

        private void Manufacturers_Click(object sender, EventArgs e)
        {
            ToTable(sender);
        }

        private void Planetype_Click(object sender, EventArgs e)
        {
            ToTable(sender);
        }

        private void Passenger_Click(object sender, EventArgs e)
        {
            ToTable(sender);
        }

        private void Tickets_Click(object sender, EventArgs e)
        {
            ToTable(sender);
        }


        private void Pilots_Click(object sender, EventArgs e)
        {
            ToTable(sender);
        }

        private void Planes_Click(object sender, EventArgs e)
        {
            ToTable(sender);
        }

        private void ToTable(object sender)
        {
            string str = (sender as ToolStripMenuItem).Text;
            bool flag = true;
            foreach (var a in MdiChildren)
            {
                if (a.Text == str)
                {
                    flag = false;
                    break;
                }
            }

            if (flag)
            {
                Table t = new Table(str, connstring);
                t.MdiParent = this;
                t.Show();
            }
        }

        private void Pilot_Flights_Click(object sender, EventArgs e)
        {
            Report rep = new Report(1, connstring);
            rep.Text = "Проведенные пилотом рейсы";
            rep.ShowDialog();
        }

        private void TimeInFlight_Click(object sender, EventArgs e)
        {
            Report rep = new Report(2, connstring);
            rep.Text = "Рейсы, проведенные с помощью одного самолета";
            rep.ShowDialog();
        }

        private void Flight_Click(object sender, EventArgs e)
        {
            ToTable(sender);
        }

        private void Schedule_On_Country_click(object sender, EventArgs e)
        {
            Report rep = new Report(3, connstring);
            rep.Text = "Расписание вылетов по стране";
            rep.ShowDialog();
        }

    }
}
