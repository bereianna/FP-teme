using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace matrice
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader pf = new StreamReader("mat.txt");
            int n=0, m=0;
            n = int.Parse(pf.ReadLine());
            m = int.Parse(pf.ReadLine());
            int[,] matrix2 = new int[n,m];
            char[] s = {' '};
            Console.WriteLine("n={0},m={1}",n,m);

            for(int i=0;i<matrix2.GetLength(0);i++)
            {
                string line = pf.ReadLine();
                string[] t = line.Split(s, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    matrix2[i, j] = int.Parse(t[j]);
                   
                };
            }
            Console.WriteLine("deasupra diagonalei sec={0}", SumDiag3(matrix2));
            Console.WriteLine("sub diagonala sec={0}", SumDiag4(matrix2)); 
            Console.WriteLine("deasupra diagonalei principale={0}", SumDiag5(matrix2)); 
            Console.WriteLine("sub diagonala principala={0}", SumDiag6(matrix2)); 
            Console.WriteLine("suma elementelor de pe o banda de dimensiune k a diagonalei principale={0}", Sumk(matrix2)); 
            Console.WriteLine("suma elementelor din sectorul S, N, V,E={0}", SumSNVE(matrix2)); 
        }

        private static int SumDiag6(int[,] matrix2)
        {
            //sub diagonala principala
            int suma = 0;
            for (int i = 0; i < matrix2.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    if (i > j)
                    {
                        suma = suma + matrix2[i, j];
                    }
                }
            }
            return suma;
        }

        private static int SumDiag5(int[,] matrix2)
        {
            //deasupra diagonalei principale
            int suma = 0;
            for (int i = 0; i < matrix2.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    if (i < j)
                    {
                        suma = suma + matrix2[i, j];
                    }
                }
            }
            return suma;
        }

        private static int SumDiag4(int[,] matrix2)
        {
            //sub diagonala sec
            int suma = 0;
            for (int i = 0; i < matrix2.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    if (i + j + 1 > matrix2.GetLength(0))
                    {
                        suma = suma + matrix2[i, j];
                    }
                }
            }
            return suma;
        }

        private static int SumDiag3(int[,] matrix2)
        {
            //deasupra diagonalei sec
            int suma = 0;
            for (int i = 0; i < matrix2.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    if (i + j + 1 < matrix2.GetLength(0))
                    {
                        suma = suma + matrix2[i, j];
                    }
                }
            }
            return suma;
        }

        private static int SumSNVE(int[,] a)
        {
            //Suma elementelor din sectorul S, N, V,E
            int sum = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if(i!=j&&i+j+1!=a.GetLength(0))
                    {
                        sum = sum + a[i, j];
                    }
                }
            }
            return sum;
        }

        private static int Sumk(int[,] a)
        {
            //suma elementelor de pe o banda de dimensiune k a diagonalei principale
            int sum = 0;
            int k;
            Console.Write("0<=k<={0}, k=? k=",a.GetLength(0)); k = int.Parse(Console.ReadLine());
            for (int i = 0; i < a.GetLength(0); i++)
            {
                if(i<k)
                {
                    sum += a[i, i];
                }
            }
            return sum;
        }
    }
}
