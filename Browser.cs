using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Browser
{
    public partial class Browser : Form
    {
        public Browser()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Height = (int) (Screen.PrimaryScreen.Bounds.Height *.8);
            this.Width = (int) (Screen.PrimaryScreen.Bounds.Width * .8);
            webBrowser1.Navigate("google.com");
        }

        // The functuin is called when the exit menu item is clicked.
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This program was made by Steven Tomas, steven.tomas@live.com");
        }

        // Onlick, the web browser control will display the page requested in the textbox (URL field)
        private void button1_Click(object sender, EventArgs e)
        {
            Navigate();
        }

        // Core navigation function
        private void Navigate()
        {
            toolStripStatusLabel1.Text = "Navigation has started";
            webBrowser1.Navigate(textBox1.Text);
        }

        // This function will fire every single time a key is pushed and released
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // If the enter button was pressed
            if (e.KeyChar == (char) ConsoleKey.Enter)
            {
                // Navigate();
                button1_Click(null, null);
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            button1.Enabled = true;
            textBox1.Enabled = true;
            toolStripStatusLabel1.Text = "Navigation Complete";
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (e.CurrentProgress > 0 && e.MaximumProgress > 0)
            {
                toolStripProgressBar1.ProgressBar.Value = (int)(e.CurrentProgress * 100 / e.MaximumProgress);
            }
        }
    }
}