using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using WindowsFormsApp7.Properties;
using System.Windows.Forms;

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

        private void button1_Click(object sender, EventArgs e)
        {
            string Name = textBox1.Text;
            richTextBox1.AppendText("歡迎【"+textBox1.Text+"】來到，小遊戲\n");
            richTextBox2.AppendText("名稱：" + Name + "，");
            richTextBox2.AppendText("木頭：" + wood+"，");
            richTextBox2.AppendText("，礦物：" + iron+ "，");
            richTextBox2.AppendText("，食物：" + food+ "\n");//輸入名稱後，顯示所有基本材料
            namedo +=1;//如果有輸入名稱namedo+1，下方if判定namedo不為零
         
            if (namedo >= 2)
            {
                MessageBox.Show($"請勿重複輸入名稱", "提示", MessageBoxButtons.OK);
                richTextBox2.Clear();
                richTextBox1.Clear();
            }

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

        private void button5_Click(object sender, EventArgs e)
        {
            if (level == 0)
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
                pictureBox1.Image= list[0];
            } else if (level==1)
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
            else if (level == 2)
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
            else if (level == 3)
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
