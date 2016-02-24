using Castle.DynamicProxy;
using Common.Logging;
using Common.Logging.Simple;

namespace LoggingProxyExample
{
    public abstract class LoggingIntercepter : IInterceptor
    {
        protected readonly ILog Log = LogManager.GetLogger(typeof (ConsoleOutLogger));

        public abstract void Intercept(IInvocation invocation);
    }
}