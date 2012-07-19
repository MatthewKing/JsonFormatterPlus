namespace JsonFormatterPlus.Internals
{
    public interface ICharacterStrategy
    {
        void ExecutePrintyPrint(JsonFormatterStrategyContext context);

        char ForWhichCharacter { get; }
    }
}
