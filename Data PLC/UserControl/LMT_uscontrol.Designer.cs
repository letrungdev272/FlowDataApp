
namespace Data_PLC
{
    partial class LMT_uscontrol
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbb_wayofuse_LMT = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label_direction = new System.Windows.Forms.Label();
            this.bt_start = new Guna.UI2.WinForms.Guna2Button();
            this.bt_stop = new Guna.UI2.WinForms.Guna2Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LMT_No = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbb_productionline = new Guna.UI2.WinForms.Guna2ComboBox();
            this.textBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.usage = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cbb_Material_Abb = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbbMaterialCode = new System.Windows.Forms.Label();
            this.cbbFormulaCode = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(1997, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 37);
            this.label1.TabIndex = 33;
            this.label1.Text = "NƯỚC RỬA ỐNG";
            this.label1.Visible = false;
            // 
            // cbb_wayofuse_LMT
            // 
            this.cbb_wayofuse_LMT.BackColor = System.Drawing.SystemColors.WindowText;
            this.cbb_wayofuse_LMT.BorderColor = System.Drawing.Color.Black;
            this.cbb_wayofuse_LMT.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbb_wayofuse_LMT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_wayofuse_LMT.FocusedColor = System.Drawing.Color.Empty;
            this.cbb_wayofuse_LMT.FocusedState.Parent = this.cbb_wayofuse_LMT;
            this.cbb_wayofuse_LMT.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbb_wayofuse_LMT.ForeColor = System.Drawing.Color.Black;
            this.cbb_wayofuse_LMT.FormattingEnabled = true;
            this.cbb_wayofuse_LMT.HoverState.Parent = this.cbb_wayofuse_LMT;
            this.cbb_wayofuse_LMT.ItemHeight = 30;
            this.cbb_wayofuse_LMT.Items.AddRange(new object[] {
            "Sử dụng LMT thông thường ",
            "Hút liệu về bồn LMT",
            "Nước rửa đường ống "});
            this.cbb_wayofuse_LMT.ItemsAppearance.Parent = this.cbb_wayofuse_LMT;
            this.cbb_wayofuse_LMT.Location = new System.Drawing.Point(1719, 154);
            this.cbb_wayofuse_LMT.Name = "cbb_wayofuse_LMT";
            this.cbb_wayofuse_LMT.ShadowDecoration.Parent = this.cbb_wayofuse_LMT;
            this.cbb_wayofuse_LMT.Size = new System.Drawing.Size(273, 36);
            this.cbb_wayofuse_LMT.StartIndex = 0;
            this.cbb_wayofuse_LMT.TabIndex = 28;
            // 
            // label_direction
            // 
            this.label_direction.AutoSize = true;
            this.label_direction.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label_direction.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_direction.Location = new System.Drawing.Point(2002, 164);
            this.label_direction.Name = "label_direction";
            this.label_direction.Size = new System.Drawing.Size(118, 21);
            this.label_direction.TabIndex = 22;
            this.label_direction.Text = "Phương hướng:";
            this.label_direction.Visible = false;
            // 
            // bt_start
            // 
            this.bt_start.BorderRadius = 10;
            this.bt_start.CheckedState.Parent = this.bt_start;
            this.bt_start.CustomImages.Parent = this.bt_start;
            this.bt_start.FillColor = System.Drawing.Color.Gray;
            this.bt_start.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.bt_start.ForeColor = System.Drawing.Color.White;
            this.bt_start.HoverState.Parent = this.bt_start;
            this.bt_start.Image = global::Data_PLC.Properties.Resources.icons8_play1;
            this.bt_start.ImageSize = new System.Drawing.Size(30, 30);
            this.bt_start.Location = new System.Drawing.Point(1203, 37);
            this.bt_start.Name = "bt_start";
            this.bt_start.ShadowDecoration.Parent = this.bt_start;
            this.bt_start.Size = new System.Drawing.Size(100, 36);
            this.bt_start.TabIndex = 45;
            this.bt_start.Tag = "開始";
            this.bt_start.Text = "START";
            this.bt_start.Click += new System.EventHandler(this.bt_start_Click);
            // 
            // bt_stop
            // 
            this.bt_stop.BorderRadius = 10;
            this.bt_stop.CheckedState.Parent = this.bt_stop;
            this.bt_stop.CustomImages.Parent = this.bt_stop;
            this.bt_stop.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bt_stop.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.bt_stop.ForeColor = System.Drawing.Color.White;
            this.bt_stop.HoverState.Parent = this.bt_stop;
            this.bt_stop.Image = global::Data_PLC.Properties.Resources.icons8_stop;
            this.bt_stop.ImageSize = new System.Drawing.Size(30, 30);
            this.bt_stop.Location = new System.Drawing.Point(1203, 79);
            this.bt_stop.Name = "bt_stop";
            this.bt_stop.ShadowDecoration.Parent = this.bt_stop;
            this.bt_stop.Size = new System.Drawing.Size(100, 36);
            this.bt_stop.TabIndex = 46;
            this.bt_stop.Tag = "停止";
            this.bt_stop.Text = "STOP";
            this.bt_stop.Click += new System.EventHandler(this.bt_stop_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(1778, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 21);
            this.label5.TabIndex = 55;
            this.label5.Text = "m³/h";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LMT_No);
            this.groupBox1.Controls.Add(this.cbb_productionline);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.cbb_Material_Abb);
            this.groupBox1.Controls.Add(this.cbbMaterialCode);
            this.groupBox1.Controls.Add(this.cbbFormulaCode);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.bt_start);
            this.groupBox1.Controls.Add(this.bt_stop);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1440, 127);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Flow Meter 1";
            // 
            // LMT_No
            // 
            this.LMT_No.BackColor = System.Drawing.Color.Transparent;
            this.LMT_No.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.LMT_No.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LMT_No.FocusedColor = System.Drawing.Color.Empty;
            this.LMT_No.FocusedState.Parent = this.LMT_No;
            this.LMT_No.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.LMT_No.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.LMT_No.FormattingEnabled = true;
            this.LMT_No.HoverState.Parent = this.LMT_No;
            this.LMT_No.ItemHeight = 30;
            this.LMT_No.Items.AddRange(new object[] {
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
            this.LMT_No.ItemsAppearance.Parent = this.LMT_No;
            this.LMT_No.Location = new System.Drawing.Point(77, 37);
            this.LMT_No.Name = "LMT_No";
            this.LMT_No.ShadowDecoration.Parent = this.LMT_No;
            this.LMT_No.Size = new System.Drawing.Size(86, 36);
            this.LMT_No.TabIndex = 75;
            // 
            // cbb_productionline
            // 
            this.cbb_productionline.BackColor = System.Drawing.Color.Transparent;
            this.cbb_productionline.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbb_productionline.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_productionline.FocusedColor = System.Drawing.Color.Empty;
            this.cbb_productionline.FocusedState.Parent = this.cbb_productionline;
            this.cbb_productionline.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.cbb_productionline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbb_productionline.FormattingEnabled = true;
            this.cbb_productionline.HoverState.Parent = this.cbb_productionline;
            this.cbb_productionline.ItemHeight = 30;
            this.cbb_productionline.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cbb_productionline.ItemsAppearance.Parent = this.cbb_productionline;
            this.cbb_productionline.Location = new System.Drawing.Point(257, 37);
            this.cbb_productionline.Name = "cbb_productionline";
            this.cbb_productionline.ShadowDecoration.Parent = this.cbb_productionline;
            this.cbb_productionline.Size = new System.Drawing.Size(80, 36);
            this.cbb_productionline.TabIndex = 74;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox1.BorderThickness = 0;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox1.DefaultText = "145";
            this.textBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox1.DisabledState.Parent = this.textBox1;
            this.textBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox1.FocusedState.Parent = this.textBox1;
            this.textBox1.Font = new System.Drawing.Font("Seven Segment", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox1.HoverState.Parent = this.textBox1;
            this.textBox1.Location = new System.Drawing.Point(1102, 87);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.PlaceholderText = "";
            this.textBox1.SelectedText = "";
            this.textBox1.SelectionStart = 3;
            this.textBox1.ShadowDecoration.Parent = this.textBox1;
            this.textBox1.Size = new System.Drawing.Size(94, 25);
            this.textBox1.TabIndex = 73;
            this.textBox1.DoubleClick += new System.EventHandler(this.textBox1_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.usage);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Location = new System.Drawing.Point(18, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 41);
            this.panel1.TabIndex = 71;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 21);
            this.label2.TabIndex = 57;
            this.label2.Text = "Sử dụng:";
            // 
            // usage
            // 
            this.usage.AutoSize = true;
            this.usage.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usage.ForeColor = System.Drawing.Color.Blue;
            this.usage.Location = new System.Drawing.Point(82, 4);
            this.usage.Name = "usage";
            this.usage.Size = new System.Drawing.Size(30, 32);
            this.usage.TabIndex = 63;
            this.usage.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(235, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 21);
            this.label12.TabIndex = 66;
            this.label12.Text = "L";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(518, 94);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(18, 21);
            this.label13.TabIndex = 70;
            this.label13.Text = "L";
            this.label13.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Blue;
            this.label14.Location = new System.Drawing.Point(400, 91);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(22, 24);
            this.label14.TabIndex = 69;
            this.label14.Text = "0";
            this.label14.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(328, 93);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 21);
            this.label15.TabIndex = 68;
            this.label15.Text = "Hiện có:";
            this.label15.Visible = false;
            // 
            // cbb_Material_Abb
            // 
            this.cbb_Material_Abb.BackColor = System.Drawing.Color.Transparent;
            this.cbb_Material_Abb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbb_Material_Abb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_Material_Abb.FocusedColor = System.Drawing.Color.Empty;
            this.cbb_Material_Abb.FocusedState.Parent = this.cbb_Material_Abb;
            this.cbb_Material_Abb.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.cbb_Material_Abb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbb_Material_Abb.FormattingEnabled = true;
            this.cbb_Material_Abb.HoverState.Parent = this.cbb_Material_Abb;
            this.cbb_Material_Abb.ItemHeight = 30;
            this.cbb_Material_Abb.Items.AddRange(new object[] {
            "1: USE LMT FOR PRODUCTION LINE",
            "2: PUMP MATERIAL BACK ",
            "3: WATER CLEAN"});
            this.cbb_Material_Abb.ItemsAppearance.Parent = this.cbb_Material_Abb;
            this.cbb_Material_Abb.Location = new System.Drawing.Point(848, 37);
            this.cbb_Material_Abb.Name = "cbb_Material_Abb";
            this.cbb_Material_Abb.ShadowDecoration.Parent = this.cbb_Material_Abb;
            this.cbb_Material_Abb.Size = new System.Drawing.Size(349, 36);
            this.cbb_Material_Abb.TabIndex = 66;
            // 
            // cbbMaterialCode
            // 
            this.cbbMaterialCode.AutoSize = true;
            this.cbbMaterialCode.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbbMaterialCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbbMaterialCode.Location = new System.Drawing.Point(681, 46);
            this.cbbMaterialCode.Name = "cbbMaterialCode";
            this.cbbMaterialCode.Size = new System.Drawing.Size(89, 21);
            this.cbbMaterialCode.TabIndex = 65;
            this.cbbMaterialCode.Text = "Way to use:";
            // 
            // cbbFormulaCode
            // 
            this.cbbFormulaCode.BackColor = System.Drawing.Color.Transparent;
            this.cbbFormulaCode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbFormulaCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFormulaCode.FocusedColor = System.Drawing.Color.Empty;
            this.cbbFormulaCode.FocusedState.Parent = this.cbbFormulaCode;
            this.cbbFormulaCode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.cbbFormulaCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbFormulaCode.FormattingEnabled = true;
            this.cbbFormulaCode.HoverState.Parent = this.cbbFormulaCode;
            this.cbbFormulaCode.ItemHeight = 30;
            this.cbbFormulaCode.ItemsAppearance.Parent = this.cbbFormulaCode;
            this.cbbFormulaCode.Location = new System.Drawing.Point(477, 37);
            this.cbbFormulaCode.Name = "cbbFormulaCode";
            this.cbbFormulaCode.ShadowDecoration.Parent = this.cbbFormulaCode;
            this.cbbFormulaCode.Size = new System.Drawing.Size(197, 36);
            this.cbbFormulaCode.TabIndex = 64;
            this.cbbFormulaCode.Click += new System.EventHandler(this.cbbFormulaCode_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(343, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(130, 21);
            this.label11.TabIndex = 63;
            this.label11.Text = "Tên phối phương:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(5, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 21);
            this.label10.TabIndex = 61;
            this.label10.Text = "LMT NO.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(165, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 21);
            this.label9.TabIndex = 60;
            this.label9.Text = "Tên chuyền:";
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
            // LMT_uscontrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbb_wayofuse_LMT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_direction);
            this.Name = "LMT_uscontrol";
            this.Size = new System.Drawing.Size(1448, 139);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button bt_start;
        private Guna.UI2.WinForms.Guna2Button bt_stop;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cbb_wayofuse_LMT;
        private System.Windows.Forms.Label label_direction;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private Guna.UI2.WinForms.Guna2ComboBox cbb_Material_Abb;
        private System.Windows.Forms.Label cbbMaterialCode;
        private Guna.UI2.WinForms.Guna2ComboBox cbbFormulaCode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label usage;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Timer timer2;
        private Guna.UI2.WinForms.Guna2TextBox textBox1;
        private Guna.UI2.WinForms.Guna2ComboBox LMT_No;
        private Guna.UI2.WinForms.Guna2ComboBox cbb_productionline;
    }
}
