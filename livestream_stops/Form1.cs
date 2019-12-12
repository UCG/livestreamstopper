using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace livestream_stops
{

    public partial class Form1 : Form
    {
        static Timer myTimer = new System.Windows.Forms.Timer();

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            //SubmitButton.Click += new EventHandler(SubmitButton_Click);

        }


        //function to handle button click
        //It checks for proper numerical input and waits that amount of time to show pop up box
        async void SubmitButton_Click(object sender, EventArgs e)
        {
            //checks TextBox input
            string time_input = TextBox1.Text;
            if (time_input.Trim() == "")
            {
                MessageBox.Show("Please enter a valid number");
                return;
            }
            for (int i = 0; i < time_input.Length; i++)
            {
                if (!char.IsNumber(time_input[i]))
                {
                    MessageBox.Show("Please enter a valid number");
                    TextBox1.Text = "";
                    return;
                }

            }

            //sets timer and displays message after that set time     
            int wait_time = Int32.Parse(time_input) * 1000;
            myTimer.Interval = wait_time;
            myTimer.Enabled = true;

            await Task.Delay(wait_time);
            MessageBox.Show("wait time: " + TextBox1.Text + " seconds");

            SubmitButton.Enabled = true;
        }

    }


}
    

