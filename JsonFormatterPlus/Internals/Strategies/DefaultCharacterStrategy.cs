namespace JsonFormatterPlus.Internals.Strategies
{
    using System;

    internal sealed class DefaultCharacterStrategy : ICharacterStrategy
    {
        public void Execute(JsonFormatterStrategyContext context)
        {
            context.AppendCurrentChar();
        }

        public char ForWhichCharacter
        {
            get 
            {
                const string msg = "This strategy was not intended for any particular character.";
                throw new InvalidOperationException(msg);
            }
        }
    }
}
