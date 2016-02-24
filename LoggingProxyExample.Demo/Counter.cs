namespace LoggingProxyExample.Demo
{
    public class Counter
    {
        public int InternalValue { get; private set; }

        public Counter(int value)
        {
            InternalValue = value;
        }

        public void Increment()
        {
            CommandFactory.Instance(() => InternalValue = InternalValue + 1).Execute();
        }

        public void Decrement()
        {
            CommandFactory.Instance(() => InternalValue = InternalValue - 1).Execute();
        }

        public void Adjust(int value)
        {
            CommandFactory.Instance<int>((number) => InternalValue = InternalValue + number).Execute(value);
        }

        
    }
}