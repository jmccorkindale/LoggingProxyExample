using System;

namespace LoggingProxyExample
{
    public class Command : ICommand
    {
        private readonly Action _commandAction;

        public Command(Action action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            _commandAction = action;
        }

        public virtual void Execute() => _commandAction.Invoke();
    }

    public class Command<T> : ICommand<T>
    {
        private readonly Action<T> _commandAction;

        public Command(Action<T> action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            _commandAction = action;
        }

        public virtual void Execute(T arg) => _commandAction.Invoke(arg);
    }
}