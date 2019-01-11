
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
            //1a+ 2b+ 3c=4
            //5a +6b +7c=5
            //2a +3b -2c=1
            //a=? ,b=? c=?
            StreamReader s = new StreamReader("mat.txt");
            string line = s.ReadLine();
            char[] sep = { ' ', '\t' };
            string[] tokens = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(tokens[0]);
            double [,] a = new double [n, n];
            double[,] b = new double[n, n];
            double[] egal = new double[n];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                line = s.ReadLine();
                tokens = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < n+1; j++)
                {
                    if (j < a.GetLength(1))
                    {
                        a[i, j] = double.Parse(tokens[j]);
                        b[i,j]= a[i, j];
                    }
                    else
                        egal[i] = double.Parse(tokens[j]);
                        
                }
            }
            Print(a,egal);
            double deta= Determin(a,n);
            Print2(a,egal,deta,b);
        }

        private static void Print2(double[,] copya, double[] egal,double deta,double[,]truea)
        {
            int j, i;
            for (i = 0; i < copya.GetLength(0); i++)
            {
                for (j = 0; j < copya.GetLength(0); j++)
                {
                    copya[j, i] = egal[j];
                }
                Console.WriteLine("{0}={1}", (char)('a' + i),Determin(copya, copya.GetLength(0))/deta);
                if(i+1<copya.GetLength(0))
                Copy(copya, truea);
            }
            
        }

        private static void Copy(double[,] copya, double[,] truea)
        {
            for (int i = 0; i < truea.GetLength(0); i++)
            {
                for (int j= 0; j < truea.GetLength(1); j++)
                {
                     copya[i, j] = truea[i, j] ;
                }
            }
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

        private static void Print(double [,] a,double[]egal)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if(a[i,j]>=0&&j>0)
                        Console.Write("+");
                    if(j<a.GetLength(0)-1)
                    Console.Write("{0}{1} ", a[i, j],(char)('a'+j));
                    if(j==a.GetLength(0)-1)
                        Console.Write("{0}{1}={2}", a[i, j], (char)('a' + j),egal[i]);
                    
                }
                Console.WriteLine();
            }
        }
    }
}
