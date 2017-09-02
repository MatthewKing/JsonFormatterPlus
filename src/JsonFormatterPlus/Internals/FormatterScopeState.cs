using System.Collections.Generic;

namespace JsonFormatterPlus.Internals
{
    internal sealed class FormatterScopeState
    {
        public enum JsonScope
        {
            Object,
            Array
        }

        private readonly Stack<JsonScope> _scopeStack = new Stack<JsonScope>();

        public bool IsTopTypeArray => _scopeStack.Count > 0 && _scopeStack.Peek() == JsonScope.Array;

        public int ScopeDepth => _scopeStack.Count;

        public void PushObjectContextOntoStack()
        {
            _scopeStack.Push(JsonScope.Object);
        }

        public JsonScope PopJsonType()
        {
            return _scopeStack.Pop();
        }

        public void PushJsonArrayType()
        {
            _scopeStack.Push(JsonScope.Array);
        }
    }
}
