using System;
using System.Windows.Forms;

namespace SimpleWinceGuiAutomation.AppTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Text = "Clicked";
        }
    }
}