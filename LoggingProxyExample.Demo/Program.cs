namespace LoggingProxyExample.Demo
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var counter = new Counter(1);

            counter.Increment();

            counter.Decrement();

            counter.Adjust(2);
        }
    }
}