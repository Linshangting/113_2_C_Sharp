using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Program5_13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            StreamWriter outputFile;
            int count;

            try
            {
                outputFile = File.AppendText("numbers.txt");
                if (int.TryParse(textBox1.Text, out count))
                {
                    for (int i = 0; i < count; i++)
                    {
                        outputFile.WriteLine(rand.Next(100) + 1);
                    }
                    outputFile.Close();
                    MessageBox.Show("The file was created.");
                }
                else
                {
                    MessageBox.Show("Please enter a valid number.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
