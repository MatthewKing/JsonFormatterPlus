using System;
using System.Text;
using JsonFormatterPlus.Internals.Strategies;

namespace JsonFormatterPlus.Internals
{
    internal sealed class JsonFormatterInternal
    {
        private readonly JsonFormatterStrategyContext _context;

        public JsonFormatterInternal(JsonFormatterStrategyContext context)
        {
            _context = context;

            _context.ClearStrategies();
            _context.AddCharacterStrategy(new OpenBracketStrategy());
            _context.AddCharacterStrategy(new CloseBracketStrategy());
            _context.AddCharacterStrategy(new OpenSquareBracketStrategy());
            _context.AddCharacterStrategy(new CloseSquareBracketStrategy());
            _context.AddCharacterStrategy(new SingleQuoteStrategy());
            _context.AddCharacterStrategy(new DoubleQuoteStrategy());
            _context.AddCharacterStrategy(new CommaStrategy());
            _context.AddCharacterStrategy(new ColonCharacterStrategy());
            _context.AddCharacterStrategy(new SkipWhileNotInStringStrategy('\n'));
            _context.AddCharacterStrategy(new SkipWhileNotInStringStrategy('\r'));
            _context.AddCharacterStrategy(new SkipWhileNotInStringStrategy('\t'));
            _context.AddCharacterStrategy(new SkipWhileNotInStringStrategy(' '));
        }

        public string Format(string json)
        {
            if (json == null)
            {
                return String.Empty;
            }

            if (json.Trim() == String.Empty)
            {
                return String.Empty;
            }

            var input = new StringBuilder(json);
            var output = new StringBuilder();

            PrettyPrintCharacter(input, output);

            return output.ToString();
        }

        private void PrettyPrintCharacter(StringBuilder input, StringBuilder output)
        {
            for (int i = 0; i < input.Length; i++)
            {
                _context.PrettyPrintCharacter(input[i], output);
            }
        }
    }
}
