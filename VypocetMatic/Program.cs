using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VypocetMatic
{
    class Program
    {
        static void Main(string[] args)
        {
            Matica Matica1 = new Matica(3,2,true);
            Console.WriteLine("Matica1");

            Matica1.VypisHodnoty();
            Console.WriteLine("Matica1[0,0] = {0}",Matica1[0, 0]);
            Matica1[0, 0] = 9;
            Console.WriteLine("Matica1[0,0] = {0}", Matica1[0, 0]);

            Matica Matica2 = new Matica(2,2,true);
            Console.WriteLine("Matica2");
            Matica2.VypisHodnoty();

            Matica Matica3 = Matica1 + Matica2;
            Console.WriteLine("Matica3 = Matica1 + Matica2");
            Matica3.VypisHodnoty();

            Matica Matica4 = Matica1 - Matica2;
            Console.WriteLine("Matica4 = Matica1 - Matica2");
            Matica4.VypisHodnoty();

            Matica Matica5 = Matica1 * Matica2;
            Console.WriteLine("Matica5 = Matica1 * Matica2");
            Matica5.VypisHodnoty();

            Matica Matica6 = ++Matica1;
            Console.WriteLine("Matica6 = ++Matica1");
            Matica6.VypisHodnoty();

            Console.ReadLine();

        }
    }
}
