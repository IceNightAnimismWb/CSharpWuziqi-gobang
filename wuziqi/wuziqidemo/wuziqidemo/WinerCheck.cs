using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wuziqidemo
{
    //  用于判断是否胜利
    internal class WinerCheck
    {
        //  首先是棋子的判断
        public static bool ChessJudgment(int[,] CheckBoard, int Judgment)
        {
            bool Win = false;
            
            //  胜利判断
            //  遍历  获取棋盘数组的每行
            for (int i = 0; i < CheckBoard.GetLength(1); i++)
            {   
                //  遍历  获取棋盘数组每行的每列
                for (int j = 0; j < CheckBoard.GetLength(0); j++)
                {
                    //  判断是否有棋子
                    if (CheckBoard[j, i] == Judgment)
                    {
                        //  水平方向判断
                        if (j < 11)             //  总共15*15个格子, 水平方向的格子数量小于11代表已经有五个被占用了
                        {
                            if (CheckBoard[j + 1, i] == Judgment && CheckBoard[j + 2, i] == Judgment && CheckBoard[j + 3, i] == Judgment && CheckBoard[j + 4, i] == Judgment)
                            {
                                return Win = true;
                            }
                        }
                        //  垂直方向判断
                        if (i < 11)
                        {
                            if (CheckBoard[j, i + 1] == Judgment && CheckBoard[j, i + 2] == Judgment && CheckBoard[j, i + 3] == Judgment && CheckBoard[j, i + 4] == Judgment)
                            {
                                return Win = true;
                            }
                        }
                        //  斜方向的判断

                        //  右下方向判断
                        if (j < 11 && i < 11)
                        {
                            if (CheckBoard[j + 1, i + 1] == Judgment && CheckBoard[j + 2, i + 2] == Judgment && CheckBoard[j + 3, i + 3] == Judgment && CheckBoard[j + 4, i + 4] == Judgment)
                            {
                                return Win = true;
                            }
                        }
                        //  左下方向判断
                        if (j >3 && i < 11)
                        {
                            if (CheckBoard[j - 1, i + 1] == Judgment && CheckBoard[j - 2, i + 2] == Judgment && CheckBoard[j - 3, i + 3] == Judgment && CheckBoard[j - 4, i + 4] == Judgment)
                            {
                                return Win = true;
                            }
                        }
                    }
                }
            }
            return Win;
        }
    }
}
