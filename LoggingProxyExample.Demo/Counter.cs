namespace LoggingProxyExample.Demo
{
    public class Counter
    {
        private int _internalValue;

        public Counter(int value)
        {
            _internalValue = value;
        }

        public void Increment()
        {
            CommandFactory.Instance(() => _internalValue = _internalValue + 1).Execute();
        }

        public void Decrement()
        {
            CommandFactory.Instance(() => _internalValue = _internalValue - 1).Execute();
        }
    }
}