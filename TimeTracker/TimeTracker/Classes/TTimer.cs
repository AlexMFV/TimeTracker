using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker
{
    public static class TTimer
    {
        //DateTime start_time;
        //Timer timer = new Timer();

        public static void Start()
        {
            /*
             //Processes Logic
            Process[] procs = Process.GetProcesses();

            FillProcessesList(procs);

            //Timer Logic
            start_time = DateTime.Now;
            btnStart.Click += BtnStart_Click;
            timer.Interval = 200;
            timer.Tick += Timer_Tick;
             */
        }

        public static string DateToTimeSpan(DateTime date1)
        {
            return DateTime.Now.Subtract(date1).ToString("h'h 'm'm 's's'");
        }

        /* private void Timer_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = TTimer.DateToTimeSpan(start_time);
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            start_time = DateTime.Now;
            lblTimer.Text = TTimer.DateToTimeSpan(start_time);
            timer.Start();
        }

        

        void FillProcessesList(Process[] procs)
        {
            foreach(Process proc in procs)
            {
                ListViewItem item = new ListViewItem(proc.ProcessName);
                lstProcesses.Items.Add(item);
            }
        } */
    }
}
