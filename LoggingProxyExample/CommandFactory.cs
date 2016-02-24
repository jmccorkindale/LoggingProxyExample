﻿using System;
using Castle.DynamicProxy;

namespace LoggingProxyExample
{
    /// <summary>
    ///     Factory to generate <see cref="Command" /> and <see cref="Command{T}" /> objects.
    /// </summary>
    public static class CommandFactory
    {
        private static readonly ProxyGenerator Generator = new ProxyGenerator();

        /// <summary>
        ///     Generates a new instance of the <see cref="Command" /> class.
        /// </summary>
        /// <param name="action">The <see cref="Action" /> constructor argument for the <see cref="Command" /> object.</param>
        /// <returns>An <see cref="ICommand" /> proxy.</returns>
        public static ICommand Instance(Action action)
            => CreateCommandProxy(typeof (Command), action) as ICommand;

        /// <summary>
        ///     Generates a new instance of the <see cref="Command{T}" /> class.
        /// </summary>
        /// <typeparam name="T">The type of the parameter taken by the <see cref="Command{T}" /> object constructor.</typeparam>
        /// <param name="action">The <see cref="Action{T}" /> object required by the <see cref="Command{T}" /> constructor.</param>
        /// <returns>An <see cref="ICommand{T}" /> proxy.</returns>
        public static ICommand<T> Instance<T>(Action<T> action)
            => CreateCommandProxy(typeof (Command<T>), action) as ICommand<T>;

        private static object CreateCommandProxy(Type commandType, Delegate @delegate)
            => Generator.CreateClassProxy(commandType, new object[] {@delegate}, new CommandInterceptor(@delegate));
    }
}