namespace JsonFormatterPlus.Internals.Strategies
{
    internal sealed class CloseBracketStrategy : ICharacterStrategy
    {
        public char ForWhichCharacter => '}';

        public void Execute(JsonFormatterStrategyContext context)
        {
            if (context.IsProcessingString)
            {
                context.AppendCurrentChar();
                return;
            }

            PeformNonStringPrint(context);
        }

        private static void PeformNonStringPrint(JsonFormatterStrategyContext context)
        {
            context.CloseCurrentScope();
            context.BuildContextIndents();
            context.AppendCurrentChar();
        }
    }
}
