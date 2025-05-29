using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cell_Phone_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The GetPhoneData method accepts a CellPhone object
        // as an argument. It assigns the data entered by the
        // user to the object's properties.
        private void GetPhoneData(CellPhone phone)
        {
            decimal price;
            // Get the brand and model from the text boxes.
            phone.Brand = brandTextBox.Text;
            phone.Model = modelTextBox.Text;
            // 嘗試將價格文字框中的文字轉換為 decimal 類型。
            if (decimal.TryParse(priceTextBox.Text, out price))
            {
                phone.Price = price; // 如果轉換成功，將價格指派給手機物件
            }
            else
            {
                // 如果轉換失敗，顯示錯誤訊息並清空價格文字框。
                MessageBox.Show("請輸入有效的價格。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                priceTextBox.Clear();
            }
        }

        private void createObjectButton_Click(object sender, EventArgs e)
        {
            CellPhone myPhone = new CellPhone();

            // Call the GetPhoneData method to populate the
            GetPhoneData(myPhone);
            // Display the phone's data in a message box.
            brandLabel.Text = myPhone.Brand;
            modelLabel.Text = myPhone.Model;
            priceLabel.Text = myPhone.Price.ToString("C2");
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
