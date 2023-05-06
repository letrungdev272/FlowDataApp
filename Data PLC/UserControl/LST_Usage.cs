using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tutorial.SqlConn;

namespace Data_PLC
{
    public partial class LST_Usage : UserControl
    {
        private string _DeviceName;
        private const int PORT = 8501;
        private const string IP = "192.168.0.10";
        bool run = false;
        double stock;
        private string _Title;
        private double _Total;
        private int interval_timer1;
        public int IntervalTimer1
        {
            get { return interval_timer1; }
            set { interval_timer1 = value; }
        }
        public string LMT_Title
        {
            get { return _Title; }
            set { _Title = value; groupBox1.Text = value; }
        }
        public double LMT_Total     // ĐỊA CHỈ TOTAL VALUE
        {
           get { return _Total;} set { _Total = value; textBox1.Text = value.ToString(); }
        }
        public string DeviceName   // ĐỊA CHỈ RESET TOTAL
        {
            get { return _DeviceName; }
            set { _DeviceName = value; }
        }
        private int pipe;
        public int Pipe
        {
            get { return pipe; }
            set { pipe = value; }
        }
        public LST_Usage()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        string date;
        private void bt_start_Click(object sender, EventArgs e)
        {
            try
            {
                if (run == false)
                {
                    date = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                    if (LSTID.Text == "") throw new Exception("Nhập ID bồn LST");
                    LMTID.Enabled = false;
                    LSTID.Enabled = false;
                    comboBox1.Enabled = false;
                    bt_start.FillColor = Color.LimeGreen;
                    bt_stop.FillColor = Color.Gray;
                    run = true;
                    class_Database.Insert_LST("LST_XUAT_2", LSTID.Text,pipe, comboBox1.Text, "convert(datetime2(0),N'" + date + "',103)", stock.ToString());
                    timer1.Interval = interval_timer1;
                    timer1.Enabled = true;
                    timer1.Start();
                    timer2.Enabled = true;
                    timer2.Start();
                    Reset_FlowMeter();
                    panel1.Visible = true;
                }
                else
                {
                    MessageBox.Show("Hệ thống đang chạy \n系統運行中","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }
        private void bt_stop_Click(object sender, EventArgs e)
        {
            if (run == true)
            {
                timer1.Stop();
                timer1.Enabled = false;
                timer2.Stop();
                timer2.Enabled = false;
                LMTID.Enabled = true;
                LSTID.Enabled = true;
                comboBox1.Enabled = true;
                bt_start.FillColor = Color.Gray;
                bt_stop.FillColor = Color.Firebrick;
                timer1_Tick(sender, e);
                run = false;
                //class_Database.Insert_LST("LST_XUAT_2", LSTID.Text, comboBox1.Text, "GETDATE()", stock.ToString());
                MessageBox.Show("Bồn LST NO." + LSTID.Text + "\nLoại Latex: " + comboBox1.Text + "\nĐã sử dụng " + stock.ToString() + "L", "Thông báo");
                stock = 0;
                label_sudung.Text = "0";
            }
            else
            {
                MessageBox.Show("Hệ thống đã dừng\n系統已停止", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_Total > 0)
            {
                class_Database.Insert_LST("LST_XUAT", LSTID.Text,pipe, comboBox1.Text, "GETDATE()", _Total.ToString());
                stock = stock + _Total;
                class_Database.Update("update LST_XUAT_2 set Luu_luong = " + stock + " where LST_No = '" + LSTID.Text + "' and Latex_Name = '" + comboBox1.Text + "' and Ngay_Xuat = convert(datetime, N'" + date + "', 103) and Pipe_number = "+pipe+";");
                Reset_FlowMeter();
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            double a = stock + _Total;
            label_sudung.Text = a.ToString();

        }
        private void LSTID_SelectedIndexChanged(object sender, EventArgs e)  // LOAD TÊN LATEX NHẬP VÀO MỚI NHẤT VÀO COMBOBOX
        {
            SqlConnection conn2 = DBUtils.GetDBConnection();
            conn2.Open();
            SqlCommand cmd = new SqlCommand("select * from LST_NHAP_2 where LST_No = "+ LSTID.Text +" order by Ngay_Nhap desc;", conn2);
            DataTable table = new DataTable();
            SqlDataReader reader = cmd.ExecuteReader();
            table.Load(reader);
            if (table.Rows.Count > 0)
            {
                comboBox1.Text = Convert.ToString(table.Rows[0][2]);
            }
            conn2.Close();
        }
        private void comboBox1_Click(object sender, EventArgs e)
        {
            class_Database.sqlShowCbb("LatexName", comboBox1);
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
            Thread.Sleep(50);
            WRITE(_DeviceName, "0");
        }
        public void Vietnamse()
        {
            bt_start.Text = "START";
            bt_stop.Text = "STOP";
            label7.Text = "Sử dụng";
            label10.Text = "Tên Latex";

        }
        public void Chinese()
        {
            bt_start.Text = "開始";
            bt_stop.Text = "停止";
            label7.Text = "使用";
            label10.Text = "乳膠原料";
        }
        private void LST_Usage_Load(object sender, EventArgs e)
        {

        }
        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            if(run == false)
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


//conn2.Open();
//SqlCommand cmd2 = new SqlCommand("insert into LST_new values (@LSTNo,@NameLatex,GETDATE(),-" + _Total + ");", conn2);
//cmd2.Parameters.AddWithValue("@LSTNo", LSTID.Text);
//cmd2.Parameters.AddWithValue("@NameLatex", comboBox1.Text);
//cmd2.ExecuteNonQuery();
//conn2.Close();

//conn2.Open();
//SqlCommand cmd3 = new SqlCommand("insert into LMT_new values (@LMTNo,'','','',GETDATE()," + _Total + ");", conn2);
//cmd3.Parameters.AddWithValue("@LMTNo", LMTID.Text);
//cmd3.ExecuteNonQuery();
//conn2.Close();

//conn2.Open();
//SqlCommand cmd = new SqlCommand("select sum(Luu_luong) from LST_new where LST_No = '" + LSTID.Text + "' group by LST_No;", conn2);
//DataTable table = new DataTable();
//SqlDataReader reader = cmd.ExecuteReader();
//table.Load(reader);
//if (table.Rows.Count > 0)
//{
//    label4.Text = Convert.ToString(table.Rows[0][0]);
//}
//conn2.Close();