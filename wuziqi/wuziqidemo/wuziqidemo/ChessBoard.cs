using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 导入绘图库Drawing
using System.Drawing;

namespace wuziqidemo
{
    internal class ChessBoard
//  棋盘的设置属性  类
    {
        /*  绘制棋盘的方法
              方法1:  使用绘图库Drawing 来绘制棋盘 DrawChessBoard
              方法2:  使用图片填充 Label1的背景
              要求: 宽度:        高度:     每一格宽度:
        */
        public static void DrawCB(Graphics g)       //  这个 “ g ” 应该就是调用的方法名称
        {
            //  棋格宽度
            int GapWidth = MainSize.CBoardGap;

            //  棋格数量
            int GapNum = MainSize.CBoardWidth / GapWidth - 1;       //  生成棋格数量为棋盘宽度-1
            g.Clear(Color.Bisque);                  //  清除画布、并用Bisque颜色来填充画布

            //  实例化 画笔  --- 用于棋盘
            Pen pen = new Pen(Color.FromArgb(192, 166, 107));

            //  实例化 画刷  --- 用于装饰点                                           //  特么, ARGB原来第一个是A, Alpha值居然在第一个
            System.Drawing.SolidBrush brushz = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(180, 0, 0, 0));       //  实例化画刷

            //  绘制棋盘
            for(int i = 0; i < GapNum + 1; i++)
            {
                //  绘制棋盘的横坐标
                //  注解: 为什么有两个 new Point, 因为这两个都是坐标点, 一个是起始点, 即要从哪里开始画(开始的xy轴坐标)。 另一个是终结点, 即画到哪里停止(停止的xy轴坐标)
                //  new Point(x(x轴离左边的距离),y(y轴离顶边的距离))

                //  注解: 画线, 循环绘制。
                //  起始点: X轴坐标是离左边20, Y轴坐标是i * 棋格宽度 + 20。  终结点: X轴坐标是 棋格的宽度 * 棋格数量 + 20, Y轴坐标是 i * 棋格宽度 + 20。
                g.DrawLine(pen, new Point(20, i * GapWidth + 20), new Point(GapWidth * GapNum + 20, i * GapWidth + 20));        //  绘制行的线条
                g.DrawLine(pen, new Point(i * GapWidth + 20, 20), new Point(i * GapWidth + 20, GapWidth * GapNum + 20));        //  绘制列的线条



//TODO  棋盘美化: 线条、五定位原点等装饰物
                //  绘制一些补充性的线条等, 例如在 第 1、3、5、7、9、11、13、15行和列单独画线条, 长度设置为 10
                //  想如此做, 只需要用 g.DrawLine 写即可。
                //  g.DrawLine(pen, new Point(), new Point());
            }

                //  画刷画出的圆有太多的锯齿, 不圆滑, 设定抗锯齿
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;         
            //  绘制坐标原点                          //  似乎由于像素没算对, 以及左边预留的边框导致位置便宜了7个像素点
            g.FillEllipse(brushz, new Rectangle(293, 293, 13, 13));                 //  中心点位        
            g.FillEllipse(brushz, new Rectangle(93, 93, 13, 13));                   //  左上点位
            g.FillEllipse(brushz, new Rectangle(93, 493, 13, 13));                  //  左下点位
            g.FillEllipse(brushz, new Rectangle(493, 93, 13, 13));                  //  右上点位
            g.FillEllipse(brushz, new Rectangle(493, 493, 13, 13));                 //  右下点位
            
            //g.SmoothingMode = SmoothingMode.HighQuality;
            //g.InterpolationMode = InterpolationMode.HighQualityBicubic;

        }
    }
}
