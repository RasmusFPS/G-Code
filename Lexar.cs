using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_Code
{
    internal class Lexer
    {
        private readonly string _input;
        private int _position = 0;
        
        public Lexer(string input)
        {
            _input = input;
        }

        private char CurrentChar => _position < _input.Length ? _input[_position] : '\0';

        private void Advance() => _position++;

        public Token GetNextToken()
        {
            while (CurrentChar != '\0')
            {
                if (char.IsWhiteSpace(CurrentChar))
                {
                    while (char.IsWhiteSpace(CurrentChar))
                    {
                        Advance();
                    }
                    continue;
                }

                if (char.IsLetter(CurrentChar))
                {
                    string text = "";
                    while (char.IsLetterOrDigit(CurrentChar))
                    {
                        text += CurrentChar;
                        Advance();
                    }

                    if(text == "fps" || text == "print")
                    {
                        return new Token(TokenType.Keyword, text);
                    }

                    return new Token(TokenType.Identifier, text);
                }

                if (char.IsDigit(CurrentChar))
                {
                    string numStr = "";
                    while (char.IsDigit(CurrentChar))
                    {
                        numStr += CurrentChar;
                        Advance();
                    }
                    return new Token(TokenType.Numbers, numStr);
                }

                if(CurrentChar == '=')
                {
                    Advance();
                    return new Token(TokenType.Equals, "=");
                }
                if (CurrentChar == '+')
                {
                    Advance();
                    return new Token(TokenType.Plus, "+");
                }
                if (CurrentChar == '-')
                {
                    Advance();
                    return new Token (TokenType.Minus, "-");
                }

                throw new Exception($"Lexer Error: Unexpected character '{CurrentChar}' at position {_position}");
            }
            return new Token(TokenType.EOF, "");
        }

        public List<Token> TokenizeAll()
        {
            var tokens = new List<Token>();
            Token token;
            do
            {
                token = GetNextToken();
                tokens.Add(token);
            } while (token.Type != TokenType.EOF);

            return tokens;
        }
    }
}
