using System;

namespace ChatButlerProjectB
{
    class Program
    {
        static void Main(string[] args)
        {
            Butler Winston = new Butler();

            Console.WriteLine(Winston.Greet());
        }
    }
}
