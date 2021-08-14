using System;

namespace HadronLib.Patterns
{
    public abstract class FluentBuilder<TSubject, TSelf>
        where TSelf : FluentBuilder<TSubject, TSelf>
    {
        private readonly TSubject _subject = Activator.CreateInstance<TSubject>();

        protected TSubject Subject
        {
            get => _subject;
        }
        
        public TSubject Build()
        {
            return _subject;
        }
        
        public static implicit operator TSubject(FluentBuilder<TSubject, TSelf> builder)
        {
            return builder._subject;
        }
    }
}