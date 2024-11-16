using database_app3;
using System;
using System.Data;
using System.Windows.Forms;

namespace database_app_task1
{
    public partial class Add_information_Form : Form
    {
        DataTable new_dt;
        DataRow new_fill_row;
        int new_student_code;

        public Add_information_Form(DataTable dt, DataRow student_row = null, string student_code = null)
        {
            InitializeComponent();
            new_dt = dt;
            if (student_code != null)
            {
                new_student_code = int.Parse(student_code);
            }
            new_fill_row = student_row;

            if (new_fill_row != null)
            {
                CheckInDate_dateTimePicker.Text = (string) new_fill_row["Дата_заселения"].ToString();
                CheckOutDate_dateTimePicker.Text = (string) new_fill_row["Дата_выселения"].ToString();
                DormitoryName.Text = (string) new_fill_row["Название_общежития"];
                DormitoryAddress.Text = (string) new_fill_row["Адрес_общежития"];
                RoomNumber.Text = (string) new_fill_row["Номер_комнаты"].ToString();
            }
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            if (DormitoryName.Text == string.Empty) MessageBox.Show("Пропущено имя общежития!");
            else if (DormitoryAddress.Text == string.Empty) MessageBox.Show("Пропущен адрес общежития!");
            else if (RoomNumber.Text == string.Empty) MessageBox.Show("Пропущен номер комнаты!");

            else
            {
                this.DialogResult = DialogResult.Yes;
                DataRow new_row = new_dt.NewRow();
                // new_row["Код_записи"] = (int)new_dt.Rows[new_dt.Rows.Count - 1][0] + 1;
                new_row["Код_студента"] = new_student_code;
                new_row["Дата_заселения"] = CheckInDate_dateTimePicker.Value.ToString().Split()[0];
                new_row["Дата_выселения"] = CheckOutDate_dateTimePicker.Value.ToString().Split()[0];
                new_row["Название_общежития"] = DormitoryName.Text;
                new_row["Адрес_общежития"] = DormitoryAddress.Text;
                new_row["Номер_комнаты"] = RoomNumber.Text;

                if (new_fill_row != null)
                {
                    new_fill_row["Код_студента"] = new_student_code;
                    new_fill_row["Дата_заселения"] = CheckInDate_dateTimePicker.Value.ToString().Split()[0];
                    new_fill_row["Дата_выселения"] = CheckOutDate_dateTimePicker.Value.ToString().Split()[0];
                    new_fill_row["Название_общежития"] = DormitoryName.Text;
                    new_fill_row["Адрес_общежития"] = DormitoryAddress.Text;
                    new_fill_row["Номер_комнаты"] = RoomNumber.Text;
                }
                else {
                    new_dt.Rows.Add(new_row);
                };
                this.Close();
            }
        }

        private void DormitoryName_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void RoomNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void CheckOutDate_dateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Add_information_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                e.Cancel = true;
                return;
            }

            e.Cancel = false;
        }

        private void Add_information_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
