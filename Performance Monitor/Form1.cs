using Microsoft.VisualBasic.Devices;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Performance_Monitor
{
    public partial class Form1 : Form
    {
        private Point mPoint;

        private static PerformanceCounter cpu = new PerformanceCounter(
            "Processor Information", "% Processor Utility", "_Total", true);

        private static PerformanceCounter memory = new PerformanceCounter(
            "Memory", "Available Bytes");



        public Form1()
        {
            InitializeComponent();

            //var q = new PerformanceCounter("cessor Information", "% Processor Utility", "_Total").NextValue();
            //var q = new PerformanceCounter("cessor Information", "% Processor Utility", "_Total").NextValue();
            //var q = new PerformanceCounter("cessor Information", "% Processor Utility", "_Total").NextValue();


            Task.Run(() =>
            {
                while (true)
                {
                    label4.BeginInvoke(new MethodInvoker(helloAction));
                    Thread.Sleep(2000);
                }
            });
            void helloAction()
            {
                label4.Text = $"{cpu.NextValue()}%";

                label5.Text = (100 - memory.NextValue() / getTotalRam() * 100).ToString();

                var e = new ComputerInfo();
                var q = e.TotalPhysicalMemory;
                var w = e.TotalPhysicalMemory;

                //var a = GetRamState();

                //string b = $"總記憶體數：{a.Item1}";
                //string c = $"可用記憶體數：{a.Item2}";
                //string d = $"使用中記憶體數：{a.Item1 - a.Item2}";
                //string e = $"記憶體佔用率：{1 - (a.Item2 / a.Item1)}";
            }
        }

        public int getTotalRam()
        {
            var a = new ComputerInfo();
            return Convert.ToInt32((a.TotalPhysicalMemory / (Math.Pow(1024, 3))) + 0.5);
            //return new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
        }
    }
}