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
    public partial class Form1 : Form
    {
        //          私有化成员

            //      私有start（开始事件）（加载事件）
        private bool Start;     //  判断游戏是否开始

        //  定义一个悔棋总数的变量
        //int Retractsum = 0;
        //  测试
        int Retractsum = -1;

        //  定义时间变量等
        //  定义总时长变量

        /*  需要获取的返回值
         *  
         *  当前时间
         *  获胜棋子
         *  是否悔棋
         *  悔棋次数
         *  总计时：
         *  黑棋总等待时间：
         *  白棋总等待时间：
         *  总落子棋数：
         *  黑棋落子棋数：
         *  白棋落子棋数：
         */

        public static string startTime;             //  开始时间    ✔
        public static string endTime;               //  结束时间
        public static string winChess = "";         //  获胜棋子    ✔
        public static bool isRetract = false;       //  是否悔棋    ✔
        public static int sumTime = 0;              //  总计时
        public static int blackWait = 0;            //  黑棋总等待时间     ✔
        public static int whiteWait = 0;            //  白棋总等待时间     ✔
        public static int sumChess = 0;             //  总落棋子数         ✔
        public static int sumBlackChess = 0;        //  黑子总落棋子数     ✔
        public static int sumWhiteChess = 0;        //  白子总落棋子数     ✔


        //  定义等待时间变量
        int NewSecond = 0;

        // //        private bool Stop;      //  判断游戏是否结束

        //      私有化白子和黑子回合
        private bool ChessCheck = true;

            //      私有化棋盘大小
        private const int size = 15;    //  设置棋盘大小为:15

        private int[,] CheckBoard = new int[size, size];     //  棋盘点位的数组 // 二维数组
                                                             //  学习: 在c#中， 定义数组 例如int[] 这是一维数组, 每多一维, 在[]中加一个 “,” 即可。 例如定义三维数组则: int[,,]
        //  TODO  加入新功能
        /*  新功能1:   悔棋
         *  新功能2:   棋盘已满
         */

        //  悔棋列表设置
            //  此处的 Retract 是一个自定义的类, 也可以用string int
        private List<Retract> RetractList = new List<Retract>();

        public Form1()
        {
            InitializeComponent();
            //Stop = true;
            //Start = false;
        }
        //          窗体 Form1
        //      窗体加载
        
        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeGame();                           //  调用初始化游戏    
            this.Width = MainSize.FormWidth;            //  设置窗口宽度
            this.Height = MainSize.FormHeight;          //  设置窗口高度
            this.Location = new Point(280, 120);        //  设置窗口位置
        }

        //  初始化游戏
        private void InitializeGame()
        {
            #region
            //  坐标点, pointX
            //for (int pointX = 0; pointX < size; pointX++)
            //{
            //    //  坐标点, pointY
            //    for (int pointY = 0; pointY < size; pointY++)
            //    {
            //        //  重设面板
            //        CheckBoard[pointX, pointY] = 0;     //  初始化面板时, 重设XY坐标的值为0

            //    }
            //}
            #endregion
            //  将棋盘的点位数组 重置为0
            for (int i = 0; i < size; i++)
            {
                //  坐标点, pointY
                for (int j = 0; j < size; j++)
                {
                    //  重设面板
                    CheckBoard[i, j] = 0;     //  初始化面板时, 重设XY坐标的值为0
                }
            }
            //  在游戏开始之前, 先执行一步清空悔棋列表
            RetractList.Clear();
            Start = false;                  //  在初始化后, 将游戏的状态重设为false

            label2.Text = "游戏未开始";      //  游戏状态下的标签2 文本更改为 : “游戏未开始”
            button1.Visible = true;         //  在游戏开始时, 设置 按钮一: “开始游戏” 为 可见
            button2.Visible = false;        //  在游戏开始时, 设置 按钮二: “重开游戏” 为 不可见  
            button3.Visible = false;        //  在游戏开始时, 设置 按钮三: “ 悔  棋 ” 为 不可见
            button4.Visible = true;         //  在游戏开始时, 设置 按钮四: “结束游戏” 为 不可见
            label3.Text = "";
            label4.Text = "";

            //TODO  细节优化: 初始化-控件和标签的位置属性等。
            //      我想, 应当可以在此处设置标签的外边距等属性。
        }

        //      其他控件

        //      面板
        //      面板"棋盘界面"的事件
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //  加载绘制棋盘在Panel1中
            //  使用绘图函数 g 让其在panel1上进行绘制
            Graphics g = panel1.CreateGraphics();   //  创建面板画布
            //  绘制棋盘 用方法DrawCB， 参数为 g函数
            ChessBoard.DrawCB(g);                   //  调用画棋盘方法

            //  重新生成棋子
            Chess.ReDrawC(panel1, CheckBoard);      //  调用重新加载棋子的方法
        }
        //      面板右侧"控制界面"的事件
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // 设置控制界面的大小
            //panel2.Size = new Size(MainSize.FormWidth - MainSize.CBoardWidth - 20, MainSize.FormHeight);
        }
        //  
        #region
        //        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        //        {
        //            //  可用的流动面板代码
        //            #region
        //            //      第一种方法， 似乎可用， 用于管理这个面板中的控件， 可以自动添加、换行和对齐等。

        //            //int i = 0;
        //            //foreach (control ctl in flowlayoutpanel.Controls)
        //            //{
        //            //    i++;
        //            //    if (ctl = 你要移动的控件)
        //            //        break;
        //            //}
        //            //flowLayoutPanel1.Controls.SetChildIndex(dp, ik - 2);

        //            //      第二种方法
        //            //for (int j = 0; j < getrows; j++)
        //            //{
        //            //    mainpanel.rowstyles.add(new rowstyle());
        //            //}
        //            //for (int j = 0; j < getcols; j++)
        //            //{
        //            //    mainpanel.columnstyles.add(new columnstyle());
        //            //}
        //            ////对动态添加的样式设定行列比例
        //            //for (int i = 0; i < mainpanel.rowstyles.count; i++)
        //            //{
        //            //    mainpanel.rowstyles[i].sizetype = sizetype.absolute;
        //            //    mainpanel.rowstyles[i].height = (int)(mainpanel.height / getrows);
        //            //}
        //            //for (int i = 0; i < mainpanel.columnstyles.count; i++)
        //            //{
        //            //    mainpanel.columnstyles[i].sizetype = sizetype.absolute;
        //            //    mainpanel.columnstyles[i].width = (int)(mainpanel.width / getcols);
        //            //}

        //            //  第三种
        //            /*
        //            this.flowLayoutPanel1.Controls.SetChildIndex(this.button1, 0);
        //            this.flowLayoutPanel1.Controls.SetChildIndex(this.button2, 1);
        //            this.flowLayoutPanel1.Controls.SetChildIndex(this.button3, 2);
        //            this.flowLayoutPanel1.Controls.SetChildIndex(this.label1, 3);
        //            this.flowLayoutPanel1.Controls.SetChildIndex(this.label2, 4);
        //            this.flowLayoutPanel1.Controls.SetChildIndex(this.label3, 5);
        //            this.flowLayoutPanel1.Controls.SetChildIndex(this.label4, 6);
        //            this.flowLayoutPanel1.Controls.SetChildIndex(this.button4, 7);
        //            */
        //            #endregion
        ////TODO  这里有错, 没有理解flowlayoutPanel的使用方法, 之后再调。 //    视频时间节点 1:15:54
        //            //flowLayoutPanel1.Size = new Size(MainSize.FormWidth - MainSize.CBoardWidth - 20, MainSize.FormHeight);

        //        } 
        #endregion
        //      标签
       
        //      按钮
        //      按钮1"开始游戏"的单击事件 "Click"
        private void button1_Click(object sender, EventArgs e)
        {
            
            Start = true;                       //  点击 "开始游戏"  则判断变量 Start 赋值为 true;
            ChessCheck = true;                  //    点击 "开始游戏"  则判断变量 ChessCheck 赋值为 true;
            label1.Text = "游戏状态:";           //  修改label1的文本
            label2.Text = "对局已开始!";         //  修改label2的文本
            label4.Visible = true;
            label4.Text = "";
            label5.Text = "当前时间:";
            button1.Enabled = false;            //  设置按钮的可用性  当按钮"开始游戏" 按下后, 设置其为 不可用
            button2.Enabled = true;             //  设置按钮的可用性  当按钮"开始游戏" 按下后, 设置其为 不可用
            timer1.Enabled = false;
            timer2.Enabled = true; 
            
            //label4.Text = "游戏开始  秒";

            //button3.Enabled = false;          //  设置按钮的可用性  当按钮"开始游戏" 按下后, 设置其为 不可用
            button2.Visible = true;             //  设置 重新开始 的可见性  当按钮"开始游戏" 按下后, 设置其为 可见
            button3.Visible = true;             //  设置 悔   棋  按钮的可见性  当按钮"开始游戏" 按下后, 设置其为 可见
            button4.Visible = true;             //  设置 退出游戏 按钮的可见性  当按钮"开始游戏" 按下后, 设置其为 可见
            panel1.Invalidate();                //  重新绘制 面板"棋盘"
            
        }

        //      按钮2"重新开始"的单击事件 "Click"
        private void button2_Click(object sender, EventArgs e)
        {
            //  MessageBox.show:显示的内容, 标题, 按钮设置为: 确定、取消, 图标设置为: 疑问, 默认选择按钮: 为按钮2(此处为取消)         提示返回值为 OK  真
            if(MessageBox.Show("确定要重新开始游戏？", "温馨提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                //Message.Create("已经重新开始游戏");
                InitializeGame();               //  初始化游戏
                button1_Click(sender, e);       //  
                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = true;
                label3.Text = "";
                label4.Text = "";
                label5.Text = "";
                Retractsum = 0;                 //  悔棋总数置为0
            }
        }
        //      按钮3" 悔   棋 "的单击事件 "Click"
        private void button3_Click(object sender, EventArgs e)
        {
            isRetract = true;                   //  记录有悔棋行为
            //  获取悔棋列表中, 记录的最后一个棋子的索引号

            int Index = RetractList.Count - 1;
            label2.Text = " 悔棋 ";
            Retractsum += 1;
            //  使用switch来判断试试
            switch (Retractsum)
            {
                case 0:
                    label2.Text = "悔棋";
                    break;
                case 1:
                    label2.Text = "已悔棋" + Retractsum + "步";
                    break;
                default:
                    label2.Text = label2.Text = "总计悔棋" + Retractsum + "步";
                    break;
            }
            #region
            //if (Retractsum > 0)
            //{
            //    if(Retractsum > 1)
            //    {
            //        label2.Text = "连续悔棋" + Retractsum + "步";
            //    }
            //    else
            //    {
            //        label2.Text = "悔棋" + Retractsum + "步";
            //    }

            //}
            //else if (Retractsum == RetractList.Count)
            //{
            //    button3.Enabled = false;
            //    Retractsum = 0;

            //}


            // 没实验出来, 明天继续
            //if (Retractsum > 0 && Retractsum <= 1)
            //{
            //    label2.Text = "悔棋" + Retractsum + "步";
            //    //if (Retractsum >= 1)
            //    //{

            //    //}
            //}
            //else if (Retractsum > 1 && Retractsum <= RetractList.Count +1)
            //{
            //    label2.Text = "连续悔棋" + Retractsum + "步";


            //}
            //else
            //{
            //    label2.Text = "";
            //    Retractsum = 0;
            //}
            #endregion

            //  判断悔棋列表是否为空
            //  我觉得可以放到面板单击事件中, 初始设置悔棋按钮不可用, 当面板按下, && 黑子时, 悔棋按钮可用
            if (Index == -1)
            {
                if(MessageBox.Show("已经没有可以撤回的棋子了！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    label2.Text = "";
                    button3.Enabled = false;
                    Retractsum = 0;
                }
                return;
            }
            
            //  判断并且获取最后一个棋子时黑子还是白子
            string ChessCheckStr = "";
            if (ChessCheck)
            {
                ChessCheckStr = "白子";
            }
            else
            {
                ChessCheckStr = "黑子";
            }

            //  得到最后一个棋子的位置
            Retract retract = RetractList[Index];

        //  检测是否失误点了悔棋, 加确认方式
            if(MessageBox.Show("您是否确认要撤回\"" + ChessCheckStr + "在坐标: [" + retract.X + ", " + retract.Y + "]\" 处的棋子吗？", "悔棋提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                //Retractsum += 1;
                //  在悔棋列表里面, 删除上一个记录的棋子
                RetractList.RemoveAt(Index);

                //  同时在点位数组里, 清除上一个棋子
                CheckBoard[retract.X, retract.Y] = 0;

                //  刷新一下窗体(目的是为了达到自动调用并且重绘棋子的方法)
                this.Refresh();

                //  对换棋子(谁悔棋了给谁)
                ChessCheck = !ChessCheck;
            }
        }
        //      按钮4"结束游戏"的单击事件 "Click"
        private void button4_Click(object sender, EventArgs e)
        {
            //  MessageBox.show:显示的内容, 标题, 按钮设置为: 确定、取消, 图标设置为: 警告, 默认选择按钮: 为按钮2(此处为取消)         返回值为 OK 真
            if (MessageBox.Show("确定要退出游戏？", "温馨提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                this.Dispose();
                System.Environment.Exit(0);             //  终极退出方法
                //  算了, 都退出游戏了, 还弄这些干嘛？？？
                //endTime = thisTime; 
                //timer2.Enabled = false;

            }
            else
            {
                timer1.Enabled = true;
                label4.Text = "";
                label4.Visible = false;
            }
        }

        /*  重头戏
         *  面板  
         *  棋盘的 鼠标 按下 事件
         *  
         */
        
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            
            //  判断游戏是否开始
            //if(Start == true)
            //waitTime = 0;
            int Judgment = 0;
            if (Start)
            {
                
                //int Judgment = 0;                                 //  判断数组当前的行列, 是白子还是黑子的回合, 0 表示没有, 1表示黑子, 2表示白子、 用来判断
                int PlacementX = e.X / MainSize.CBoardGap;          //  求鼠标点击的X方向的第几个点位
                int PlacementY = e.Y / MainSize.CBoardGap;          //  求鼠标点击的Y方向的第几个点位
                label2.Text = "游戏进行中";
                label3.Text = "等待中: ";
                try
                {
                    //  判断落点坐标是否为空
                    if (CheckBoard[PlacementX, PlacementY] != 0)
                    {
                        return;                                     //  此位置已有棋子  
                    }
                    //  判断是黑子的回合还是白子的回合
                    if(ChessCheck)
                    {
                        timer1.Enabled = true;
                        CheckBoard[PlacementX, PlacementY] = 1;             //  黑子回合
                        Judgment = 1;                                       //  切换到判断黑子
                        label4.Text = "黑棋已落子";
                        label4.Text = "黑棋已落子";
                        label3.Text = "等待白棋落子";                        //  文本更改为"白子回合"
                        NewSecond = -1;
                        sumBlackChess++;                                    //  记录黑棋总落棋子数
                    }
                    else
                    {
                        timer1.Enabled = true;
                        CheckBoard[PlacementX, PlacementY] = 2;             //  白回合
                        Judgment = 2;                                       //  切换到判断白子
                        label4.Text = "白棋已落子";
                        label4.Text = "白棋已落子";
                        label3.Text = "等待黑棋落子";                            //  文本更改为"黑子回合"
                        NewSecond = -1;
                        sumWhiteChess++;            //  记录白棋总落棋子数
                        
                    }

                    Chess.DrawC(panel1, ChessCheck, PlacementX, PlacementY);
                    button3.Enabled = true;
        //  添加悔棋列表  记录棋子位置, 用于悔棋;
                    RetractList.Add(new Retract(PlacementX, PlacementY));       //  记录棋子位置, 用于悔棋
                    //  关于胜利的判断
                    if (WinerCheck.ChessJudgment(CheckBoard, Judgment))
                    {

                        label4.Visible = false;
                        //  判断是白子胜利还是黑子胜利
                        if (Judgment == 1)
                        {
                            label2.Text = "黑棋胜利";
                            label3.Text = "游戏结束";
                            label4.Text = "信息已记录";
                            MessageBox.Show("黑子 五子连珠, 黑棋胜利！", "胜利提示");     //  提示黑棋胜利
                            //  记录黑棋胜利
                            winChess = "黑棋";
                            timer2.Enabled = false;
                            timer1.Enabled = false;
                            endTime = "结束时间:" + thisTime;
                            
                        }
                        else
                        {
                            label2.Text = "白棋胜利";
                            label3.Text = "游戏结束";
                            label4.Text = "信息已记录";
                            MessageBox.Show("白子 五子连珠, 白棋胜利！", "胜利提示");     //  提示白棋胜利
                            //  记录白棋胜利
                            winChess = "白棋";
                            timer2.Enabled = false;
                            timer1.Enabled = false;
                            endTime = "结束时间:" + thisTime;
                            
                        }

                        //  添加是否打开From2 棋局总结
                        if (MessageBox.Show("是否观看总结？", "温馨提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                        {
                            timer2.Enabled = false;
                            timer1.Enabled = false;
                            Form2 frm2 = new Form2();
                            this.Hide();
                            frm2.Show();
                        }
                        else
                        {
                            InitializeGame();           //  调用初始化游戏
                            button1.Enabled = true;
                        }
                    }
//  TODO  这里好像有个小问题
            //  当悔棋列表总数为 15*15 == 225 时, 可能会莫名提示 黑棋胜利, 在我设置 == 224时, 会在剩余1个位置的时候弹出提示。
                    else if(RetractList.Count == size * size)               //  悔棋列表的总数 = 棋盘点位总数时
                    {
                        label2.Text = "  平局  ";
                        MessageBox.Show("棋盘已满, 平局！", "对局提示");     //  提示平局
                        label3.Text = "游戏结束";
                        label4.Text = "信息已记录";
                        InitializeGame();           //  调用初始化游戏
                        button1.Enabled = true;
                        //  添加平局胜利
                        winChess = "平局";

                        //  添加是否打开From2 棋局总结
                        if (MessageBox.Show("是否观看总结？", "温馨提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                        {
                            //FinalMethod();
                            Form2 frm2 = new Form2();
                            this.Hide();
                            frm2.Show();
                        }
                        else
                        {
                            InitializeGame();           //  调用初始化游戏
                            button1.Enabled = true;
                        }
                    }
                    //  更换棋子
                    ChessCheck = !ChessCheck;
                }
                catch (Exception) { }                   //  防止鼠标点击
            }
            else
            {
                MessageBox.Show("请先点击开始游戏", "提示信息");        //  提示需要点击开始游戏
            }
        }

        //  定义全局变量 thisTime 传递给startTime
        public static string thisTime;
        private void timer1_Tick(object sender, EventArgs e)
        {
             DateTime dateTime = DateTime.Now;                   //  实例化对象, 捕获当前系统时间
             string setTime = dateTime.ToLongTimeString();       //  将实例的值转换为等效时间字符串值
             string Hour = dateTime.Hour.ToString();             //  获取变量小时
             string Minute = dateTime.Minute.ToString();         //  获取变量分钟
             string Second = dateTime.Second.ToString();         //  获取变量秒数
                    thisTime = Hour + "时" + Minute + "分" + Second + "秒";
            //  获取从0开始的秒数

            if (NewSecond > 0)
            {
                label4.Text = "已等待" + NewSecond + "秒";
                if (ChessCheck)
                {
                    blackWait = NewSecond + 1;                 //  记录黑棋的等待时间
                }
                else
                {
                    whiteWait = NewSecond + 1;                 //  记录白棋的等待时间
                }
            }
            else
            {
                label4.Text = "";
            }
            NewSecond++;

            //  label5的显示
                label5.Text = " " + Hour + ":" + Minute + ":" + Second;
        }
        int timei = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;                      //  实例化对象, 捕获当前系统时间
            string setNewTime = dateTime.ToLongTimeString();       //  将实例的值转换为等效时间字符串值
            string newHour = dateTime.Hour.ToString();             //  获取变量小时
            string newMinute = dateTime.Minute.ToString();         //  获取变量分钟
            string newSecond = dateTime.Second.ToString();         //  获取变量秒数
            string newThisTime = newHour + "时 " + newMinute + "分 " + newSecond + "秒     ";

            sumTime++;
            
            if(timei == 0)
            {
                startTime = newThisTime;
                timei += 1;
            } 
        }

        //  插入点
        //  当鼠标在棋盘上移动的时候, 判断是否有棋子, 来决定鼠标指针
        private bool isDownChess = false;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            
            int PlacementX1 = e.X / MainSize.CBoardGap;          //  求鼠标点击的X方向的第几个点位
            int PlacementY1 = e.Y / MainSize.CBoardGap;          //  求鼠标点击的Y方向的第几个点位
            try
            {
                //  判断落点坐标是否为空
                if (CheckBoard[PlacementX1, PlacementY1] == 0)
                {
                    this.Cursor = Cursors.Hand;         //  如果无棋子, 鼠标变成手形状
                }
                else
                {
                    this.Cursor = Cursors.Default;      //  如果有棋子, 鼠标默认箭头形状
                }
            }
            catch (Exception) { }                   //  防止鼠标点击
        }

        //  这个label用来查看值

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Default;              //  修正鼠标指针在右侧面板也是手形状的问题
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            MessageBox.Show("欢迎来到五子棋", "提示信息");
        }

        
        //  form2引入
        /*  需要获取的返回值
         *  
         *  当前时间
         *  获胜棋子
         *  是否悔棋
         *  悔棋次数
         *  总计时：
         *  黑棋总等待时间：
         *  白棋总等待时间：
         *  总落子棋数：
         *  黑棋落子棋数：
         *  白棋落子棋数：
         *  结束评语：
         *  评语1
         *  评语2
         *  评语3
         *  评语4
         *  评语5
         */
        
    }
}

/*
 *  要实现的目标
 *  附加:         
 *              1. 统计信息, 当对局结束时(可以使用特殊事件), 跳转到另一个窗体, 其中显示了各种信息, 如:  总落子颗数、总悔棋次数和本场游戏总用时等, 包括庆祝胜利者信息, 鼓励失败者信息。 
 *              2. 警告信息,(每当有一方落子等待时间满20秒时, 记警告一次, 判断是白子还是黑子。
 *              3. 实现可下棋的坐标 鼠标变为手形状
 *              
 *  优化:
 *              1. 优化棋盘界面, 添加居中点位, 添加4角的点位, 添加坐标数字          
 *              2. 优化判断信息, 如悔棋...等
 *              3.
 */             
/*  紧急记录
 *  获取当前时间的秒值, 然后用下一秒的时间减去之前的值, 将这个值赋值给waitTime。 即可实现计时效果.
*/