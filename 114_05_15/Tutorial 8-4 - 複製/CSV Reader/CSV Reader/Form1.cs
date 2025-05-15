using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CSV_Reader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // 設定表單標題為繁體中文  
            this.Text = "CSV 檔案讀取器";

            // 設定按鈕的 Text 屬性為繁體中文  
            getScoresButton.Text = "取得分數";
            exitButton.Text = "離開";
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader inputFile = null; // 初始化 inputFile 為 null  
                string line; // 儲存讀取的行  
                int count = 0; // 計數器  
                int total = 0; // 總分  
                double average; // 平均分數  
                char[] delimiter = { ',', ' ' }; // 分隔字元  

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    inputFile = File.OpenText(openFile.FileName);
                }

                if (inputFile != null) // 確保 inputFile 已被指派  
                {
                    while (!inputFile.EndOfStream)
                    {
                        line = inputFile.ReadLine(); // 讀取一行  
                        line = line.Trim(); // 去除行首行尾的空白字元  
                        string[] tokens = line.Split(delimiter); // 以分隔字元分隔字串  
                        for (int i = 1; i < tokens.Length; i++)
                        {
                            total += int.Parse(tokens[i]); // 將字串轉換為整數並累加  
                        }
                        average = (double)total / tokens.Length; // 計算平均分數  
                        averagesListBox.Items.Add("第" + (++count) + "同學的平均分數為: " + average.ToString("F2")); // 將平均分數加入 ListBox  
                    }
                }
                else
                {
                    MessageBox.Show("未選擇任何檔案");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("檔案讀取錯誤: " + ex.Message);
                return;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉目前的表單，結束應用程式的執行。  
            // 此方法會釋放所有與表單相關的資源，並將視窗從螢幕上移除。  
            this.Close();
        }
    }
}
