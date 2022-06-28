using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace wuziqidemo
{
    internal class Rainbow_fart
    {
        public static string[] rainFart;        //  可以在类下面直接声明数组
        public static void Readtxt()
        {
            string path = @"rainbowfart.txt";
            string line = "";
            string oneLine = "";
            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.Peek() >= 0)              //  每次读一行
                {
                    //line = sr.ReadLine();           //  把这一行的变量给line
                    line = sr.ReadToEnd();              //  从头读到尾, 一次性把所有的字符全部读取
                    //Console.Write(line);
                }
                oneLine = line.Replace("\r\n", oneLine);        //  成功将字符串放到一行中去了。
                //Console.WriteLine();
                //Console.Write(oneLine + "   ----去除换行： 结束");

                //  分割
                //Console.WriteLine();
                rainFart = oneLine.Split(new char[] { '!' });
                
                //Console.WriteLine(rainFart[0]);
            }
        }
    }
}
