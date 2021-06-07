using System;
using System.Threading;

namespace ConsoleAppRedTrust.Service
{
    using Domain;
    
    public class ConsumerService: IConsumerService
    {
        #region Const
        private const string Thread1Name = "th1";
        private const string Thread2Name = "th2";
        private const string MessageFormat = "HH:mm:ss.fff";
        private const int RandomElapsedTime = 25;
        private const int EnqueueElapsedTime = 200;
        #endregion
        
        #region Attributes
        private readonly CustomQueue _queue;
        private readonly QueueConsumer _consumer;
        private readonly Thread _thr1;
        private readonly Thread _thr2;
        #endregion

        #region Ctor
        public ConsumerService()
        {
            _queue = new CustomQueue();
            _consumer = new QueueConsumer(_queue);
            _thr1 = new Thread(_consumer.Consume);
            _thr2 = new Thread(_consumer.Consume);

            InitServiceThreads();
        }
        #endregion
        
        private void InitServiceThreads()
        {
            _thr1.Name = Thread1Name;
            _thr1.Start();
            
            _thr2.Name = Thread2Name;
            _thr2.Start();
        }
        
        private void RandomEnqueuedMessages()
        {
            var num = new Random().Next(1,8);

            for (var i = 0; i < num; i++)
            {
                _queue.Enqueue(DateTime.Now.ToString(MessageFormat));
                Thread.Sleep(RandomElapsedTime);
            }
            
            Thread.Sleep((num * EnqueueElapsedTime));
        }
        
        private void Stop()
        {
            _consumer.Stop();
        }
        
        public void Start()
        {
            do {
                while (! Console.KeyAvailable)
                {
                    RandomEnqueuedMessages();
                }       
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            
            Stop();
        }
    }
}