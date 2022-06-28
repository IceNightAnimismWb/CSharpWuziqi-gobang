using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 五子棋2
{
    public partial class Form1 : Form
    {
        private bool start;     // 游戏是否开始

        private bool ChessCheck = true;     // 白子黑子回合

        private const int size = 15;     // 棋盘大小

        private int[,] CheckBoard = new int[size, size];     // 棋盘点位数组
        public Form1()
        {
            InitializeComponent();
        }

        // "窗口"Load事件
        private void Form1_Load(object sender, EventArgs e)
        {
            initializeGame();                      // 调用初始化游戏
            this.Width = MainSize.FormWidth;       // 设置窗口宽度
            this.Height = MainSize.FormHeight;     // 设置窗口高度
            this.Location = new Point(400, 75);     // 设置窗口位置
        }

        // 初始化游戏
        private void initializeGame()
        {
            // 棋盘点位数组 重置为0
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    CheckBoard[i, j] = 0;
                }
            }
            start = false;                         // 未开始
            label1.Text = "游戏未开始";            // 提示文本改为"游戏未开始"
            button1.Visible = true;                // 显示'开始游戏'按钮
            button4.Visible = false;               // 隐藏'重新开始'按钮
        }

        //  开始游戏
        private void button1_Click(object sender, EventArgs e)
        {
            start = true;                              // 开始
            ChessCheck = true;                         // 黑子回合
            label1.Text = "黑子回合";                  // 提示文本改为"黑子回合"
            button1.Visible = false;                   // 隐藏'开始游戏'按钮
            button4.Visible = true;                    // 显示'重新开始'按钮
            panel1.Invalidate();                       // 重绘面板"棋盘"
        }
        //重开
        private void button2_Click(object sender, EventArgs e)
        {
            // 确认是否重新开始
            if (MessageBox.Show("确认要重新开始？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                initializeGame();                      // 调用初始化游戏方法
                button1_Click(sender, e);              // 调用按钮"开始游戏"Click事件
            }
        }
        //  
        private void button3_Click(object sender, EventArgs e)
        {

        }
        // 退出
        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();                            // 退出窗口
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();      // 创建面板画布
            ChessBoard.DrawCB(g);                      // 调用画棋盘方法
            Chess.ReDrawC(panel1, CheckBoard);         // 调用重新加载棋子方法
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // 设置控制界面的大小
            panel2.Size = new Size(MainSize.FormWidth - MainSize.CBoardWidth - 20, MainSize.FormHeight);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            // 判断游戏是否开始
            if (start)
            {
                int Judgment = 0;            // 判断数组当前行列，白子还是黑子回合，0表示没有，1表示黑子，2表示白子、用来判断胜利

                int PlacementX = e.X / MainSize.CBoardGap;      // 求鼠标点击的X方向的第几个点位
                int PlacementY = e.Y / MainSize.CBoardGap;      // 求鼠标点击的Y方向的第几个点位

                try
                {
                    // 判断此位置是否为空
                    if (CheckBoard[PlacementX, PlacementY] != 0)
                    {
                        return;                                 // 此位置有棋子
                    }

                    // 黑子回合还是白子回合
                    if (ChessCheck)
                    {
                        CheckBoard[PlacementX, PlacementY] = 1; // 黑子回合
                        Judgment = 1;                           // 切换为判断黑子
                        label1.Text = "白子回合";               // 提示文本改为"白子回合"
                    }
                    else
                    {
                        CheckBoard[PlacementX, PlacementY] = 2; // 白子回合
                        Judgment = 2;                           // 切换为判断白子
                        label1.Text = "黑子回合";               // 提示文本改为"黑子回合"
                    }

                    Chess.DrawC(panel1, ChessCheck, PlacementX, PlacementY);  // 画棋子

                    // 胜利判断
                    if (WinJudgment.ChessJudgment(CheckBoard, Judgment))
                    {
                        // 判断黑子还是白子胜利
                        if (Judgment == 1)
                        {
                            MessageBox.Show("五连珠，黑胜！", "胜利提示");    // 提示黑胜
                        }
                        else
                        {
                            MessageBox.Show("五连珠，白胜！", "胜利提示");    // 提示白胜
                        }
                        initializeGame();                      // 调用初始化游戏
                    }

                    ChessCheck = !ChessCheck;                   // 换棋子
                }
                catch (Exception) { }                            // 防止鼠标点击边界，导致数组越界

            }
            else
            {
                MessageBox.Show("请先开始游戏！", "提示");      // 提示开始游戏
            }
        }
    }
}
