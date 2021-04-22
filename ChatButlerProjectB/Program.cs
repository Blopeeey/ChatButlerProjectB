using System;
using System.Text;//tijdelijk

namespace ChatButlerProjectB
{
    class Program
    {
        static void Main(string[] args)
        {
            Review Rev = new Review();

            //tests
            double discount_pc = Rev.Make_review();
            //Console.WriteLine(discount_pc);
            Rev.Get_reviews();
        }
    }
}
