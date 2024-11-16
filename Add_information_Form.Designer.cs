namespace database_app_task1
{
    partial class Add_information_Form
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.RoomNumber = new System.Windows.Forms.TextBox();
            this.DormitoryAddress = new System.Windows.Forms.TextBox();
            this.CheckInDate_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.DormitoryAddress_label = new System.Windows.Forms.Label();
            this.RoomNumber_label = new System.Windows.Forms.Label();
            this.CheckInDate_label = new System.Windows.Forms.Label();
            this.DormitoryName_label = new System.Windows.Forms.Label();
            this.CheckOutDate_label = new System.Windows.Forms.Label();
            this.CheckOutDate_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.DormitoryName = new System.Windows.Forms.TextBox();
            this.save_button = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68F));
            this.tableLayoutPanel1.Controls.Add(this.RoomNumber, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.DormitoryAddress, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.CheckInDate_dateTimePicker, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.DormitoryAddress_label, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.RoomNumber_label, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.CheckInDate_label, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.DormitoryName_label, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.CheckOutDate_label, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.CheckOutDate_dateTimePicker, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.DormitoryName, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(494, 397);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // RoomNumber
            // 
            this.RoomNumber.Location = new System.Drawing.Point(161, 326);
            this.RoomNumber.Name = "RoomNumber";
            this.RoomNumber.Size = new System.Drawing.Size(286, 20);
            this.RoomNumber.TabIndex = 15;
            this.RoomNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RoomNumber_KeyPress);
            // 
            // DormitoryAddress
            // 
            this.DormitoryAddress.Location = new System.Drawing.Point(161, 248);
            this.DormitoryAddress.Name = "DormitoryAddress";
            this.DormitoryAddress.Size = new System.Drawing.Size(286, 20);
            this.DormitoryAddress.TabIndex = 14;
            // 
            // CheckInDate_dateTimePicker
            // 
            this.CheckInDate_dateTimePicker.Location = new System.Drawing.Point(161, 3);
            this.CheckInDate_dateTimePicker.Name = "CheckInDate_dateTimePicker";
            this.CheckInDate_dateTimePicker.Size = new System.Drawing.Size(286, 20);
            this.CheckInDate_dateTimePicker.TabIndex = 5;
            // 
            // DormitoryAddress_label
            // 
            this.DormitoryAddress_label.AutoSize = true;
            this.DormitoryAddress_label.Location = new System.Drawing.Point(3, 245);
            this.DormitoryAddress_label.Name = "DormitoryAddress_label";
            this.DormitoryAddress_label.Size = new System.Drawing.Size(102, 13);
            this.DormitoryAddress_label.TabIndex = 12;
            this.DormitoryAddress_label.Text = "Адрес общежития:";
            // 
            // RoomNumber_label
            // 
            this.RoomNumber_label.AutoSize = true;
            this.RoomNumber_label.Location = new System.Drawing.Point(3, 323);
            this.RoomNumber_label.Name = "RoomNumber_label";
            this.RoomNumber_label.Size = new System.Drawing.Size(92, 13);
            this.RoomNumber_label.TabIndex = 9;
            this.RoomNumber_label.Text = "Номер комнаты:";
            // 
            // CheckInDate_label
            // 
            this.CheckInDate_label.AutoSize = true;
            this.CheckInDate_label.Location = new System.Drawing.Point(3, 0);
            this.CheckInDate_label.Name = "CheckInDate_label";
            this.CheckInDate_label.Size = new System.Drawing.Size(93, 13);
            this.CheckInDate_label.TabIndex = 5;
            this.CheckInDate_label.Text = "Дата заселения:";
            // 
            // DormitoryName_label
            // 
            this.DormitoryName_label.AutoSize = true;
            this.DormitoryName_label.Location = new System.Drawing.Point(3, 161);
            this.DormitoryName_label.Name = "DormitoryName_label";
            this.DormitoryName_label.Size = new System.Drawing.Size(121, 13);
            this.DormitoryName_label.TabIndex = 7;
            this.DormitoryName_label.Text = "Название общежития:";
            // 
            // CheckOutDate_label
            // 
            this.CheckOutDate_label.AutoSize = true;
            this.CheckOutDate_label.Location = new System.Drawing.Point(3, 77);
            this.CheckOutDate_label.Name = "CheckOutDate_label";
            this.CheckOutDate_label.Size = new System.Drawing.Size(95, 13);
            this.CheckOutDate_label.TabIndex = 8;
            this.CheckOutDate_label.Text = "Дата выселения:";
            // 
            // CheckOutDate_dateTimePicker
            // 
            this.CheckOutDate_dateTimePicker.Location = new System.Drawing.Point(161, 80);
            this.CheckOutDate_dateTimePicker.Name = "CheckOutDate_dateTimePicker";
            this.CheckOutDate_dateTimePicker.Size = new System.Drawing.Size(286, 20);
            this.CheckOutDate_dateTimePicker.TabIndex = 6;
            this.CheckOutDate_dateTimePicker.ValueChanged += new System.EventHandler(this.CheckOutDate_dateTimePicker_ValueChanged);
            // 
            // DormitoryName
            // 
            this.DormitoryName.Location = new System.Drawing.Point(161, 164);
            this.DormitoryName.Name = "DormitoryName";
            this.DormitoryName.Size = new System.Drawing.Size(286, 20);
            this.DormitoryName.TabIndex = 13;
            this.DormitoryName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DormitoryName_KeyPress);
            // 
            // save_button
            // 
            this.save_button.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.save_button.Location = new System.Drawing.Point(431, 429);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(75, 23);
            this.save_button.TabIndex = 5;
            this.save_button.Text = "Сохранить";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // Add_information_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 472);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.save_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Add_information_Form";
            this.Text = "Добавить/Изменить строку";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Add_information_Form_FormClosing);
            this.Load += new System.EventHandler(this.Add_information_Form_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label DormitoryAddress_label;
        private System.Windows.Forms.Label CheckOutDate_label;
        private System.Windows.Forms.Label RoomNumber_label;
        private System.Windows.Forms.Label CheckInDate_label;
        private System.Windows.Forms.Label DormitoryName_label;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.DateTimePicker CheckInDate_dateTimePicker;
        private System.Windows.Forms.DateTimePicker CheckOutDate_dateTimePicker;
        private System.Windows.Forms.TextBox RoomNumber;
        private System.Windows.Forms.TextBox DormitoryAddress;
        private System.Windows.Forms.TextBox DormitoryName;
    }
}