namespace JsonFormatterPlus.Internals.Strategies
{
    using System;

    public class DefaultCharacterStrategy : ICharacterStrategy
    {
        public void ExecutePrintyPrint(JsonFormatterStrategyContext context)
        {
            context.AppendCurrentChar();
        }

        public char ForWhichCharacter
        {
            get { throw new InvalidOperationException("This strategy was not intended for any particular character, so it has no one character"); }
        }
    }
}
