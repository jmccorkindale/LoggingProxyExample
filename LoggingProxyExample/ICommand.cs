using System;

namespace LoggingProxyExample
{
    /// <summary>
    ///     Represents a parameterless <see cref="Action" /> object with the means to execute it.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        ///     Gets the <see cref="Action" /> object.
        /// </summary>
        Action Action { get; }

        /// <summary>
        ///     Invokes the <see cref="Action" /> object.
        /// </summary>
        void Execute();
    }

    /// <summary>
    ///     Represents a <see cref="Action{T} " /> object with the means to exexute it.
    /// </summary>
    /// <typeparam name="T">The type of the <see cref="Action{T}" /> parameter.</typeparam>
    public interface ICommand<in T>
    {
        /// <summary>
        ///     Gets the <see cref="Action{T}" /> object.
        /// </summary>
        Action<T> Action { get; }

        /// <summary>
        ///     Invokes the <see cref="Action{T}" /> object.
        /// </summary>
        /// <param name="argument">The argument required for the <see cref="Action{T}" /> object.</param>
        void Execute(T argument);
    }
}