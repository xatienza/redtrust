namespace ConsoleAppRedTrust.Domain
{
    public interface ICustomQueue
    {
        int Count();
        void Enqueue(string item);
        string Dequeue();
    }
}