using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephone_Unformat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The IsValidFormat method accepts a string argument
        // and determines whether it is properly formatted as
        // a US telephone number in the following manner:
        // (XXX)XXX-XXXX
        // If the argument is properly formatted, the method
        // returns true, otherwise false.
        private bool IsValidFormat(string str)
        {
            // 使用一般字串處理方法檢查格式是否為 (XXX)XXX-XXXX
            if (str.Length == 13 &&
                str[0] == '(' &&
                str[4] == ')' &&
                str[8] == '-')
            {
                string areaCode = str.Substring(1, 3);
                string firstPart = str.Substring(5, 3);
                string secondPart = str.Substring(9, 4);

                // 確保括號內和破折號分隔的部分都是數字
                if (IsAllDigits(areaCode) &&
                    IsAllDigits(firstPart) &&
                    IsAllDigits(secondPart))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        // The unformat method accepts a string, by reference,
        // assumed to contain a telephone number formatted in
        // this manner: (XXX)XXX-XXXX.
        // The method unformats the string by removing the
        // parentheses and the hyphen.
        private void Unformat(ref string str)
        {
            // 使用 Remove 方法移除括號和連字符
            str = str.Remove(0, 1); // 移除左括號 '('
            str = str.Remove(3, 1); // 移除右括號 ')'
            str = str.Remove(6, 1); // 移除連字符 '-'
        }

        private void unformatButton_Click(object sender, EventArgs e)
        {
            string input = numberTextBox.Text; // 取得使用者輸入的電話號碼

            if (IsValidFormat(input))
            {
                Unformat(ref input); // 移除格式
                MessageBox.Show($"去除格式化後的電話號碼為：{input}", "結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("請輸入正確格式的電話號碼！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }

        // Add the missing IsAllDigits method to resolve the CS0103 error.  
        private bool IsAllDigits(string str)
        {
            // Check if all characters in the string are digits.  
            return str.All(char.IsDigit);
        }
    }
}