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
    public partial class InsEditCountry : Form
    {
        public string ConnectionString;
        private SQLiteCommand command;
        private SQLiteDataAdapter a;
        private DataSet tmp;
        private DataRow dr;


        public InsEditCountry(string name, string ConnectionString)
        {
            InitializeComponent();
            this.ConnectionString = ConnectionString;
            this.Text = name;

            using (var conn = new SQLiteConnection(this.ConnectionString))
            {
                conn.Open();
                this.dr = dr;
                tmp = new DataSet();
                tmp.Tables.Add(new DataTable("Country"));
                a = new SQLiteDataAdapter("select id_country, country_name from Country", conn);
                a.Fill(tmp.Tables["Country"]);
            }

        }

        //При изменении (3 входных параметра)
        public InsEditCountry(string name, string ConnectionString, DataRow dr)
        {
            InitializeComponent();
            this.ConnectionString = ConnectionString;
            this.Text = name;
            using (var conn = new SQLiteConnection(this.ConnectionString))
            {
                conn.Open();
                this.dr = dr;
                tmp = new DataSet();
                tmp.Tables.Add(new DataTable("Country"));
                a = new SQLiteDataAdapter("select id_country, country_name from Country", conn);
                a.Fill(tmp.Tables["Country"]);

                textBox1.Text = dr["Страна"].ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Count() == 0)
            {
                CustomMessageBox messageBox = new CustomMessageBox("Hе все поля заполнены!");
                messageBox.ShowDialog(this);
            }
            else
            {
                using (var conn = new SQLiteConnection(this.ConnectionString))
                {
                    conn.Open();

                    if ((int)Tag == 0)
                    {
                        command = new SQLiteCommand("INSERT INTO Country(country_name) VALUES('" + textBox1.Text + "');", conn);
                    }
                    else
                    {
                        command = new SQLiteCommand("UPDATE Country SET country_name = '" + textBox1.Text
                            + "' WHERE id_country = " + dr[0] + ";", conn);
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
    }
}
