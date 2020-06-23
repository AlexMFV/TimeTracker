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
    public partial class ProcessList : Form
    {
        Timer refreshTimer = new Timer();

        public ProcessList()
        {
            InitializeComponent();
            FillProcessList(LoadProcesses.GetRunningProcesses());
            refreshTimer.Interval = 1000;
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            FillProcessList(LoadProcesses.GetRunningProcesses());
        }

        void FillProcessList(List<Process> procs)
        {
            lstProcesses.Clear();
            foreach (Process proc in procs)
            {
                ListViewItem item = new ListViewItem();
                item.Text = proc.ProcessName;
                lstProcesses.Items.Add(item);
            }
        }
    }
}