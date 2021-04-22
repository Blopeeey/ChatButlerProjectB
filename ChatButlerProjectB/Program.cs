using System;
using Newtonsoft.Json;
using ChatButlerProjectB;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json.Converters;
using System.IO;

using System.Text.RegularExpressions;

namespace ChatButlerProjectB
{

    public
    class Program
    {
        public static void Main()
        {


            string result = "";

            var exePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(exePath).Value;
            var filePath = appRoot + @"\languages.json";
            var readCurrentText = File.ReadAllText(filePath);
            var sentences = JsonConvert.DeserializeObject<greeting>(readCurrentText);

            Console.WriteLine(sentences);




            //Butler Winston = new Butler();
            //Register reg = new Register();
            //Login log = new Login();
            //Account acc = new Account();

            //Console.WriteLine(Winston.Greet());
            //Console.WriteLine(Winston.ShowComponents());
            //Console.WriteLine("Kies het nummer waar u heen wilt gaan!");
            //string chosenInput = Console.ReadLine();

            //if (chosenInput != "1" && chosenInput != "2" && chosenInput != "3" && chosenInput != "4" && chosenInput != "5" && chosenInput != "6" && chosenInput != "7" && chosenInput != "chef input")
            //{
            //    Console.WriteLine("Dat is een ongeldig nummer");
            //    Main();
            //}
            //else if(chosenInput == "5")
            //{
            //    Console.WriteLine("Bedankt voor uw bezoek");
            //}
            //else if (chosenInput == "1")
            //{
            //    Console.WriteLine("Review");
            //}
            //else if (chosenInput == "2")
            //{
            //    Console.WriteLine("Reservering");
            //}
            //else if (chosenInput == "3")
            //{
            //    reg.MainReg();
            //}
            //else if (chosenInput == "4")
            //{
            //    log.MainLogin();
            //}
            //else if (chosenInput == "6")
            //{
            //    acc.MainAcc();
            //}
            //else if (chosenInput == "7")
            //{
            //    log.LogUserOut();
            //}
            //else if(chosenInput == "ma names cheff")
            //{
            //    Console.WriteLine("Cheff");
            //}
        }
    }
}
