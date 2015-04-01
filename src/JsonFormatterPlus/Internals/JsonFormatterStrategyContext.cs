namespace JsonFormatterPlus.Internals
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using JsonFormatterPlus.Internals.Strategies;

    internal sealed class JsonFormatterStrategyContext
    {
        private const string Space = " ";
        private const int SpacesPerIndent = 4;

        private string indent = String.Empty;

        private char currentCharacter;
        private char previousChar;

        private StringBuilder outputBuilder;

        private readonly FormatterScopeState scopeState = new FormatterScopeState();
        private readonly IDictionary<char, ICharacterStrategy> strategies = new Dictionary<char, ICharacterStrategy>();


        public string Indent
        {
            get
            {
                if (this.indent == String.Empty)
                {
                    this.InitializeIndent();
                }

                return this.indent;
            }
        }

        private void InitializeIndent()
        {
            for (int i = 0; i < SpacesPerIndent; i++)
            {
                this.indent += Space;
            }
        }


        public bool IsInArrayScope
        {
            get
            {
                return this.scopeState.IsTopTypeArray;
            }
        }

        private void AppendIndents(int indents)
        {
            for (int i = 0; i < indents; i++)
            {
                this.outputBuilder.Append(Indent);
            }
        }

        public bool IsProcessingVariableAssignment;
        public bool IsProcessingDoubleQuoteInitiatedString { get; set; }
        public bool IsProcessingSingleQuoteInitiatedString { get; set; }

        public bool IsProcessingString
        {
            get
            {
                return this.IsProcessingDoubleQuoteInitiatedString 
                    || this.IsProcessingSingleQuoteInitiatedString;
            }
        }

        public bool IsStart
        {
            get
            {
                return this.outputBuilder.Length == 0;
            }
        }

        public bool WasLastCharacterABackSlash
        {
            get
            {
                return this.previousChar == '\\';
            }
        }
            
        public void PrettyPrintCharacter(char curChar, StringBuilder output)
        {
            this.currentCharacter = curChar;

            ICharacterStrategy strategy = this.strategies.ContainsKey(curChar)
                ? strategies[curChar]
                : new DefaultCharacterStrategy();

            this.outputBuilder = output;

            strategy.Execute(this);

            this.previousChar = curChar;
        }

        public void AppendCurrentChar()
        {
            this.outputBuilder.Append(this.currentCharacter);
        }

        public void AppendNewLine()
        {
            this.outputBuilder.Append(Environment.NewLine);
        }

        public void BuildContextIndents()
        {
            this.AppendNewLine();
            this.AppendIndents(this.scopeState.ScopeDepth);
        }

        public void EnterObjectScope()
        {
            this.scopeState.PushObjectContextOntoStack();
        }

        public void CloseCurrentScope()
        {
            this.scopeState.PopJsonType();
        }

        public void EnterArrayScope()
        {
            this.scopeState.PushJsonArrayType();
        }

        public void AppendSpace()
        {
            this.outputBuilder.Append(Space);
        }

        public void ClearStrategies()
        {
            this.strategies.Clear();
        }

        public void AddCharacterStrategy(ICharacterStrategy strategy)
        {
            this.strategies[strategy.ForWhichCharacter] = strategy;
        }
    }
}
