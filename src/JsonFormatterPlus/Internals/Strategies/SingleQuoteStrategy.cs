namespace JsonFormatterPlus.Internals.Strategies
{
    internal sealed class SingleQuoteStrategy : ICharacterStrategy
    {
        public char ForWhichCharacter => '\'';

        public void Execute(JsonFormatterStrategyContext context)
        {
            if (!context.IsProcessingDoubleQuoteInitiatedString && !context.WasLastCharacterABackSlash)
            {
                context.IsProcessingSingleQuoteInitiatedString = !context.IsProcessingSingleQuoteInitiatedString;
            }

            context.AppendCurrentChar();
        }
    }
}
