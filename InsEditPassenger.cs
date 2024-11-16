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

namespace database_app3
{
    public partial class InsEditPassenger : Form
    {

        private string ConnectionString;
        private SQLiteCommand command;
        private SQLiteDataAdapter a;
        private DataSet tmp;
        private DataRow dr;

        public InsEditPassenger(string name, string ConnectionString)
        {
            InitializeComponent();
            this.ConnectionString = ConnectionString;
            this.Text = name;
            using (var conn = new SQLiteConnection(this.ConnectionString))
            {
                conn.Open();
                tmp = new DataSet();
                tmp.Tables.Add(new DataTable("Passenger"));
                a = new SQLiteDataAdapter("Select * from Passenger", conn);
                a.Fill(tmp.Tables["Passenger"]);
            }
        }

        //При изменении (3 входных параметра)
        public InsEditPassenger(string name, string ConnectionString, DataRow dr)
        {
            InitializeComponent();
            this.ConnectionString = ConnectionString;
            this.Text = name;
            using (var conn = new SQLiteConnection(this.ConnectionString))
            {
                conn.Open();
                this.dr = dr;
                tmp = new DataSet();
                tmp.Tables.Add(new DataTable("Passenger"));
                a = new SQLiteDataAdapter("select * from Passenger", conn);
                a.Fill(tmp.Tables["Passenger"]);

                textBox1.Text = dr["ФИО"].ToString();
                textBox2.Text = dr["Номер телефона"].ToString();
                textBox3.Text = dr["Паспортные данные"].ToString();
                dateTimePicker1.Text = dr["Дата рождения"].ToString();
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string[] birth_date_list = dateTimePicker1.Text.Split('-');

            DateTime birth_date = new DateTime(int.Parse(birth_date_list[2]),
                int.Parse(birth_date_list[1]), int.Parse(birth_date_list[0]));

            double age = (DateTime.Today - birth_date).TotalDays / 365;

            if (textBox1.Text.Count() == 0)
            {
                CustomMessageBox messageBox = new CustomMessageBox("Hе все поля заполнены!");
                messageBox.ShowDialog(this);
            }
            else if (age < 14)
            {
                CustomMessageBox messageBox = new CustomMessageBox("Пассажир не может быть младше 14 лет!");
                messageBox.ShowDialog(this);
            }
            else
            {
                using (var conn = new SQLiteConnection(this.ConnectionString))
                {
                    conn.Open();

                    if ((int)Tag == 0)
                    {
                        command = new SQLiteCommand("INSERT INTO Passenger(FIO, phone_number, passport_details, "
                            + "birth_date) VALUES('" + textBox1.Text 
                            + "', '" + textBox2.Text
                            + "', '" + textBox3.Text
                            + "', date('" + Program.ConvertDate(dateTimePicker1.Text)
                            + "'));", conn);
                    }
                    else
                    {
                        command = new SQLiteCommand("UPDATE Passenger SET FIO = '" + textBox1.Text
                            + "', phone_number = '" + textBox2.Text 
                            + "', passport_details = '" + textBox3.Text + "', birth_date = "
                            + "date('" + Program.ConvertDate(dateTimePicker1.Text)
                            + "') WHERE id_passenger = " + dr[0] + ";", conn);
                    }
                    command.ExecuteNonQuery();
                }
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void InsEditPassenger_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
