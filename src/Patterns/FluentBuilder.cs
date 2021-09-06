using System;

namespace HadronLib.Patterns
{
    /// <summary>
    /// Abstract class implementing the fluent builder design pattern
    /// </summary>
    /// <typeparam name="TSubject">The class that's being built</typeparam>
    /// <typeparam name="TSelf">The class that implements the design pattern</typeparam>
    public abstract class FluentBuilder<TSubject, TSelf>
        where TSelf : FluentBuilder<TSubject, TSelf>
    {
        private TSubject _subject = Activator.CreateInstance<TSubject>();

        protected TSubject Subject
        {
            get => _subject;
            set => _subject = value;
        }
        
        public virtual TSubject Build()
        {
            return _subject;
        }
        
        public static implicit operator TSubject(FluentBuilder<TSubject, TSelf> builder)
        {
            return builder._subject;
        }
    }
}