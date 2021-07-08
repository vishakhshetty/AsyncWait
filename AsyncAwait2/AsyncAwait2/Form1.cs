using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncAwait2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public int CountChars()
        {
            int count = 0;
            using (StreamReader sr = new StreamReader("C:\\Users\\Sumanth kumar\\Desktop\\Hello.txt"))
            {
                string content = sr.ReadToEnd();
                count = content.Length;
                Thread.Sleep(9000);
            }
            return count;
        }
        private async void label1_Click(object sender, EventArgs e)
        {
            Task<int> task = new Task<int>(CountChars);
            task.Start();

            label1.Text = "File is processing";
            int count = await task;
            label1.Text = count.ToString() + " characters";
        }

       
    }
}
