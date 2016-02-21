using System;
using Castle.DynamicProxy;
using Common.Logging;
using Common.Logging.Simple;

namespace LoggingProxyExample
{
    public class CommandInterceptor : IInterceptor
    {
        private readonly Action _commandAction;
        private readonly ILog _log = LogManager.GetLogger(typeof (ConsoleOutLogger));

        public CommandInterceptor(Action action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            _commandAction = action;
        }

        public void Intercept(IInvocation invocation)
        {
            if (invocation.Method.Name.Equals("Execute"))
            {
                var methodInfo = _commandAction.Method;

                _log.Trace($"Command executing : {methodInfo.DeclaringType?.FullName + methodInfo.Name}");

                invocation.Proceed();
            }
        }
    }
}