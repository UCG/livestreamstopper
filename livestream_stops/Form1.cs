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
        //private EventHandler check_keypress_simulation;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            //check_keypress_simulation += new EventHandler(check_keypress_simulation);
            //SubmitButton.Click += new EventHandler(SubmitButton_Click);

        }


        //function to handle button click
        //It checks for proper numerical input and waits that amount of time to show pop up box
        async void SubmitButton_Click(object sender, EventArgs e)
        {
            //gets user input
            string time_input = TimeDelay.Text;
            string button1 = "{" + ButtonClick1.Text + "}";
            string button2 = "{" + ButtonClick2.Text + "}";

            //check input
            if (!check_valid_time_input(time_input))
            {
                MessageBox.Show("Please enter a valid number");
                TimeDelay.Text = "";
                return;
            }
            if (!check_valid_button_input(button1))
            {
                MessageBox.Show("Incorrect input for Button Click #1, please try again");
                ButtonClick1.Text = "";
                return;
            }
            if (!check_valid_button_input(button2))
            {
                MessageBox.Show("Incorrect input for Button Click #2, please try again");
                ButtonClick2.Text = "";
                return;
            }

            //sets timer and displays message after that set time     
            int wait_time = Int32.Parse(time_input) * 1000;
            await Task.Delay(wait_time);
            
            //simulate FTB press
            SendKeys.Send(button1);
            MessageBox.Show("pressed " + button1);

            //wait 30 seconds
            await Task.Delay(30000);

            //simulate stream keypress
            SendKeys.Send(button2);
            MessageBox.Show("Pressed" + button2);
           
        }

        private bool check_valid_time_input(string input)
        {
            if (input.Trim() == "")
            {
                return false;
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsNumber(input[i]))
                {
                    return false;
                }
            }
            return true;
        }
        private bool check_valid_button_input(string input)
        {
            List<string> sendkeysignals = new List<string> {"{END}", "{INSERT}"};
            if (sendkeysignals.Contains(input))
            {
                return true;
            }

            return false;
        }

        //function that allows form to submit by pressing "enter"
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SubmitButton.PerformClick();
            }

            else
            {
                if(e.KeyCode == Keys.Insert)
                {
                    MessageBox.Show("Clicked Insert");
                }
                if(e.KeyCode == Keys.End)
                {
                    MessageBox.Show("Clicked Exit");
                }
            }
        }

        
    }
 


}
    

