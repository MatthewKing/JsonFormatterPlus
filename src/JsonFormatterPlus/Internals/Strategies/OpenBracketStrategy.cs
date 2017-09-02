namespace JsonFormatterPlus.Internals.Strategies
{
    internal sealed class OpenBracketStrategy : ICharacterStrategy
    {
        public char ForWhichCharacter => '{';

        public void Execute(JsonFormatterStrategyContext context)
        {
            if (context.IsProcessingString)
            {
                context.AppendCurrentChar();
                return;
            }

            context.AppendCurrentChar();
            context.EnterObjectScope();

            if (!IsBeginningOfNewLineAndIndentionLevel(context))
            {
                return;
            }

            context.BuildContextIndents();
        }

        private static bool IsBeginningOfNewLineAndIndentionLevel(JsonFormatterStrategyContext context)
        {
            return context.IsProcessingVariableAssignment
                || (!context.IsStart && !context.IsInArrayScope);
        }
    }
}
