using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lottery_Numbers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            const int SIZE = 5; // 陣列的大小，表示我們將生成 5 個樂透號碼
            int[] lotteryNumbers = new int[SIZE]; // 宣告一個整數型別的陣列來儲存樂透號碼
            Random rand = new Random(); // 建立一個 Random 類別的物件，用於產生隨機數

            // 使用迴圈重複 5 次，產生 1 到 42 之間的隨機數，並存入 lotteryNumbers 陣列中
            for (int i = 0; i < lotteryNumbers.Length; i++)
            {
                lotteryNumbers[i] = rand.Next(1, 43); // 產生 1 到 42 之間的亂數（包含 1 和 42）
            }

            // 這段程式碼原先是硬寫，每一個樂透號碼都要指定顯示的標籤上
            // firstLabel.Text = lotteryNumbers[0].ToString();
            // secondLabel.Text = lotteryNumbers[1].ToString();
            // thirdLabel.Text = lotteryNumbers[2].ToString();
            // fourthLabel.Text = lotteryNumbers[3].ToString();
            // fifthLabel.Text = lotteryNumbers[4].ToString();

            // 使用標籤陣列來顯示樂透號碼在畫面上的標籤上
            // 為了將多個 Label 放入一個 Label 陣列中
            Label[] showLabels = { firstLabel, secondLabel, thirdLabel, fourthLabel, fifthLabel };
            for (int i = 0; i < showLabels.Length; i++) // 將每個樂透號碼寫入對應的標籤，並顯示在畫面上
            {
                showLabels[i].Text = lotteryNumbers[i].ToString(); // 將樂透號碼轉為字串並顯示
            }
        }  
        

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}


    
