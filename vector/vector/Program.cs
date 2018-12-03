using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vector
{
    class Program
    {
        static void Main(string[] args)
        {
            int cate = 0;
            uint n;
            int x, y;
            Console.Write("n= "); n = uint.Parse(Console.ReadLine());
            int[] v = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("v[{0}]= ", i); v[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(v);
            Console.Write("T= "); int T = int.Parse(Console.ReadLine());
            for (int i = 0; i < T; i++)
            {
                cate = 0;
                Console.Write("x = "); x = int.Parse(Console.ReadLine());
                Console.Write("y = ", x); y = int.Parse(Console.ReadLine());
                if (y < x)
                {
                    int a = x;
                    x = y;
                    y = a;
                }
                for (int j = 0; j < n; j++)
                {
                    
                    if (v[j] >= x && v[j] <= y)
                    {
                        cate++;
                    }
                    if (v[j] > y)
                    {
                        break;
                    }
                   
                }
                Console.WriteLine("in [{0},{1}] se afla {2} numere din elem. de mai sus ", x, y,cate);


            }
        }
    }
}

