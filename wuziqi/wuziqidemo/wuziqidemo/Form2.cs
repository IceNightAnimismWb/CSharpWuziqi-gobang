using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wuziqidemo
{
    public partial class Form2 : Form
    {
        //  这个列表用来储存label
        List<Label> labels = new List<Label>();
        //  这个列表用来储存从from1获取的结果
        List<string> getvalue = new List<string>();
        //  这个数组用来存label12-16的内容
        
        public Form2()
        {
            InitializeComponent();

            //  我太难了呜呜呜， 这里要先引用下类的方法， 否则就获取不到值，为null。
            Rainbow_fart.Readtxt();
        }

        //  新建一个随机函数
        //public static int sjs;
        //  现在需要4个随机数，用来当作彩虹屁数组的下标。
        //public static void Random()
        //{
        //    Random random = new Random();
        //    for (int i = 0; i < 4; i++)
        //    {
        //        sjs = random.Next(0, 15);            //  生成随机数
        //    }  
        //}




        /// <summary>
        /// 生成随机数， 并且要求它不重复
        /// 存放到了数组n中
        /// </summary>
        public static int[] nsc = new int[5];
        public static void Random()
        {
            Random r = new Random();
            
            for (int i = 0; i < 5; i++)
            {
                nsc[i] = r.Next(0, 24);
                for (int j = 0; j < i; j++)
                {
                    if (nsc[i] == nsc[j])
                    {
                        nsc[i] = r.Next(0, 24);
                        j = 0;
                        
                    }
                }
                //  在这里将数组 nsc 中的值给彩虹屁
                //richTextBox2.Text += n[i].ToString() + "\t";
            }
            //  确认了，随机数未重复
            //Console.WriteLine(nsc[0]);
            //Console.WriteLine(nsc[1]);
            //Console.WriteLine(nsc[2]);
            //Console.WriteLine(nsc[3]);
            //Console.WriteLine(nsc[4]);
        }

        public static void PinJie()
        {

            for (int i = 0; i < nsc.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        pingyu1 = Rainbow_fart.rainFart[nsc[i]];
                        break;                              
                    case 1:
                        pingyu2 = Rainbow_fart.rainFart[nsc[i]];
                        break;
                    case 2:
                        pingyu3 = Rainbow_fart.rainFart[nsc[i]];
                        break;
                    case 3:
                        pingyu4 = Rainbow_fart.rainFart[nsc[i]];
                        break;
                    case 4:
                        pingyu5 = Rainbow_fart.rainFart[nsc[i]];
                        break;
                }
            }
        }

        private void Form2_Init()
        {
            //  初始化
            //  添加所有的Label到列表labels中
            labels.Clear();
            labels.Add(label1);
            labels.Add(label2);
            labels.Add(label3);
            labels.Add(label4);
            labels.Add(label5);
            labels.Add(label6);
            labels.Add(label7);
            labels.Add(label8);
            labels.Add(label9);
            labels.Add(label10);
            labels.Add(label11);
            labels.Add(label12);
            labels.Add(label13);
            labels.Add(label14);
            labels.Add(label15);
            labels.Add(label16);

            foreach(Form f in Application.OpenForms)
            {
                if(f is Form1)
                {
                    f.Visible = false;
                    return;
                }
            }
        }

        public void GetValue()
        {
            //getvalue.Clear();
            getvalue.Add(startTime);
            getvalue.Add(winChess);
            getvalue.Add(isRetract);
            getvalue.Add(sumTime + " 秒");
            getvalue.Add(blackWait + " 秒");
            getvalue.Add(whiteWait + " 秒");
            getvalue.Add(sumChess + " 颗");
            getvalue.Add(sumBlackChess + " 颗");
            getvalue.Add(sumWhiteChess + " 颗");
            getvalue.Add(" 欢呼！！！");
            getvalue.Add(" ——————— ");
            getvalue.Add(pingyu1 + "!");
            getvalue.Add(pingyu2 + "!");
            getvalue.Add(pingyu3 + "!");
            getvalue.Add(pingyu4 + "!");
            getvalue.Add(pingyu5 + "!");


            #region 无用的东西了
            //string startTime;
            //string winChess;
            //bool isRetract;
            //int sumTime;
            //int blackWait;
            //int whiteWait;
            //int sumChess;
            //int sumBlackChess;
            //int sumWhiteChess;
            //getvalue.Add();

            /*  需要获取的返回值
             *  
             *  当前时间
             *  获胜棋子
             *  是否悔棋
             *  总计时：
             *  黑棋总等待时间：
             *  白棋总等待时间：
             *  总落子棋数：
             *  黑棋落子棋数：
             *  白棋落子棋数：
             *  欢呼！！！
             *  结束评语：
             *  评语1
             *  评语2
             *  评语3
             *  评语4
             *  评语5
             */
            //  遍历列表
            #endregion
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            Form2_Init();
            FinalMethod();
            //  在窗体加载时生成随机数数组， 但要在getvalue之前。
            Random();
            PinJie();
            GetValue();
            
            //  无效的代码--添加所有label控件到labels中去
            #region
            //  使用无效
            //foreach (Control c in this.Controls)
            //{
            //    if ((c as Label) != null)
            //    {
            //        labels.Add((Label)c);
            //    }
            //}
            #endregion

            timer1.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = true;

            for (int i = 0; i < labels.Count; i++)
            {//这样可以遍历按序访问每一个Label
                labels[i].Visible = false;
            }

            this.Location = new Point(300, 150);
            this.Width = 600;
            this.Height = 500;

            //  重新设定下所有label的margin值
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            System.Environment.Exit(0);             //  终极退出方法
        }

        private int i = -1;
        public void timer1_Tick(object sender, EventArgs e)
        {
            
            if (i >= 15)
            {
                i = 0;
                timer1.Enabled = false;
            }
            else
            {
                i++;
                labels[i].Visible = true;
                labels[i].Text = labels[i].Text + getvalue[i];
                //  在此处将两个列表的内容拼接在一起

            }
            //for (int i = 0; i < labels.Count; i++)
            //{//这样可以遍历按序访问每一个Label
            //    labels[i].Visible = true;
            //}
            
        }
        public static string startTime;            //  开始时间    ✔
        public static string winChess;             //  获胜棋子    ✔
        public static string isRetract;            //  是否悔棋    ✔
        public static string sumTime;              //  总计时     ✔
        public static string blackWait;            //  黑棋总等待时间     ✔
        public static string whiteWait;            //  白棋总等待时间     ✔ 
        public static string sumChess;             //  总落棋子数         ✔
        public static string sumBlackChess;        //  黑子总落棋子数     ✔
        public static string sumWhiteChess;        //  白子总落棋子数     ✔
        public static string pingyu1;              //  评语1的变量
        public static string pingyu2;              //  评语2的变量
        public static string pingyu3;              //  评语3的变量
        public static string pingyu4;              //  评语4的变量
        public static string pingyu5;              //  评语5的变量

        public void FinalMethod()
        {   //  eeee.....   只能全部强转为string字符串了
            startTime = Form1.startTime;                //  开始时间
            winChess = Form1.winChess;                  //  获胜棋子
            isRetract = Convert.ToString(Form1.isRetract?"是":"无");                //  是否悔棋
            sumTime = Convert.ToString(Form1.sumTime);                    //  总计时         此处应该是结束时间减去开始时间
            blackWait = Convert.ToString(Form1.blackWait);                //  黑棋总等待时间
            whiteWait = Convert.ToString(Form1.whiteWait);                //  白棋总等待时间
            sumBlackChess = Convert.ToString(Form1.sumBlackChess);        //  黑子总落棋子数
            sumWhiteChess = Convert.ToString(Form1.sumWhiteChess);        //  白子总落棋子数
            sumChess = Convert.ToString(Form1.sumBlackChess + Form1.sumWhiteChess);   //  总落棋子数
        }
        // 测试
    }
}
