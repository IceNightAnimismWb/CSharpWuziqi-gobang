using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace 五子棋2
{
    internal class ChessBoard
    {
        // 画棋盘方法
        public static void DrawCB(Graphics g)
        {
            int GapWidth = MainSize.CBoardGap;                   // 棋格宽度
            int GapNum = MainSize.CBoardWidth / GapWidth - 1;    // 棋格数量
            Pen pen = new Pen(Color.FromArgb(192, 166, 107));    // 实例化画笔
            // 画棋盘
            for (int i = 0; i < GapNum + 1; i++)
            {
                g.DrawLine(pen, new Point(20, i * GapWidth + 20), new Point(GapWidth * GapNum + 20, i * GapWidth + 20));
                g.DrawLine(pen, new Point(i * GapWidth + 20, 20), new Point(i * GapWidth + 20, GapWidth * GapNum + 20));
            }
        }
    }
}
