namespace Lab10_University
{
    public class Program
    {
        static void Main(string[] args)
        {
            EventThrottler eventThrottler = new EventThrottler();

            EventHandler handler1 = (sender, e) =>
            {
                Console.WriteLine($"Handler 1 triggered at {DateTime.Now}");
            };

            EventHandler handler2 = (sender, e) =>
            {
                Console.WriteLine($"Handler 2 triggered at {DateTime.Now}");
            };

            eventThrottler.RegisterEventHandler("event1", handler1);
            eventThrottler.RegisterEventHandler("event1", handler2);

            for (int i = 0; i < 10; i++)
            {
                eventThrottler.TriggerEvent("event1", EventArgs.Empty, 1000);
                Thread.Sleep(500);
            }

            eventThrottler.UnregisterEventHandler("event1", handler2);

            for (int i = 0; i < 10; i++)
            {
                eventThrottler.TriggerEvent("event1", EventArgs.Empty, 1000);
                Thread.Sleep(500);
            }

            Console.ReadKey();
        }
    }
}