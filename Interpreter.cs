using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_Code
{
    internal class Interpreter
    {
        private readonly List<Token> _tokens;
        private int _position = 0;

        private readonly Dictionary<string, float> _enviorment = new Dictionary<string, float>();

        public Interpreter(List<Token> tokens)
        {
            _tokens = tokens;
        }

        private Token CurrentToken => _tokens[_position];

        private void Eat(TokenType expectedType)
        {
            if (CurrentToken.Type == expectedType)
            {
                _position++;
            }
            else
            {
                throw new Exception($"Parser Error: Expected {expectedType} but got {CurrentToken.Type}");
            }
        }

        public void Interpret()
        {
            while(CurrentToken.Type != TokenType.EOF)
            {
                if(CurrentToken.Type == TokenType.Keyword && CurrentToken.Value == "fps")
                {
                    ParseVariableAssignment();
                }
                else if (CurrentToken.Type == TokenType.Keyword && CurrentToken.Value == "print")
                {
                    ParsePrintStatment();
                }
                else
                {
                    throw new Exception($"Syntax Error: Unexpected token {CurrentToken.Value}");
                }

            }
        }

        private void ParseVariableAssignment()
        {
            Eat(TokenType.Keyword);

            string varName = CurrentToken.Value;
            Eat(TokenType.Identifier);

            Eat(TokenType.Equals);

            float value = EvaluateExpression();

            _enviorment[varName] = value;
        }

        private void ParsePrintStatment()
        {
            Eat(TokenType.Keyword);

            float value = EvaluateExpression();

            Console.WriteLine($"G-Code Output: {value}");
        }

        private float EvaluateExpression()
        {
            float leftValue = 0;

            if(CurrentToken.Type == TokenType.Numbers)
            {
                leftValue = int.Parse(CurrentToken.Value);
                Eat(TokenType.Numbers);
            }
            else if(CurrentToken.Type == TokenType.Identifier)
            {
                string varName = CurrentToken.Value;
                if(_enviorment.ContainsKey(varName))
                {
                    leftValue = _enviorment[varName];
                }
                else
                {
                    throw new Exception($"Runtime Error: Variable '{varName}' is not defined.");
                }
                Eat(TokenType.Identifier);
            }
            else
            {
                throw new Exception($"Expression Error: Expected a number or variable");
            }

            if (CurrentToken.Type == TokenType.Plus)
            {
                Eat(TokenType.Plus);
                float rightValue = EvaluateExpression();
                return leftValue + rightValue;
            }
            else if(CurrentToken.Type == TokenType.Minus)
            {
                Eat(TokenType.Minus);
                float rightValue = EvaluateExpression();
                return leftValue - rightValue;
            }

            else if(CurrentToken.Type == TokenType.Multi)
            {
                Eat(TokenType.Multi);
                float rightValue = EvaluateExpression();
                return leftValue * rightValue;
            }
            else if(CurrentToken.Type == TokenType.Div)
            {

                Eat(TokenType.Div);
                float rightValue = EvaluateExpression();
                return leftValue / rightValue;
            }

                return leftValue;
        }
    }
}
