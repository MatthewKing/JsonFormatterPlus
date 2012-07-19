namespace JsonFormatterPlus.Internals.Strategies
{
    internal sealed class OpenSquareBracketStrategy : ICharacterStrategy
    {
        public void ExecutePrintyPrint(JsonFormatterStrategyContext context)
        {
            context.AppendCurrentChar();

            if (context.IsProcessingString) return;

            context.EnterArrayScope();
            context.BuildContextIndents();
        }

        public char ForWhichCharacter
        {
            get { return '['; }
        }
    }
}
