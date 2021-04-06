using System;

namespace ChatButlerProjectB
{
    class Program
    {
        static void Main(string[] args)
        {

            Butler Winston = new Butler();
            //int count = 1;
            //Menu-- > reviews opvragen
            //Console.WriteLine("-Recensies restaurant La Mouette-\nDruk op de spatiebalk om een eerste review op te vragen.");
            //while (Console.ReadKey().Key != ConsoleKey.Enter)
            //{

            //    if (Console.ReadKey().Key == ConsoleKey.Spacebar)
            //    {
            //        Console.Clear();
            //        Console.WriteLine(count++);
            //        Console.WriteLine(Winston.Review_text());
            //    }

            //}
            Review Rev = new Review();
            Console.WriteLine(Rev.Make_review());
        }
    }
}



