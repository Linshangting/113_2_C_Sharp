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

namespace Test_Average
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Average 方法接受一個整數陣列作為參數，並返回該陣列中所有值的平均值。
        private double Average(int[] scores)
        {
            return scores.Average();
        }

        // Highest 方法接受一個整數陣列作為參數，並返回該陣列中的最大值。
        private int Highest(int[] scores)
        {
            return scores.Max();
        }

        // Lowest 方法接受一個整數陣列作為參數，並返回該陣列中的最小值。
        private int Lowest(int[] scores)
        {
            return scores.Min();
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            const int SIZE = 48; // 定義陣列大小為 48
            int[] testScores = new int[SIZE]; // 初始化整數陣列以存儲測試分數
            int index = 0; // 初始化索引變量
            int highestScore = 0; // 初始化最高分數變量
            int lowestScore = 0; // 初始化最低分數變量
            double averageScore = 0; // 初始化平均分數變量
            StreamReader inputFile; // 定義 StreamReader 變量以讀取文件

            try
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    // 打開選擇的文件
                    inputFile = File.OpenText(openFile.FileName);

                    // 從文件中讀取測試分數
                    while (!inputFile.EndOfStream && index < SIZE)
                    {
                        testScores[index] = Convert.ToInt32(inputFile.ReadLine());
                        index++;
                    }

                    inputFile.Close(); // 關閉文件

                    // 計算平均分數、最高分數和最低分數
                    averageScore = Average(testScores);
                    highestScore = Highest(testScores);
                    lowestScore = Lowest(testScores);

                    // 顯示結果
                    averageScoreLabel.Text = averageScore.ToString("n1");
                    highScoreLabel.Text = highestScore.ToString();
                    lowScoreLabel.Text = lowestScore.ToString();
                }
            }
            catch (Exception ex)
            {
                // 處理可能發生的異常
                MessageBox.Show(ex.Message);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單
            this.Close();
        }
    }
}