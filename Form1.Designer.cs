namespace database_app3
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.основныеТаблицыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пассажирToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.билетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.рейсыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пилотыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.самолетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.страныToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.прозводителиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.типыСамолетовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.окноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.каскадToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.горизонтальноеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вертикальноеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.рейсыУПилотаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.времяПолетаСамолетовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Sans Serif Collection", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.основныеТаблицыToolStripMenuItem,
            this.справочникиToolStripMenuItem,
            this.окноToolStripMenuItem,
            this.отчетыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.окноToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1106, 47);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(97, 43);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(175, 44);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.Exit_Click);
            // 
            // основныеТаблицыToolStripMenuItem
            // 
            this.основныеТаблицыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.пассажирToolStripMenuItem,
            this.билетыToolStripMenuItem,
            this.рейсыToolStripMenuItem,
            this.пилотыToolStripMenuItem,
            this.самолетыToolStripMenuItem});
            this.основныеТаблицыToolStripMenuItem.Name = "основныеТаблицыToolStripMenuItem";
            this.основныеТаблицыToolStripMenuItem.Size = new System.Drawing.Size(268, 43);
            this.основныеТаблицыToolStripMenuItem.Text = "Основные таблицы";
            // 
            // пассажирToolStripMenuItem
            // 
            this.пассажирToolStripMenuItem.Name = "пассажирToolStripMenuItem";
            this.пассажирToolStripMenuItem.Size = new System.Drawing.Size(240, 44);
            this.пассажирToolStripMenuItem.Text = "Пассажиры";
            this.пассажирToolStripMenuItem.Click += new System.EventHandler(this.Passenger_Click);
            // 
            // билетыToolStripMenuItem
            // 
            this.билетыToolStripMenuItem.Name = "билетыToolStripMenuItem";
            this.билетыToolStripMenuItem.Size = new System.Drawing.Size(240, 44);
            this.билетыToolStripMenuItem.Text = "Билеты";
            this.билетыToolStripMenuItem.Click += new System.EventHandler(this.Tickets_Click);
            // 
            // рейсыToolStripMenuItem
            // 
            this.рейсыToolStripMenuItem.Name = "рейсыToolStripMenuItem";
            this.рейсыToolStripMenuItem.Size = new System.Drawing.Size(240, 44);
            this.рейсыToolStripMenuItem.Text = "Рейсы";
            this.рейсыToolStripMenuItem.Click += new System.EventHandler(this.Flight_Click);
            // 
            // пилотыToolStripMenuItem
            // 
            this.пилотыToolStripMenuItem.Name = "пилотыToolStripMenuItem";
            this.пилотыToolStripMenuItem.Size = new System.Drawing.Size(240, 44);
            this.пилотыToolStripMenuItem.Text = "Пилоты";
            this.пилотыToolStripMenuItem.Click += new System.EventHandler(this.Pilots_Click);
            // 
            // самолетыToolStripMenuItem
            // 
            this.самолетыToolStripMenuItem.Name = "самолетыToolStripMenuItem";
            this.самолетыToolStripMenuItem.Size = new System.Drawing.Size(240, 44);
            this.самолетыToolStripMenuItem.Text = "Самолеты";
            this.самолетыToolStripMenuItem.Click += new System.EventHandler(this.Planes_Click);
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.страныToolStripMenuItem,
            this.прозводителиToolStripMenuItem,
            this.типыСамолетовToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(196, 43);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // страныToolStripMenuItem
            // 
            this.страныToolStripMenuItem.Name = "страныToolStripMenuItem";
            this.страныToolStripMenuItem.Size = new System.Drawing.Size(298, 44);
            this.страныToolStripMenuItem.Text = "Страны";
            this.страныToolStripMenuItem.Click += new System.EventHandler(this.Countries_Click);
            // 
            // прозводителиToolStripMenuItem
            // 
            this.прозводителиToolStripMenuItem.Name = "прозводителиToolStripMenuItem";
            this.прозводителиToolStripMenuItem.Size = new System.Drawing.Size(298, 44);
            this.прозводителиToolStripMenuItem.Text = "Производители";
            this.прозводителиToolStripMenuItem.Click += new System.EventHandler(this.Manufacturers_Click);
            // 
            // типыСамолетовToolStripMenuItem
            // 
            this.типыСамолетовToolStripMenuItem.Name = "типыСамолетовToolStripMenuItem";
            this.типыСамолетовToolStripMenuItem.Size = new System.Drawing.Size(298, 44);
            this.типыСамолетовToolStripMenuItem.Text = "Типы самолетов";
            this.типыСамолетовToolStripMenuItem.Click += new System.EventHandler(this.Planetype_Click);
            // 
            // окноToolStripMenuItem
            // 
            this.окноToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.каскадToolStripMenuItem,
            this.горизонтальноеToolStripMenuItem,
            this.вертикальноеToolStripMenuItem});
            this.окноToolStripMenuItem.Name = "окноToolStripMenuItem";
            this.окноToolStripMenuItem.Size = new System.Drawing.Size(94, 43);
            this.окноToolStripMenuItem.Text = "Окно";
            // 
            // каскадToolStripMenuItem
            // 
            this.каскадToolStripMenuItem.Name = "каскадToolStripMenuItem";
            this.каскадToolStripMenuItem.Size = new System.Drawing.Size(299, 44);
            this.каскадToolStripMenuItem.Text = "Каскад";
            this.каскадToolStripMenuItem.Click += new System.EventHandler(this.Cascad_Click);
            // 
            // горизонтальноеToolStripMenuItem
            // 
            this.горизонтальноеToolStripMenuItem.Name = "горизонтальноеToolStripMenuItem";
            this.горизонтальноеToolStripMenuItem.Size = new System.Drawing.Size(299, 44);
            this.горизонтальноеToolStripMenuItem.Text = "Горизонтальное";
            this.горизонтальноеToolStripMenuItem.Click += new System.EventHandler(this.Horizontal_Click);
            // 
            // вертикальноеToolStripMenuItem
            // 
            this.вертикальноеToolStripMenuItem.Name = "вертикальноеToolStripMenuItem";
            this.вертикальноеToolStripMenuItem.Size = new System.Drawing.Size(299, 44);
            this.вертикальноеToolStripMenuItem.Text = "Вертикальное";
            this.вертикальноеToolStripMenuItem.Click += new System.EventHandler(this.Vertical_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.рейсыУПилотаToolStripMenuItem,
            this.времяПолетаСамолетовToolStripMenuItem,
            this.отчетToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(122, 43);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // рейсыУПилотаToolStripMenuItem
            // 
            this.рейсыУПилотаToolStripMenuItem.Name = "рейсыУПилотаToolStripMenuItem";
            this.рейсыУПилотаToolStripMenuItem.Size = new System.Drawing.Size(594, 44);
            this.рейсыУПилотаToolStripMenuItem.Text = "Рейсы, проведенные одним пилотом";
            this.рейсыУПилотаToolStripMenuItem.Click += new System.EventHandler(this.Pilot_Flights_Click);
            // 
            // времяПолетаСамолетовToolStripMenuItem
            // 
            this.времяПолетаСамолетовToolStripMenuItem.Name = "времяПолетаСамолетовToolStripMenuItem";
            this.времяПолетаСамолетовToolStripMenuItem.Size = new System.Drawing.Size(594, 44);
            this.времяПолетаСамолетовToolStripMenuItem.Text = "Рейсы, проведенные на одном самолета";
            this.времяПолетаСамолетовToolStripMenuItem.Click += new System.EventHandler(this.TimeInFlight_Click);
            // 
            // отчетToolStripMenuItem
            // 
            this.отчетToolStripMenuItem.Name = "отчетToolStripMenuItem";
            this.отчетToolStripMenuItem.Size = new System.Drawing.Size(594, 44);
            this.отчетToolStripMenuItem.Text = "Расписание вылетов по стране";
            this.отчетToolStripMenuItem.Click += new System.EventHandler(this.Schedule_On_Country_click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1106, 508);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Приложение для работы с базой данных SQLite";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem основныеТаблицыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пассажирToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem билетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem рейсыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пилотыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem самолетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem страныToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem прозводителиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem типыСамолетовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem окноToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem каскадToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem горизонтальноеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вертикальноеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem рейсыУПилотаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem времяПолетаСамолетовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетToolStripMenuItem;
    }

}

