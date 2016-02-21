namespace LoggingProxyExample.Demo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var counter = new Counter(1);

            counter.Increment();

            counter.Decrement();
        }
    }
}