using System;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;

namespace LoggingProxyExample
{
    /// <summary>
    ///     Intercepts the <see cref="ICommand" /> or <see cref="ICommand{T}" /> object and inserts Logging functionality.
    /// </summary>
    /// <remarks>
    ///     Key class that uses Dynamic Proxy which allows the separation of the specific class logic from cross-cutting
    ///     business requirements.
    /// </remarks>
    public class CommandInterceptor : LoggingIntercepter
    {
        private readonly Delegate _delegate;

        public CommandInterceptor(Delegate @delegate)
        {
            if (@delegate == null) throw new ArgumentNullException(nameof(@delegate));

            _delegate = @delegate;
        }

        /// <summary>
        ///     Implementation of the Intercept method.
        /// </summary>
        /// <param name="invocation">The <see cref="IInvocation" /> method to be passed.</param>
        public override void Intercept(IInvocation invocation)
        {
            Log.Trace(BuildLogMessage(_delegate, invocation));

            invocation.Proceed();
        }

        private string BuildLogMessage(Delegate @delegate, IInvocation invocation)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append($"Command executing : {@delegate.Target} {@delegate.Method.Name}");

            if (invocation.Arguments.Any())
            {
                stringBuilder.Append(
                    $" | arguments : count {invocation.Arguments.Length} : values {string.Join(", ", invocation.Arguments)}");
            }

            return stringBuilder.ToString();
        }
    }
}