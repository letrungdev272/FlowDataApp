
namespace Data_PLC
{
    partial class LST_Usage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.LSTID = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LMTID = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label_sudung = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.bt_start = new Guna.UI2.WinForms.Guna2Button();
            this.bt_stop = new Guna.UI2.WinForms.Guna2Button();
            this.labelID = new System.Windows.Forms.Label();
            this.ccb1 = new Guna.UI2.WinForms.Guna2ComboBox();
            this.labelName = new System.Windows.Forms.Label();
            this.guna2ProgressBar1 = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.LSTID);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.LMTID);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.bt_start);
            this.groupBox1.Controls.Add(this.bt_stop);
            this.groupBox1.Controls.Add(this.labelID);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Location = new System.Drawing.Point(7, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(808, 132);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Flow Meter OUTPUT 1";
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(278, 41);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(273, 36);
            this.comboBox1.TabIndex = 81;
            this.comboBox1.Click += new System.EventHandler(this.comboBox1_Click);
            // 
            // LSTID
            // 
            this.LSTID.BackColor = System.Drawing.Color.Transparent;
            this.LSTID.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.LSTID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LSTID.FocusedColor = System.Drawing.Color.Empty;
            this.LSTID.FocusedState.Parent = this.LSTID;
            this.LSTID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.LSTID.ForeColor = System.Drawing.Color.Black;
            this.LSTID.FormattingEnabled = true;
            this.LSTID.HoverState.Parent = this.LSTID;
            this.LSTID.ItemHeight = 30;
            this.LSTID.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64"});
            this.LSTID.ItemsAppearance.Parent = this.LSTID;
            this.LSTID.Location = new System.Drawing.Point(84, 42);
            this.LSTID.Name = "LSTID";
            this.LSTID.ShadowDecoration.Parent = this.LSTID;
            this.LSTID.Size = new System.Drawing.Size(107, 36);
            this.LSTID.TabIndex = 80;
            this.LSTID.SelectedIndexChanged += new System.EventHandler(this.LSTID_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(192, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 21);
            this.label10.TabIndex = 74;
            this.label10.Text = "Tên Latex:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(871, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 21);
            this.label1.TabIndex = 70;
            this.label1.Text = "LMT NO.";
            this.label1.Visible = false;
            // 
            // LMTID
            // 
            this.LMTID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.LMTID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.LMTID.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.LMTID.FormattingEnabled = true;
            this.LMTID.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74"});
            this.LMTID.Location = new System.Drawing.Point(947, 35);
            this.LMTID.Margin = new System.Windows.Forms.Padding(2);
            this.LMTID.Name = "LMTID";
            this.LMTID.Size = new System.Drawing.Size(80, 36);
            this.LMTID.TabIndex = 69;
            this.LMTID.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Data_PLC.Properties.Resources.icons8_arrow_48px;
            this.pictureBox1.Location = new System.Drawing.Point(808, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 50);
            this.pictureBox1.TabIndex = 68;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label_sudung);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(7, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 42);
            this.panel1.TabIndex = 67;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 21);
            this.label7.TabIndex = 57;
            this.label7.Text = "Sử dụng:";
            // 
            // label_sudung
            // 
            this.label_sudung.AutoSize = true;
            this.label_sudung.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_sudung.ForeColor = System.Drawing.Color.Blue;
            this.label_sudung.Location = new System.Drawing.Point(82, 5);
            this.label_sudung.Name = "label_sudung";
            this.label_sudung.Size = new System.Drawing.Size(30, 32);
            this.label_sudung.TabIndex = 63;
            this.label_sudung.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(206, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 21);
            this.label11.TabIndex = 66;
            this.label11.Text = "L";
            // 
            // textBox1
            // 
            this.textBox1.BorderThickness = 0;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox1.DefaultText = "145";
            this.textBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox1.DisabledState.Parent = this.textBox1;
            this.textBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox1.FillColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox1.FocusedState.Parent = this.textBox1;
            this.textBox1.Font = new System.Drawing.Font("Seven Segment", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox1.HoverState.Parent = this.textBox1;
            this.textBox1.Location = new System.Drawing.Point(690, 95);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.PlaceholderText = "";
            this.textBox1.SelectedText = "";
            this.textBox1.SelectionStart = 3;
            this.textBox1.ShadowDecoration.Parent = this.textBox1;
            this.textBox1.Size = new System.Drawing.Size(94, 25);
            this.textBox1.TabIndex = 63;
            this.textBox1.DoubleClick += new System.EventHandler(this.textBox1_DoubleClick);
            // 
            // bt_start
            // 
            this.bt_start.BorderRadius = 10;
            this.bt_start.CheckedState.Parent = this.bt_start;
            this.bt_start.CustomImages.Parent = this.bt_start;
            this.bt_start.FillColor = System.Drawing.Color.Gray;
            this.bt_start.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.bt_start.ForeColor = System.Drawing.Color.White;
            this.bt_start.HoverState.Parent = this.bt_start;
            this.bt_start.Image = global::Data_PLC.Properties.Resources.icons8_play1;
            this.bt_start.ImageOffset = new System.Drawing.Point(1, 0);
            this.bt_start.ImageSize = new System.Drawing.Size(30, 30);
            this.bt_start.Location = new System.Drawing.Point(596, 42);
            this.bt_start.Name = "bt_start";
            this.bt_start.ShadowDecoration.Parent = this.bt_start;
            this.bt_start.Size = new System.Drawing.Size(91, 36);
            this.bt_start.TabIndex = 42;
            this.bt_start.Text = "START";
            this.bt_start.Click += new System.EventHandler(this.bt_start_Click);
            // 
            // bt_stop
            // 
            this.bt_stop.BorderRadius = 10;
            this.bt_stop.CheckedState.Parent = this.bt_stop;
            this.bt_stop.CustomImages.Parent = this.bt_stop;
            this.bt_stop.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bt_stop.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.bt_stop.ForeColor = System.Drawing.Color.White;
            this.bt_stop.HoverState.Parent = this.bt_stop;
            this.bt_stop.Image = global::Data_PLC.Properties.Resources.icons8_stop;
            this.bt_stop.ImageSize = new System.Drawing.Size(30, 30);
            this.bt_stop.Location = new System.Drawing.Point(693, 42);
            this.bt_stop.Name = "bt_stop";
            this.bt_stop.ShadowDecoration.Parent = this.bt_stop;
            this.bt_stop.Size = new System.Drawing.Size(91, 36);
            this.bt_stop.TabIndex = 44;
            this.bt_stop.Text = "STOP";
            this.bt_stop.Click += new System.EventHandler(this.bt_stop_Click);
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelID.Location = new System.Drawing.Point(12, 49);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(66, 21);
            this.labelID.TabIndex = 11;
            this.labelID.Text = "LST NO.";
            // 
            // ccb1
            // 
            this.ccb1.BackColor = System.Drawing.Color.Transparent;
            this.ccb1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ccb1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ccb1.FocusedColor = System.Drawing.Color.Empty;
            this.ccb1.FocusedState.Parent = this.ccb1;
            this.ccb1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ccb1.ForeColor = System.Drawing.Color.Black;
            this.ccb1.FormattingEnabled = true;
            this.ccb1.HoverState.Parent = this.ccb1;
            this.ccb1.ItemHeight = 30;
            this.ccb1.ItemsAppearance.Parent = this.ccb1;
            this.ccb1.Location = new System.Drawing.Point(86, 229);
            this.ccb1.Name = "ccb1";
            this.ccb1.ShadowDecoration.Parent = this.ccb1;
            this.ccb1.Size = new System.Drawing.Size(161, 36);
            this.ccb1.Sorted = true;
            this.ccb1.TabIndex = 54;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelName.Location = new System.Drawing.Point(10, 237);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(76, 21);
            this.labelName.TabIndex = 30;
            this.labelName.Text = "Tên Latex:";
            // 
            // guna2ProgressBar1
            // 
            this.guna2ProgressBar1.AutoRoundedCorners = true;
            this.guna2ProgressBar1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ProgressBar1.BorderRadius = 8;
            this.guna2ProgressBar1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.guna2ProgressBar1.ForeColor = System.Drawing.Color.White;
            this.guna2ProgressBar1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.guna2ProgressBar1.Location = new System.Drawing.Point(890, 219);
            this.guna2ProgressBar1.Name = "guna2ProgressBar1";
            this.guna2ProgressBar1.ProgressBrushMode = Guna.UI2.WinForms.Enums.BrushMode.SolidTransition;
            this.guna2ProgressBar1.ProgressColor = System.Drawing.Color.Blue;
            this.guna2ProgressBar1.ProgressColor2 = System.Drawing.Color.Blue;
            this.guna2ProgressBar1.ShadowDecoration.Parent = this.guna2ProgressBar1;
            this.guna2ProgressBar1.ShowPercentage = true;
            this.guna2ProgressBar1.Size = new System.Drawing.Size(661, 19);
            this.guna2ProgressBar1.TabIndex = 60;
            this.guna2ProgressBar1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.guna2ProgressBar1.Value = 100;
            this.guna2ProgressBar1.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // LST_Usage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.guna2ProgressBar1);
            this.Controls.Add(this.ccb1);
            this.Controls.Add(this.labelName);
            this.Name = "LST_Usage";
            this.Size = new System.Drawing.Size(835, 145);
            this.Load += new System.EventHandler(this.LST_Usage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label_sudung;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2TextBox textBox1;
        private Guna.UI2.WinForms.Guna2ComboBox ccb1;
        private Guna.UI2.WinForms.Guna2Button bt_start;
        private System.Windows.Forms.Label labelName;
        private Guna.UI2.WinForms.Guna2Button bt_stop;
        private Guna.UI2.WinForms.Guna2ProgressBar guna2ProgressBar1;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox LMTID;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Timer timer2;
        private Guna.UI2.WinForms.Guna2ComboBox LSTID;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
