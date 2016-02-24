using System;
using Castle.DynamicProxy;

namespace LoggingProxyExample
{
    public static class CommandFactory
    {
        private static readonly ProxyGenerator Generator = new ProxyGenerator();

        public static ICommand Instance(Action action)
            => CreateCommandProxy(typeof (Command), action) as ICommand;

        public static ICommand<T> Instance<T>(Action<T> action)
            => CreateCommandProxy(typeof (Command<T>), action) as ICommand<T>;

        private static object CreateCommandProxy(Type commandType, Delegate @delegate)
            => Generator.CreateClassProxy(commandType, new object[] {@delegate}, new CommandInterceptor(@delegate));
    }
}