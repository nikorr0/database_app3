using database_app3;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using System.Data.SQLite;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
// using System.Data.SQLite;

namespace database_app_task1
{
    public partial class Add_students_Form : Form
    {
        DataTable new_dt;
        DataRow new_fill_row;

        public Add_students_Form(DataTable dt, DataRow fill_row=null)
        {
            InitializeComponent();

            new_dt = dt;
            new_fill_row = fill_row;
            
            if (new_fill_row != null)
            {
                FIO_textbox.Text = (string)new_fill_row["ФИО"];
                DateBirth_dateTimePicker.Text = (string)new_fill_row["Дата_Рождения"].ToString();
                Gender_comboBox.Text = (string) new_fill_row["Пол"];
                PassportSeries_textbox.Text = (string)new_fill_row["Серия_Паспорта"].ToString();
                PassportNumber_textBox.Text = (string)new_fill_row["Номер_Паспорта"].ToString();
                Who_textBox.Text = (string)new_fill_row["Кем_выдан"];
                When_dateTimePicker.Text = (string) new_fill_row["Когда_выдан"].ToString();
            }
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            if (FIO_textbox.Text == string.Empty)
                MessageBox.Show("Пропущено ФИО!");
            else if (Gender_comboBox.Text == string.Empty) MessageBox.Show("Пропущен пол!");
            else if (PassportSeries_textbox.Text == string.Empty) MessageBox.Show("Пропущена серия паспорта!");
            else if (PassportNumber_textBox.Text == string.Empty) MessageBox.Show("Пропущен номер паспорта!");
            else if (Who_textBox.Text == string.Empty) MessageBox.Show("Пропущена ячейка \"Кем выдан\"!");

            else
            {
                this.DialogResult = DialogResult.Yes;
                DataRow new_row = new_dt.NewRow();

                // new_row[0] = (int)new_dt.Rows[new_dt.Rows.Count - 1][0] + 1;
                new_row["ФИО"] = FIO_textbox.Text;
                new_row["Дата_Рождения"] = DateBirth_dateTimePicker.Value.ToString().Split()[0];
                new_row["Пол"] = Gender_comboBox.Text;
                new_row["Серия_Паспорта"] = PassportSeries_textbox.Text;
                new_row["Номер_Паспорта"] = PassportNumber_textBox.Text;
                new_row["Кем_выдан"] = Who_textBox.Text;
                new_row["Когда_выдан"] = When_dateTimePicker.Value.ToString().Split()[0];

                if (new_fill_row != null)
                {
                    new_fill_row["ФИО"] = FIO_textbox.Text;
                    new_fill_row["Дата_Рождения"] = DateBirth_dateTimePicker.Value.ToString().Split()[0];
                    new_fill_row["Пол"] = Gender_comboBox.Text;
                    new_fill_row["Серия_Паспорта"] = PassportSeries_textbox.Text;
                    new_fill_row["Номер_Паспорта"] = PassportNumber_textBox.Text;
                    new_fill_row["Кем_выдан"] = Who_textBox.Text;
                    new_fill_row["Когда_выдан"] = When_dateTimePicker.Value.ToString().Split()[0];
                }
                else
                {
                    new_dt.Rows.Add(new_row);
                }
                this.Close();

            }
        }

        private void FIO_textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if(Char.IsDigit(ch) && ch != 8 && ch != 46 ) 
            {
                e.Handled = true;
            }
        }

        private void Who_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void PassportNumber_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void PassportSeries_textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void Add_students_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                e.Cancel = true;
                return;
            }
            e.Cancel = false;
        }

        private void Add_students_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
