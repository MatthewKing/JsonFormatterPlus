namespace JsonFormatterPlus.Internals.Strategies
{
    internal sealed class CloseSquareBracketStrategy : ICharacterStrategy
    {
        public char ForWhichCharacter => ']';

        public void Execute(JsonFormatterStrategyContext context)
        {
            if (context.IsProcessingString)
            {
                context.AppendCurrentChar();
                return;
            }

            context.CloseCurrentScope();
            context.BuildContextIndents();
            context.AppendCurrentChar();
        }
    }
}
