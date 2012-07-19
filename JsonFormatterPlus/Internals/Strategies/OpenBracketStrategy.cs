namespace JsonFormatterPlus.Internals.Strategies
{
    public class OpenBracketStrategy : ICharacterStrategy
    {
        public void ExecutePrintyPrint(JsonFormatterStrategyContext context)
        {
            if (context.IsProcessingString)
            {
                context.AppendCurrentChar();
                return;
            }

            context.AppendCurrentChar();
            context.EnterObjectScope();

            if (!IsBeginningOfNewLineAndIndentionLevel(context)) return;

            context.BuildContextIndents();
        }

        private static bool IsBeginningOfNewLineAndIndentionLevel(JsonFormatterStrategyContext context)
        {
            return context.IsProcessingVariableAssignment || (!context.IsStart && !context.IsInArrayScope);
        }

        public char ForWhichCharacter
        {
            get { return '{'; }
        }
    }
}
