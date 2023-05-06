using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Net;
using System.Threading;
using System.Data.SqlClient;
using Tutorial.SqlConn;
using System.Data;

namespace Data_PLC
{
    public partial class LST_uscontrol : UserControl
    {
        private const int PORT = 8501;
        private const string IP = "192.168.0.10";
        private string _title;
        private string _flow_rate_value;
        private string _total_value;
        private string _DeviceName;
        private string _Value;
        private string Compare;
        bool run = false;
        double stock;
        public LST_uscontrol()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; groupBox1.Text = value; }
        }    
        public string Flow_Rate_Value
        {
            get { return _flow_rate_value; }
            set { _flow_rate_value = value; }
        }
        public string Total_Value      // ĐỊA CHỈ TOTAL VALUE
        {
            get { return _total_value; }
            set { _total_value = value; textBox1.Text = value; }
        }
        public string DeviceName       // ĐỊA CHỈ RESET TOTAL
        {
            get { return _DeviceName;  }
            set { _DeviceName = value; }
        }
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
        public string compare
        {
            get { return Compare; }
            set { Compare = value; }
        }
        private int timer_interval;
        public int Timer_Interval
        {
            get { return timer_interval; }
            set { timer_interval = value; }
        }
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
                    if (comboBoxID.Text == "") throw new Exception("Enter LST No.");
                    if (ccb1.Text == "") throw new Exception("Enter Latex Name");
                    ccb1.Enabled = false;
                    comboBoxID.Enabled = false;
                    bt_start.FillColor = Color.LimeGreen;
                    bt_stop.FillColor = Color.Gray;
                    run = true;
                    class_Database.Insert_LST("LST_NHAP_2", comboBoxID.Text,pipe, ccb1.Text, "convert(datetime2(0),N'"+date+"',103)", stock.ToString());
                    timer1.Interval = timer_interval;
                    timer1.Enabled = true;
                    timer1.Start();
                    timer2.Enabled = true;
                    timer2.Start();
                    Reset_FlowMeter();
                    panel1.Visible = true;
                }
                else
                {
                    MessageBox.Show("Hệ thống đang chạy \n系統運行中", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void bt_stop_Click(object sender, EventArgs e)
        {
            if (run == true)
            {
                timer1.Stop();
                timer1.Enabled = false;
                timer2.Stop();
                timer2.Enabled = false;
                ccb1.Enabled = true;
                comboBoxID.Enabled = true;
                bt_start.FillColor = Color.Gray;
                bt_stop.FillColor = Color.Firebrick;
                run = false;
                timer1_Tick(sender, e);
                //timer2_Tick(sender, e);
                MessageBox.Show("Bồn LST NO." + comboBoxID.Text + "\nLoại Latex: " + ccb1.Text + "\nĐã bơm vào được " + stock.ToString() + "L", "Thông báo");
                stock = 0;
                label_bomvao.Text = "0";
                label_hienco.Text = "0";
            }
            else
            {
                MessageBox.Show("Hệ thống đã dừng\n系統已停止", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        } 
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Convert.ToDouble(_total_value) > 0)
            {
                class_Database.Insert_LST("LST_NHAP", comboBoxID.Text,pipe, ccb1.Text, "convert(datetime2(0),GETDATE())", _total_value);
                stock = stock + Convert.ToDouble(_total_value);
                class_Database.Update("update LST_NHAP_2 set Luu_luong = " + stock + " where LST_No = '" + comboBoxID.Text + "' and Latex_Name = '" + ccb1.Text + "' and Ngay_Nhap = convert(datetime, N'" + date + "', 103) and Pipe_number = "+pipe+";");

                Reset_FlowMeter();
            }
        }
        private void ccb1_Click(object sender, EventArgs e)
        {
            class_Database.sqlShowCbb("LatexName", ccb1);    //LOAD TÊN LATEX TRONG DATABASE LÊN COMBOBOX
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            double a = stock + Convert.ToDouble(_total_value);
            label_bomvao.Text = a.ToString();

        }
        public Task WRITE(string Device_No, string Value)
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
            WRITE(_DeviceName, "1");
            Thread.Sleep(25);
            WRITE(_DeviceName, "0");
        }
        public void Vietnamse()
        {
            bt_start.Text = "START";
            bt_stop.Text = "STOP";
            label7.Text = "Nhập vào";
            labelName.Text = "Tên Latex";

        }
        public void Chinese()
        {
            bt_start.Text = "開始";
            bt_stop.Text = "停止";
            label7.Text = "入料";
            labelName.Text = "乳膠原料";
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
    }                                      
}



//SqlConnection conn2 = DBUtils.GetDBConnection();
//conn2.Open();
//SqlCommand cmd2 = new SqlCommand("insert into LST_new values (@LSTNo,@NameLatex,GETDATE(),GETDATE()," + _total_value + ");", conn2);
//cmd2.Parameters.AddWithValue("@LSTNo", comboBoxID.Text);
//cmd2.Parameters.AddWithValue("@NameLatex", ccb1.Text);
//cmd2.ExecuteNonQuery();
//conn2.Close();



//conn2.Open();
//SqlCommand cmd = new SqlCommand("select sum(Luu_luong) from LST_new where LST_No = '"+comboBoxID.Text+"' group by LST_No;", conn2);
//DataTable table = new DataTable();
//SqlDataReader reader = cmd.ExecuteReader();
//table.Load(reader);
//if (table.Rows.Count > 0)
//{
//    label_hienco.Text = Convert.ToString(table.Rows[0][0]);
//}
//conn2.Close();