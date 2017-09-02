using System;
using System.Collections.Generic;
using System.Text;
using JsonFormatterPlus.Internals.Strategies;

namespace JsonFormatterPlus.Internals
{
    internal sealed class JsonFormatterStrategyContext
    {
        private const string Space = " ";
        private const int SpacesPerIndent = 4;

        private string _indent = String.Empty;

        private char _currentCharacter;
        private char _previousChar;

        private StringBuilder _outputBuilder;

        private readonly FormatterScopeState _scopeState = new FormatterScopeState();
        private readonly IDictionary<char, ICharacterStrategy> _strategies = new Dictionary<char, ICharacterStrategy>();

        public string Indent
        {
            get
            {
                if (_indent == String.Empty)
                {
                    InitializeIndent();
                }

                return _indent;
            }
        }

        public bool IsInArrayScope => _scopeState.IsTopTypeArray;

        public bool IsProcessingVariableAssignment { get; set; }

        public bool IsProcessingDoubleQuoteInitiatedString { get; set; }

        public bool IsProcessingSingleQuoteInitiatedString { get; set; }

        public bool IsProcessingString => IsProcessingDoubleQuoteInitiatedString
                                       || IsProcessingSingleQuoteInitiatedString;

        public bool IsStart => _outputBuilder.Length == 0;

        public bool WasLastCharacterABackSlash => _previousChar == '\\';

        private void InitializeIndent()
        {
            for (int i = 0; i < SpacesPerIndent; i++)
            {
                _indent += Space;
            }
        }

        private void AppendIndents(int indents)
        {
            for (int i = 0; i < indents; i++)
            {
                _outputBuilder.Append(Indent);
            }
        }
            
        public void PrettyPrintCharacter(char curChar, StringBuilder output)
        {
            _currentCharacter = curChar;

            ICharacterStrategy strategy = _strategies.ContainsKey(curChar)
                ? _strategies[curChar]
                : new DefaultCharacterStrategy();

            _outputBuilder = output;

            strategy.Execute(this);

            _previousChar = curChar;
        }

        public void AppendCurrentChar()
        {
            _outputBuilder.Append(_currentCharacter);
        }

        public void AppendNewLine()
        {
            _outputBuilder.Append(Environment.NewLine);
        }

        public void BuildContextIndents()
        {
            AppendNewLine();
            AppendIndents(_scopeState.ScopeDepth);
        }

        public void EnterObjectScope()
        {
            _scopeState.PushObjectContextOntoStack();
        }

        public void CloseCurrentScope()
        {
            _scopeState.PopJsonType();
        }

        public void EnterArrayScope()
        {
            _scopeState.PushJsonArrayType();
        }

        public void AppendSpace()
        {
            _outputBuilder.Append(Space);
        }

        public void ClearStrategies()
        {
            _strategies.Clear();
        }

        public void AddCharacterStrategy(ICharacterStrategy strategy)
        {
            _strategies[strategy.ForWhichCharacter] = strategy;
        }
    }
}
