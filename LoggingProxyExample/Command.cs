using System;

namespace LoggingProxyExample
{
    /// <summary>
    ///     Implementation of the <see cref="ICommand" /> interface.
    /// </summary>
    public class Command : ICommand
    {
        public Command(Action action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            Action = action;
        }

        /// <summary>
        ///     Gets the <see cref="Action" /> object.
        /// </summary>
        public Action Action { get; }

        /// <summary>
        ///     Invokes the <see cref="Action" /> object.
        /// </summary>
        public virtual void Execute() => Action.Invoke();
    }

    /// <summary>
    ///     Implementaiton of the <see cref="ICommand{T}" /> interface.
    /// </summary>
    /// <typeparam name="T">The type parameter taken by the <see cref="Action{T}" /> object.</typeparam>
    public class Command<T> : ICommand<T>
    {
        public Command(Action<T> action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            Action = action;
        }

        /// <summary>
        ///     Gets the <see cref="Action" /> object.
        /// </summary>
        public Action<T> Action { get; }

        /// <summary>
        ///     Invokes the <see cref="Action{T}" /> object.
        /// </summary>
        /// <param name="argument">The argument required for the <see cref="Action{T}" /> object.</param>
        public virtual void Execute(T argument) => Action.Invoke(argument);
    }
}