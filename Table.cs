using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Windows.Documents;
using System.Diagnostics;

namespace database_app3
{
    public partial class Table : Form
    {
        private SQLiteDataAdapter a;
        private SQLiteCommand command = new SQLiteCommand();

        private string nameTable;
        private string name;
        private string query;

        private string ConnectionString;
        private int CurrentIndex = 0;
        private DataTable dt = new DataTable();

        public Table(string nameF, string connectionString)
        {
            InitializeComponent();
            this.Text = nameF;
            this.name = nameF;
            this.ConnectionString = connectionString;

            switch (this.name)
            {
                case "Самолеты":
                    {
                        this.query = "SELECT id_plane, Manufacturer.manufacturer_name as 'Производитель', PlaneType.type_name as 'Тип самолета', "
                            + "capacity as 'Вместимость' "
                            + "from Manufacturer inner join (PlaneType inner join Plane on "
                            + "PlaneType.id_planetype = Plane.id_type) on Manufacturer.id_manufacturer = Plane.id_manufacturer";

                        this.nameTable = "Plane";
                        break;
                    }
                case "Страны":
                    {
                        this.query = "SELECT id_country, country_name as 'Страна' from Country;";
                        this.nameTable = "Country";
                        break;
                    }
                case "Производители":
                    {
                        this.query = "SELECT id_manufacturer, manufacturer_name as 'Производитель' from Manufacturer;";
                        this.nameTable = "Manufacturer";
                        break;
                    }
                case "Типы самолетов":
                    {
                        this.query = "SELECT id_planetype, type_name as 'Тип самолета' from PlaneType;";
                        this.nameTable = "PlaneType";
                        break;
                    }
                case "Пассажиры":
                    {
                        this.query = "Select id_passenger, FIO as 'ФИО', " 
                            + "phone_number as 'Номер телефона', " 
                            + "passport_details as 'Паспортные данные', "
                            + "STRFTIME('%d-%m-%Y', birth_date) as 'Дата рождения'"
                            + "from Passenger";
                        this.nameTable = "Passenger";
                        break;
                    }
                case "Пилоты":
                    {
                        this.query = "Select id_pilot, FIO as 'ФИО', "
                            + "phone_number as 'Номер телефона', "
                            + "passport_details as 'Паспортные данные', "
                            + "STRFTIME('%d-%m-%Y', birth_date) as 'Дата рождения', "
                            + "experience as 'Стаж'"
                            + "from Pilot";
                        this.nameTable = "Pilot";
                        break;
                    }
                case "Билеты":
                    {
                        this.query = "SELECT id_ticket, Passenger.FIO as 'ФИО пассажира', "
                            + "STRFTIME('%d-%m-%Y %H:%M', Flight.departure_time) as 'Время отправления рейса', "
                            + "STRFTIME('%d-%m-%Y %H:%M', buy_date) as 'Дата покупки билета', "
                            + "price as 'Цена' "
                            + "from Flight inner join (Passenger inner join Ticket on "
                            + "Passenger.id_passenger = Ticket.id_passenger) on Flight.id_flight = Ticket.id_flight";
                        this.nameTable = "Ticket";
                        break;
                    }
                case "Рейсы":
                    {
                        this.query = "Select Flight.id_flight, Pilot.FIO as [Пилот], Manufacturer.manufacturer_name " 
                            + "|| \" \" || PlaneType.type_name as [Самолет], "
                            + "country1.country_name as [Страна отправления], country2.country_name as [Страна прибытия], "
                            + "STRFTIME('%d-%m-%Y %H:%M', Flight.departure_time) as [Время отправления], "
                            + "STRFTIME('%d-%m-%Y %H:%M', Flight.arrival_time) as [Время прибытия], Flight.status as [Статус] "
                            + "From Country as country2 inner join (Country as country1 inner join (Pilot inner JOIN (Flight inner join (Manufacturer inner join "
                            + "(Plane inner join PlaneType on PlaneType.id_planetype = Plane.id_type) on Manufacturer.id_manufacturer = "
                            + "Plane.id_manufacturer) on Plane.id_plane = Flight.id_plane) on Pilot.id_pilot = Flight.id_pilot) " 
                            + "on Flight.id_departure_country = country1.id_country) on Flight.id_arrival_country = country2.id_country";

                        this.nameTable = "Flight";
                        break;
                    }
            }
            using (var conn = new SQLiteConnection(this.ConnectionString))
            {
                conn.Open();
                a = new SQLiteDataAdapter(this.query, conn);
                a.Fill(this.dt);
            }
            dataGridView2.DataSource = this.dt;
            HideFields();
        }

        private void HideFields()
        {
            switch (this.nameTable)
            {
                case "Plane":
                    {
                        dataGridView2.Columns["id_plane"].Visible = false;
                        break;
                    }
                case "Passenger":
                    {
                        dataGridView2.Columns["id_passenger"].Visible = false;
                        break;
                    }
                case "Pilot":
                    {
                        dataGridView2.Columns["id_pilot"].Visible = false;
                        break;
                    }
                case "PlaneType":
                    {
                        dataGridView2.Columns["id_planetype"].Visible = false;
                        break;
                    }
                case "Country":
                    {
                        dataGridView2.Columns["id_country"].Visible = false;
                        break;
                    }
                case "Manufacturer":
                    {
                        dataGridView2.Columns["id_manufacturer"].Visible = false;
                        break;
                    }
                case "Ticket":
                    {
                        dataGridView2.Columns["id_ticket"].Visible = false;
                        break;
                    }
                case "Flight":
                    {
                        dataGridView2.Columns["id_flight"].Visible = false;
                        break;
                    }
            }
        }

        private void InsEdit(int param)
        {
            int rowCount = dataGridView2.RowCount;

            if (rowCount != 0)
            {
                CurrentIndex = dataGridView2.CurrentRow.Index;
            }
            else if (param == 1)
            {
                CustomMessageBox messageBox = new CustomMessageBox("Нет данных для редактирования");
                messageBox.ShowDialog(this);
                return;
            }

            switch (name)
            {
                case "Самолеты":
                    {
                        InsEditPlane ed; // Форма
                        if (param == 0) ed = new InsEditPlane("Добавление самолета", this.ConnectionString);
                        else ed = new InsEditPlane("Изменение данных о самолете", this.ConnectionString, this.dt.Rows[dataGridView2.CurrentRow.Index]);
                        ed.Tag = param;
                        ed.ShowDialog();
                        break;
                    }

                case "Страны":
                    {
                        InsEditCountry ed; // Форма
                        if (param == 0) ed = new InsEditCountry("Добавление страны", this.ConnectionString);
                        else ed = new InsEditCountry("Изменение данных о стране", this.ConnectionString, this.dt.Rows[dataGridView2.CurrentRow.Index]);
                        ed.Tag = param;
                        ed.ShowDialog();
                        break;
                    }

                case "Типы самолетов":
                    {
                        InsEditPlaneType ed; // Форма
                        if (param == 0) ed = new InsEditPlaneType("Добавление типа самолета", this.ConnectionString);
                        else ed = new InsEditPlaneType("Изменение типа самолета", this.ConnectionString, this.dt.Rows[dataGridView2.CurrentRow.Index]);
                        ed.Tag = param;
                        ed.ShowDialog();
                        break;
                    }
                case "Производители":
                    {
                        InsEditManufacturer ed; // Форма
                        if (param == 0) ed = new InsEditManufacturer("Добавление производителя", this.ConnectionString);
                        else ed = new InsEditManufacturer("Изменение производителя", this.ConnectionString, this.dt.Rows[dataGridView2.CurrentRow.Index]);
                        ed.Tag = param;
                        ed.ShowDialog();
                        break;
                    }
                case "Пассажиры":
                    {
                        InsEditPassenger ed; // Форма
                        if (param == 0) ed = new InsEditPassenger("Добавление пассажира", this.ConnectionString);
                        else ed = new InsEditPassenger("Изменение данных о пассажире", this.ConnectionString, this.dt.Rows[dataGridView2.CurrentRow.Index]);
                        ed.Tag = param;
                        ed.ShowDialog();
                        break;
                    }
                case "Пилоты":
                    {
                        InsEditPilot ed; // Форма
                        if (param == 0) ed = new InsEditPilot("Добавление пилота", this.ConnectionString);
                        else ed = new InsEditPilot("Изменение данных о пилоте", this.ConnectionString, this.dt.Rows[dataGridView2.CurrentRow.Index]);
                        ed.Tag = param;
                        ed.ShowDialog();
                        break;
                    }
                case "Билеты":
                    {
                        InsEditTicket ed; // Форма
                        if (param == 0) ed = new InsEditTicket("Добавление билета", this.ConnectionString);
                        else ed = new InsEditTicket("Изменение данных о билете", this.ConnectionString, this.dt.Rows[dataGridView2.CurrentRow.Index]);
                        ed.Tag = param;
                        ed.ShowDialog();
                        break;
                    }
                case "Рейсы":
                    {
                        InsEditFlight ed; // Форма
                        if (param == 0) ed = new InsEditFlight("Добавление рейса", this.ConnectionString);
                        else ed = new InsEditFlight("Изменение данных о рейсе", this.ConnectionString, this.dt.Rows[dataGridView2.CurrentRow.Index]);
                        ed.Tag = param;
                        ed.ShowDialog();
                        break;
                    }
            }

            this.dt.Clear();
            using (var conn = new SQLiteConnection(this.ConnectionString))
            {
                conn.Open();
                a = new SQLiteDataAdapter(this.query, conn);
                a.Fill(this.dt);
            }

            dataGridView2.DataSource = this.dt;

            if (rowCount != 0)
            {
                this.dt.Clear();
                using (var conn = new SQLiteConnection(this.ConnectionString))
                {
                    conn.Open();
                    a = new SQLiteDataAdapter(this.query, conn);
                    a.Fill(this.dt);
                }

                dataGridView2.DataSource = this.dt;

                if (param == 0)
                {
                    dataGridView2.CurrentCell = dataGridView2[1, dataGridView2.Rows.Count - 1];
                }

                if (param == 1)
                {
                    dataGridView2.CurrentCell = dataGridView2[1, CurrentIndex];
                }
            }
        }


        private void Table_Load(object sender, EventArgs e)
        {

        }


        private void InsTable_Click(object sender, EventArgs e)
        {
            InsEdit(0);
        }

        private void EditTable_Click(object sender, EventArgs e)
        {
            InsEdit(1);
        }

        private void CloseTable_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DelTable_Click(object sender, EventArgs e)
        {
            if (dataGridView2.RowCount == 0)
            {
                CustomMessageBox messageBox = new CustomMessageBox("Нет данных для удаления");
                messageBox.ShowDialog(this);
                return;
            }

            if (dataGridView2.RowCount != 0 && dataGridView2.CurrentRow.Index != 0)
            {
                CurrentIndex = dataGridView2.CurrentRow.Index - 1;
            }

            try
            {
                using (var conn = new SQLiteConnection(this.ConnectionString))
                {
                    conn.Open();
                    command = new SQLiteCommand("DELETE From " + this.nameTable + " " +
                        "Where " + dt.Columns[0].ColumnName + " = " + dt.Rows[dataGridView2.CurrentRow.Index][0], conn);
                    command.ExecuteNonQuery();
                    this.dt.Clear();
                    a = new SQLiteDataAdapter(query, conn);
                    a.Fill(this.dt);
                }

                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                CustomMessageBox messageBox = new CustomMessageBox(ex.Message);
                messageBox.ShowDialog(this);
            }

            if (dataGridView2.RowCount != 0)
            {
                dataGridView2.CurrentCell =
                    dataGridView2.Rows[CurrentIndex].Cells[dataGridView2.ColumnCount - 1];
            }

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(this.ConnectionString))
            {
                if (toolStripTextBox1.Text != "")
                {
                    conn.Open();
                    string field = "";
                    switch (this.nameTable)
                    {
                        case "Pilot":
                            {
                                field = "ФИО";
                                query = "Select FIO as [ФИО], passport_details as [Паспортные данные], " +
                                    $"phone_number as [Номер телефона], experience as [Стаж], birth_date as [Дата рождения] from {this.nameTable} where [{field}] glob '*{toolStripTextBox1.Text}*'";
                                break;
                            }
                        case "Plane":
                            {
                                field = "Производитель";
                                query = "SELECT Manufacturer.manufacturer_name as [Производитель], PlaneType.type_name as [Тип самолета], capacity as [Вместимость] " +
                                    "from Manufacturer inner join (PlaneType inner join Plane on Plane.id_type = PlaneType.id_planetype) " +
                                    $"on Manufacturer.id_manufacturer = Plane.id_manufacturer where [{field}] glob '*{toolStripTextBox1.Text}*'";
                                break;
                            }
                        case "Passenger":
                            {
                                field = "ФИО";
                                query = "SELECT FIO as [ФИО], phone_number as [Номер телефона], passport_details as [Паспортные данные], birth_date as [Дата рождения] " +
                                    $"from Passenger where [{field}] glob '*{toolStripTextBox1.Text}*'";
                                break;
                            }
                        case "Flight":
                            {
                                field = "Пилот";
                                query = "select Pilot.FIO as [Пилот], Manufacturer.manufacturer_name || \" \" || PlaneType.type_name as [Самолет], " +
                                    "country1.country_name as [Страна отправления], " +
                                    "country2.country_name as [Страна прибытия], " +
                                    "departure_time as [Время отправления], " +
                                    "arrival_time as [Время прибытия], " +
                                    "status as [Статус] " +
                                    "FROM Country as country2 INNER join " +
                                    "(Country as country1 inner join " +
                                    "(Pilot inner join " +
                                    "(Flight inner JOIN " +
                                    "(Manufacturer INNER join " +
                                    "(Plane inner join PlaneType " +
                                    "on Plane.id_plane = PlaneType.id_planetype) " +
                                    "on Manufacturer.id_manufacturer = PLane.id_manufacturer) " +
                                    "on Flight.id_plane = Plane.id_plane) " +
                                    "on Flight.id_pilot = Pilot.id_pilot) " +
                                    "on country1.id_country = Flight.id_departure_country) " +
                                    "on country2.id_country = Flight.id_arrival_country " +
                                    $"where [{field}] glob '*{toolStripTextBox1.Text}*'";
                                break;
                            }
                        case "Ticket":
                            field = "ФИО пассажира";
                            query = "SELECT id_ticket, Passenger.FIO as [ФИО пассажира], Flight.departure_time as [Время отправления рейса], " +
                                "buy_date as [Дата покупки билета], price as [Цена] " +
                                "from Passenger inner join " +
                                "(Ticket inner join Flight " +
                                "on Flight.id_flight = Ticket.id_flight) " +
                                $"on Passenger.id_passenger = Ticket.id_passenger where [{field}] glob '*{toolStripTextBox1.Text}*'";
                            break;
                        case "Country":
                            {
                                field = "Страна";
                                query = $"select country_name as [Страна] from Country where [{field}] glob '*{toolStripTextBox1.Text}*'";
                                break;
                            }
                        case "Manufacturer":
                            {
                                field = "Производитель";
                                query = $"select manufacturer_name as [Производитель] from Manufacturer where [{field}] glob '*{toolStripTextBox1.Text}*'";
                                break;
                            }
                        case "PlaneType":
                            {
                                field = "Тип самолета";
                                query = $"select type_name as [Тип самолета] from PlaneType where [{field}] glob '*{toolStripTextBox1.Text}*'";
                                break;
                            }
                    }
                    this.dt.Clear();
                    a = new SQLiteDataAdapter(query, conn);
                    a.Fill(dt);
                    dataGridView2.DataSource = this.dt;

                    conn.Close();
                }

                else
                {
                    switch (this.nameTable)
                    {
                        case "Pilot":
                            {
                                query = "Select FIO as [ФИО], passport_details as [Паспортные данные], " +
                                    $"phone_number as [Номер телефона], experience as [Стаж], birth_date as [Дата рождения] from {this.nameTable}";
                                break;
                            }
                        case "Plane":
                            {
                                query = "SELECT Manufacturer.manufacturer_name as [Производитель], PlaneType.type_name as [Тип самолета], capacity as [Вместимость] " +
                                    "from Manufacturer inner join (PlaneType inner join Plane on Plane.id_type = PlaneType.id_planetype) " +
                                    "on Manufacturer.id_manufacturer = Plane.id_manufacturer";
                                break;
                            }
                        case "Passenger":
                            {
                                query = "SELECT FIO as [ФИО], phone_number as [Номер телефона], passport_details as [Паспортные данные], birth_date as [Дата рождения] " +
                                    "from Passenger";
                                break;
                            }
                        case "Flight":
                            {
                                query = "select Pilot.FIO as [Пилот], Manufacturer.manufacturer_name || \" \" || PlaneType.type_name as [Самолет], " +
                                "country1.country_name as [Страна отправления], " +
                                "country2.country_name as [Страна прибытия], " +
                                "departure_time as [Время отправления], " +
                                "arrival_time as [Время прибытия], " +
                                "status as [Статус] " +
                                "FROM Country as country2 INNER join " +
                                "(Country as country1 inner join " +
                                "(Pilot inner join " +
                                "(Flight inner JOIN " +
                                "(Manufacturer INNER join " +
                                "(Plane inner join PlaneType " +
                                "on Plane.id_plane = PlaneType.id_planetype) " +
                                "on Manufacturer.id_manufacturer = PLane.id_manufacturer) " +
                                "on Flight.id_plane = Plane.id_plane) " +
                                "on Flight.id_pilot = Pilot.id_pilot) " +
                                "on country1.id_country = Flight.id_departure_country) " +
                                "on country2.id_country = Flight.id_arrival_country ";
                                break;
                            }
                        case "Ticket":
                            query = "SELECT id_ticket, Passenger.FIO as [ФИО пассажира], Flight.departure_time as [Время отправления рейса], " +
                                "buy_date as [Дата покупки билета], price as [Цена] " +
                                "from Passenger inner join " +
                                "(Ticket inner join Flight " +
                                "on Flight.id_flight = Ticket.id_flight) " +
                                $"on Passenger.id_passenger = Ticket.id_passenger";
                            break;
                        case "Country":
                            {
                                query = "select country_name as [Страна] from Country ";
                                break;
                            }
                        case "Manufacturer":
                            {
                                query = "select manufacturer_name as [Производитель] from Manufacturer ";
                                break;
                            }
                        case "PlaneType":
                            {
                                query = "select type_name as [Тип самолета] from PlaneType ";
                                break;
                            }

                    }
                    this.dt.Clear();
                    a = new SQLiteDataAdapter(query, conn);
                    a.Fill(dt);
                    dataGridView2.DataSource = this.dt;

                    conn.Close();
                }
            }
        }
    }
}
