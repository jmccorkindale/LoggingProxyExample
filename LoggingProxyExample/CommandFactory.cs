using System;
using Castle.DynamicProxy;

namespace LoggingProxyExample
{
    public static class CommandFactory
    {
        private static readonly ProxyGenerator Generator = new ProxyGenerator();

        public static ICommand Instance(Action action)
            => (ICommand) Generator.CreateClassProxy(typeof (Command), new object[] {action}, new CommandInterceptor(action));
    }
}