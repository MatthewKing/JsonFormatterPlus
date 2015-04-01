namespace JsonFormatterPlus.Internals
{
    using System.Collections.Generic;

    internal sealed class FormatterScopeState
    {
        public enum JsonScope
        {
            Object,
            Array
        }

        private readonly Stack<JsonScope> scopeStack = new Stack<JsonScope>();

        public bool IsTopTypeArray
        {
            get
            {
                return scopeStack.Count > 0 
                    && scopeStack.Peek() == JsonScope.Array;
            }
        }

        public int ScopeDepth
        {
            get
            {
                return scopeStack.Count;
            }
        }

        public void PushObjectContextOntoStack()
        {
            scopeStack.Push(JsonScope.Object);
        }

        public JsonScope PopJsonType()
        {
            return scopeStack.Pop();
        }

        public void PushJsonArrayType()
        {
            scopeStack.Push(JsonScope.Array);
        }
    }
}
