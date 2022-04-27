using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHW
{
    public partial class Frm標準練習cs : Form
    {
        public Frm標準練習cs()
        {
            InitializeComponent();
        }


        static string Func(string max, params int[] nums)
        {
            int maxvalue = nums[0];

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > maxvalue)
                {
                    maxvalue = nums[i];
                }

            }

            return max + maxvalue;
        }

      

        private void button6_Click_1(object sender, EventArgs e)
        {
            int number = Convert.ToInt32(textBox4.Text);

            if (number % 2 != 0)
            {
                lblResult.Text = "輸入的數" + number + "為奇數";

            }
            else
            {
                lblResult.Text = "輸入的數" + number + "為偶數";

            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int a = 100;
            int b = 66;
            int c = 77;

            int[] arr = { a, b, c };
            lblResult.Text = "int[] nums = {100,66,77 } " + "\n " +
                "最大值為" + Convert.ToString(arr.Max());

        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(textBox1.Text);
            int b = Convert.ToInt32(textBox2.Text);
            int c = Convert.ToInt32(textBox3.Text);

            int sum = 0;
            for (int i = a; i <= b; i = i + c)
            {


                sum += i;
            }

            lblResult.Text = a + "到" + b + "相隔" + (c - 1) + "加總為" + sum;
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(textBox1.Text);
            int b = Convert.ToInt32(textBox2.Text);
            int c = Convert.ToInt32(textBox3.Text);

            int sum = 0;
            int k = a;
            while (k <= b)
            {
                sum = sum + k;
                k += c;
            }

            lblResult.Text = a + "到" + b + "相隔" + (c - 1) + "加總為" + sum;

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(textBox1.Text);
            int b = Convert.ToInt32(textBox2.Text);
            int c = Convert.ToInt32(textBox3.Text);

            int sum = 0;
            int k = a;

            do
            {
                sum = sum + k;
                k += c;
            }
            while (k <= b);

            lblResult.Text = a + "到" + b + "相隔" + (c - 1) + "加總為" + sum;
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            int[] x = new int[9];

            for (int i = 2; i < 10; i++)
            {
                for (int k = 1; k < 10; k++)
                {

                    lblResult.Text += i + "X" + k + "=" + i * k + "|";
                }

                lblResult.Text += "\n";
            }
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            int z = 100;

            string binary = Convert.ToString(z, 2);

            lblResult.Text = "100的二進位是" + binary;

        }

        private void button5_Click_1(object sender, EventArgs e)
        {

            int[] nums = { 33, 4, 5, 11, 222, 34 };

            int count1 = 0;
            int count2 = 0;
            foreach (int i in nums)
            {
                if (i % 2 != 0)
                {
                    count1++;
                }
                else
                {
                    count2++;
                }
            }

            lblResult.Text = "int[] nums = { 33, 4, 5, 11, 222, 34 }" + "\n" +
                "奇數有" + count1 + "\n" + "偶數有" + count2;

        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            string[] names = { "aaa", "ksdkfjsdk" };

            string maxvalue = names[0];

            foreach (string name in names)
            {
                if (name.Length > maxvalue.Length)
                {
                    maxvalue = name;
                }
            }

            lblResult.Text = "陣列 names {   aaa ,  ksdkfjsdk  } " + "\n" +
                "最長名字是" + maxvalue;

        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            string[] names = { "aaa", "ksdkfjsdk" };
            int count = 0;
            foreach (string k in names)
            {
                if (k.Contains("c") || k.Contains("C"))
                {
                    count++;
                }

                else
                {
                    count = 0;
                }
            }

            lblResult.Text = "陣列 names {   aaa ,  ksdkfjsdk  } " + "\n" +
                "有c或C的名字共有" + count + "個";

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            // int[] nums = { 33, 4, 5, 11, 222, 34 };

            string x = Func("最大值為", 33, 4, 5, 11, 222, 34);

            lblResult.Text = "int陣列 nums = { 33, 4, 5, 11, 222, 34 }" + "\n" + x;

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            int[] nums = { 33, 4, 5, 11, 222, 34 };
            nums.Max();
            nums.Min();

            lblResult.Text = "int陣列 nums = { 33, 4, 5, 11, 222, 34 }" + "\n" +
                "最大值為" + nums.Max() + "\n" + "最小值為" + nums.Min();

        }

        private void button19_Click_1(object sender, EventArgs e)
        {
            Random r = new Random();
            int[] a = new int[6];

            for (int i = 0; i < 6; i++)
            {
                a[i] = r.Next(1, 50);

                for (int j = 0; j < i; j++)
                {
                    //檢查號碼是否重複
                    while (a[j] == a[i])
                    {
                        j = 0;
                        //重新產生，存回陣列，亂數產生的範圍是1~49
                        a[i] = r.Next(1, 50);
                    }

                }

                lblResult.Text = "樂透號碼" + "\n" + a[0] + " " + a[1] + " " + a[2] + " " + a[3] + " " + a[4] + " " +
                +a[5];
            }


        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            lblResult.Text = string.Empty;
            lblResult.Text = "結果";
        }
    }
}