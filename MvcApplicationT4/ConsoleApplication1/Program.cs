using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApplication1
{

    public class EmployeeOptionEntry
    {
        public int id;
        public long optionsCount;
        public DateTime dateAwarded;

        public static EmployeeOptionEntry[] GetEmployeeOptionEntries()
        {
            EmployeeOptionEntry[] empOptions = new EmployeeOptionEntry[] {
                new EmployeeOptionEntry { 
                  id = 1, 
                  optionsCount = 2, 
                  dateAwarded = DateTime.Parse("1999/12/31") },
                new EmployeeOptionEntry { 
                  id = 2, 
                  optionsCount = 10000, 
                  dateAwarded = DateTime.Parse("1992/06/30")  },
                new EmployeeOptionEntry { 
                  id = 2, 
                  optionsCount = 10000, 
                  dateAwarded = DateTime.Parse("1994/01/01")  },
                new EmployeeOptionEntry { 
                  id = 3, 
                  optionsCount = 5000, 
                  dateAwarded = DateTime.Parse("1997/09/30") },
                new EmployeeOptionEntry { 
                  id = 2, 
                  optionsCount = 10000, 
                  dateAwarded = DateTime.Parse("2003/04/01")  },
                new EmployeeOptionEntry { 
                  id = 3, 
                  optionsCount = 7500, 
                  dateAwarded = DateTime.Parse("1998/09/30") },
                new EmployeeOptionEntry { 
                  id = 3, 
                  optionsCount = 7500, 
                  dateAwarded = DateTime.Parse("1998/09/30") },
                new EmployeeOptionEntry { 
                  id = 4, 
                  optionsCount = 1500, 
                  dateAwarded = DateTime.Parse("1997/12/31") },
                new EmployeeOptionEntry { 
                  id = 101, 
                  optionsCount = 2, 
                  dateAwarded = DateTime.Parse("1998/12/31") }
              };

            return (empOptions);
        }
    }

    public class optComparer : IEqualityComparer<int>
    {

        public bool Equals(int x, int y)
        {
            if (x < 100 && y  < 100)
            {
                return true;
            }
            else if (x > 100 && y > 100)
            {
                return true;
            }
            else {
                return false;
            }
            
        }

        public int GetHashCode(int i)
        {
            int f = 1;
            int nf = 100;
            return (isFounder(i) ? f.GetHashCode() : nf.GetHashCode());
        }

        public bool isFounder(int id)
        {
            return (id < 100);
        }
    }

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
            //Func<string> f = () => SomeMethod() ?? " Un ti t l ed ";
            //string aa = f();

            //Console.WriteLine(aa);

            //Days dd = Days.mon | Days.tu;

            //int a = (int)dd;

            //Days ff = Days.sa;

            //if ((int)(dd & ff) != 0)
            //{
            //    Console.WriteLine('1');
            //}
            //else
            //{
            //    Console.WriteLine('0');
            //}

            var qqq = EmployeeOptionEntry.GetEmployeeOptionEntries();

            var outPos = qqq.GroupBy(k => k.id);

            foreach (var i in outPos)
            {
                Console.WriteLine(" " + i.Key);

                foreach (var j in i)
                {
                    Console.WriteLine("  "+ j.id + " " + j.optionsCount);
                }
            }

            Console.WriteLine();

            var myC = new optComparer();

            var out2 = qqq.GroupBy(k => k.id, myC);

            foreach (var i in out2)
            {
                Console.WriteLine(" " + i.Key);

                foreach (var j in i)
                {
                    Console.WriteLine("  " + j.id + " " + j.optionsCount);
                }
            }

            Console.WriteLine();

            var outPos3 = qqq.GroupBy(k => k.id, e => e.dateAwarded);

            foreach (var i in outPos3)
            {
                Console.WriteLine(" " + i.Key);

                foreach (var j in i)
                {
                    Console.WriteLine("date = " + j);
                }
            }
            
            Console.ReadLine();
             
        }
    }
}
