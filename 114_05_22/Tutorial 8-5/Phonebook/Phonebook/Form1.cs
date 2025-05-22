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

namespace Phonebook
{
    struct PhoneBookEntry
    {
        public string name;
        public string phone;
    }

    public partial class Form1 : Form
    {
        // Field to hold a list of PhoneBookEntry objects.
        private List<PhoneBookEntry> phoneList = 
            new List<PhoneBookEntry>();

        public Form1()
        {
            InitializeComponent();
        }

        // The ReadFile method reads the contents of the
        // PhoneList.txt file and stores it as PhoneBookEntry
        // objects in the phoneList.
        private void ReadFile()
        {
            StreamReader inputFile; // 開啟檔案的 StreamReader 物件
            if (openFile.ShowDialog() == DialogResult.OK) // 選擇檔案
            {
                try // 嘗試開啟檔案
                {
                    inputFile = File.OpenText(openFile.FileName); // 開啟檔案
                    string line;
                    while (!inputFile.EndOfStream) // 讀取檔案直到結尾
                    {
                        // 讀取一行資料，並去除前後空白
                        line = inputFile.ReadLine().Trim();
                        // 將資料以逗號分隔，並檢查是否有兩個部分
                        string[] parts = line.Split(',');
                        if (parts.Length == 2) // 檔案格式正確
                        {
                            PhoneBookEntry entry = new PhoneBookEntry(); // 宣告一個 PhoneBookEntry 結構
                            entry.name = parts[0].Trim(); // 姓名
                            entry.phone = parts[1].Trim(); // 電話號碼
                            phoneList.Add(entry); // 將資料加入清單中
                        }
                        else // 檔案格式錯誤
                        {
                            MessageBox.Show("檔案格式錯誤");
                        }
                    }
                    inputFile.Close();
                }
                catch (Exception ex) // 嘗試開啟檔案時發生錯誤
                {
                    MessageBox.Show("讀取檔案時發生錯誤：" + ex.Message);
                }
            }
        }
        private void DisplayNames()
        {
         foreach (PhoneBookEntry entry in phoneList)
            {
                nameListBox.Items.Add(entry.name); // 將姓名加入 ListBox
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReadFile();

            DisplayNames();
        }

        private void nameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = nameListBox.SelectedIndex; // 取得選擇的索引
            if (index != -1)
            {
                // 顯示對應的電話號碼在 phoneLabel 控制項上
                phoneLabel.Text = phoneList[index].phone;
            }
            else
            {
                // 如果沒有選擇任何姓名，則清空 phoneLabel 控制項的文字
                phoneLabel.Text = "無資料";
            }
        }
       
        // exitButton_Click 事件處理函式:
        // 當使用者按下「離開」按鈕時，會關閉整個表單。

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
