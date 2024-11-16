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
    public partial class InsEditTicket : Form
    {
        private SQLiteCommand command;
        private SQLiteDataAdapter a;
        private DataSet tmp;
        private DataRow dr;
        private string ConnectionString;
        private string mode;

        // При добавлении (2 входных параметра)
        public InsEditTicket(string name, string ConnectionString)
        {
            InitializeComponent();
            this.mode = "add";
            this.ConnectionString = ConnectionString;
            this.Text = name;
            using (var conn = new SQLiteConnection(this.ConnectionString))
            {
                conn.Open();
                tmp = new DataSet();
                tmp.Tables.Add(new DataTable("Passenger"));
                a = new SQLiteDataAdapter("select id_passenger, FIO from Passenger", conn);
                a.Fill(tmp.Tables["Passenger"]);

                comboBox1.DisplayMember = tmp.Tables["Passenger"].Columns["FIO"].ToString();
                comboBox1.ValueMember = tmp.Tables["Passenger"].Columns["id_passenger"].ToString();
                comboBox1.DataSource = tmp.Tables["Passenger"];

                tmp.Tables.Add(new DataTable("Flight"));
                a = new SQLiteDataAdapter("select id_flight, STRFTIME('%d-%m-%Y %H:%M', departure_time) as departure_time_ from Flight", conn);
                a.Fill(tmp.Tables["Flight"]);

                comboBox2.DisplayMember = tmp.Tables["Flight"].Columns["departure_time_"].ToString();
                comboBox2.ValueMember = tmp.Tables["Flight"].Columns["id_flight"].ToString();
                comboBox2.DataSource = tmp.Tables["Flight"];
            }
        }

        // При изменении (3 входных параметра)
        public InsEditTicket(string name, string ConnectionString, DataRow dr)
        {
            InitializeComponent();
            this.ConnectionString = ConnectionString;
            this.mode = "edit";
            this.Text = name;
            using (var conn = new SQLiteConnection(this.ConnectionString))
            {
                conn.Open();
                this.dr = dr;
                tmp = new DataSet();

                tmp.Tables.Add(new DataTable("Passenger"));
                a = new SQLiteDataAdapter("Select id_passenger, FIO from Passenger", conn);
                a.Fill(tmp.Tables["Passenger"]);

                comboBox1.DisplayMember = tmp.Tables["Passenger"].Columns["FIO"].ToString();
                comboBox1.ValueMember = tmp.Tables["Passenger"].Columns["id_passenger"].ToString();
                comboBox1.DataSource = tmp.Tables["Passenger"];

                tmp.Tables.Add(new DataTable("Flight"));
                a = new SQLiteDataAdapter("select id_flight, STRFTIME('%d-%m-%Y %H:%M', departure_time) as departure_time_ from Flight;", conn);
                a.Fill(tmp.Tables["Flight"]);

                comboBox2.DisplayMember = tmp.Tables["Flight"].Columns["departure_time_"].ToString();
                comboBox2.ValueMember = tmp.Tables["Flight"].Columns["id_flight"].ToString();
                comboBox2.DataSource = tmp.Tables["Flight"];

               // Заполнение значения пассажира в комбобоксе
               command = new SQLiteCommand("SELECT id_passenger FROM Passenger "
                   + "WHERE Passenger.FIO = '"
                   + dr["ФИО пассажира"].ToString() + "'", conn);
                object passenger_id = command.ExecuteScalar();
                comboBox1.SelectedValue = passenger_id;

                // Заполнение значения времени рейса в комбобоксе
                command = new SQLiteCommand("SELECT id_flight FROM Flight "
                    + "WHERE STRFTIME('%d-%m-%Y %H:%M', datetime(Flight.departure_time)) = '"
                    + dr["Время отправления рейса"].ToString() + "'", conn);
                object flight_id = command.ExecuteScalar();
                comboBox2.SelectedValue = flight_id;

                textBox1.Text = dr["Цена"].ToString();
                dateTimePicker1.Text = (string)dr["Дата покупки билета"].ToString();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // преобразование даты покупки в DateTime
            string[] buy_date_list = dateTimePicker1.Text.Split('-');
            string[] hour_minute = buy_date_list[2].Split(' ')[1].Split(':');

            DateTime buy_date = new DateTime(int.Parse(buy_date_list[2].Split(' ')[0]),
                int.Parse(buy_date_list[1]), int.Parse(buy_date_list[0]), 
                int.Parse(hour_minute[0]), int.Parse(hour_minute[1]), 0);

            // преобразование времени отправления в DateTime
            string[] departure_time_list = comboBox2.Text.Split('-');
            hour_minute = departure_time_list[2].Split(' ')[1].Split(':');

            DateTime departure_time = new DateTime(int.Parse(departure_time_list[2].Split(' ')[0]),
                int.Parse(departure_time_list[1]), int.Parse(departure_time_list[0]),
                int.Parse(hour_minute[0]), int.Parse(hour_minute[1]), 0);

            // Проверка на то, чтобы у пассажира не было больше одного билета на конкретный рейс
            Int64 passenger_tickets;
            using (var conn = new SQLiteConnection(this.ConnectionString))
            {
                conn.Open();
                string command_text = "SELECT id_flight, id_passenger, COUNT(*) as count FROM Ticket "
                    + "WHERE id_passenger = " + comboBox1.SelectedValue.ToString()
                    + " and id_flight = " + comboBox2.SelectedValue.ToString();

                DataTable new_tmp = new DataTable();
                a = new SQLiteDataAdapter(command_text, conn);
                a.Fill(new_tmp);
                passenger_tickets = new_tmp.Rows[0].Field<Int64>("count");
            }

            if (comboBox1.Items.Count == 0 || comboBox2.Items.Count == 0
                || textBox1.Text.Count() == 0)
            {
                CustomMessageBox messageBox = new CustomMessageBox("Hе все поля заполнены!");
                messageBox.ShowDialog(this);
            }

            else if (DateTime.Compare(buy_date, departure_time) >= 0)
            {
                CustomMessageBox messageBox = new CustomMessageBox("Дата покупки билета не может быть позже или равной дате отправления рейса!");
                messageBox.ShowDialog(this);
            }

            else if (mode == "add" && passenger_tickets > 0)
            {
                CustomMessageBox messageBox = new CustomMessageBox("У пассажира не может быть больше одного билета на конкретный рейс!");
                messageBox.ShowDialog(this);
            }
            else
            {
                using (var conn = new SQLiteConnection(this.ConnectionString))
                {
                    conn.Open();
                    if ((int)Tag == 0)
                    {
                        command = new SQLiteCommand("INSERT INTO Ticket (id_passenger, id_flight, buy_date, price) VALUES('"
                            + int.Parse(comboBox1.SelectedValue.ToString())
                            + "', '" + int.Parse(comboBox2.SelectedValue.ToString())
                            + "', '" + Program.ConvertDate(dateTimePicker1.Text, true)
                            + "', '" + textBox1.Text
                            + "')", conn);
                    }
                    else
                    {
                        command = new SQLiteCommand("UPDATE Ticket SET id_passenger = '"
                            + int.Parse(comboBox1.SelectedValue.ToString())
                            + "', id_flight = '" + int.Parse(comboBox2.SelectedValue.ToString())
                            + "', buy_date = "
                            + "datetime('" + Program.ConvertDate(dateTimePicker1.Text, true)
                            + "'), " + "price = " + int.Parse(textBox1.Text.ToString())
                            + " WHERE id_ticket = " + dr[0] + ";", conn);
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

        private void InsEditTicket_Load(object sender, EventArgs e)
        {

        }
    }
}
