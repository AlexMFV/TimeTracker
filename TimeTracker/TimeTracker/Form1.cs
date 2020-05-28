using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTracker
{
    public partial class Form1 : Form
    {
        DateTime start_time;
        Timer timer = new Timer();

        public Form1()
        {
            InitializeComponent();

            //Processes Logic
            Process[] procs = Process.GetProcesses();

            FillProcessesList(procs);

            //Timer Logic
            start_time = DateTime.Now;
            btnStart.Click += BtnStart_Click;
            timer.Interval = 200;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = DateToTimeSpan(start_time);
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            start_time = DateTime.Now;
            lblTimer.Text = DateToTimeSpan(start_time);
            timer.Start();
        }

        string DateToTimeSpan(DateTime date1)
        {
            return DateTime.Now.Subtract(date1).ToString("h'h 'm'm 's's'");
        }

        void FillProcessesList(Process[] procs)
        {
            foreach(Process proc in procs)
            {
                ListViewItem item = new ListViewItem(proc.ProcessName);
                lstProcesses.Items.Add(item);
            }
        }
    }
}