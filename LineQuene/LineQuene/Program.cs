using System;
using System.IO;

namespace LineQuene
{


    class Program
    {
        /// <summary>
        /// 链式表
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            LQueue<string> lq = new LQueue<string>();
            ///Console.WriteLine("LinkQuene init");

            ///Console.WriteLine($"LinkQuene is empty: {lq.IsEmpty()}");
            ///Console.WriteLine("insert 'a',1 ");
            lq.Insert("a", 1);
            ///lq.Loop();
            
            ///Console.WriteLine("insert 'b',1 ");
            lq.Insert("b", 1);
            ///lq.Loop();
            
            ///Console.WriteLine("insert 'c',2 ");
            lq.Insert("c", 2);
            ///lq.Loop();
            
            ///Console.WriteLine("insert 'd',7 ");
            lq.Insert("d", 4);
            ///lq.Loop();
            ///Console.WriteLine(lq.Find(7));
 
            lq.Modify("e", 3);
            lq.Delete(1);
            lq.Loop();
            ///lq.Loop();
          //   if (!lq.IsEmpty())
          //   {
          //        lq.Loop();
          //    }
          //  Console.WriteLine(lq.Find(1));
        }
    }
}
