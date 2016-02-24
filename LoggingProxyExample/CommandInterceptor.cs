using System;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;

namespace LoggingProxyExample
{
    public class CommandInterceptor : LoggingIntercepter
    {
        private readonly Delegate _delegate;

        public CommandInterceptor(Delegate @delegate)
        {
            if (@delegate == null) throw new ArgumentNullException(nameof(@delegate));

            _delegate = @delegate;
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

        public override void Intercept(IInvocation invocation)
        {
            Log.Trace(BuildLogMessage(_delegate, invocation));

            invocation.Proceed();
        }
    }
}