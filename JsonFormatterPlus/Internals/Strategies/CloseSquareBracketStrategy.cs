namespace JsonFormatterPlus.Internals.Strategies
{
    public class CloseSquareBracketStrategy : ICharacterStrategy
    {
        public void ExecutePrintyPrint(JsonFormatterStrategyContext context)
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

        public char ForWhichCharacter
        {
            get { return ']'; }
        }
    }
}