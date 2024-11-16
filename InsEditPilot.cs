using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database_app3
{
    public partial class InsEditPilot : Form
    {
        public string ConnectionString;
        private SQLiteCommand command;
        private SQLiteDataAdapter a;
        private DataSet tmp;
        private DataRow dr;
        public InsEditPilot(string name, string ConnectionString)
        {
            InitializeComponent();
            this.ConnectionString = ConnectionString;
            this.Text = name;

            using (var conn = new SQLiteConnection(this.ConnectionString))
            {
                conn.Open();
                this.dr = dr;
                tmp = new DataSet();
                tmp.Tables.Add(new DataTable("Pilot"));
                a = new SQLiteDataAdapter("Select id_pilot, FIO, "
                            + "phone_number, "
                            + "passport_details, "
                            + "birth_date, "
                            + "experience"
                            + " from Pilot", conn);
                a.Fill(tmp.Tables["Pilot"]);
            }
        }

        //При изменении (3 входных параметра)
        public InsEditPilot(string name, string ConnectionString, DataRow dr)
        {
            InitializeComponent();
            this.ConnectionString = ConnectionString;
            this.Text = name;
            using (var conn = new SQLiteConnection(this.ConnectionString))
            {
                conn.Open();
                this.dr = dr;
                tmp = new DataSet();
                tmp.Tables.Add(new DataTable("Pilot"));
                a = new SQLiteDataAdapter("Select id_pilot, FIO, "
                            + "phone_number, "
                            + "passport_details, "
                            + "birth_date, "
                            + "experience"
                            + " from Pilot", conn);
                a.Fill(tmp.Tables["Pilot"]);

                textBox1.Text = dr["ФИО"].ToString();
                textBox2.Text = dr["Номер телефона"].ToString();
                textBox3.Text = dr["Паспортные данные"].ToString();
                dateTimePicker1.Text = dr["Дата рождения"].ToString();
                textBox4.Text = dr["Стаж"].ToString();
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
            else if (age <= int.Parse(textBox4.Text))
            {
                CustomMessageBox messageBox = new CustomMessageBox("Стаж не может быть больше или равен возрасту!");
                messageBox.ShowDialog(this);
            }
            else
            {
                using (var conn = new SQLiteConnection(this.ConnectionString))
                {
                    conn.Open();

                    if ((int)Tag == 0)
                    {
                        command = new SQLiteCommand("INSERT INTO Pilot(FIO, phone_number, passport_details, "
                            + "birth_date, experience) VALUES('" + textBox1.Text
                            + "', '" + textBox2.Text
                            + "', '" + textBox3.Text
                            + "', date('" + Program.ConvertDate(dateTimePicker1.Text)
                            + "'), '" + int.Parse(textBox4.Text.ToString()) + "');", conn);
                    }
                    else
                    {
                        command = new SQLiteCommand("UPDATE Pilot SET FIO = '" + textBox1.Text
                            + "', phone_number = '" + textBox2.Text
                            + "', passport_details = '" + textBox3.Text + "', birth_date = "
                            + "date('" + Program.ConvertDate(dateTimePicker1.Text)

                            + "'), " + "experience = " + int.Parse(textBox4.Text.ToString())
                            + " WHERE id_pilot = " + dr[0] + ";", conn);
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

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
    }
}
