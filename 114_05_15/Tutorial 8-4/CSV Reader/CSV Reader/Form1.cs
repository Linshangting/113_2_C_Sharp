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
                int total; // 總分  
                double average; // 平均分數  
                char[] delimiter = { ',', ' ' }; // 分隔字元  

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    inputFile = File.OpenText(openFile.FileName);
                }

                if (inputFile != null)
                {
                    while (!inputFile.EndOfStream)
                    {
                        line = inputFile.ReadLine().Trim();
                        string[] tokens = line.Split(delimiter);

                        total = 0; // 每位同學重新計算總分

                        for (int i = 0; i < tokens.Length; i++) // 從第 0 個開始讀分數
                        {
                            total += int.Parse(tokens[i]);
                        }

                        average = (double)total / tokens.Length;
                        averagesListBox.Items.Add("第" + (++count) + "位同學的平均分數為: " + average.ToString("F2"));
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
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

