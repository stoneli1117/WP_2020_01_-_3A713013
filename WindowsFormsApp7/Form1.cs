using System;
using System.Collections.Generic;
using System.Drawing;
using WindowsFormsApp7.Properties;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        int iron,food,wood= 0;//設定變數
        int namedo = 0;//用來判定是否有輸入名稱
        int level = 0;//時代變數
        List<Image> list = new List<Image>();
        public Form1()
        {
            InitializeComponent();
            richTextBox3.AppendText("黑暗時代：100份木頭，100份食物\n");
            richTextBox3.AppendText("封建時代：500份木頭，300份食物，100份礦物\n");
            richTextBox3.AppendText("城堡時代：1000份木頭，500份食物，500份礦物\n");
            richTextBox3.AppendText("帝王時代：5000份木頭，2000份食物，1500份礦物\n");
        }

        public class resp
        {
            public List<img> data { get; set; }
        }

        public class img
        {
            public string Link { get; set; }
        }

        private resp GetImages(string albumHash, string clientId)                                                                   //抓圖片
        {
            resp result = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://api.imgur.com/3/album/{albumHash}/images");    //設定網址位置
                //Add Header 
                WebHeaderCollection webHeaderCollection = request.Headers;
                webHeaderCollection.Add("Authorization", $"Client-ID {clientId}");                                                  //先前設定imgur有說到
                ////////////////////////////////////////////把東西抓到json  不用改
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                string json = readStream.ReadToEnd();
                /////////////////////////////////////////////
                result = JsonConvert.DeserializeObject<resp>(json);
            }
            catch (Exception exp)                                                                                                    //如果錯誤會跳來這邊
            {
                Console.WriteLine(exp.ToString());                                                                                  //顯示在主控台介面的訊息 要另外開
                throw;
            }
            return result;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            string Name = textBox1.Text;
            try
            {

                Regex regex = new Regex(@"[\u4e00-\u9fa5]");
                if (regex.IsMatch(Name))
                {
                    
                    //輸入名稱後，顯示所有基本材料
                    namedo += 1;//如果有輸入名稱namedo+1，下方if判定namedo不為零
                    if (namedo >= 2)
                    {
                        MessageBox.Show($"請勿重複執行取名", "提示", MessageBoxButtons.OK);
                        
                    }
                    else
                    {
                        MessageBox.Show("取名成功");
                        richTextBox1.AppendText("歡迎【" + textBox1.Text + "】來到，小遊戲\n");
                        richTextBox2.AppendText("名稱：" + Name + "，");
                        richTextBox2.AppendText("木頭：" + wood + "，");
                        richTextBox2.AppendText("，礦物：" + iron + "，");
                        richTextBox2.AppendText("，食物：" + food + "\n");
                        int randomNum = new Random().Next(5); //0-100
                        int index = randomNum;//模擬隨機產生 一個值;

                        var m = GetImages("Ys2CVS9", "8cdcd3a197e0eb7");                                    //你的網址 加 你的金鑰

                        Console.WriteLine(m.data.Count);


                        // download 一張照片下來  
                        string url = m.data[index].Link;                                                    //決定輸出結果
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        Stream receiveStream = response.GetResponseStream();
                        var image = System.Drawing.Image.FromStream(receiveStream);

                        Console.WriteLine(image.Width);                                                     //顯示在主控台介面的訊息 要另外開 不影響功能                                        


                        // 顯示照片
                        pictureBox2.Image = image;

                        Console.WriteLine($"hi....{index}");
                    }
                    return;
                }

            }
            catch (FormatException)
            {

            }
            MessageBox.Show("請輸入中文名");

            
         
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }
        

        private void button5_Click(object sender, EventArgs e)
        {
            
             if (level==0 && wood > 99 && food > 99)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        wood--;
                        food--;
                    }
                    richTextBox2.Clear();
                    richTextBox2.AppendText("木頭：" + wood);
                    richTextBox2.AppendText("，礦物：" + iron);
                    richTextBox2.AppendText("，食物：" + food);
                    richTextBox1.AppendText("付出了100個木頭跟食物，演變至黑暗時代\n");
                    level++;
                    pictureBox1.Image = list[0];
                }
                else if (level == 1 && wood > 499 && food > 299 && iron >99)
                {
                    wood = wood - 500;
                    food = food - 300;
                    iron = iron - 100;
                    richTextBox2.Clear();
                    richTextBox2.AppendText("木頭：" + wood);
                    richTextBox2.AppendText("，礦物：" + iron);
                    richTextBox2.AppendText("，食物：" + food);
                    richTextBox1.AppendText("付出了500份木頭300份食物100份礦物，演變至封建時代\n");
                    level++;
                    pictureBox1.Image = list[1];
                }
                else if (level == 2 && wood > 999 && food > 499 && iron > 499)
                {
                    wood = wood - 1000;
                    food = food - 500;
                    iron = iron - 500;
                    richTextBox2.Clear();
                    richTextBox2.AppendText("木頭：" + wood);
                    richTextBox2.AppendText("，礦物：" + iron);
                    richTextBox2.AppendText("，食物：" + food);
                    richTextBox1.AppendText("付出了1000份木頭500份食物500份礦物，演變至城堡時代\n");
                    level++;
                    pictureBox1.Image = list[2];
                }
                else if (level == 3 && wood > 4999 && food > 1999 && iron > 1499)
                {
                    wood = wood - 5000;
                    food = food - 2000;
                    iron = iron - 1500;
                    richTextBox2.Clear();
                    richTextBox2.AppendText("木頭：" + wood);
                    richTextBox2.AppendText("，礦物：" + iron);
                    richTextBox2.AppendText("，食物：" + food);
                    richTextBox1.AppendText("付出了5000份木頭2000份食物1500份礦物，演變至帝王時代\n");
                    pictureBox1.Image = list[3];
            }
            else
            {
                MessageBox.Show($"窮鬼別亂按", "提示", MessageBoxButtons.OK);
            }
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            list.Add(Resources._001);
            list.Add(Resources._002);
            list.Add(Resources._003);
            list.Add(Resources._004);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int things = new Random().Next(5);//每次點選打獵，伐木，採礦隨機取得的數值
            richTextBox2.AppendText("名稱：" + Name + "，");
            if (namedo > 0 && namedo < 2)
            {
                richTextBox2.Clear();
                iron += things;
                richTextBox2.AppendText("木頭：" + wood);
                richTextBox2.AppendText("，礦物：" + iron);
                richTextBox2.AppendText("，食物：" + food);
                richTextBox1.AppendText("拿到了" + things + "個礦物\n");
            }
            else
            {
                MessageBox.Show($"請輸入名稱", "提示", MessageBoxButtons.OK);
                richTextBox2.Clear();
                richTextBox1.Clear();
            }
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int things = new Random().Next(5);//每次點選打獵，伐木，採礦隨機取得的數值
            richTextBox2.AppendText("名稱：" + Name + "，");
            if (namedo > 0 && namedo < 2)
            {
                richTextBox2.Clear();
                wood += things;
                richTextBox2.AppendText("木頭：" + wood);
                richTextBox2.AppendText("，礦物：" + iron);
                richTextBox2.AppendText("，食物：" + food);
                richTextBox1.AppendText("拿到了" + things + "個木頭\n");
            }
            else
            {
                MessageBox.Show($"請輸入名稱", "提示", MessageBoxButtons.OK);
                richTextBox2.Clear();
                richTextBox1.Clear();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            int things = new Random().Next(5);//每次點選打獵，伐木，採礦隨機取得的數值
            richTextBox2.AppendText("名稱：" + Name + "，");
            if (namedo > 0 && namedo < 2)
            {
                richTextBox2.Clear();
                food += things;
                richTextBox2.AppendText("木頭：" + wood);
                richTextBox2.AppendText("，礦物：" + iron);
                richTextBox2.AppendText("，食物：" + food);
                richTextBox1.AppendText("拿到了"+things+ "個食物\n");
            }
            else
            {
                MessageBox.Show($"請輸入名稱", "提示", MessageBoxButtons.OK);
                richTextBox2.Clear();
                richTextBox1.Clear();
            }
        }
    }
}
