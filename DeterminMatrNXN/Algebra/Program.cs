﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Algebra
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader s = new StreamReader("mat.txt");
            string line = s.ReadLine();
            char[] sep = { ' ', '\t' };
            string[] tokens = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(tokens[0]);
            double [,] a = new double [n, n];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                line = s.ReadLine();
                tokens = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    a[i, j] = double.Parse(tokens[j]);
                }
            }
            Print(a);

           Console.WriteLine("determinata={0}", Determin(a,n));
        }

        private static double Determin(double[,] a,int n)
        {
            double deta = 0;
            double[,] b = new double[n,n];
            if(n>2)
            {
                int i, j=0;
                for (int p = 0; p < n; p++)
                {
                    int x = 0;
                    for (i = 1; i < n; i++)
                    {
                        int y = 0;
                        for (j = 0; j < n; j++)
                        {
                            if (j == p)
                                continue;
                            else
                            {
                                b[x, y] = a[i, j];
                                y++;
                            }
                            
                        }
                        x++;
                    }
                    deta = deta + (Inv(0,p)*a[0, p] * Determin(b, n - 1));
                }
            }else
            {
                if (n == 2)
                    return (a[0, 0] *a[1, 1])-(a[1, 0] * a[0, 1]);
            }
            return deta;
        }

        private static int Inv(int i,int j)
        {
            if ((i+j)  % 2 == 0)
                return 1;
            else
                return -1;
        }

        private static void Print(double [,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write("{0} ", a[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
