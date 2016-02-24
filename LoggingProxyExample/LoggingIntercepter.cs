using Castle.DynamicProxy;
using Common.Logging;
using Common.Logging.Simple;

namespace LoggingProxyExample
{
    /// <summary>
    ///     Base class for <see cref="IInterceptor" /> objects that log to the console.
    /// </summary>
    public abstract class LoggingIntercepter : IInterceptor
    {
        /// <summary>
        ///     The Logging instance.
        /// </summary>
        protected readonly ILog Log = LogManager.GetLogger(typeof (ConsoleOutLogger));

        /// <summary>
        ///     Abstract method defining the implementation of the intercepted method.
        /// </summary>
        /// <param name="invocation">The <see cref="IInvocation" /> passed to the interception.</param>
        public abstract void Intercept(IInvocation invocation);
    }
}