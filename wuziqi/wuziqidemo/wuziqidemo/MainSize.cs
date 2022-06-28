using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wuziqidemo
{
    internal class MainSize
    {
        //  说明： 此文件用于设置主体的各种属性
        //  有窗体Form， 有棋盘

        //  窗口大小

        //  访问器: 封装字段
        public static int FormWidth { get { return 710; } }     //  获取窗体的宽度
        //public static int FormWidth { get { return 1050; } }     //  获取窗体的宽度
        public static int FormHeight { get { return 640; } }    //  获取窗体的高度
        //public static int FormHeight { get { return 840; } }    //  获取窗体的高度

        //   棋盘大小
        public static int CBoardWidth { get { return 600; } }   //  设置棋盘宽度为640       
        public static int CBoardHeight { get { return 600; } }  //  设置棋盘高度为640

        //  每行棋格的宽度
        public static int CBoardGap { get { return 40; } }      //  设置棋格宽度为40

        //  每颗棋子的直径（大小）
        public static int ChessDiameter { get { return 36; } }  //  设置棋子大小为36

    }
}
