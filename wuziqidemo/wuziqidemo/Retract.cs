using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wuziqidemo
{
    //  记录上一个棋子摆放的位置
    internal class Retract
    {
        //  构造函数, 实例化时传递坐标参数
        public Retract(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
        //  默认坐标赋值为 -1, 以此在初始化时作为无效坐标
        public int X = -1, Y = -1;
    }
}
