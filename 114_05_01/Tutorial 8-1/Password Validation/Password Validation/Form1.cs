using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password_Validation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The NumberUpperCase method accepts a string argument
        // and returns the number of uppercase letters it contains.
        private int NumberUpperCase(string str)
        {
            int upperCaseCount = 0; // 計數器，初始值為0
            foreach (char c in str)
            {
                // 如果字元是大寫字母，則計數器加1
                if (char.IsUpper(c))
                {
                    upperCaseCount++;
                }
            }
            return upperCaseCount; // 回傳大寫字母的數量    
        }

        // The NumberLowerCase method accepts a string argument
        // and returns the number of lowercase letters it contains.
        private int NumberLowerCase(string str)
        {
            int lowerCaseCount = 0; // 計數器，初始值為0
            for (int i = 0; i < str.Length; i++)
            {
                // 如果字元是小寫字母，則計數器加1
                if (char.IsLower(str[i]))
                {
                    lowerCaseCount++;
                }
            }
            return lowerCaseCount; // 回傳小寫字母的數量   
        }

        // The NumberDigits method accepts a string argument
        // and returns the number of numeric digits it contains.
        private int NumberDigits(string str)
        {
            int digits = 0;
            foreach (char c in str)
            {
                // 如果字元是數字，則計數器加1
                if (char.IsDigit(c))
                {
                    digits++;
                }
            }
            return digits; // 回傳數字元（數字）的數量
        }  
        

        private void checkPasswordButton_Click(object sender, EventArgs e)
        {
            const int MIN_LENGTH = 8; // 密碼的最小長度
            string password = passwordTextBox.Text; // 取得使用者輸入的密碼
            if (password.Length >= MIN_LENGTH &&
                NumberUpperCase(password) > 0 &&
                NumberLowerCase(password) > 0 &&
                NumberDigits(password) > 0)
            {
                MessageBox.Show("密碼有效！", "密碼檢查結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("密碼無效！", "密碼檢查結果", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
