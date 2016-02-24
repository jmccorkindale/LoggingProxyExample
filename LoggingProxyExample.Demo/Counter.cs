namespace LoggingProxyExample.Demo
{
    public class Counter
    {
        public Counter(int value)
        {
            Value = value;
        }

        public int Value { get; private set; }

        public void Increment()
        {
            CommandFactory.Instance(() => Value = Value + 1).Execute();
        }

        public void Decrement()
        {
            CommandFactory.Instance(() => Value = Value - 1).Execute();
        }

        public void Adjust(int value)
        {
            CommandFactory.Instance<int>((number) => Value = Value + number).Execute(value);
        }
    }
}