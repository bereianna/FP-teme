using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LRU
{
    class Program
    {

        static int[] v;
        private static int contor = 0;
        private static int j = 1;
        private static int ind = 1;
        private static int test;
        static int[] lru;
        static int[] index;
        static void Main(string[] args)
        {
            int min = 32000;
            int p = 0;
            Console.Write("cate pg ? "); int n = int.Parse(Console.ReadLine());
            Console.Write("cate pg cadru? "); int k = int.Parse(Console.ReadLine());
            lru = new int[k+1];
            v = new int[n+1];
            index = new int[k+1];
            int lung = k;
            for (int i = 1; i <= n; i++)
            {
                Console.Write("v[{0}]=", i); v[i] = int.Parse(Console.ReadLine());

                contor++;
                test = 0;
                if (contor <= k)
                {
                    Maker(v, i, contor, test, ref min,ref p, lung);
                }
                else
                {
                    Maker(v, i, k, test, ref min,ref p,lung);
                }

            }
            for (int i = 1; i <= lung; i++)
            {
                Console.WriteLine("lru[{0}]={1}", i, lru[i]);
            }

        }

        private static void Maker(int[] v, int i, int contor, int test, ref int min, ref int p,int lung)
        {
            
            for (j = 1; j <= contor; j++)
            {
                if (lru[j] == v[i])
                {
                    index[j] = i;
                    test = 1;
                    break;
                }
                else
                {
                    if (index[j] < min)
                    {
                        min = index[j];
                        ind = j;
                    }
                }
            }
            if (lru[lung-1]==0&&test==0)
            {
                p++;
                lru[p] = v[i];
                index[p] = i;
                
            }
            else
            {
                if (test == 0||test==2)
                {
                    lru[ind] = v[i];
                    index[ind] = i;
                    p++;
                    min = 32000;
                }

            }
        }
    }

}