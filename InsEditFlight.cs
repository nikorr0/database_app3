using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace database_app3
{
    public partial class InsEditFlight : Form
    {
        private SQLiteCommand command;
        private SQLiteDataAdapter a;
        private DataSet tmp;
        private DataRow dr;
        private string ConnectionString;
        private string mode;

        public InsEditFlight(string name, string ConnectionString)
        {
            InitializeComponent();
            this.mode = "add";
            this.ConnectionString = ConnectionString;
            this.Text = name;
            using (var conn = new SQLiteConnection(this.ConnectionString))
            {
                conn.Open();
                tmp = new DataSet();
                tmp.Tables.Add(new DataTable("Plane"));
                a = new SQLiteDataAdapter("SELECT id_plane, Manufacturer.manufacturer_name || \" \" || PlaneType.type_name as [Самолет] " +
                    "from Manufacturer inner join " +
                    "(Plane inner join PlaneType on PlaneType.id_planetype = Plane.id_type) " +
                    "on Manufacturer.id_manufacturer = Plane.id_manufacturer", conn);

                a.Fill(tmp.Tables["Plane"]);

                comboBox1.DisplayMember = tmp.Tables["Plane"].Columns["Самолет"].ToString();
                comboBox1.ValueMember = tmp.Tables["Plane"].Columns["id_plane"].ToString();
                comboBox1.DataSource = tmp.Tables["Plane"];

                tmp.Tables.Add(new DataTable("Pilot"));
                a = new SQLiteDataAdapter("select id_pilot, FIO from Pilot", conn);
                a.Fill(tmp.Tables["Pilot"]);

                comboBox2.DisplayMember = tmp.Tables["Pilot"].Columns["FIO"].ToString();
                comboBox2.ValueMember = tmp.Tables["Pilot"].Columns["id_pilot"].ToString();
                comboBox2.DataSource = tmp.Tables["Pilot"];

                tmp.Tables.Add(new DataTable("Flight"));
                a = new SQLiteDataAdapter("SELECT Flight.id_departure_country, Flight.id_arrival_country, Country.country_name, Country.country_name " +
                    "from Flight INNER join Country on Country.id_country = Flight.id_departure_country " +
                    "   ", conn);
                a.Fill(tmp.Tables["Flight"]);

                tmp.Tables.Add(new DataTable("Country1"));
                a = new SQLiteDataAdapter("select id_country, country_name from Country", conn);
                a.Fill(tmp.Tables["Country1"]);

                tmp.Tables.Add(new DataTable("Country2"));
                a = new SQLiteDataAdapter("select id_country, country_name from Country", conn);
                a.Fill(tmp.Tables["Country2"]);

                comboBox3.DisplayMember = tmp.Tables["Country1"].Columns["country_name"].ToString();
                comboBox3.ValueMember = tmp.Tables["Country1"].Columns["id_country"].ToString();
                comboBox3.DataSource = tmp.Tables["Country1"];

                comboBox4.DisplayMember = tmp.Tables["Country2"].Columns["country_name"].ToString();
                comboBox4.ValueMember = tmp.Tables["Country2"].Columns["id_country"].ToString();
                comboBox4.DataSource = tmp.Tables["Country2"];
                comboBox5.Text = comboBox5.Items[0].ToString();
            }
        }

        // При изменении (3 входных параметра)
        public InsEditFlight(string name, string ConnectionString, DataRow dr)
        {
            InitializeComponent();
            this.mode = "edit";
            this.ConnectionString = ConnectionString;
            this.dr = dr;
            this.Text = name;
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                tmp = new DataSet();
                tmp.Tables.Add(new DataTable("Plane"));
                a = new SQLiteDataAdapter("SELECT Manufacturer.id_manufacturer || \"\" || PlaneType.id_planetype as id_plane_, id_plane, "
                    + "Manufacturer.manufacturer_name || \" \" || PlaneType.type_name as [Самолет] "
                    + "from Manufacturer inner join "
                    + "(Plane inner join PlaneType on PlaneType.id_planetype = Plane.id_type) "
                    + "on Manufacturer.id_manufacturer = Plane.id_manufacturer", conn);

                a.Fill(tmp.Tables["Plane"]);

                comboBox1.DisplayMember = tmp.Tables["Plane"].Columns["Самолет"].ToString();
                comboBox1.ValueMember = tmp.Tables["Plane"].Columns["id_plane"].ToString();
                comboBox1.DataSource = tmp.Tables["Plane"];

                tmp.Tables.Add(new DataTable("Pilot"));
                a = new SQLiteDataAdapter("select id_pilot, FIO from Pilot", conn);
                a.Fill(tmp.Tables["Pilot"]);

                comboBox2.DisplayMember = tmp.Tables["Pilot"].Columns["FIO"].ToString();
                comboBox2.ValueMember = tmp.Tables["Pilot"].Columns["id_pilot"].ToString();
                comboBox2.DataSource = tmp.Tables["Pilot"];

                tmp.Tables.Add(new DataTable("Flight"));
                a = new SQLiteDataAdapter("SELECT Flight.id_departure_country, Flight.id_arrival_country, Country.country_name, Country.country_name " +
                    "from Flight INNER join Country on Country.id_country = Flight.id_departure_country " +
                    "   ", conn);
                a.Fill(tmp.Tables["Flight"]);


                tmp.Tables.Add(new DataTable("Country1"));
                a = new SQLiteDataAdapter("select id_country, country_name from Country", conn);
                a.Fill(tmp.Tables["Country1"]);

                tmp.Tables.Add(new DataTable("Country2"));
                a = new SQLiteDataAdapter("select id_country, country_name from Country", conn);
                a.Fill(tmp.Tables["Country2"]);

                comboBox3.DisplayMember = tmp.Tables["Country1"].Columns["country_name"].ToString();
                comboBox3.ValueMember = tmp.Tables["Country1"].Columns["id_country"].ToString(); // tmp.Tables["Flight"].Columns["id_departure_country"].ToString();
                comboBox3.DataSource = tmp.Tables["Country1"];

                comboBox4.DisplayMember = tmp.Tables["Country2"].Columns["country_name"].ToString();
                comboBox4.ValueMember = tmp.Tables["Country2"].Columns["id_country"].ToString();
                comboBox4.DataSource = tmp.Tables["Country2"];


                dateTimePicker1.Text = (string)dr["Время отправления"].ToString();
                dateTimePicker2.Text = (string)dr["Время прибытия"].ToString();

                // Заполнение значения самолета в комбобоксе
                command = new SQLiteCommand("SELECT id_plane, Manufacturer.id_manufacturer || \"\" || PlaneType.id_planetype as id_plane_, "
                    + "Manufacturer.manufacturer_name || \" \" || PlaneType.type_name as plane_name "
                    + "from Manufacturer inner join "
                    + "(Plane inner join PlaneType on PlaneType.id_planetype = Plane.id_type) "
                    + "on Manufacturer.id_manufacturer = Plane.id_manufacturer "
                    + "WHERE plane_name = '" + dr["Самолет"].ToString()
                    + "'", conn);
                object plane_id = command.ExecuteScalar();
                comboBox1.SelectedValue = plane_id;

                // Заполнение значения пилота в комбобоксе
                command = new SQLiteCommand("SELECT id_pilot FROM Pilot "
                    + "WHERE Pilot.FIO = '"
                    + dr["Пилот"].ToString() + "'", conn);
                object pilot_id = command.ExecuteScalar();
                comboBox2.SelectedValue = pilot_id;

                // Заполнение значения страны отправления в комбобоксе
                command = new SQLiteCommand("SELECT id_country FROM Country "
                    + "WHERE Country.country_name = '"
                    + dr["Страна отправления"].ToString() + "'", conn);
                object country1_id = command.ExecuteScalar();
                comboBox3.SelectedValue = country1_id;

                // Заполнение значения страны прибытия в комбобоксе
                command = new SQLiteCommand("SELECT id_country FROM Country "
                    + "WHERE Country.country_name = '"
                    + dr["Страна прибытия"].ToString() + "'", conn);
                object country2_id = command.ExecuteScalar();
                comboBox4.SelectedValue = country2_id;

                comboBox5.Text = dr["Статус"].ToString();
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void InsEditFlight_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Проверка на то, чтобы время вылета не повторялось
            Int64 count_flight;
            using (var conn = new SQLiteConnection(this.ConnectionString))
            {
                conn.Open();
                string command_text = "SELECT departure_time, COUNT(*) as count FROM Flight "
                    + "WHERE STRFTIME('%d-%m-%Y %H:%M', datetime(departure_time)) = '"
                    + dateTimePicker1.Text + "'";

                DataTable new_tmp = new DataTable();
                a = new SQLiteDataAdapter(command_text, conn);
                a.Fill(new_tmp);
                count_flight = new_tmp.Rows[0].Field<Int64>("count");
            }

            if (comboBox1.Items.Count == 0 || comboBox2.Items.Count == 0
                || comboBox3.Items.Count == 0 || comboBox4.Items.Count == 0 || comboBox5.Items.Count == 0)
            {
                CustomMessageBox messageBox = new CustomMessageBox("Hе все поля заполнены!");
                messageBox.ShowDialog(this);
            }
            else if (mode == "add" && count_flight > 0)
            {
                CustomMessageBox messageBox = new CustomMessageBox("Время вылета не может повторятся!");
                messageBox.ShowDialog(this);
            }
            else
            {
                using (var conn = new SQLiteConnection(this.ConnectionString))
                {
                    conn.Open();
                    if ((int)Tag == 0)
                    {
                        command = new SQLiteCommand("INSERT INTO Flight (id_plane, id_pilot, id_departure_country, "
                            + "id_arrival_country, departure_time, arrival_time, status) VALUES('"
                            + int.Parse(comboBox1.SelectedValue.ToString())
                            + "', '" + int.Parse(comboBox2.SelectedValue.ToString())
                            + "', '" + int.Parse(comboBox3.SelectedValue.ToString())
                            + "', '" + int.Parse(comboBox4.SelectedValue.ToString())
                            + "', datetime('" + Program.ConvertDate(dateTimePicker1.Text, true)
                            + "'), datetime('" + Program.ConvertDate(dateTimePicker2.Text, true)
                            + "'), '" + comboBox5.Text.ToString()
                            + "');", conn);
                    }
                    else
                    {
                        command = new SQLiteCommand("UPDATE Flight SET id_plane = " + int.Parse(comboBox1.SelectedValue.ToString())
                            + ", id_pilot = " + int.Parse(comboBox2.SelectedValue.ToString())
                            + ", id_departure_country = " + int.Parse(comboBox3.SelectedValue.ToString())
                            + ", id_arrival_country = " + int.Parse(comboBox4.SelectedValue.ToString())
                            + ", departure_time = datetime('" + Program.ConvertDate(dateTimePicker1.Text, true)
                            + "'), arrival_time = datetime('" + Program.ConvertDate(dateTimePicker2.Text, true)
                            + "'), status = '" + comboBox5.Text.ToString() + "' WHERE id_flight = " + dr[0] + ";", conn);
                    }
                    command.ExecuteNonQuery();
                }
                Close();
            }
        }
    }
}