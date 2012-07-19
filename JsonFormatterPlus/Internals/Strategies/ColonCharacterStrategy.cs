namespace JsonFormatterPlus.Internals.Strategies
{
    public class ColonCharacterStrategy : ICharacterStrategy
    {
        public void ExecutePrintyPrint(JsonFormatterStrategyContext context)
        {
            if (context.IsProcessingString)
            {
                context.AppendCurrentChar();
                return;
            }

            context.IsProcessingVariableAssignment = true;
            context.AppendCurrentChar();
            context.AppendSpace();
        }

        public char ForWhichCharacter
        {
            get { return ':'; }
        }
    }
}
