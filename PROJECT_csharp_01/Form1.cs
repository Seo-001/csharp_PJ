using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJECT_csharp_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }//load

        private Task ProcessData(List<string> list, IProgress<Progress> progress)
        {
            int index = 1;
            int totalProcess = list.Count;
            var progressReport = new Progress();
            return Task.Run(() =>
            {
                for (int i = 0; i < totalProcess; i++)
                {
                    progressReport.PercentComplete = index++ * 100
                    / totalProcess;
                    progress.Report(progressReport);
                    Thread.Sleep(80);

                }//for
            });//run
        } // private Task ProcessData



        private async void btnSTART_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                list.Add(i.ToString());
            }//for
            label1.Text = "작업중.....";
            var progress = new Progress<Progress>();
            
            progress.ProgressChanged += (o, report) =>
            {
                label1.Text = string.Format("처리중...{0}%", report.PercentComplete);

                progressBar1.Value = report.PercentComplete;
                
                progressBar1.Update();
            };//
            await ProcessData(list, progress);
            label1.Text = "완료!!";


            Form2 f2 = new Form2();
            f2.Show();


        }// click 


    }// public partial class Form1 : Form
}
