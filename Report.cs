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
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using System.Threading;
using System.IO;
using Aspose.Pdf;

namespace database_app3
{

    public partial class Report : Form
    {
        static string path = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
        private string ConnectionString;
        private SQLiteDataAdapter a;
        private DataSet tmp;
        private DataTable dt = new DataTable();
        private string query;

        public Report(int rep, string ConnectionString)
        {
            InitializeComponent();
            this.ConnectionString = ConnectionString;
            using (var conn = new SQLiteConnection(this.ConnectionString))
            {
                tmp = new DataSet();

                if (rep == 1)
                {
                    Tag = 1;
                    label1.Text = "Выберите пилота";
                    tmp.Tables.Add(new DataTable("Pilot"));
                    query = "Select id_pilot, FIO from Pilot";
                    a = new SQLiteDataAdapter(query, conn);

                    a.Fill(tmp.Tables["Pilot"]);

                    comboBox1.DisplayMember = tmp.Tables["Pilot"].Columns["FIO"].ToString();
                    comboBox1.ValueMember = tmp.Tables["Pilot"].Columns["id_pilot"].ToString();
                    comboBox1.DataSource = tmp.Tables["Pilot"];
                }

                else if (rep == 2)
                {
                    Tag = 2;
                    label1.Text = "Выберите самолет";
                    tmp.Tables.Add(new DataTable("Plane"));
                    query = "SELECT id_plane, Manufacturer.manufacturer_name || \" \" || PlaneType.type_name as [Plane] " +
                        "from Manufacturer inner join " +
                        "(Plane inner join PlaneType on PlaneType.id_planetype = Plane.id_type) " +
                        "on Manufacturer.id_manufacturer = Plane.id_manufacturer";
                    a = new SQLiteDataAdapter(query, conn);
                    a.Fill(tmp.Tables["Plane"]);

                    comboBox1.DisplayMember = tmp.Tables["Plane"].Columns["Plane"].ToString();
                    comboBox1.ValueMember = tmp.Tables["Plane"].Columns["id_plane"].ToString();
                    comboBox1.DataSource = tmp.Tables["Plane"];
                }

                else
                {
                    Tag = 3;
                    label1.Text = "Выберите страну";
                    tmp.Tables.Add(new DataTable("Country"));

                    query = "Select id_country, country_name from Country";
                    a = new SQLiteDataAdapter(query, conn);
                    a.Fill(tmp.Tables["Country"]);

                    comboBox1.DisplayMember = tmp.Tables["Country"].Columns["country_name"].ToString();
                    comboBox1.ValueMember = tmp.Tables["Country"].Columns["id_country"].ToString();
                    comboBox1.DataSource = tmp.Tables["Country"];
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //Сформировать отчет
        private void button1_Click(object sender, EventArgs e)
        {
            //Все рейсы проведенные одним пилотом
            if ((int)Tag == 1)
            {
                try
                {
                    string value = comboBox1.SelectedValue.ToString();
                    string Text = comboBox1.Text;

                    Thread th = new Thread(() => GetOtchet1(value, Text));
                    th.Start();
                }
                catch (Exception ex)
                {
                    CustomMessageBox messageBox = new CustomMessageBox("Ошибка попробуйте еще раз!");
                    messageBox.ShowDialog();
                    return;
                }

            }

            else if ((int)Tag == 2)
            {
                try
                {
                    string value = comboBox1.SelectedValue.ToString();
                    string Text = comboBox1.Text;
                    Thread th = new Thread(() => GetOtchet2(value, Text));
                    th.Start();
                }
                catch (Exception ex)
                {
                    CustomMessageBox messageBox = new CustomMessageBox("Ошибка попробуйте еще раз!");
                    messageBox.ShowDialog();
                    return;
                }

            }

            else if ((int)Tag == 3)
            {
                try
                {
                    string value = comboBox1.SelectedValue.ToString();
                    string Text = comboBox1.Text;
                    Thread th = new Thread(() => GetOtchet3(value, Text));
                    th.Start();
                }
                catch (Exception ex)
                {
                    CustomMessageBox messageBox = new CustomMessageBox("Ошибка попробуйте еще раз!");
                    messageBox.ShowDialog();
                    return;
                }
            }

        }


        private void GetOtchet1(string value, string text)
        {
            using (var conn = new SQLiteConnection(this.ConnectionString))
            {
                query = "Select Flight.id_flight, Pilot.FIO as [Пилот], Manufacturer.manufacturer_name || \" \" || " +
                    "PlaneType.type_name as [Самолет], " +
                    "country1.country_name as [Страна отправления], " +
                    "country2.country_name as [Страна прибытия],  " +
                    "STRFTIME('%d-%m-%Y %H:%M', datetime(Flight.departure_time)) as [Время отправления], " +
                    "STRFTIME('%d-%m-%Y %H:%M', datetime(Flight.arrival_time)) as [Время прибытия], " +
                    "Flight.status as [Статус] " +
                    "From Country as country2 inner join " +
                    "(Country as country1 inner join " +
                    "(Pilot inner JOIN " +
                    "(Flight inner join " +
                    "(Manufacturer inner join " +
                    "(Plane inner join PlaneType on " +
                    "PlaneType.id_planetype = Plane.id_type) " +
                    "on Manufacturer.id_manufacturer = Plane.id_manufacturer) " +
                    "on Plane.id_plane = Flight.id_plane) " +
                    "on Pilot.id_pilot = Flight.id_pilot) " +
                    "on Flight.id_departure_country = country1.id_country) " +
                    "on Flight.id_arrival_country = country2.id_country where Pilot.id_pilot = " + value;

                a = new SQLiteDataAdapter(query, conn);
                dt.Clear();
                a.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    CustomMessageBox messageBox = new CustomMessageBox("Нет данных для формирования отчета!");
                    messageBox.ShowDialog();
                    return;
                }
                else
                {
                    Excel.Application ObjExcel = new Excel.Application();
                    Excel.Workbook ObjWorkBook;
                    Excel.Worksheet ObjWorkSheet;

                    //Создание книги
                    ObjWorkBook = ObjExcel.Workbooks.Add(System.Reflection.Missing.Value);

                    //Создание листа
                    ObjWorkSheet = (Excel.Worksheet)ObjWorkBook.Sheets[1];
                    ObjWorkSheet.Cells[1, 1] = "Пилот";
                    ObjWorkSheet.Cells[1, 2] = "Самолет";
                    ObjWorkSheet.Cells[1, 3] = "Страна отправления";
                    ObjWorkSheet.Cells[1, 4] = "Страна прибытия";
                    ObjWorkSheet.Cells[1, 5] = "Время отправления";
                    ObjWorkSheet.Cells[1, 6] = "Время прибытия";
                    ObjWorkSheet.Cells[1, 7] = "Статус";

                    for (int _row = 0; _row < dt.Rows.Count; _row++)
                    {
                        DataRow dr = dt.Rows[_row];
                        ObjWorkSheet.Cells[_row + 2, 1] = dr["Пилот"].ToString();
                        ObjWorkSheet.Cells[_row + 2, 2] = dr["Самолет"].ToString();
                        ObjWorkSheet.Cells[_row + 2, 3] = dr["Страна отправления"].ToString();
                        ObjWorkSheet.Cells[_row + 2, 4] = dr["Страна прибытия"].ToString();
                        ObjWorkSheet.Cells[_row + 2, 5] = dr["Время отправления"].ToString();
                        ObjWorkSheet.Cells[_row + 2, 6] = dr["Время прибытия"].ToString();
                        ObjWorkSheet.Cells[_row + 2, 7] = dr["Статус"].ToString();
                    }

                    ObjWorkBook.SaveAs(path + "\\Отчеты\\Отчет1.xlsx");
                    ObjExcel.UserControl = true;
                    ObjExcel.Quit();

                    CustomMessageBox messageBox = new CustomMessageBox("Отчет сформирован и находится по пути: \"" + path + "\\Отчеты\\Отчет1.xlsx\"");
                    messageBox.ShowDialog();
                }
            }   
        }

        private void GetOtchet2(string value, string text)
        {
            using (var conn = new SQLiteConnection(this.ConnectionString))
            {
                query = "SELECT Manufacturer.manufacturer_name || \" \" || PlaneType.type_name as [Самолет], " +
                    "country2.country_name as [Страна отправления], " +
                    "country1.country_name as [Страна прибытия], " +
                    "STRFTIME('%d-%m-%Y %H:%M', datetime(Flight.departure_time)) as [Время отправления], " +
                    "STRFTIME('%d-%m-%Y %H:%M', datetime(Flight.arrival_time)) as [Время прибытия] " +
                    "From Country as country1 Inner join " +
                    "(Country as country2 inner join " +
                    "(Flight inner join " +
                    "(Manufacturer inner join " +
                    "(Plane inner join PlaneType " +
                    "on Plane.id_type = PlaneType.id_planetype) " +
                    "on Plane.id_manufacturer = Manufacturer.id_manufacturer) " +
                    "on Plane.id_plane = Flight.id_plane ) " +
                    "on country2.id_country = Flight.id_departure_country) " +
                    "on country1.id_country = Flight.id_arrival_country where Flight.id_plane = " + value;

                a = new SQLiteDataAdapter(query, conn);
                dt.Clear();
                a.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    CustomMessageBox messageBox = new CustomMessageBox("Нет данных для формирования отчета!");
                    messageBox.ShowDialog(); 
                    return;
                }
                else
                {
                    Word.Application wrdApp = new Word.Application();
                    Word.Document wrdDoc = wrdApp.Documents.Add();
                    Word.Range range = wrdDoc.Range();
                    range.InsertAfter("Самолет: " + Text);
                    range.InsertParagraphAfter();
                    range = wrdDoc.Range();
                    Word.Table wrdTable = wrdDoc.Tables.Add(range, dt.Rows.Count + 1, 5);
                    wrdTable.Borders.Enable = 1;
                    wrdDoc.Tables[1].Cell(1, 1).Range.InsertAfter("Самолет");
                    wrdDoc.Tables[1].Cell(1, 2).Range.InsertAfter("Страна отправления");
                    wrdDoc.Tables[1].Cell(1, 3).Range.InsertAfter("Страна прибытия");
                    wrdDoc.Tables[1].Cell(1, 4).Range.InsertAfter("Время отправления");
                    wrdDoc.Tables[1].Cell(1, 5).Range.InsertAfter("Время прибытия");

                    for (int _row = 0; _row < dt.Rows.Count; _row++)
                    {
                        DataRow dr = dt.Rows[_row];
                        wrdDoc.Tables[1].Cell(_row + 2, 1).Range.InsertAfter(dr["Самолет"].ToString());
                        wrdDoc.Tables[1].Cell(_row + 2, 2).Range.InsertAfter(dr["Страна отправления"].ToString());
                        wrdDoc.Tables[1].Cell(_row + 2, 3).Range.InsertAfter(dr["Страна прибытия"].ToString());
                        wrdDoc.Tables[1].Cell(_row + 2, 4).Range.InsertAfter(dr["Время отправления"].ToString());
                        wrdDoc.Tables[1].Cell(_row + 2, 5).Range.InsertAfter(dr["Время прибытия"].ToString());
                    }
                    wrdDoc.Saved = true;
                    wrdDoc.SaveAs(path + "\\Отчеты\\Отчет2.docx");
                    wrdDoc.Close();
                    wrdApp.Quit();
                    wrdDoc = null;
                    wrdApp = null;

                    CustomMessageBox messageBox = new CustomMessageBox("Отчет сформирован и находится по пути: \"" + path + "\\Отчеты\\Отчет2.docx\"");
                    messageBox.ShowDialog();
                }
            }
        }

        private void GetOtchet3(string value, string text)
        {
            using (var conn = new SQLiteConnection(this.ConnectionString))
            {
                query = "Select Pilot.FIO as [Пилот], Manufacturer.manufacturer_name || \" \" || PlaneType.type_name as [Самолет], " +
                    "country1.country_name as [Страна отправления], STRFTIME('%d-%m-%Y %H:%M', datetime(Flight.departure_time)) as [Время отправления]" +
                    "From Country as country1 inner join " +
                    "(Pilot inner JOIN " +
                    "(Flight inner join " +
                    "(Manufacturer inner join" +
                    " (Plane inner join PlaneType on PlaneType.id_planetype = Plane.id_type)" +
                    " on Manufacturer.id_manufacturer = Plane.id_manufacturer)" +
                    " on Plane.id_plane = Flight.id_plane)" +
                    " on Pilot.id_pilot = Flight.id_pilot)" +
                    " on Flight.id_departure_country = country1.id_country" +
                    " Where country1.id_country = " + value +
                    " order by Flight.departure_time desc";

                a = new SQLiteDataAdapter(query, conn);
                dt.Clear();
                a.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    CustomMessageBox messageBox = new CustomMessageBox("Нет данных для формирования отчета!");
                    messageBox.ShowDialog();
                    return;
                }

                else
                {
                    Document document = new Document();

                    Page page = document.Pages.Add();

                    Aspose.Pdf.Table table = new Aspose.Pdf.Table();

                    table.Border = new BorderInfo(BorderSide.All, .5f, Aspose.Pdf.Color.FromRgb(System.Drawing.Color.LightGray));

                    table.DefaultCellBorder = new BorderInfo(BorderSide.All, .5f, Aspose.Pdf.Color.FromRgb(System.Drawing.Color.LightGray));

                    Row row1 = table.Rows.Add();
                    row1.DefaultCellTextState.FontSize = 16;
                    row1.Cells.Add("Пилот");
                    row1.Cells.Add("Самолет");
                    row1.Cells.Add("Страна отправления");
                    row1.Cells.Add("Время отправления");


                    for (int _row = 0; _row < dt.Rows.Count; _row++)
                    {
                        DataRow dr = dt.Rows[_row];

                        // Добавить строку в таблицу
                        Row row = table.Rows.Add();
                        row.DefaultCellTextState.FontSize = 14;

                        // Добавить ячейки таблицы
                        row.Cells.Add(dr["Пилот"] + "");
                        row.Cells.Add(dr["Самолет"] + "");
                        row.Cells.Add(dr["Страна отправления"] + "");
                        row.Cells.Add(dr["Время отправления"] + "");
                    }

                    document.Pages[1].Paragraphs.Add(table);

                    document.Save(path + "\\Отчеты\\Отчет3.pdf");

                    CustomMessageBox messageBox = new CustomMessageBox("Отчет сформирован и находится по пути: \"" + path + "\\Отчеты\\Отчет3.pdf\"");
                    messageBox.ShowDialog();
                }
            }
        }

        //Выход
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Report_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
