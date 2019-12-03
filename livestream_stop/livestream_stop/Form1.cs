using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace livestream_stop
{
    public partial class Form1 : Form
    {
        TextBox TextBox1 = new TextBox();

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }

        public Form1()
        {
            this.AutoSize = true;

            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.AutoSize = true;
            panel.FlowDirection = FlowDirection.TopDown;
            panel.Controls.Add(TextBox1);
            this.Controls.Add(panel);

            this.KeyPreview = true;
            this.KeyPress +=
                new KeyPressEventHandler(Form1_KeyPress);
            TextBox1.KeyPress +=
                new KeyPressEventHandler(TextBox1_KeyPress);
        }

        //Detect numeric characters at the form level and consume 1,
        //4, and 7. Form.KeyPreview must be set to true to work
        void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                MessageBox.Show("Form.KeyPress:'" + e.KeyChar.ToString()
                    + "'pressed.");

                switch (e.KeyChar)
                {
                    case (char)49:
                    case (char)52:
                    case (char)55:
                        MessageBox.Show("Form.KeyPress: '" +
                            e.KeyChar.ToString() + "' consumed.");
                        e.Handled = true;
                        break;
                }

            }
        }
        
        //Detect all numeric characters at the TextBox level and consume
        //2,5,8
        void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                MessageBox.Show("Control.KeyPress: '" +
                    e.KeyChar.ToString() + "' pressed.");

                switch (e.KeyChar)
                {
                    case (char)50:
                    case (char)53:
                    case (char)56:
                        MessageBox.Show("Control.KeyPress: '" +
                            e.KeyChar.ToString() + "''consumed.");
                        e.Handled = true;
                        break;
                }
            }
        }
    }

    //static class Program
    //{
    //    /// <summary>
    //    /// The main entry point for the application.
    //    /// </summary>
    //    [STAThread]
    //    static void Main()
    //    {
    //        Application.EnableVisualStyles();
    //        Application.SetCompatibleTextRenderingDefault(false);
    //        Application.Run(new Form1());
    //    }



    //}
}

