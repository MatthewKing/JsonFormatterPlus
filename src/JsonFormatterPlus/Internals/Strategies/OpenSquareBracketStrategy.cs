namespace JsonFormatterPlus.Internals.Strategies
{
    internal sealed class OpenSquareBracketStrategy : ICharacterStrategy
    {
        public char ForWhichCharacter => '[';

        public void Execute(JsonFormatterStrategyContext context)
        {
            context.AppendCurrentChar();

            if (context.IsProcessingString)
            {
                return;
            }

            context.EnterArrayScope();
            context.BuildContextIndents();
        }
    }
}
