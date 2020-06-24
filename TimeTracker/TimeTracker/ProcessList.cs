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
        List<Process> procs;

        public ProcessList()
        {
            InitializeComponent();
            lstProcesses.Columns[0].Width = lstProcesses.Width-10;
            refreshTimer.Interval = 1000;
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();
            FillProcessList();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            Task.Run(FillProcessList);
        }

        void FillProcessList()
        {
            procs = LoadProcesses.GetRunningProcesses();
            //lstProcesses.Clear();

            //Add opened Processes
            foreach (Process proc in procs)
            {
                ListViewItem index = lstProcesses.FindItemWithText(proc.ProcessName);

                if (index == null)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = proc.ProcessName;
                    lstProcesses.Items.Add(item);
                }
            }

            ListView.ListViewItemCollection item_collection = lstProcesses.Items;

            //Remove closed processes
            foreach(ListViewItem item in item_collection)
            {
                bool aux = true;
                for (int i = 0; i < procs.Count; i++)
                {
                    if(item.Text == procs[i].ProcessName)
                    {
                        aux = false;
                        procs.RemoveAt(i);
                        break;
                    }
                }

                if (aux)
                    lstProcesses.Items.Remove(item);
            }
        }
    }
}