using System;

namespace JsonFormatterPlus.Internals.Strategies
{
    internal sealed class DefaultCharacterStrategy : ICharacterStrategy
    {
        public char ForWhichCharacter => throw new InvalidOperationException("This strategy was not intended for any particular character.");

        public void Execute(JsonFormatterStrategyContext context)
        {
            context.AppendCurrentChar();
        }
    }
}
