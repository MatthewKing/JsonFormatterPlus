namespace JsonFormatterPlus.Internals
{
    using System;
    using System.Text;
    using JsonFormatterPlus.Internals.Strategies;

    internal sealed class JsonFormatterInternal
    {
        private readonly JsonFormatterStrategyContext context;

        public JsonFormatterInternal(JsonFormatterStrategyContext context)
        {
            this.context = context;

            this.context.ClearStrategies();
            this.context.AddCharacterStrategy(new OpenBracketStrategy());
            this.context.AddCharacterStrategy(new CloseBracketStrategy());
            this.context.AddCharacterStrategy(new OpenSquareBracketStrategy());
            this.context.AddCharacterStrategy(new CloseSquareBracketStrategy());
            this.context.AddCharacterStrategy(new SingleQuoteStrategy());
            this.context.AddCharacterStrategy(new DoubleQuoteStrategy());
            this.context.AddCharacterStrategy(new CommaStrategy());
            this.context.AddCharacterStrategy(new ColonCharacterStrategy());
            this.context.AddCharacterStrategy(new SkipWhileNotInStringStrategy('\n'));
            this.context.AddCharacterStrategy(new SkipWhileNotInStringStrategy('\r'));
            this.context.AddCharacterStrategy(new SkipWhileNotInStringStrategy('\t'));
            this.context.AddCharacterStrategy(new SkipWhileNotInStringStrategy(' '));
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

            StringBuilder input = new StringBuilder(json);
            StringBuilder output = new StringBuilder();

            this.PrettyPrintCharacter(input, output);

            return output.ToString();
        }

        private void PrettyPrintCharacter(StringBuilder input, StringBuilder output)
        {
            for (int i = 0; i < input.Length; i++)
            {
                this.context.PrettyPrintCharacter(input[i], output);
            }
        }
    }
}
