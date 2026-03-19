using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_Code
{
    internal class Fun
    {
        public void StartGG()
        {
            string welcome = "-------------------------------------------\n             --- Welcome to the G-Code Guessing Game ---            \n-------------------------------------------";


            Thread.Sleep(2000);
            Console.Write("Do you wish to continue press [1] else [2] ");
            string input = Console.ReadLine();
            if(input != "1")
            {
                return;
            }
            NumberGuess();
        }
        public void NumberGuess()
        {
            int[] prevAttempts = new int[5];
            int attempts = 5;
            Random rnd = new Random();
            int number = rnd.Next(0,101);

            for (int i = 1; i < attempts; i++)
            {

            }

        }

        public void garfield()
        {
            Console.Clear();
            string garfield = "      .-.,     ,.-.\r\n '-.  /:::\\\\   //:::\\  .-'\r\n '-.\\|':':' `\"` ':':'|/.-'\r\n `-./`. .-=-. .-=-. .`\\.-`\r\n   /=- /     |     \\ -=\\\r\n  ;   |      |      |   ;\r\n  |=-.|______|______|.-=|\r\n  |==  \\  0 /_\\ 0  /  ==|\r\n  |=   /'---( )---'\\   =|\r\n   \\   \\:   .'.   :/   /\r\n    `\\= '--`   `--' =/'\r\n      `-=._     _.=-'\r\n           `\"\"\"`\r\n";
            string[] lines = garfield.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            int longestLine = 0;
            foreach (var line in lines)
            {
                if (line.Length > longestLine) longestLine = line.Length;
            }

            int centerX = Math.Max(0, (Console.WindowWidth / 2) - (longestLine / 2));
            int centerY = Math.Max(0, (Console.WindowHeight / 2) - (lines.Length / 2));

            for (int i = 0; i < lines.Length; i++)
            {
                Console.SetCursorPosition(centerX, centerY + i);
                Console.WriteLine(lines[i]);
            }
        }
    }
}
