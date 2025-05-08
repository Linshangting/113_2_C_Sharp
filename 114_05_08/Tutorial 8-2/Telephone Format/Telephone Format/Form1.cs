using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephone_Format
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The IsValidNumber method accepts a string and
        // returns true if it contains 10 digits, or false
        // otherwise.
        private bool IsValidNumber(string str)
        {
            const int VALID_LENGTH = 10;  // 定義有效的字串長度為 10
                                          // 檢查字串長度是否為 10，並且每個字元是否都是數字
            if (str.Length == VALID_LENGTH)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (!char.IsDigit(str[i]))  // 檢查字元是否為數字
                    {
                        return false;  // 如果不是數字，則回傳 false
                    }
                }
                return true;  // 如果所有字元都是數字，則回傳 true
            }
            return false;
        }
        // The TelephoneFormat method accepts a string argument
        // by reference and formats it as a telephone number.
        private void TelephoneFormat(ref string str)
        {
            // 確保字串長度為 10，並格式化為 (XX) XXXX-XXXX
            if (str.Length == 10)
            {
                // str = $"({str.Substring(0, 2)}) {str.Substring(2, 4)}-{str.Substring(6, 4)}";
            }

            str = str.Insert(0, "(");   // 在字串開頭插入 (
            str = str.Insert(3, ") ");  // 在字串的第 3 個位置插入 ) 和空格
            str = str.Insert(9, "-");   // 在字串的第 9 個位置插入 -
        }
        private void formatButton_Click(object sender, EventArgs e)
        {
            string input = numberTextBox.Text;  // 取得使用者輸入的字串
            if (IsValidNumber(input))  // 檢查字串是否為有效的 10 位數字
            {
                TelephoneFormat(ref input);  // 格式化字串
                MessageBox.Show(input, "格式化結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //numberTextBox.Text = input;  // 將格式化後的字串顯示在文字框中
            }
            else
            {
                MessageBox.Show("請輸入有效的 10 位數字。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}