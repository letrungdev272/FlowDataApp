using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data_PLC
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (PriorProcess() != null)
            {

                MessageBox.Show("PHẦN MỀM ĐANG HOẠT ĐỘNG!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // trả về, không cho process chạy
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static Process PriorProcess()
        // Returns a System.Diagnostics.Process pointing to
        // a pre-existing process with the same name as the
        // current one, if any; or null if the current process
        // is unique.
        {
            Process curr = Process.GetCurrentProcess(); // Các ứng dụng hiện tại
            Process[] procs = Process.GetProcessesByName(curr.ProcessName); // Tên các ứng dụng hiện tại
            foreach (Process p in procs)
            {
                if ((p.Id != curr.Id) &&
                    (p.MainModule.FileName == curr.MainModule.FileName))
                {
                    return p; // trả về tên process
                }
            }
            return null;
        }
    }
}
