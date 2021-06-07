using System.Drawing;
using Console = Colorful.Console;

namespace ConsoleAppRedTrust
{
    using Domain;
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteAscii("Redtrust Test", Color.FromArgb(155, 0, 0));
            
            var queue = new CustomQueue();
            
            queue.Enqueue("First");
            queue.Enqueue("Second");
            queue.Enqueue("Third");
            queue.Enqueue("Fourth");
            
            Console.WriteLine($"Number of enqueued elements: {queue.Count()}");

            var item = queue.Dequeue();
            Console.WriteLine($"Dequeued element: {item}");
            Console.WriteLine($"Number of enqueued elements: {queue.Count()}");
            
             item = queue.Dequeue();
            Console.WriteLine($"Dequeued element: {item}");
            Console.WriteLine($"Number of enqueued elements: {queue.Count()}");
            
            item = queue.Dequeue();
            Console.WriteLine($"Dequeued element: {item}");
            Console.WriteLine($"Number of enqueued elements: {queue.Count()}");
            
            item = queue.Dequeue();
            Console.WriteLine($"Dequeued element: {item}");
            Console.WriteLine($"Number of enqueued elements: {queue.Count()}");
            

            Console.ReadLine();
        }
    }
}