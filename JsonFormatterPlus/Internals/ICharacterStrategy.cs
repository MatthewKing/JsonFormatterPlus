namespace JsonFormatterPlus.Internals
{
    internal interface ICharacterStrategy
    {
        void ExecutePrintyPrint(JsonFormatterStrategyContext context);

        char ForWhichCharacter { get; }
    }
}
