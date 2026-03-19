namespace G_Code
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fun gg = new Fun();
            Console.Write("G-Code: ");
            string? code = Console.ReadLine();
            if (code == "GG")
            {

                gg.StartGG();
            }
            else if(code == "garfield")
            {
                gg.garfield();
            }
            else
            {
                Console.WriteLine("-- Tokenizing --");
                Lexer lexer = new Lexer(code);
                List<Token> tokens = lexer.TokenizeAll();

                foreach (var token in tokens)
                {
                    Console.WriteLine(token);
                }

                Console.WriteLine("\n --- Interpreting ---");
                Interpreter interpreter = new Interpreter(tokens);
                interpreter.Interpret();

                Console.ReadLine();
            }
        }
    }
}
