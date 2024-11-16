namespace database_app_task1
{
    partial class Add_students_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.save_button = new System.Windows.Forms.Button();
            this.FIO_textbox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DateBirth_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.When_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.FIO_label = new System.Windows.Forms.Label();
            this.Who_textBox = new System.Windows.Forms.TextBox();
            this.PassportNumber_textBox = new System.Windows.Forms.TextBox();
            this.PassportNumber_label = new System.Windows.Forms.Label();
            this.PassportSeries_textbox = new System.Windows.Forms.TextBox();
            this.When_label = new System.Windows.Forms.Label();
            this.Who_label = new System.Windows.Forms.Label();
            this.Gender_label = new System.Windows.Forms.Label();
            this.DataBirth_label = new System.Windows.Forms.Label();
            this.PassportSeries_label = new System.Windows.Forms.Label();
            this.Gender_comboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // save_button
            // 
            this.save_button.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.save_button.Location = new System.Drawing.Point(431, 431);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(75, 23);
            this.save_button.TabIndex = 0;
            this.save_button.Text = "Сохранить";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // FIO_textbox
            // 
            this.FIO_textbox.Location = new System.Drawing.Point(161, 3);
            this.FIO_textbox.Name = "FIO_textbox";
            this.FIO_textbox.Size = new System.Drawing.Size(286, 20);
            this.FIO_textbox.TabIndex = 1;
            this.FIO_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FIO_textbox_KeyPress);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68F));
            this.tableLayoutPanel1.Controls.Add(this.DateBirth_dateTimePicker, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.When_dateTimePicker, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.FIO_label, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Who_textBox, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.PassportNumber_textBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.PassportNumber_label, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.PassportSeries_textbox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.When_label, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.Who_label, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.Gender_label, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.DataBirth_label, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.PassportSeries_label, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Gender_comboBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.FIO_textbox, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(494, 397);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // DateBirth_dateTimePicker
            // 
            this.DateBirth_dateTimePicker.Location = new System.Drawing.Point(161, 52);
            this.DateBirth_dateTimePicker.Name = "DateBirth_dateTimePicker";
            this.DateBirth_dateTimePicker.Size = new System.Drawing.Size(286, 20);
            this.DateBirth_dateTimePicker.TabIndex = 5;
            // 
            // When_dateTimePicker
            // 
            this.When_dateTimePicker.Location = new System.Drawing.Point(161, 328);
            this.When_dateTimePicker.Name = "When_dateTimePicker";
            this.When_dateTimePicker.Size = new System.Drawing.Size(286, 20);
            this.When_dateTimePicker.TabIndex = 6;
            // 
            // FIO_label
            // 
            this.FIO_label.AutoSize = true;
            this.FIO_label.Location = new System.Drawing.Point(3, 0);
            this.FIO_label.Name = "FIO_label";
            this.FIO_label.Size = new System.Drawing.Size(37, 13);
            this.FIO_label.TabIndex = 5;
            this.FIO_label.Text = "ФИО:";
            // 
            // Who_textBox
            // 
            this.Who_textBox.Location = new System.Drawing.Point(161, 270);
            this.Who_textBox.Name = "Who_textBox";
            this.Who_textBox.Size = new System.Drawing.Size(286, 20);
            this.Who_textBox.TabIndex = 10;
            this.Who_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Who_textBox_KeyPress);
            // 
            // PassportNumber_textBox
            // 
            this.PassportNumber_textBox.Location = new System.Drawing.Point(161, 214);
            this.PassportNumber_textBox.Name = "PassportNumber_textBox";
            this.PassportNumber_textBox.Size = new System.Drawing.Size(286, 20);
            this.PassportNumber_textBox.TabIndex = 11;
            this.PassportNumber_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PassportNumber_textBox_KeyPress);
            // 
            // PassportNumber_label
            // 
            this.PassportNumber_label.AutoSize = true;
            this.PassportNumber_label.Location = new System.Drawing.Point(3, 211);
            this.PassportNumber_label.Name = "PassportNumber_label";
            this.PassportNumber_label.Size = new System.Drawing.Size(96, 13);
            this.PassportNumber_label.TabIndex = 12;
            this.PassportNumber_label.Text = "Номер Паспорта:";
            // 
            // PassportSeries_textbox
            // 
            this.PassportSeries_textbox.Location = new System.Drawing.Point(161, 156);
            this.PassportSeries_textbox.Name = "PassportSeries_textbox";
            this.PassportSeries_textbox.Size = new System.Drawing.Size(286, 20);
            this.PassportSeries_textbox.TabIndex = 13;
            this.PassportSeries_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PassportSeries_textbox_KeyPress);
            // 
            // When_label
            // 
            this.When_label.AutoSize = true;
            this.When_label.Location = new System.Drawing.Point(3, 325);
            this.When_label.Name = "When_label";
            this.When_label.Size = new System.Drawing.Size(75, 13);
            this.When_label.TabIndex = 8;
            this.When_label.Text = "Когда выдан:";
            // 
            // Who_label
            // 
            this.Who_label.AutoSize = true;
            this.Who_label.Location = new System.Drawing.Point(3, 267);
            this.Who_label.Name = "Who_label";
            this.Who_label.Size = new System.Drawing.Size(66, 13);
            this.Who_label.TabIndex = 9;
            this.Who_label.Text = "Кем выдан:";
            // 
            // Gender_label
            // 
            this.Gender_label.AutoSize = true;
            this.Gender_label.Location = new System.Drawing.Point(3, 98);
            this.Gender_label.Name = "Gender_label";
            this.Gender_label.Size = new System.Drawing.Size(30, 13);
            this.Gender_label.TabIndex = 6;
            this.Gender_label.Text = "Пол:";
            // 
            // DataBirth_label
            // 
            this.DataBirth_label.AutoSize = true;
            this.DataBirth_label.Location = new System.Drawing.Point(3, 49);
            this.DataBirth_label.Name = "DataBirth_label";
            this.DataBirth_label.Size = new System.Drawing.Size(89, 13);
            this.DataBirth_label.TabIndex = 5;
            this.DataBirth_label.Text = "Дата рождения:";
            // 
            // PassportSeries_label
            // 
            this.PassportSeries_label.AutoSize = true;
            this.PassportSeries_label.Location = new System.Drawing.Point(3, 153);
            this.PassportSeries_label.Name = "PassportSeries_label";
            this.PassportSeries_label.Size = new System.Drawing.Size(91, 13);
            this.PassportSeries_label.TabIndex = 7;
            this.PassportSeries_label.Text = "Серия паспорта:";
            // 
            // Gender_comboBox
            // 
            this.Gender_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Gender_comboBox.FormattingEnabled = true;
            this.Gender_comboBox.Items.AddRange(new object[] {
            "Мужской",
            "Женский"});
            this.Gender_comboBox.Location = new System.Drawing.Point(161, 101);
            this.Gender_comboBox.Name = "Gender_comboBox";
            this.Gender_comboBox.Size = new System.Drawing.Size(286, 21);
            this.Gender_comboBox.TabIndex = 15;
            // 
            // Add_students_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 466);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.save_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Add_students_Form";
            this.Text = "Добавить/Изменить строку";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Add_students_Form_FormClosing);
            this.Load += new System.EventHandler(this.Add_students_Form_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.TextBox FIO_textbox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label FIO_label;
        private System.Windows.Forms.Label DataBirth_label;
        private System.Windows.Forms.Label Gender_label;
        private System.Windows.Forms.Label PassportSeries_label;
        private System.Windows.Forms.Label When_label;
        private System.Windows.Forms.Label Who_label;
        private System.Windows.Forms.TextBox Who_textBox;
        private System.Windows.Forms.TextBox PassportNumber_textBox;
        private System.Windows.Forms.Label PassportNumber_label;
        private System.Windows.Forms.TextBox PassportSeries_textbox;
        private System.Windows.Forms.ComboBox Gender_comboBox;
        private System.Windows.Forms.DateTimePicker DateBirth_dateTimePicker;
        private System.Windows.Forms.DateTimePicker When_dateTimePicker;
    }
}