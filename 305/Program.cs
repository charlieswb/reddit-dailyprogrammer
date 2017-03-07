using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace permbase2
{
    class Program
    {
        static BigInteger index = 0;
        static string result = "";
        static void Main(string[] args)
        {
            try {
            if (args[0].Equals("inv")) {
                result = args[1];
                inv();
            } else
            {
                if (BigInteger.TryParse(args[0], out index))
                {
                    pb();
                }
                    else
                    {
                        Console.WriteLine("error");
                    }
            }
            }catch (Exception e)
            {
                Console.WriteLine(e);
            }
            //Console.ReadKey();
        }

        static void pb()
        {
            int digits = 0;
            BigInteger c = 0;
            BigInteger p2 = 1;
            while ( c <= index) {
                digits++;
                p2 *= 2;
                c += p2;
            }
            c -= p2;
            Console.WriteLine("digit : " + digits);
            BigInteger half = p2/2;
            while (digits>1)
            {
                if (index >= c + half)
                {
                    index -= (half*2);
                    result += "1";
                }
                else
                {
                    index -= half;
                    result += "0";
                }
                c -= half;
                half /= 2;
                digits--;
            }
            if(index % 2 == 0)
            {
                result += "0";
            }else
            {
                result += "1";
            }
            Console.WriteLine("value : " + result);
        }
        static void inv()
        {
            int digits = result.Length;
            BigInteger start = 1;
            for(int i=0;i < digits; i++)
            {
                start *= 2;
            }
            start -= 2;

            foreach (char c in result)
            {
                index <<= 1;
                index += c == '1' ? 1 : 0;
            }
            index += start;

            Console.WriteLine("index : " + index);

        }
    }
}
