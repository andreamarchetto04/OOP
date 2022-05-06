using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoDiLonh
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("inserisci il PAN");
            int [] pan = new int[16];
            int i = 0;
            int numerotot = 0;
            for(i = 0; i < 16; i++)
            {
                pan[i] = Convert.ToInt32(Console.ReadLine());
            }
            int j = 1;
            for(j = 1; j < 17; j++)
            {
                if(j % 2 == 0)
                {
                    numerotot += (pan[j - 1] * 2);
                }
                else
                {
                    numerotot += pan[j - 1];
                }
            }
            if(numerotot % 10 == 0)
            {
                Console.WriteLine("PAN valido");
            }
            else
            {
                Console.WriteLine("PAN non valido");
            }
            Console.ReadKey();
        }
    }
}
