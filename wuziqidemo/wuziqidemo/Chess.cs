using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//  导入绘图库Drawing
using System.Drawing;
//  导入绘图库绘制2D图的功能
using System.Drawing.Drawing2D;
//  导入Windows窗体库
using System.Windows.Forms;

namespace wuziqidemo
{
    internal class Chess
    {
        
        //  棋子的设置属性  类
        public static void DrawC(Panel p, bool ChessCheck, int PlacementX, int PlacementY)
        {
            
            Graphics g = p.CreateGraphics();        //  创建面板画布  这个面板就是棋子的容器
            //  消除棋子边缘的锯齿
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //  定义棋子位置
            int AccurateX = PlacementX * MainSize.CBoardGap + 20 - 17;  //  精确棋子的X轴中心位置
            int AccurateY = PlacementY * MainSize.CBoardGap + 20 - 17;  //  精确棋子的Y轴中心位置

            //  判断是 黑子 还是 白子 的回合,   并且绘制棋子。 
            //  黑回合当然画黑子啦
            if (ChessCheck)
            {
                /*  
                 *  线性渐变会平铺整个面板, 根据位置填充颜色, 从上到下渐变, 这样棋子看起来就很像真的了。
                    使用这样的绘制方法需要导入库 : System.Drawing.Drawing2D;
                    这个函数的方法为: Point point1, Point point2, Color color1, Color color2
                    point1  表示线性渐变的起始点结构
                */
                g.FillEllipse(new LinearGradientBrush(new Point(20, 0), new Point(20, 40), Color.FromArgb(122, 122, 122), Color.FromArgb(0, 0, 0)), new Rectangle(new Point(AccurateX, AccurateY), new Size(MainSize.ChessDiameter, MainSize.ChessDiameter)));
                
            }
            //  白回合画白子  
            //else if(ChessCheck == false)
            else
            {
                g.FillEllipse(new LinearGradientBrush(new Point(20, 0), new Point(20, 40), Color.FromArgb(255, 255, 255), Color.FromArgb(204, 204, 204)), new Rectangle(new Point(AccurateX, AccurateY), new Size(MainSize.ChessDiameter, MainSize.ChessDiameter)));
                
            }
        }

        //  当界面重载时, 重新绘制棋子
        public static void ReDrawC(Panel p, int[,] CheckBoard)
        {
            Graphics g = p.CreateGraphics();        //  创建面板画布  这个面板就是棋子的容器
            //  当页面重载后, 依然要消除棋子边缘的锯齿
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //  遍历, 获取期盼数组的 每一行
            for (int i = 0; i < CheckBoard.GetLength(0); i++)
            {
                //  遍历, 获取棋盘数组每行的每一列
                for (int j = 0; j < CheckBoard.GetLength(0); j++)
                {
                    int Judgment = CheckBoard[j, i];            //  判断数组当前行列 是白子回合还是黑子的回合。0表示没有, 1表示黑子, 2表示白子
                    
                    //  判断棋盘上是否有棋子存在
                    if(Judgment != 0)
                    {
                        //  重写
                        //  如果如果这个位置没有棋子, 则重新绘制
                        
                        int AccurateX = j * MainSize.CBoardGap + 20 - 17;  //  精确棋子的X轴中心位置
                        int AccurateY = i * MainSize.CBoardGap + 20 - 17;  //  精确棋子的Y轴中心位置
                        
                        //  判断是谁的回合 并且绘制棋子
                        if (Judgment == 1)
                        {
                            /*  
                             *  线性渐变会平铺整个面板, 根据位置填充颜色, 从上到下渐变, 这样棋子看起来就很像真的了。
                                使用这样的绘制方法需要导入库 : System.Drawing.Drawing2D;
                                这个函数的方法为: Point point1, Point point2, Color color1, Color color2
                                point1  表示线性渐变的起始点结构
                            */
                            g.FillEllipse(new LinearGradientBrush(new Point(20, 0), new Point(20, 40), Color.FromArgb(122, 122, 122), Color.FromArgb(0, 0, 0)), new Rectangle(new Point(AccurateX, AccurateY), new Size(MainSize.ChessDiameter, MainSize.ChessDiameter)));
                            
                        }
                        else if(Judgment == 2)
                        {
                            g.FillEllipse(new LinearGradientBrush(new Point(20, 0), new Point(20, 40), Color.FromArgb(255, 255, 255), Color.FromArgb(204, 204, 204)), new Rectangle(new Point(AccurateX, AccurateY), new Size(MainSize.ChessDiameter, MainSize.ChessDiameter)));
                            
                        }
                    }
                }
            }
        }
    }
}
