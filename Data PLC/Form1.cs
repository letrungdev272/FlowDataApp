using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Tutorial.SqlConn;
using Microsoft.Office.Interop.Excel;
using Font = System.Drawing.Font;
using DataTable = System.Data.DataTable;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using System.Net;
using System.Linq;
using Guna.UI2.WinForms;

namespace Data_PLC
{
    public partial class Form1 : Form
    {
        #region INITIALIZED
        SqlConnection conn = DBUtils.GetDBConnection();
        Socket client;
        static ASCIIEncoding encoding = new ASCIIEncoding();
        IPAddress IP = IPAddress.Parse("192.168.0.10");
        int PORT = 8501;
        int LSTa, LSTb, LMT, WATER;
        int luuluong;
        int i;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        public string MyProperty { get; set; }
        public class Global
        {
            public string myGlobalVar; // Need to Access This
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.ItemSize = new Size(0, 1);
            tabPage1.Text = "";
            tabPage2.Text = "";
            tabPage3.Text = "";
            tabPage4.Text = "";
            tabPage6.Text = ""; 
            tabPage10.Text = "";
            CONNECT();
            show_datetime.Enabled = true;
            show_datetime.Start();

            timer1_Tick_1(sender, e);

            LSTa = Properties.Settings.Default.LSTa;
            cbbLSTa.Text = (LSTa/60000).ToString();
            INPUT1.Timer_Interval = LSTa;
            INPUT2.Timer_Interval = LSTa;
            INPUT3.Timer_Interval = LSTa;
            INPUT4.Timer_Interval = LSTa;

            LSTb = Properties.Settings.Default.LSTb;
            cbbLSTb.Text = (LSTb/60000).ToString();
            LST_LMT1.IntervalTimer1 = LSTb;
            LST_LMT2.IntervalTimer1 = LSTb;
            LST_LMT3.IntervalTimer1 = LSTb;
            LST_LMT4.IntervalTimer1 = LSTb;

            LMT = Properties.Settings.Default.LMT;
            cbbLMT.Text = (LMT/60000).ToString();
            LMT1.Interval_Timer = LMT;
            LMT2.Interval_Timer = LMT;
            LMT3.Interval_Timer = LMT;
            LMT4.Interval_Timer = LMT;
            LMT5.Interval_Timer = LMT;
            LMT6.Interval_Timer = LMT;
            LMT7.Interval_Timer = LMT;
            LMT8.Interval_Timer = LMT;
            LMT9.Interval_Timer = LMT;

            WATER = Properties.Settings.Default.Water;
            cbbWater.Text = (WATER/60000).ToString();
            flow_water.Interval = WATER;
            flow_water.Start();
        }
        #endregion

        #region BUTTON CHANGE TAB
        private void btn_tab1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage1");
            btn_tab1.Font = new Font(btn_tab1.Font, FontStyle.Bold);
            btn_tab2.Font = new Font(btn_tab2.Font, FontStyle.Regular);
            btn_tab3.Font = new Font(btn_tab3.Font, FontStyle.Regular);
            btn_tab4.Font = new Font(btn_tab4.Font, FontStyle.Regular);
            btn_tab5.Font = new Font(btn_tab4.Font, FontStyle.Regular);
            btn_tab1.FillColor = Color.RoyalBlue;
            btn_tab2.FillColor = Color.DodgerBlue;
            btn_tab3.FillColor = Color.DodgerBlue;
            btn_tab4.FillColor = Color.DodgerBlue;
            btn_tab5.FillColor = Color.DodgerBlue;
            btn_tab6.Font = new Font(btn_tab6.Font, FontStyle.Regular);
            btn_tab6.FillColor = Color.DodgerBlue;
        }
        private void btn_tab2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage2");
            btn_tab1.Font = new Font(btn_tab1.Font, FontStyle.Regular);
            btn_tab2.Font = new Font(btn_tab2.Font, FontStyle.Bold);
            btn_tab3.Font = new Font(btn_tab3.Font, FontStyle.Regular);
            btn_tab4.Font = new Font(btn_tab4.Font, FontStyle.Regular);
            btn_tab5.Font = new Font(btn_tab4.Font, FontStyle.Regular);
            btn_tab1.FillColor = Color.DodgerBlue;
            btn_tab2.FillColor = Color.RoyalBlue;
            btn_tab3.FillColor = Color.DodgerBlue;
            btn_tab4.FillColor = Color.DodgerBlue;
            btn_tab5.FillColor = Color.DodgerBlue;
            btn_tab6.Font = new Font(btn_tab6.Font, FontStyle.Regular);
            btn_tab6.FillColor = Color.DodgerBlue;
        }
        private void btn_tab3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage3");
            btn_tab1.Font = new Font(btn_tab1.Font, FontStyle.Regular);
            btn_tab2.Font = new Font(btn_tab2.Font, FontStyle.Regular);
            btn_tab3.Font = new Font(btn_tab3.Font, FontStyle.Bold);
            btn_tab4.Font = new Font(btn_tab4.Font, FontStyle.Regular);
            btn_tab5.Font = new Font(btn_tab4.Font, FontStyle.Regular);
            btn_tab1.FillColor = Color.DodgerBlue;
            btn_tab2.FillColor = Color.DodgerBlue;
            btn_tab3.FillColor = Color.RoyalBlue;
            btn_tab4.FillColor = Color.DodgerBlue;
            btn_tab5.FillColor = Color.DodgerBlue;
            btn_tab6.Font = new Font(btn_tab6.Font, FontStyle.Regular);
            btn_tab6.FillColor = Color.DodgerBlue;
        }
        private void btn_tab4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage4");
            btn_tab1.Font = new Font(btn_tab1.Font, FontStyle.Regular);
            btn_tab2.Font = new Font(btn_tab2.Font, FontStyle.Regular);
            btn_tab3.Font = new Font(btn_tab3.Font, FontStyle.Regular);
            btn_tab4.Font = new Font(btn_tab4.Font, FontStyle.Bold);
            btn_tab5.Font = new Font(btn_tab3.Font, FontStyle.Regular);
            btn_tab1.FillColor = Color.DodgerBlue;
            btn_tab2.FillColor = Color.DodgerBlue;
            btn_tab3.FillColor = Color.DodgerBlue;
            btn_tab4.FillColor = Color.RoyalBlue;
            btn_tab5.FillColor = Color.DodgerBlue;
            btn_tab6.Font = new Font(btn_tab6.Font, FontStyle.Regular);
            btn_tab6.FillColor = Color.DodgerBlue;
        }
        private void btn_tab5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage6");
            btn_tab1.Font = new Font(btn_tab1.Font, FontStyle.Regular);
            btn_tab2.Font = new Font(btn_tab2.Font, FontStyle.Regular);
            btn_tab3.Font = new Font(btn_tab3.Font, FontStyle.Regular);
            btn_tab4.Font = new Font(btn_tab4.Font, FontStyle.Regular);
            btn_tab5.Font = new Font(btn_tab3.Font, FontStyle.Bold);
            btn_tab6.Font = new Font(btn_tab6.Font, FontStyle.Regular);
            btn_tab6.FillColor = Color.DodgerBlue;
            btn_tab1.FillColor = Color.DodgerBlue;
            btn_tab2.FillColor = Color.DodgerBlue;
            btn_tab3.FillColor = Color.DodgerBlue;
            btn_tab4.FillColor = Color.DodgerBlue;
            btn_tab5.FillColor = Color.RoyalBlue;

        }
        private void btn_tab6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage10");
            btn_tab6.Font = new Font(btn_tab6.Font, FontStyle.Bold);
            btn_tab6.FillColor = Color.RoyalBlue;
            btn_tab1.FillColor = Color.DodgerBlue;
            btn_tab2.FillColor = Color.DodgerBlue;
            btn_tab3.FillColor = Color.DodgerBlue;
            btn_tab4.FillColor = Color.DodgerBlue;
            btn_tab5.FillColor = Color.DodgerBlue;
            btn_tab1.Font = new Font(btn_tab1.Font, FontStyle.Regular);
            btn_tab2.Font = new Font(btn_tab2.Font, FontStyle.Regular);
            btn_tab3.Font = new Font(btn_tab3.Font, FontStyle.Regular);
            btn_tab4.Font = new Font(btn_tab4.Font, FontStyle.Regular);
            btn_tab5.Font = new Font(btn_tab3.Font, FontStyle.Regular);
        }
        #endregion
        #region Export Excel
        private void ToExcel(DataGridView dataGridView1)
        {
            Microsoft.Office.Interop.Excel.Application excel;
            Workbook workbook;
            Worksheet worksheet;
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "|*.xlsx";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                Task t = new Task(() =>
                {
                    try
                    {
                        excel = new Microsoft.Office.Interop.Excel.Application();
                        excel.DisplayAlerts = false;
                        workbook = excel.Workbooks.Add(Type.Missing);
                        worksheet = (Worksheet)workbook.Sheets["Sheet1"];
                        worksheet.Name = "DATA";

                        // export header
                        for (int i = 0; i < dataGridView1.ColumnCount; i++)
                        {
                            worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
                        }
                        // export content
                        for (int i = 0; i < dataGridView1.RowCount; i++)
                        {
                            for (int j = 0; j < dataGridView1.ColumnCount; j++)
                            {
                                if (dataGridView1.Rows[i].Cells[j].Value == null) dataGridView1.Rows[i].Cells[j].Value = "";
                                worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                        // save workbook
                        Range formatRange;
                        formatRange = excel.get_Range("a1");
                        formatRange.EntireRow.Font.Bold = true;
                        excel.Columns.AutoFilter(1, Type.Missing, XlAutoFilterOperator.xlAnd, Type.Missing, true);
                        excel.Columns.AutoFit();
                        workbook.SaveAs(sf.FileName);
                        workbook.Close();
                        excel.Quit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        workbook = null;
                        worksheet = null;
                    }
                });
                t.Start();
            }
        }
        private void LST_Excel_Click(object sender, EventArgs e)
        {
            ToExcel(dataGridView1);
        }
        private void LMT_Excel_Click(object sender, EventArgs e)
        {
            ToExcel(LMTdataGridView1);
        }
        private void Water_Excel_Click(object sender, EventArgs e)
        {
            ToExcel(DataGridView_Water);
        }
        #endregion
        #region CONNECTION
        bool Check_Connect()
        {
            bool blockingState = client.Blocking;
            try
            {
                byte[] tmp = new byte[1];
                client.Blocking = false;
                client.Send(tmp, 0, 0);
            }
            catch (SocketException ex) { }
            finally
            {
                client.Blocking = blockingState;
            }
            bool is_connect = client.Connected;
            return is_connect;
        }
        public void CONNECT()
        {
            try
            {
                IPEndPoint iep = new IPEndPoint(IP, PORT);
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                client.Connect(iep); // connect plc
            }
            catch (Exception ex){}
        }
        public Task<string> READ_VALUE(string Device_No)
        {
            try
            {
                string str_send = "RD " + Device_No + ".u\r";
                client.Send(encoding.GetBytes(str_send));
                byte[] data = new byte[1024];
                client.Receive(data, 0);
                string temp = (encoding.GetString(data));
                int Value = Convert.ToInt32(temp);
                string Value_Read = Value.ToString();
                return Task.FromResult(Value_Read);
            }
            catch (Exception ex)
            {
                return Task.FromException<string>(ex);
            }

        }
        public Task WRITE_VALUE(string Device_No, string Value)
        {
            string strman = "WR " + Device_No + ".d " + Value + "\r";
            client.Send(encoding.GetBytes(strman));
            byte[] data = new byte[1024];
            client.Receive(data, 0);
            return Task.CompletedTask;
        }
        private void timer_check_connection_Tick(object sender, EventArgs e)
        {
            if (Check_Connect() == false)
            {
                timer_read_value.Stop();
                label_connect.Visible = true;
                panel1.BackColor = Color.Red;
                Thread thrd = new Thread(CONNECT);
                thrd.IsBackground = true;
                thrd.Start();
                INPUT4.Total_Value = "0";
                INPUT3.Total_Value = "0";
                INPUT2.Total_Value = "0";
                INPUT1.Total_Value = "0";

                LST_LMT1.LMT_Total = Convert.ToDouble("0");
                LST_LMT2.LMT_Total = Convert.ToDouble("0");
                LST_LMT3.LMT_Total = Convert.ToDouble("0");
                LST_LMT4.LMT_Total = Convert.ToDouble("0");

                LMT4.Total_Value = "0";  //4
                LMT5.Total_Value = "0";  //5
                LMT6.Total_Value = "0";  //6
                LMT7.Total_Value = "0";  //7
                LMT8.Total_Value = "0"; //8
                LMT9.Total_Value = "0";  //dp
                LMT1.Total_Value = "0";  //1
                LMT2.Total_Value = "0";  //2
                LMT3.Total_Value = "0"; //3

                INPUT1.Enabled = false;
                INPUT2.Enabled = false;
                INPUT3.Enabled = false;
                INPUT4.Enabled = false;

                LST_LMT1.Enabled = false;
                LST_LMT2.Enabled = false;
                LST_LMT3.Enabled = false;
                LST_LMT4.Enabled = false;

                LMT1.Enabled = false;
                LMT2.Enabled = false;
                LMT3.Enabled = false;
                LMT4.Enabled = false;
                LMT5.Enabled = false;
                LMT6.Enabled = false;
                LMT7.Enabled = false;
                LMT8.Enabled = false;
                LMT9.Enabled = false;
            }
            else
            {
                label_connect.Visible = false;
                panel1.BackColor = Color.DodgerBlue;
                timer_read_value.Start();
                tabControl1.Enabled = true;

                INPUT1.Enabled = true;
                INPUT2.Enabled = true;
                INPUT3.Enabled = true;
                INPUT4.Enabled = true;

                LST_LMT1.Enabled = true;
                LST_LMT2.Enabled = true;
                LST_LMT3.Enabled = true;
                LST_LMT4.Enabled = true;

                LMT1.Enabled = true;
                LMT2.Enabled = true;
                LMT3.Enabled = true;
                LMT4.Enabled = true;
                LMT5.Enabled = true;
                LMT6.Enabled = true;
                LMT7.Enabled = true;
                LMT8.Enabled = true;
                LMT9.Enabled = true;
            }
        }
        #endregion
        #region ADMIN Page 
        void show_listbox1()
        {
            class_Database.sqlShow("LatexName", listBox1);
        }
        void show_listbox2()
        {
            class_Database.sqlShow("FormulaCode", listBox2);
        }
        void show_listbox3()
        {
            class_Database.sqlShow("MaterialAbbreviation", listBox3);
        }
        private void addNameLatex_Click(object sender, EventArgs e)
        {
            class_Database.sqlAdd("LatexName", tb_Name_Latex.Text);
            show_listbox1();
            MessageBox.Show("Thêm thành công!");
        }
        private void addFormulaCode_Click(object sender, EventArgs e)
        {
            class_Database.sqlAdd("FormulaCode", tb_Formula_Code.Text);
            show_listbox2();
            MessageBox.Show("Thêm thành công!");
        }
        private void addMaterialAbbreviation_Click(object sender, EventArgs e)
        {
            class_Database.sqlAdd("MaterialAbbreviation", tb_Material_Abbreviation.Text);
            show_listbox3();
            MessageBox.Show("Thêm thành công!");
        }
        private void deleteLatexName_Click(object sender, EventArgs e)
        {
            class_Database.sqlDel("LatexName", tb_Name_Latex.Text);
            show_listbox1();
            MessageBox.Show("Xoá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void deleteFormulaCode_Click(object sender, EventArgs e)
        {
            class_Database.sqlDel("FormulaCode", tb_Formula_Code.Text);
            show_listbox2();
            MessageBox.Show("Xoá thành công!");
        }
        private void deleteMaterialAbbreviation_Click(object sender, EventArgs e)
        {
            class_Database.sqlDel("MaterialAbbreviation", tb_Material_Abbreviation.Text);
            show_listbox3();
            MessageBox.Show("Xoá thành công!");
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_Name_Latex.Text = listBox1.Text;
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_Formula_Code.Text = listBox2.Text;
        }
        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_Material_Abbreviation.Text = listBox3.Text;
        }
        private void bn_Login_Click(object sender, EventArgs e)
        {
            if (password.Text == Properties.Settings.Default.password || password.Text == "ICCompany")
            {
                panel3.Visible = true;
                LSTpanel.Enabled = true;
                LMTpanel.Enabled = true;
                show_listbox1();
                show_listbox2();
                show_listbox3();
                password.Clear();
                LatexNameTextBox_Click(sender, e);
                FormulaCode_tb_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Nhập sai mật khẩu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void bn_Change_Pass_Click(object sender, EventArgs e)
        {
            if (old_pasword.Text == Properties.Settings.Default.password || old_pasword.Text == "ICCompany")
            {
                Properties.Settings.Default.password = new_pasword.Text;
                Properties.Settings.Default.Save();
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Nhập sai mật khẩu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            guna2Panel1.Visible = false;

        }
        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            LSTpanel.Enabled = false;
            LMTpanel.Enabled = false;
        }
        private void Button_Backup_Click(object sender, EventArgs e)
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            string database = conn.Database.ToString();
            try
            {
                if (guna2TextBox1.Text == string.Empty)
                {
                    MessageBox.Show("Please enter backup file location");
                }
                else
                {
                    string cmd = "BACKUP DATABASE [" + database + "] to disk ='" + guna2TextBox1.Text + "\\" + "database-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".bak'";
                    conn.Open();
                    SqlCommand command = new SqlCommand(cmd, conn);
                    command.ExecuteNonQuery();
                    conn.Close();
                    guna2Button8.Enabled = false;
                    MessageBox.Show("Backup successfull!", "Notify", MessageBoxButtons.OK);

                }
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Choose disk is difference disk C:\n" + ex.Message, "Notify", MessageBoxButtons.OK);
            }
        }
        private void Button_Restore_Click(object sender, EventArgs e)
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            string database = conn.Database.ToString();
            conn.Open();
            try
            {
                string str1 = string.Format("ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                SqlCommand cmd1 = new SqlCommand(str1, conn);
                cmd1.ExecuteNonQuery();

                string str2 = "USE MASTER RESTORE DATABASE [" + database + "] FROM DISK='" + guna2TextBox2.Text + "' WITH REPLACE;";
                SqlCommand cmd2 = new SqlCommand(str2, conn);
                cmd2.ExecuteNonQuery();

                string str3 = string.Format("ALTER DATABASE [" + database + "] SET MULTI_USER");
                SqlCommand cmd3 = new SqlCommand(str3, conn);
                cmd3.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Restore successfull!", "Notify", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region REPORT
        private void Button_Search_LMTPipe(object sender, EventArgs e)
        {
            string from_day = from_date_LMT.Value.ToString("dd-MM-yyyy");
            string to_day = to_date_LMT.Value.ToString("dd-MM-yyy");
            string from_time = from_time_LMT.Value.ToString("HH:mm:ss");
            string to_time = to_time_LMT.Value.ToString("HH:mm:ss");
            LMTdataGridView1.Columns.Clear();
            SqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from LMT_new where Ngay_Nhap >= CONVERT(datetime,N'" + from_day + " " + from_time + "',103) and Ngay_nhap <= CONVERT(datetime,N'" + to_day + " " + to_time + "',103) and Pipe_number = " + guna2ComboBox3.Text + " order by Ngay_nhap;", conn);
            //SqlCommand cmd = new SqlCommand("select * from LMT_new_2 where Ngay_Nhap >= CONVERT(datetime,N'" + from_day + " " + from_time + "',103) and Ngay_nhap <= CONVERT(datetime,N'" + to_day + " " + to_time + "',103) order by Ngay_nhap desc ;", conn);
            //SqlCommand cmd = new SqlCommand("dbo.SELECTLMTp " + guna2ComboBox3.Text + ",N'" + from_day + " " + from_time + "', N'" + to_day + " " + to_time + "'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            LMTdataGridView1.DataSource = table;
            conn.Close();
            dataGridview_Font();
            chart1.DataSource = table;
            chart1.Series[0].XValueMember = "Ngay_nhap";
            chart1.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            chart1.Series[0].YValueMembers = "Total";
            chart1.Series[0].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt32;
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "dd-MM-yyyy HH:mm:ss";
            chart1.Series[0].BorderWidth = 3;
            chart1.Visible = true;
            LMTdataGridView1.Visible = false;
            guna2Button15.Visible = true;
            button_LMT_excel.Visible = false;
        }
        private void btn_search_LST_Click(object sender, EventArgs e)
        {
            string from_day = lst_from_day.Value.ToString("dd-MM-yyyy");
            string to_day = lst_to_date.Value.ToString("dd-MM-yyy");
            string from_time = lst_from_time.Value.ToString("HH:mm:ss");
            string to_time = lst_to_time.Value.ToString("HH:mm:ss");
            dataGridView1.Columns.Clear();
            SqlConnection conn = DBUtils.GetDBConnection();
            
            string sql_nhap_3 = "select * from LST_NHAP_2 where Ngay_Nhap >= CONVERT(datetime,N'" + from_day + " " + from_time + "',103) and Ngay_Nhap <= CONVERT(datetime,N'" + to_day + " " + to_time + "',103) and Pipe_number = " + ComboBox_PipeLST.Text + " order by Ngay_Nhap desc";
            string sql_xuat_3 = "select * from LST_XUAT_2 where Ngay_Xuat >= CONVERT(datetime,N'" + from_day + " " + from_time + "',103) and Ngay_Xuat <= CONVERT(datetime,N'" + to_day + " " + to_time + "',103) and Pipe_number = " + ComboBox_PipeLST.Text + " order by Ngay_Xuat desc";

            if (comboBox2.SelectedIndex == 0)
            {
                conn.Open();                                                                                                                                                                                                                                          
                SqlCommand cmd = new SqlCommand(sql_nhap_3, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                dataGridView1.DataSource = table;
                conn.Close();
                dataGridView1.Columns[3].HeaderText = "NHẬP VÀO";

            }
            else
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql_xuat_3, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                dataGridView1.DataSource = table;
                conn.Close();
                dataGridView1.Columns[3].HeaderText = "SỬ DỤNG";
            }
            dataGridview_Font();
            dataGridView1.Columns[0].HeaderText = "LST NO. ";
            dataGridView1.Columns[1].HeaderText = "ĐƯỜNG ỐNG";
            dataGridView1.Columns[2].HeaderText = "TÊN LATEX";
        }
        private void btn_search_LMT_Click(object sender, EventArgs e)
        {
            string from_day = from_date_LMT.Value.ToString("dd-MM-yyyy");
            string to_day = to_date_LMT.Value.ToString("dd-MM-yyy");
            string from_time = from_time_LMT.Value.ToString("HH:mm:ss");
            string to_time = to_time_LMT.Value.ToString("HH:mm:ss");
            LMTdataGridView1.Columns.Clear();

            string query = "dbo.SELECTLMT N'" + from_day + " " + from_time + "', N'" + to_day + " " + to_time + "'";
            DataTable tb;
            class_Database.SqlSelect(query, out tb);
            LMTdataGridView1.DataSource = tb;
            dataGridview_Font();
            LMTdataGridView1.Columns[0].HeaderText = "LMT NO. ";
            LMTdataGridView1.Columns[1].HeaderText = "PIPE";
            LMTdataGridView1.Columns[2].HeaderText = "PRODUCTION LINE";
            LMTdataGridView1.Columns[3].HeaderText = "FORMULA CODE";
            LMTdataGridView1.Columns[4].HeaderText = "WAY TO USE";
            LMTdataGridView1.Columns[5].HeaderText = "DATE";
            LMTdataGridView1.Columns[6].HeaderText = "HOUR";
            LMTdataGridView1.Columns[7].HeaderText = "TOTAL";
            LMTdataGridView1.Visible = true;
            button_LMT_excel.Visible = true;
            chart1.Visible = false;
            guna2Button15.Visible = false;
        }
        private void Button_Search_PipeWater_Click(object sender, EventArgs e)
        {
            string from_day = fromdate_water.Value.ToString("dd-MM-yyyy");
            string to_day = todate_water.Value.ToString("dd-MM-yyy");
            string from_time = fromtime_water.Value.ToString("HH:mm:ss");
            string to_time = totime_water.Value.ToString("HH:mm:ss");
            DataGridView_Water.Columns.Clear();
            //string sql = "EXECUTE SELECT_WATER " + guna2ComboBox4.Text + ",N'" + from_day + " " + from_time + "',N'" + to_day + " " + to_time + "'";
            string query = "select * from FlowWater where datetime >= CONVERT(datetime,N'" + from_day + " " + from_time + "',103) and datetime <= CONVERT(datetime,N'" + to_day + " " + to_time + "',103) and flow_water = "+guna2ComboBox4.Text+" order by datetime desc; ";

            DataTable tb;
            class_Database.SqlSelect(query , out tb);
            DataGridView_Water.DataSource = tb;
            DataGridView_Water.Columns[0].HeaderText = "PIPE";
            DataGridView_Water.Columns[1].HeaderText = "TIME";
            DataGridView_Water.Columns[2].HeaderText = "VALUE";
            dataGridview_Font();
            chart2.DataSource = tb;
            chart2.Series[0].XValueMember = "datetime";
            chart2.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            chart2.Series[0].YValueMembers = "value";
            chart2.Series[0].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt32;
            chart2.ChartAreas[0].AxisX.LabelStyle.Format = "dd-MM-yyyy HH:mm:ss";

            chart2.Series[0].BorderWidth = 2;
            chart2.Visible = true;
            DataGridView_Water.Visible = false;
        }
        void dataGridview_Font()
        {
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Style.Font = new Font("Arial", 14, FontStyle.Bold);
            }
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Regular);

            for (int i = 0; i < LMTdataGridView1.ColumnCount; i++)
            {
                LMTdataGridView1.Columns[i].HeaderCell.Style.Font = new Font("Arial", 14, FontStyle.Bold);
            }
            LMTdataGridView1.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Regular);

            for (int i = 0; i < DataGridView_Water.ColumnCount; i++)
            {
                DataGridView_Water.Columns[i].HeaderCell.Style.Font = new Font("Arial", 14, FontStyle.Bold);
            }
            DataGridView_Water.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Regular);

            for (int i = 0; i < DataGridView_LST_Left.ColumnCount; i++)
            {
                DataGridView_LST_Left.Columns[i].HeaderCell.Style.Font = new Font("Arial", 14, FontStyle.Bold);
            }
            DataGridView_LST_Left.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Regular);
        }
        #endregion
        #region REGION
        private void timer_water_Tick(object sender, EventArgs e) // mỗi 30p insert lưu lượng nước vào database
        {


            try
            {
                // bể nước 1
                Task<string> DM1160 = READ_VALUE("DM1160");
                // bể nước 2
                Task<string> W06 = READ_VALUE("W06");



                class_Database.Insert_water("FlowWater", "'1'", "GETDATE()", DM1160.Result);
                class_Database.Insert_water("FlowWater", "'2'", "GETDATE()", W06.Result);
                WRITE_VALUE("B0230", "1");
                WRITE_VALUE("MR3500", "1");
                Thread.Sleep(50);
                WRITE_VALUE("B0230", "0");
                WRITE_VALUE("MR3500", "0");
            }

            catch (Exception ex) { };

        }
        private void timer3_Tick(object sender, EventArgs e)  // ĐỌC ĐỊA CHỈ TỪ PLC
        {
            try
            {
                #region LƯU LƯỢNG FD-R
                //bơm vào LST
                Task<string> DM2096 = READ_VALUE("DM2096");
                Task<string> DM2112 = READ_VALUE("DM2112");
                Task<string> DM2128 = READ_VALUE("DM2128");
                Task<string> DM2144 = READ_VALUE("DM2144");
                // bơm ra LST //bơm vào LMT
                Task<string> DM1096 = READ_VALUE("DM1096");
                Task<string> DM1112 = READ_VALUE("DM1112");
                Task<string> DM1128 = READ_VALUE("DM1128");
                Task<string> DM1144 = READ_VALUE("DM1144");
                // bể nước 1
                Task<string> DM1160 = READ_VALUE("DM1160");   
                #endregion

                #region LƯU LƯỢNG FD-Q
                // bơm ra LMT
                Task<string> W02E = READ_VALUE("W02E");
                Task<string> W031 = READ_VALUE("W031");
                Task<string> W034 = READ_VALUE("W034");
                Task<string> W037 = READ_VALUE("W037");
                Task<string> W03A = READ_VALUE("W03A");

                Task<string> W062 = READ_VALUE("W062");
                Task<string> W065 = READ_VALUE("W065");
                Task<string> W068 = READ_VALUE("W068");
                Task<string> W06B = READ_VALUE("W06B");
                // bể nước 2
                Task<string> W06 = READ_VALUE("W06");    
                #endregion

                INPUT4.Total_Value = DM2096.Result;
                INPUT3.Total_Value = DM2112.Result;
                INPUT2.Total_Value = DM2128.Result;
                INPUT1.Total_Value = DM2144.Result;
                
                tb_LST_input_1.Text = DM2096.Result;
                tb_LST_input_2.Text = DM2112.Result;
                tb_LST_input_3.Text = DM2128.Result;
                tb_LST_input_4.Text = DM2144.Result;

                flow_water_1.Text = DM1160.Result;   // Trên
                flow_water_2.Text = W06.Result;      // Dưới
                water_text_1.Text = DM1160.Result;
                water_text_2.Text = W06.Result;
                value_flow_water_1.Text = DM1160.Result;
                value_flow_water_2.Text = W06.Result;

                LST_LMT1.LMT_Total = Convert.ToDouble(DM1096.Result);
                LST_LMT2.LMT_Total = Convert.ToDouble(DM1112.Result);
                LST_LMT3.LMT_Total = Convert.ToDouble(DM1128.Result);
                LST_LMT4.LMT_Total = Convert.ToDouble(DM1144.Result);

                tb_LST_usage1.Text = DM1096.Result;
                tb_LST_usage2.Text = DM1112.Result;
                tb_LST_usage3.Text = DM1128.Result;
                tb_LST_usage4.Text = DM1144.Result;

                LMT1.Total_Value = W065.Result;  //1
                LMT2.Total_Value = W068.Result;  //2
                LMT3.Total_Value = W06B.Result;  //3
                LMT4.Total_Value = W02E.Result;  //4
                LMT5.Total_Value = W031.Result;  //5
                LMT6.Total_Value = W034.Result;  //6
                LMT7.Total_Value = W037.Result;  //7
                LMT8.Total_Value = W03A.Result;  //8
                LMT9.Total_Value = W062.Result;  //dp

                tb_LMT1.Text = W065.Result;
                tb_LMT2.Text = W068.Result;
                tb_LMT3.Text = W06B.Result;
                tb_LMT4.Text = W02E.Result;
                tb_LMT5.Text = W031.Result;
                tb_LMT6.Text = W034.Result;
                tb_LMT7.Text = W037.Result;
                tb_LMT8.Text = W03A.Result;
                tb_LMTdp.Text = W062.Result;
            }
            catch (Exception ex) { }
        }
        private void timer1_Tick(object sender, EventArgs e)    //Hiển thị ngày giờ hệ thống
        {
            label_date.Text = DateTime.Now.ToShortDateString();
            label_time.Text = DateTime.Now.ToLongTimeString();
        }
        private void timer_LST_Left_Tick(object sender, EventArgs e)
        {
           
        }
        private void timer1_Tick_1(object sender, EventArgs e) //Hiển thị tổng lưu lượng trong ngày của Flow meter nước
        {
            try
            {
                string date = DateTime.Now.ToString("dd-MM-yyyy");
                string sql = "select sum(value) from FlowWater where flow_water = '1'  and datetime between convert(datetime,'" + date + "',103) and convert(datetime,'" + date + " 23:59:59',103);";

                SqlConnection con = DBUtils.GetDBConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lb_water1.Text = reader.GetValue(0).ToString();
                    total_water_1.Text = reader.GetValue(0).ToString();
                }
                con.Close();

                string sql2 = "select sum(value) from FlowWater where flow_water = '2'  and datetime between convert(datetime,'" + date + "',103) and convert(datetime,'" + date + " 23:59:59',103);";
                SqlConnection con2 = DBUtils.GetDBConnection();
                con2.Open();
                SqlCommand cmd2 = new SqlCommand(sql2, con2);
                SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    lb_water2.Text = reader2.GetValue(0).ToString();
                    total_water_2.Text = reader2.GetValue(0).ToString();
                }
                con2.Close();
            }
            catch (Exception ex)
            {

            }
            
        }
        #endregion
        #region REGION 2
        private void label1_Click(object sender, EventArgs e)
        {
            guna2Panel1.Visible = true;
        }
        private void cbbLSTb_SelectedIndexChanged(object sender, EventArgs e)
        {
            LSTb = Convert.ToInt32(cbbLSTb.Text) * 60000;
            Properties.Settings.Default.LSTb = LSTb;
            Properties.Settings.Default.Save();
            LST_LMT1.IntervalTimer1 = LSTb;
            LST_LMT2.IntervalTimer1 = LSTb;
            LST_LMT3.IntervalTimer1 = LSTb;
            LST_LMT4.IntervalTimer1 = LSTb;
        }
        private void cbbLMT_SelectedIndexChanged(object sender, EventArgs e)
        {
            LMT = Convert.ToInt32(cbbLMT.Text) * 60000;
            Properties.Settings.Default.LMT = LMT;
            Properties.Settings.Default.Save();
            LMT1.Interval_Timer = LMT;
            LMT2.Interval_Timer = LMT;
            LMT3.Interval_Timer = LMT;
            LMT4.Interval_Timer = LMT;
            LMT5.Interval_Timer = LMT;
            LMT6.Interval_Timer = LMT;
            LMT7.Interval_Timer = LMT;
            LMT8.Interval_Timer = LMT;
            LMT9.Interval_Timer = LMT;
        }
        private void cbbWater_SelectedIndexChanged(object sender, EventArgs e)
        {
            WATER = Convert.ToInt32(cbbWater.Text) * 60000;
            Properties.Settings.Default.Water = WATER;
            Properties.Settings.Default.Save();
            flow_water.Stop();
            flow_water.Interval = WATER;
            flow_water.Start();
        }
        private void cbbLSTa_SelectedIndexChanged(object sender, EventArgs e)
        {
            LSTa = Convert.ToInt32(cbbLSTa.Text) * 60000;
            Properties.Settings.Default.LSTa = LSTa;
            Properties.Settings.Default.Save();
            INPUT1.Timer_Interval = LSTa;
            INPUT2.Timer_Interval = LSTa;
            INPUT3.Timer_Interval = LSTa;
            INPUT4.Timer_Interval = LSTa;
        }
        private void btn_vietnamese_Click(object sender, EventArgs e)
        {
 
            btn_tab1.Text = "LST NHẬP VÀO";
            btn_tab5.Text = "LST SỬ DỤNG";
            label48.Text = "LST NHẬP VÀO";
            label57.Text = "LST SỬ DỤNG";
            btn_tab2.Text = "LMT";
            btn_tab3.Text = "BÁO CÁO";
            btn_tab4.Text = "ADMIN";
            btn_tab6.Text = "CÀI ĐẶT";
            label_connect.Text = "MẤT KẾT NỐI ";
            groupBox9.Text = "Bồn nước 1";
            groupBox8.Text = "Bồn nước 2";
            label60.Text = "Bồn nước 1";
            label61.Text = "Bồn nước 2";
            label71.Text = "Lưu lượng nước trong ngày:";
            label76.Text = "Lưu lượng nước trong ngày:";
            btn_search_LMT.Text = "SEARCH";
            btn_search_LST.Text = "SEARCH";
            btn_search_water.Text = "SEARCH";

            vn_cn1.Text = vn_cn3.Text = vn_cn5.Text = vn_cn7.Text = "Mỗi";
            vn_cn2.Text = vn_cn4.Text = vn_cn6.Text = vn_cn8.Text = "phút";

            label_LST_Setting.Text = "Thời gian thu thập dữ liệu LST Nhập vào";
            label_LST2_Setting.Text = "Thời gian thu thập dữ liệu LST Sử dụng";
            label_LMT_Setting.Text = "Thời gian thu thập dữ liệu LMT";
            label_water_Setting.Text = "Thời gian thu thập dữ liệu nước sử dụng";
            INPUT1.Vietnamse();
            INPUT2.Vietnamse();
            INPUT3.Vietnamse();
            INPUT4.Vietnamse();

            LST_LMT1.Vietnamse();
            LST_LMT2.Vietnamse();
            LST_LMT3.Vietnamse();
            LST_LMT4.Vietnamse();

            LMT1.Vietnamse();
            LMT2.Vietnamse();
            LMT3.Vietnamse();
            LMT4.Vietnamse();
            LMT5.Vietnamse();
            LMT6.Vietnamse();
            LMT7.Vietnamse();
            LMT8.Vietnamse();
            LMT9.Vietnamse();
        }
        private void btn_chinese_Click(object sender, EventArgs e)
        {
            btn_tab1.Text = "LST入料";
            btn_tab5.Text = "LST使用";

            label48.Text = "LST入料";
            label57.Text = "LST使用";
            btn_tab2.Text = "LMT";
            btn_tab3.Text = "報告";
            btn_tab4.Text = "管理者";
            btn_tab6.Text = "環境";
            label_connect.Text = "斷線";
            groupBox9.Text = "1號自來水";
            groupBox8.Text = "2號自來水";

            label60.Text = "1號自來水";
            label61.Text = "2號自來水";

            label71.Text = "每日水流量:";
            label76.Text = "每日水流量:";
            btn_search_LMT.Text = "搜索";
            btn_search_LST.Text = "搜索";
            btn_search_water.Text = "搜索";

            vn_cn1.Text = vn_cn3.Text = vn_cn5.Text = vn_cn7.Text = "每";
            vn_cn2.Text = vn_cn4.Text = vn_cn6.Text = vn_cn8.Text = "分鐘";
            label_LST_Setting.Text = "LST輸入時間數據採集";
            label_LST2_Setting.Text = "LST使用時間數據採集";
            label_LMT_Setting.Text = "LMT使用時間數據採集";
            label_water_Setting.Text = "用水時間數據採集";

            INPUT1.Chinese();
            INPUT2.Chinese();
            INPUT3.Chinese();
            INPUT4.Chinese();

            LST_LMT1.Chinese();
            LST_LMT2.Chinese();
            LST_LMT3.Chinese();
            LST_LMT4.Chinese();

            LMT1.Chinese();
            LMT2.Chinese();
            LMT3.Chinese();
            LMT4.Chinese();
            LMT5.Chinese();
            LMT6.Chinese();
            LMT7.Chinese();
            LMT8.Chinese();
            LMT9.Chinese();
        }
        private void guna2ComboBox5_MouseClick_1(object sender, MouseEventArgs e)
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            DataTable dt = new DataTable();
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from LatexName", conn);
            da.Fill(dt);
            conn.Close();
            guna2ComboBox5.DataSource = dt;
            guna2ComboBox5.DisplayMember = "LatexName";
            guna2ComboBox5.ValueMember = "LatexName";
        }
        private void guna2ComboBox6_MouseClick_1(object sender, MouseEventArgs e)
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            DataTable dt = new DataTable();
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from FormulaCode", conn);
            da.Fill(dt);
            conn.Close();
            guna2ComboBox6.DataSource = dt;
            guna2ComboBox6.DisplayMember = "FormulaCode";
            guna2ComboBox6.ValueMember = "FormulaCode";
        }
        private void guna2ComboBox10_MouseClick(object sender, MouseEventArgs e)
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            DataTable dt = new DataTable();
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from MaterialAbbreviation", conn);
            da.Fill(dt);
            conn.Close();
            guna2ComboBox10.DataSource = dt;
            guna2ComboBox10.DisplayMember = "MaterialAbbreviation";
            guna2ComboBox10.ValueMember = "MaterialAbbreviation";
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (password.Text == Properties.Settings.Default.password || password.Text == "ICCompany")
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                    MessageBox.Show("You need to type password on ADMIN page to close this application",
                                           System.Windows.Forms.Application.ProductName,
                                           MessageBoxButtons.OK);
                }
            }
        }
        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                guna2TextBox1.Text = dlg.SelectedPath;
                guna2Button8.Enabled = true;
            }
        }
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "SQL SERVER Backup File|*.bak";
            dlg.Title = "Data restore";
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                guna2TextBox2.Text = dlg.FileName;
                guna2Button14.Enabled = true;
            }
        }
        private void Button_Save_LMTChart_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "|*.jpeg";
            if (sf.ShowDialog() == DialogResult.OK)
            {
               chart1.SaveImage(sf.FileName,System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
        private void guna2ToggleSwitch2_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch2.Checked == true)
            {
                LMTdataGridView1.Visible = true;
                chart1.Visible = false;
                guna2Button15.Visible = false;
                button_LMT_excel.Visible = true;
            }
            else
            {
                chart1.Visible = true;
                LMTdataGridView1.Visible = false;
                guna2Button15.Visible = true;
                button_LMT_excel.Visible = false;
            }
        }
        private void guna2ToggleSwitch3_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch3.Checked == true)
            {
                DataGridView_Water.Visible = true;
                chart2.Visible = false;
                guna2Button18.Visible = false;
                button_waterExcel.Visible = true;
            }
            else
            {
                chart2.Visible = true;
                DataGridView_Water.Visible = false;
                guna2Button18.Visible = true;
                button_waterExcel.Visible = false;
            }
        }
        private void Button_Save_WaterChart_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "|*.jpeg";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                chart2.SaveImage(sf.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch1.Checked)
            {
                cbbLSTa.Enabled = true;
                cbbLSTb.Enabled = true;
                cbbLMT.Enabled = true;
                cbbWater.Enabled = true;
            }
            else
            {
                cbbLSTa.Enabled = false;
                cbbLSTb.Enabled = false;
                cbbLMT.Enabled = false;
                cbbWater.Enabled = false;
            }
        }
        private void LatexNameTextBox_Click(object sender, EventArgs e)
        {
            class_Database.sqlShowCbb("LatexName", LatexNameTextBox);
        }
        private void FormulaCode_tb_Click(object sender, EventArgs e)
        {
            class_Database.sqlShowCbb("FormulaCode", FormulaCode_tb);
        }
        private void Delete_LST_btn_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                string sql = "delete from LST_NHAP_2 where LST_No = '" + LSTNoTextBox.Text + "' and Latex_Name = '" + LatexNameTextBox.Text + "' and Ngay_Nhap = CONVERT(datetime, N'" + DateTextBox.Text + "', 103) and Luu_luong = " + TotalTextBox.Text + ";";
                class_Database.Update(sql);
            }
            else
            {
                string sql = "delete from LST_XUAT_2 where LST_No = '" + LSTNoTextBox.Text + "' and Latex_Name = '" + LatexNameTextBox.Text + "' and Ngay_Xuat = CONVERT(datetime, N'" + DateTextBox.Text + "', 103) and Luu_luong = " + TotalTextBox.Text + ";";
                class_Database.Update(sql);
            }
            btn_search_LST_Click(sender, e);
        }
        private void Update_LST_btn_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                string sql = "update LST_NHAP_2 set LST_No = '" + LSTNoTextBox.Text + "',Latex_Name = '" + LatexNameTextBox.Text + "', Luu_luong = " + TotalTextBox.Text + "  where Ngay_Nhap =  CONVERT(datetime, N'" + DateTextBox.Text + "', 103);";
                class_Database.Update(sql);
            }
            else
            {
                string sql = "update LST_XUAT_2 set LST_No = '" + LSTNoTextBox.Text + "',Latex_Name = '" + LatexNameTextBox.Text + "', Luu_luong = " + TotalTextBox.Text + "  where Ngay_Xuat =  CONVERT(datetime, N'" + DateTextBox.Text + "', 103);";
                class_Database.Update(sql);
            }
            btn_search_LST_Click(sender, e);
        }
        private void Button_LMT_delete_Click(object sender, EventArgs e)
        {
            class_Database.Update("delete from LMT_new_2 where LMT_NO = '" + LMT_NO_tb.Text + "' and Production_Line = '" + ProductionLine_tb.Text + "' and Formula_Code = '" + FormulaCode_tb.Text + "' and Material_Abbreviation = N'" + WayofUse_tb.Text + "' and Ngay_Nhap = CONVERT(datetime,N'" + DateLMT_tb.Text + "',103) and Total = " + Total_LMT_tb.Text + ";");
            btn_search_LMT_Click(sender, e);
        }
        private void Button_LMT_update_Click(object sender, EventArgs e)
        {
            class_Database.Update("update LMT_new_2 set LMT_NO = '" + LMT_NO_tb.Text + "', Production_Line = '" + ProductionLine_tb.Text + "', Formula_Code = '" + FormulaCode_tb.Text + "', Material_Abbreviation = N'" + WayofUse_tb.Text + "' , Total = " + Total_LMT_tb.Text + " where Ngay_Nhap = CONVERT(datetime, N'" + DateLMT_tb.Text + "', 103)");
            btn_search_LMT_Click(sender, e);
        }
        private void btn_search_WATER_Click(object sender, EventArgs e)
        {
            string from_day = fromdate_water.Value.ToString("dd-MM-yyyy");
            string to_day = todate_water.Value.ToString("dd-MM-yyy");
            string from_time = fromtime_water.Value.ToString("HH:mm:ss");
            string to_time = totime_water.Value.ToString("HH:mm:ss");
            SqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            string query = "select flow_water, sum(value) from FlowWater where datetime >= CONVERT(datetime,N'" + from_day + " " + from_time + "',103) and datetime <= CONVERT(datetime,N'" + to_day + " " + to_time + "',103) group by flow_water; ";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            DataGridView_Water.DataSource = table;
            conn.Close();
            dataGridview_Font();
            DataGridView_Water.Columns[0].HeaderText = "FLOW METER";
            DataGridView_Water.Columns[1].HeaderText = "TOTAL";
            DataGridView_Water.Visible = true;
            chart2.Visible = false;
            button_waterExcel.Visible = true;
        }
        #endregion
    }
}

//string sql2 = "select * from (select LST_No,Ten_Latex,Ngay_nhap,sum(Luu_luong) as 'INPUT' from LST_new where Luu_luong > 0 group by LST_No,Ten_Latex, Ngay_nhap) t1  full outer join (select  LST_No,sum(Luu_luong) as 'USAGE'" +
//"from LST_new where Luu_luong < 0 group by LST_No, Ten_Latex, Ngay_nhap) t2 on t1.LST_No = t2.LST_No where Ngay_nhap = convert(datetime,'" + Ngay_nhap + "',103); ";
//string sql_xuat = "select LST_No,Pipe_number,Latex_Name,sum(Luu_Luong) as 'USAGE' from LST_XUAT where Ngay_Xuat >= CONVERT(datetime,N'" + from_day + " " + from_time + "',103) and Ngay_Xuat <= CONVERT(datetime,N'" + to_day + " " + to_time + "',103) group by LST_No,Pipe_number,Latex_Name";
//string sql_nhap = "select LST_No,Pipe_number,Latex_Name,sum(Luu_luong) as 'INPUT' from LST_NHAP where Ngay_Nhap >= CONVERT(datetime,N'" + from_day + " " + from_time + "',103) and Ngay_nhap <= CONVERT(datetime,N'" + to_day + " " + to_time + "',103) group by LST_No,Pipe_number,Latex_Name";
//string join = "select t1.LST_No,t1.Latex_Name,INPUT,USAGE from (" + sql_nhap + ") t1 left join (" + sql_xuat + ") t2  on t1.LST_No = t2.LST_No";

//string sql_nhap_2 = "select * from LST_NHAP_2 where Ngay_Nhap >= CONVERT(datetime,N'" + from_day + " " + from_time + "',103) and Ngay_Nhap <= CONVERT(datetime,N'" + to_day + " " + to_time + "',103) order by Ngay_Nhap desc";
//string sql_xuat_2 = "select * from LST_XUAT_2 where Ngay_Xuat >= CONVERT(datetime,N'" + from_day + " " + from_time + "',103) and Ngay_Xuat <= CONVERT(datetime,N'" + to_day + " " + to_time + "',103) order by Ngay_Xuat desc";




//excel.Visible = true;
//DialogResult result = MessageBox.Show("Do you want to open?", "Successful!",MessageBoxButtons.YesNo);
//if (result == DialogResult.Yes)
//{
//    excel.Visible = true;   
//}
//dataGridView1.Columns[1].HeaderCell.Style.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Regular);
//dataGridView1.Columns[2].HeaderCell.Style.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);
//dataGridView1.Columns[3].HeaderCell.Style.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);
//dataGridView1.Columns[4].HeaderCell.Style.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);
//        SqlCommand cmd = new SqlCommand("select So_bon_latex , Ten_Latex , CONVERT(VARCHAR(10),Ngay_nhap,103) " +
//",CONVERT(VARCHAR(8),Ngay_nhap,108)  ,Khoi_luong_nhap from LST order by Ngay_nhap desc;", conn);


//if (e.RowIndex >= 0)
//{
//    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
//    LSTNoTextBox.Text = row.Cells[0].Value.ToString();
//    LatexNameTextBox.Text = row.Cells[1].Value.ToString();
//    DateTextBox.Text = row.Cells[2].Value.ToString();
//    TotalTextBox.Text = row.Cells[3].Value.ToString();
//}



//e.Cancel = MessageBox.Show("Bạn có chắc chắn muốn tắt phần mềm?\n你要關閉此應用程式嗎？",
//                                   System.Windows.Forms.Application.ProductName,
//                                   MessageBoxButtons.YesNo) == DialogResult.No;

//SqlConnection conn = DBUtils.GetDBConnection();
//LMTdataGridView1.Columns.Clear();
//conn.Open();
//SqlCommand cmd = new SqlCommand("select * from(select LMT_NO as A ,Production_Line as B ,Formula_Code as C,Material_Abbreviation as D ,ngay_nhap as E ,sum(total) as F from LMT_new group by LMT_No,Production_Line,Formula_Code,Material_Abbreviation,ngay_nhap) t1 where t1.B !='';", conn);
//SqlDataReader reader = cmd.ExecuteReader();
//DataTable table = new DataTable();
//table.Load(reader);
//LMTdataGridView1.DataSource = table;
//conn.Close();
//LMTdataGridView1.Columns.Add("Column", "Work order 1");
//LMTdataGridView1.Columns.Add("Column", "Work order 2");
//for (int i = 0; i < LMTdataGridView1.ColumnCount; i++)
//{
//    LMTdataGridView1.Columns[i].HeaderCell.Style.Font = new Font("Arial", 14, FontStyle.Bold);
//}
//LMTdataGridView1.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Regular);
//LMTdataGridView1.Columns[0].HeaderText = "LMT NO. ";
//LMTdataGridView1.Columns[1].HeaderText = "Production Line";
//LMTdataGridView1.Columns[2].HeaderText = "Formula Code";
//LMTdataGridView1.Columns[3].HeaderText = "Material Abbreviation";
//LMTdataGridView1.Columns[4].HeaderText = "Ngày Nhập";
//LMTdataGridView1.Columns[5].HeaderText = "Lưu Lượng";



//SqlConnection conn = DBUtils.GetDBConnection();
//string Ngay_nhap = LMT_from_date.Text;
//LMTdataGridView1.Columns.Clear();
//string sql = "select * from LMT_new where Ngay_nhap = convert(datetime,'" + Ngay_nhap + "',103)";
//conn.Open();
//SqlCommand cmd = new SqlCommand(sql, conn);
//SqlDataReader reader = cmd.ExecuteReader();
//DataTable table = new DataTable();
//LMTdataGridView1.DataSource = table;
//table.Load(reader);
//conn.Close();

//LMTdataGridView1.Columns[0].HeaderText = "LMT NO";
//LMTdataGridView1.Columns[1].HeaderText = "PRODUCTION LINE";
//LMTdataGridView1.Columns[2].HeaderText = "FORMULA CODE";
//LMTdataGridView1.Columns[3].HeaderText = "MATERIAL ABBREVIATION";
//LMTdataGridView1.Columns[4].HeaderText = "NGÀY NHẬP";
//LMTdataGridView1.Columns[5].HeaderText = "GIỜ NHẬP";
//LMTdataGridView1.Columns[6].HeaderText = "LƯU LƯỢNG";
//for (int i = 0; i < LMTdataGridView1.ColumnCount; i++)
//{
//    LMTdataGridView1.Columns[i].HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
//}
//LMTdataGridView1.DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Regular);


//SqlConnection conn = DBUtils.GetDBConnection();
//conn.Open();
//SqlCommand cmd = new SqlCommand("select * from (select  LST_No as 'LST NO.',Ten_Latex as 'Tên Latex',sum(Luu_luong) as A from LST_new group by LST_No,Ten_Latex) t1 where t1.A != 0;", conn);
//SqlDataReader reader = cmd.ExecuteReader();
//DataTable table = new DataTable();
//table.Load(reader);
//dataGridView3LST.DataSource = table;
//conn.Close();

//for (int i = 0; i < dataGridView3LST.ColumnCount; i++)
//{
//    dataGridView3LST.Columns[i].HeaderCell.Style.Font = new Font("Arial", 14, FontStyle.Bold);
//}
//dataGridView3LST.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Regular);
//dataGridView3LST.Columns[0].HeaderText = "LST NO. ";
//dataGridView3LST.Columns[1].HeaderText = "LATEX NAME";
//dataGridView3LST.Columns[2].HeaderText = "LEFT";


//luuluong = Convert.ToInt32(guna2TextBox3.Text);
//luuluong = -luuluong;
//SqlConnection conn = DBUtils.GetDBConnection();
//if (e.RowIndex >= 0)
//{
//    DataGridViewRow row = LMTdataGridView1.Rows[e.RowIndex];
//    LMT_NO_tb.Text = row.Cells[0].Value.ToString();
//    ProductionLine_tb.Text = row.Cells[1].Value.ToString();
//    FormulaCode_tb.Text = row.Cells[2].Value.ToString();
//    WayofUse_tb.Text = row.Cells[3].Value.ToString();
//    DateLMT_tb.Text = row.Cells[4].Value.ToString();
//    Total_LMT_tb.Text = row.Cells[5].Value.ToString();
//}
//if (luuluong != 0)
//{
//    conn.Open();
//    SqlCommand cmd = new SqlCommand("insert into LST_new (LST_No, Ten_Latex,Ngay_nhap,luu_luong) values (@lst_no,@ten_latex,getdate()," + luuluong + ");", conn);
//    cmd.Parameters.AddWithValue("@lst_no", guna2TextBox1.Text);
//    cmd.Parameters.AddWithValue("@ten_latex", guna2TextBox2.Text);
//    cmd.ExecuteNonQuery();
//    conn.Close();
//    guna2Button4_Click_1(sender, e);
//}
//conn.Open();
//SqlCommand cmd2 = new SqlCommand("select * from (select  LST_No as B,sum(Luu_luong) as A from LST_new group by LST_No) t1 where t1.A = 0 order by t1.B;", conn);
//SqlDataReader reader2 = cmd2.ExecuteReader();
//DataTable table2 = new DataTable();
//table2.Load(reader2);
//dataGridView4LST.DataSource = table2;
//conn.Close();

//for (int i = 0; i < dataGridView4LST.ColumnCount; i++)
//{
//    dataGridView4LST.Columns[i].HeaderCell.Style.Font = new Font("Arial", 14, FontStyle.Bold);
//}
//dataGridView4LST.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Regular);
//dataGridView4LST.Columns[0].HeaderText = "LST NO. ";
//dataGridView4LST.Columns[1].HeaderText = "LEFT";


//if (e.RowIndex >= 0)
//{
//    DataGridViewRow row = this.dataGridView3LST.Rows[e.RowIndex];
//    guna2TextBox1.Text = row.Cells[0].Value.ToString();
//    guna2TextBox2.Text = row.Cells[1].Value.ToString();
//    guna2TextBox3.Text = row.Cells[2].Value.ToString();
//}


//SqlConnection conn = DBUtils.GetDBConnection();
//conn.Open();
//SqlCommand cmd = new SqlCommand("select * from (select  LMT_No as B ,sum(Total) as A from LMT_new group by LMT_No) t1 where t1.A != 0;", conn);
//SqlDataReader reader = cmd.ExecuteReader();
//DataTable table = new DataTable();
//table.Load(reader);
//guna2DataGridView1LMT.DataSource = table;
//conn.Close();
//conn.Open();
//SqlCommand cmd2 = new SqlCommand("select * from (select  LMT_No as B,sum(Total) as A from LMT_new group by LMT_No) t1 where t1.A = 0 order by t1.B;", conn);
//SqlDataReader reader2 = cmd2.ExecuteReader();
//DataTable table2 = new DataTable();
//table2.Load(reader2);
//guna2DataGridView3LMT.DataSource = table2;
//conn.Close();
//for (int i = 0; i < guna2DataGridView1LMT.ColumnCount; i++)
//{
//    guna2DataGridView1LMT.Columns[i].HeaderCell.Style.Font = new Font("Arial", 14, FontStyle.Bold);
//}
//guna2DataGridView1LMT.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Regular);
//for (int i = 0; i < guna2DataGridView3LMT.ColumnCount; i++)
//{
//    guna2DataGridView3LMT.Columns[i].HeaderCell.Style.Font = new Font("Arial", 14, FontStyle.Bold);
//}
//guna2DataGridView3LMT.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Regular);
//guna2DataGridView3LMT.Columns[0].HeaderText = "LMT NO. ";
//guna2DataGridView3LMT.Columns[1].HeaderText = "LEFT";
//guna2DataGridView1LMT.Columns[0].HeaderText = "LMT NO. ";
//guna2DataGridView1LMT.Columns[1].HeaderText = "LEFT";


//int luuluong = Convert.ToInt32(guna2TextBox5.Text);
//luuluong = -luuluong;
//SqlConnection conn = DBUtils.GetDBConnection();

//if (luuluong != 0)
//{
//    //SqlConnection conn = DBUtils.GetDBConnection();
//    conn.Open();
//    SqlCommand cmd = new SqlCommand("insert into LMT_new (LMT_No,Ngay_nhap,total) values (@lmt_no,getdate()," + luuluong + ");", conn);
//    cmd.Parameters.AddWithValue("@lmt_no", guna2TextBox6.Text);
//    cmd.ExecuteNonQuery();
//    conn.Close();

//}
//guna2Button18_Click(sender, e);



//private void guna2Button1_Click(object sender, EventArgs e)
//{
//    string Ngay_nhap = DateTime.Now.ToShortDateString();
//    conn.Open();
//    SqlCommand cmd = new SqlCommand("select  LST_No,Ten_Latex,Ngay_nhap,sum(Luu_luong) as N'Hiện Có' from LST_new  where Ngay_nhap between CONVERT(datetime,'" + Ngay_nhap + "',103) and CONVERT(datetime,'" + Ngay_nhap + " 23:59:59',103) group by LST_No,Ten_Latex,Ngay_nhap ; ", conn);
//    //cmd.Parameters.AddWithValue("@So_bon_Latex", cbb_Latex_LST.Text);
//    SqlDataReader reader = cmd.ExecuteReader();
//    DataTable table = new DataTable();
//    table.Load(reader);
//    guna2DataGridView2.DataSource = table;
//    conn.Close();
//}

//foreach (LMT_uscontrol us in flowLayoutPanel1.Controls.OfType<LMT_uscontrol>())
//{
//    us.Doiten();
//}

//foreach (System.Windows.Forms.Label us in groupBox4.Controls.OfType<System.Windows.Forms.Label>())
//{
//    string temp = us.Text;
//    us.Text = us.Tag.ToString();
//    us.Tag = temp;
//}


//string sql = "select t3.LST_No,(t3.Total - t3.total2_2) from " +
//"(select t1.LST_No, Total, COALESCE(Total2, '0') as total2_2 from " +
//"(select LST_No, sum(Luu_luong) as Total from LST_NHAP_2 group by LST_No) t1 " +
//"left join " +
//"(select LST_No, sum(Luu_luong) as Total2 from LST_XUAT_2 group by LST_No) t2 " +
//"on t1.LST_No = t2.LST_No) as t3 order by LST_No";
//SqlConnection conn = DBUtils.GetDBConnection();
//conn.Open();
//SqlCommand cmd = new SqlCommand(sql, conn);
//SqlDataReader reader = cmd.ExecuteReader();
//DataTable table = new DataTable();
//table.Load(reader);
//DataGridView_LST_Left.DataSource = table;
//conn.Close();

//dataGridview_Font();
//DataGridView_LST_Left.Columns[0].HeaderText = "LST NO. ";
//DataGridView_LST_Left.Columns[1].HeaderText = "CÒN LẠI";



//string sql = "select * from FlowWater where datetime >= CONVERT(datetime,N'" + from_day + " " + from_time + "',103) and datetime <= CONVERT(datetime,N'" + to_day + " " + to_time + "',103) and flow_water = " + guna2ComboBox4.Text + " order by datetime;";
//SqlConnection conn = DBUtils.GetDBConnection();
//conn.Open();
//SqlCommand cmd = new SqlCommand(sql, conn);
//SqlCommand cmd = new SqlCommand("select * from LMT_new_2 where Ngay_Nhap >= CONVERT(datetime,N'" + from_day + " " + from_time + "',103) and Ngay_nhap <= CONVERT(datetime,N'" + to_day + " " + to_time + "',103) order by Ngay_nhap desc ;", conn);
//SqlDataReader reader = cmd.ExecuteReader();
//DataTable table = new DataTable();
//table.Load(reader);
//DataGridView_Water.DataSource = table;
//conn.Close();

//SqlConnection conn = DBUtils.GetDBConnection();
//conn.Open();
//SqlCommand cmd = new SqlCommand("select LMT_NO,Pipe_number,Production_Line,Formula_Code,Material_Abbreviation,sum(Total) from LMT_new where Ngay_Nhap >= CONVERT(datetime,N'" + from_day + " " + from_time + "',103) and Ngay_nhap <= CONVERT(datetime,N'" + to_day + " " + to_time + "',103) group by LMT_NO,Pipe_number,Production_Line,Formula_Code,Material_Abbreviation;", conn);
////SqlCommand cmd = new SqlCommand("select * from LMT_new_2 where Ngay_Nhap >= CONVERT(datetime,N'" + from_day + " " + from_time + "',103) and Ngay_nhap <= CONVERT(datetime,N'" + to_day + " " + to_time + "',103) order by Ngay_nhap desc ;", conn);
//SqlDataReader reader = cmd.ExecuteReader();
//DataTable table = new DataTable();
//table.Load(reader);
//LMTdataGridView1.DataSource = table;
//conn.Close();
//string query = "select LMT_NO,Pipe_number,Production_Line,Formula_Code,Material_Abbreviation,sum(Total) from LMT_new where Ngay_Nhap >= CONVERT(datetime,N'" + from_day + " " + from_time + "',103) and Ngay_nhap <= CONVERT(datetime,N'" + to_day + " " + to_time + "',103) group by LMT_NO,Pipe_number,Production_Line,Formula_Code,Material_Abbreviation;";


//private void search_lst_Click(object sender, EventArgs e)
//{
//    SqlConnection conn = DBUtils.GetDBConnection();
//    string Ngay_nhap = lst_from_day.Text;
//    dataGridView1.Columns.Clear();

//    string sql = "select LST_NO,Ten_Latex,CONVERT(VARCHAR(10),Ngay_nhap,103),CONVERT(VARCHAR(8),gio_nhap,108),Luu_luong from LST_new where Ngay_nhap = convert(datetime,'" + Ngay_nhap + "',103)";
//    conn.Open();
//    SqlCommand cmd = new SqlCommand(sql, conn);
//    SqlDataReader reader = cmd.ExecuteReader();
//    DataTable table = new DataTable();
//    dataGridView1.DataSource = table;
//    table.Load(reader);
//    conn.Close();
//    dataGridview_Font();

//    dataGridView1.Columns[0].HeaderText = "LMT NO.";
//    dataGridView1.Columns[1].HeaderText = "Latex Name";
//    dataGridView1.Columns[2].HeaderText = "DATE";
//    dataGridView1.Columns[3].HeaderText = "TIME";
//    dataGridView1.Columns[4].HeaderText = "Total Value";
//}