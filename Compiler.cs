using System;
using System.Collections.Generic;
using System.Text;


namespace G_Code
{
    public class Compiler
    {
        private readonly List<Token> _tokens;
        private int _position = 0;

        private readonly StringBuilder _CsharpCode = new StringBuilder();

        public Compiler(List<Token> tokens)
        {
            _tokens = tokens;
        }

        private Token CurrentToken => _position < _tokens.count ? _tokens[_position] : new Token(tokenType.EOF, "");

        private void Eat(TokenType expectedType)
        {
            if(CurrentToken.Type == expectedType)
            {
                _position++;
            }
            else
            {
                throw new Exception($"Compiler Error: Expected {expectedType} but got {CurrentToken.Type}")
            }
        }
    }

    public string Compiler()
        {
            //Generates the main of a standard C# file
            _CsharpCode.AppendLine("using System;");
            _CsharpCode.AppendLine("namespace CompiledGCode {");
            _CsharpCode.AppendLine("class Program {");
            _CsharpCode.AppendLine("static void Main() {");

            while(CurrentToken.Type != TokenType.EOF)
            {
                if(CurrentToken.Type == TokenType.Keyword && CurrentToken.Value == "fps")
                {
                    CompileVariableAssignment();
                }
                else if(CurrentToken.Type == TokenType.Keyword && CurrentToken == "print")
                {
                    CompilePrintStatment();
                }
                else
                {
                    throw new Exception($"Syntax Error: Unexpected token {CurrentToken.Value}");
                }
            }
            //Closing brackets and pause at the end
            _CsharpCode.AppendLine("Console.ReadLine();");
            _CsharpCode.AppendLine("}");
            _CsharpCode.AppendLine("}");
            _CsharpCode.AppendLine("}");

        }
    }