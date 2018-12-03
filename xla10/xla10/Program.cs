using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xla10
{
    class Program
    {
        static void Main(string[] args)
        {
            int b,d,i;
            string s;
            double nr_10=0;
            Console.Write("x=");
            s = Console.ReadLine();
            Console.Write("baza de numeratie sursa( 2 ||  8 || 10 || 16) = "); b = int.Parse(Console.ReadLine());
            if (b < 10)
            {
                d = Convert.ToInt32(s, 10);
                s = Convert.ToString(d);
            }
            for (i=0;i<s.Length; i++)
            {
                if (char.IsDigit(s[i])) nr_10 += (s[i] - '0') * Math.Pow(b, s.Length - i - 1);    
                if (char.IsLetter(s[i])) nr_10 += (char.ToUpper(s[i]) - 'A'+10) * Math.Pow(b, s.Length - i - 1);
            }
            string binary2 = Convert.ToString((byte)nr_10, 2);
            Console.WriteLine("nr2={0}",binary2);
            string binary8 = Convert.ToString((byte)nr_10, 8);
            Console.WriteLine("nr8={0}",binary8);
            string binary10 = Convert.ToString((byte)nr_10, 10);
            Console.WriteLine("nr10={0}", binary10);
            string binary16 = Convert.ToString((byte)nr_10, 16);
            Console.WriteLine("nr16={0}", binary16);
        }
    }
}
