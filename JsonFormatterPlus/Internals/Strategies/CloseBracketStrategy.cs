namespace JsonFormatterPlus.Internals.Strategies
{
    internal sealed class CloseBracketStrategy : ICharacterStrategy
    {
        public void ExecutePrintyPrint(JsonFormatterStrategyContext context)
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

        public char ForWhichCharacter
        {
            get { return '}'; }
        }
    }
}
