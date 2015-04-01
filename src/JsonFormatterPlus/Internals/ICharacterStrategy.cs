namespace JsonFormatterPlus.Internals
{
    internal interface ICharacterStrategy
    {
        void Execute(JsonFormatterStrategyContext context);

        char ForWhichCharacter { get; }
    }
}
