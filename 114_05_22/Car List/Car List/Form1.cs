﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_List
{
    struct Automobile
    {
        public string make;
        public int year;
        public double mileage;
    }

    public partial class Form1 : Form
    {
        // Create a List as a field.
        private List<Automobile> carList = new List<Automobile>();

        public Form1()
        {
            InitializeComponent();
        }

        // The GetData method gets the data entered
        // by the user and assigns it to the parameter
        // object's fields.
        private void GetData(ref Automobile auto)
        {
            try
            {
                // Get the data from the TextBoxes.
                auto.make = makeTextBox.Text;
                auto.year = int.Parse(yearTextBox.Text);
                auto.mileage = double.Parse(mileageTextBox.Text);
            }
            catch (Exception ex)
            {
                // Display the exception message.
                MessageBox.Show(ex.Message);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            {
                // 建立一個新的汽車結構實例
                Automobile car = new Automobile();

                // 取得使用者輸入的資料並指派給 car
                GetData(ref car);

                // 將汽車資料加入清單
                carList.Add(car);

                // 清空所有輸入欄位
                makeTextBox.Clear();
                yearTextBox.Clear();
                mileageTextBox.Clear();
            }

            // Reset the focus.
            makeTextBox.Focus();
        }

        private void displayButton_Click(object sender, EventArgs e)
        {
            // Declare a string to hold a line of output.
            string output;

            // Clear the ListBox's current contents.
            carListBox.Items.Clear();

            // Display the car info in the ListBox.
            foreach (Automobile aCar in carList)
            {
                // Make a line of output.
                output = aCar.year + " " + aCar.make +
                    " with " + aCar.mileage + " miles.";

                // Add the line of output to the ListBox.
                carListBox.Items.Add(output);
            }
        }
    }
}
