using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApplication1
{

     
    [Flags]
    public enum Days
    { 
        mon = 1,
        tu = 2,
        we = 4,
        fu = 8,
        fr = 16,
        sa = 32,
        su = 64
    }


    class Program
    {
        public static string SomeMethod()
        {
            return null;
        }
         
        static void Main(string[] args)
        {
            Func<string> f = () => SomeMethod() ?? " Un ti t l ed ";
            string aa = f();

            Console.WriteLine(aa);

            Days dd = Days.mon | Days.tu;

            int a = (int)dd;

            Days ff = Days.sa;

            if ((int)(dd & ff) != 0)
            {
                Console.WriteLine('1');
            }
            else
            {
                Console.WriteLine('0');
            }


            
            Console.ReadLine();

            int baa = Int32.MaxValue;

            baa = baa + 2;
        }
    }
}
