using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tutorial.SqlConn;

namespace Data_PLC
{
    public partial class LMT_uscontrol : UserControl
    {
        public LMT_uscontrol()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        private const int PORT = 8501;
        private const string IP = "192.168.0.10";
        private string _title;
        private string _flow_rate_value;
        private string _total_value;
        private string _DeviceName;
        bool run = false;
        double stock;
        private string _lefttoright;
        public string LefttoRight   //ĐỊA CHỈ SET CHIỀU TRÁI SANG PHẢI
        {
            get { return _lefttoright; }
            set { _lefttoright = value; }
        }
        private string _righttoleft;
        public string RighttoLeft   //ĐỊA CHỈ SET CHIỀU PHẢI SANG TRÁI
        {
            get { return _righttoleft; }
            set { _righttoleft = value; }
        }
        private int interval_timer;
        public int Interval_Timer
        {
            get { return interval_timer; }
            set { interval_timer = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; groupBox1.Text = value; }
        }
        public string Flow_Rate_Value
        {
            get { return _flow_rate_value; }
            set { _flow_rate_value = value;  }
        }
        public string Total_Value
        {
            get { return _total_value; }
            set { _total_value = value; textBox1.Text = value; }
        }      //ĐỊA CHỈ TOTAL VALUE
        public string Device_Name
        {
            get { return _DeviceName; }
            set { _DeviceName = value;  }
        }      //ĐỊA CHỈ RESET TOTAL
        private int pipe;
        public int Pipe
        {
            get { return pipe; }
            set { pipe = value; }
        }
        string date;
        private void bt_start_Click(object sender, EventArgs e)
        {
            try
            {
                if (run == false)
                {
                    date = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                    if (LMT_No.Text == "") throw new Exception("Enter LMT No.");
                    if (cbb_productionline.Text == "") throw new Exception("Enter Production Line");
                    if (cbbFormulaCode.Text == "") throw new Exception("Enter Formula Code");
                    if (cbb_Material_Abb.Text == "") throw new Exception("Enter Way to use");

                    if (cbb_Material_Abb.SelectedIndex == 1)
                    {
                        WRITE_VALUE(_righttoleft, "1");
                        Thread.Sleep(20);
                        WRITE_VALUE(_righttoleft, "0");
                    }
                    else if (cbb_Material_Abb.SelectedIndex == 0 || cbb_Material_Abb.SelectedIndex == 2)
                    {
                        WRITE_VALUE(_lefttoright, "1");
                        Thread.Sleep(20);
                        WRITE_VALUE(_lefttoright, "0");
                    };
                    bt_start.FillColor = Color.LimeGreen;
                    bt_stop.FillColor = Color.Gray;
                    bt_start.FillColor = Color.LimeGreen;
                    bt_stop.FillColor = Color.Gray;
                    LMT_No.Enabled = false;
                    cbb_productionline.Enabled = false;
                    cbbFormulaCode.Enabled = false;
                    cbb_Material_Abb.Enabled = false;
                    run = true;
                    timer1.Interval = interval_timer;
                    timer1.Enabled = true;
                    timer1.Start();
                    timer2.Enabled = true;
                    timer2.Start();
                    Reset_FlowMeter();
                    string sql = "insert into LMT_new_2 values ("+ LMT_No.Text+","+pipe+ ",'" + cbb_productionline.Text+"','"+cbbFormulaCode.Text+"',N'"+cbb_Material_Abb.Text+"',convert(datetime2(0),N'"+date+"',103),0)";
                    class_Database.Update(sql);
                }
                else
                {
                    MessageBox.Show("Hệ thống đang chạy \n系統運行中", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void bt_stop_Click(object sender, EventArgs e)
        {
            try
            {
                if (run == true)
                {
                    timer1.Stop();
                    timer1.Enabled = false;
                    timer2.Stop();
                    timer2.Enabled = false;
                    bt_start.FillColor = Color.Gray;
                    bt_stop.FillColor = Color.Firebrick;
                    run = false;
                    LMT_No.Enabled = true;
                    cbb_productionline.Enabled = true;
                    cbbFormulaCode.Enabled = true;
                    cbb_Material_Abb.Enabled = true;
                    timer1_Tick(sender, e);
                    MessageBox.Show("Bồn LMT NO." + LMT_No.Text + "\nTên chuyền: " + cbb_productionline.Text + "\nTên phối phương: " + cbbFormulaCode.Text +"\nCách thức sử dụng: "+cbb_Material_Abb.Text+ "\nĐã sử dụng: "+ stock.ToString()+ " L", "Thông báo");
                    stock = 0;
                    usage.Text = "0";
                }
                else
                {
                    MessageBox.Show("Hệ thống đã dừng\n系統已停止", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(Convert.ToInt32( _total_value) > 0)
            {
                string sql = "insert into LMT_new values (" + LMT_No.Text + "," +pipe+ ",'" + cbb_productionline.Text + "','" + cbbFormulaCode.Text + "',N'" + cbb_Material_Abb.Text + "',convert(datetime2(0),GETDATE(),103),"+ _total_value + ")";
                class_Database.Update(sql);

                stock = stock + Convert.ToDouble(_total_value);
                string sql2 = "update LMT_new_2 set Total = "+ stock +" where LMT_NO = '"+ LMT_No.Text + "' and Production_Line = '"+ cbb_productionline.Text + "' and Formula_Code = '"+ cbbFormulaCode.Text + "' and Material_Abbreviation = N'"+ cbb_Material_Abb.Text + "' and  Ngay_Nhap = CONVERT(datetime,N'"+date+"',103) and Pipe_number = " + pipe;
                class_Database.Update(sql2);
                Reset_FlowMeter();
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            double a = stock + Convert.ToDouble(_total_value);
            usage.Text = a.ToString();
        }
        private void cbbFormulaCode_Click(object sender, EventArgs e)
        {
            class_Database.sqlShowCbb("FormulaCode", cbbFormulaCode);
        }
        public Task WRITE_VALUE(string Device_No, string Value)
        {
            try
            {
                TcpClient client = new TcpClient();
                client.Connect(IP, PORT);
                Stream stream = client.GetStream();
                var reader = new StreamReader(stream);
                var writer = new StreamWriter(stream);
                writer.AutoFlush = true;
                // 2. send
                writer.WriteLine("WR " + Device_No + " " + Value + "\r");
                // 3. receive
                string Value_Read = reader.ReadLine();
                // 4. close
                stream.Close();
                client.Close();
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                return Task.FromException<string>(ex);
            }
        }
        void Reset_FlowMeter()
        {
            WRITE_VALUE(_DeviceName, "1");
            Thread.Sleep(50);
            WRITE_VALUE(_DeviceName, "0");
        }
        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            if (run == false)
            {
                DialogResult result = MessageBox.Show("Do you want to reset this value?", "Warning", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    Reset_FlowMeter();
                }
            }
        }
        public void Vietnamse()
        {
            bt_start.Text = "START";
            bt_stop.Text = "STOP";
            label9.Text = "Tên chuyền";
            label11.Text = "Tên Phối Phương";
            cbbMaterialCode.Text = "Material Abbreviation";

        }
        public void Chinese()
        {
            bt_start.Text = "開始";
            bt_stop.Text = "停止";
            label9.Text = "生產線";
            label11.Text = "配方代碼";
            cbbMaterialCode.Text = "材料縮寫";
        }
        public void Doiten()
        {
            foreach (Guna2Button button in groupBox1.Controls.OfType<Guna2Button>())
            {
                string temp = button.Text;
                button.Text = button.Tag.ToString();
                button.Tag = temp;
            }
        }
    }
}


//conn2.Open();
//SqlCommand cmd = new SqlCommand("select sum(total) from LMT_new where LMT_No = '" + LMT_No.Text + "' group by LMT_No;", conn2);
//DataTable table = new DataTable();
//SqlDataReader reader = cmd.ExecuteReader();
//table.Load(reader);
//if (table.Rows.Count > 0)
//{
//    label14.Text = Convert.ToString(table.Rows[0][0]);
//}
//conn2.Close();


//SqlConnection conn2 = DBUtils.GetDBConnection();
//conn2.Open();
//SqlCommand cmd2 = new SqlCommand("insert into LMT_new_2 values (@LMTNo,@ProductionLine,@FormulaCode,@Marterial_Abbreviation,convert(datetime2(0),GETDATE(),103)," + stock + ");", conn2);
//cmd2.Parameters.AddWithValue("LMTNo", LMT_No.Text);
//cmd2.Parameters.AddWithValue("ProductionLine", cbb_productionline.Text);
//cmd2.Parameters.AddWithValue("FormulaCode", cbbFormulaCode.Text);
//cmd2.Parameters.AddWithValue("Marterial_Abbreviation", cbb_Material_Abb.Text);
//cmd2.ExecuteNonQuery();
//conn2.Close();

//string sql = "insert into LMT_new_2 values ('" + LMT_No.Text + "','" + cbb_productionline.Text + "','" + cbbFormulaCode.Text + "',N'" + cbb_Material_Abb.Text + "',convert(datetime2(0),GETDATE(),103),0)";
//class_Database.Update(sql);


//SqlConnection conn2 = DBUtils.GetDBConnection();
//conn2.Open();
//SqlCommand cmd2 = new SqlCommand("insert into LMT_new values (@LMTNo,@ProductionLine,@FormulaCode,@Marterial_Abbreviation,convert(datetime2(0),GETDATE(),103)," + _total_value + ");", conn2);
//cmd2.Parameters.AddWithValue("LMTNo", LMT_No.Text);
//cmd2.Parameters.AddWithValue("ProductionLine", cbb_productionline.Text);
//cmd2.Parameters.AddWithValue("FormulaCode", cbbFormulaCode.Text);
//cmd2.Parameters.AddWithValue("Marterial_Abbreviation", cbb_Material_Abb.Text);
//cmd2.ExecuteNonQuery();
//conn2.Close();