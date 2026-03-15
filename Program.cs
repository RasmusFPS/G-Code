namespace G_Code
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("G-Code: ");
            string? code = Console.ReadLine();

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
