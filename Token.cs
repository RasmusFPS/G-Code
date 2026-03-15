using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_Code
{
    public enum TokenType
    {
        Keyword,
        Identifier,
        Numbers,
        Equals,
        Plus,
        Minus,
        EOF
    }

    internal class Token
    {
        public TokenType Type {get;}
        public string Value {get;}

        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }

        public override string ToString() => $"[{Type}: {Value}]";

    }
}
