using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SQLite.SQLite3;

namespace database_app3
{
    public partial class InsEditPlane : Form
    {
        private string ConnectionString;
        private SQLiteCommand command;
        private SQLiteDataAdapter a;
        private DataSet tmp;
        private DataRow dr;

        public InsEditPlane(string name, string ConnectionString)
        {
            InitializeComponent();
            this.ConnectionString = ConnectionString;
            this.Text = name;
            using (var conn = new SQLiteConnection(this.ConnectionString))
            {
                conn.Open();
                tmp = new DataSet();
                tmp.Tables.Add(new DataTable("Manufacturer"));
                a = new SQLiteDataAdapter("Select id_manufacturer, manufacturer_name from Manufacturer", conn);
                a.Fill(tmp.Tables["Manufacturer"]);

                comboBox1.DisplayMember = tmp.Tables["Manufacturer"].Columns["manufacturer_name"].ToString();
                comboBox1.ValueMember = tmp.Tables["Manufacturer"].Columns["id_manufacturer"].ToString();
                comboBox1.DataSource = tmp.Tables["Manufacturer"];

                tmp.Tables.Add(new DataTable("PlaneType"));
                a = new SQLiteDataAdapter("select id_planetype, type_name from PlaneType", conn);
                a.Fill(tmp.Tables["PlaneType"]);

                comboBox2.DisplayMember = tmp.Tables["PlaneType"].Columns["type_name"].ToString();
                comboBox2.ValueMember = tmp.Tables["PlaneType"].Columns["id_planetype"].ToString();
                comboBox2.DataSource = tmp.Tables["PlaneType"];
            }

        }

        //При изменении (3 входных параметра)
        public InsEditPlane(string name, string ConnectionString, DataRow dr)
        {
            InitializeComponent();
            this.ConnectionString = ConnectionString;
            this.Text = name;
            using (var conn = new SQLiteConnection(this.ConnectionString))
            {
                conn.Open();
                this.dr = dr;
                tmp = new DataSet();

                tmp.Tables.Add(new DataTable("Manufacturer"));
                a = new SQLiteDataAdapter("Select id_manufacturer, manufacturer_name from Manufacturer", conn);
                a.Fill(tmp.Tables["Manufacturer"]);

                comboBox1.DisplayMember = tmp.Tables["Manufacturer"].Columns["manufacturer_name"].ToString();
                comboBox1.ValueMember = tmp.Tables["Manufacturer"].Columns["id_manufacturer"].ToString();
                comboBox1.DataSource = tmp.Tables["Manufacturer"];

                tmp.Tables.Add(new DataTable("PlaneType"));
                a = new SQLiteDataAdapter("select id_planetype, type_name from PlaneType", conn);
                a.Fill(tmp.Tables["PlaneType"]);

                comboBox2.DisplayMember = tmp.Tables["PlaneType"].Columns["type_name"].ToString();
                comboBox2.ValueMember = tmp.Tables["PlaneType"].Columns["id_planetype"].ToString();
                comboBox2.DataSource = tmp.Tables["PlaneType"];

                textBox1.Text = dr["Вместимость"].ToString();

                // Заполнение значения производителя в комбобоксе
                command = new SQLiteCommand("SELECT id_manufacturer FROM Manufacturer "
                    + "WHERE Manufacturer.manufacturer_name = '"
                    + dr["Производитель"].ToString() + "'", conn);
                object manufacturer_id  = command.ExecuteScalar();
                comboBox1.SelectedValue = manufacturer_id;

                // Заполнение значения типа самолета в комбобоксе
                command = new SQLiteCommand("SELECT id_planetype FROM PlaneType "
                    + "WHERE PlaneType.type_name = '"
                    + dr["Тип самолета"].ToString() + "'", conn);

                object planetype_id = command.ExecuteScalar();
                comboBox2.SelectedValue = planetype_id;
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count == 0 || comboBox2.Items.Count == 0
                || textBox1.Text.Count() == 0)
            {
                CustomMessageBox messageBox = new CustomMessageBox("Hе все поля заполнены!");
                messageBox.ShowDialog(this);
            }

            else if ((int.Parse(textBox1.Text.ToString())) > 2000)
            {
                CustomMessageBox messageBox = new CustomMessageBox("Вместимость не может быть больше 2000!");
                messageBox.ShowDialog(this);
            }
            else
            {
                using (var conn = new SQLiteConnection(this.ConnectionString))
                {
                    conn.Open();

                    if ((int)Tag == 0)
                    {
                        command = new SQLiteCommand("INSERT INTO Plane (id_manufacturer, id_type, capacity) VALUES('"
                            + int.Parse(comboBox1.SelectedValue.ToString())
                            + "', '" + int.Parse(comboBox2.SelectedValue.ToString())
                            + "', '" + textBox1.Text
                            + "');", conn);
                    }
                    else
                    {
                        command = new SQLiteCommand("UPDATE Plane SET id_manufacturer = " + int.Parse(comboBox1.SelectedValue.ToString())
                            + ", id_type = " + int.Parse(comboBox2.SelectedValue.ToString()) + ", "
                            + "capacity = " + textBox1.Text + " WHERE id_plane = " + dr[0], conn);
                    }

                    command.ExecuteNonQuery();
                }
                Close();
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
    }
}
