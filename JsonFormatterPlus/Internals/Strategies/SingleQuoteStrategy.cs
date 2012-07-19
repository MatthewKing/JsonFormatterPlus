namespace JsonFormatterPlus.Internals.Strategies
{
    internal sealed class SingleQuoteStrategy : ICharacterStrategy
    {
        public void Execute(JsonFormatterStrategyContext context)
        {
            if (!context.IsProcessingDoubleQuoteInitiatedString && !context.WasLastCharacterABackSlash)
                context.IsProcessingSingleQuoteInitiatedString = !context.IsProcessingSingleQuoteInitiatedString;

            context.AppendCurrentChar();
        }

        public char ForWhichCharacter
        {
            get { return '\''; }
        }
    }
}