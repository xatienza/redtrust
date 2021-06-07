using Console = Colorful.Console;
using System;
using System.Threading;

namespace ConsoleAppRedTrust.Domain
{
    public class QueueConsumer
    {
        #region Const
        private const int QueueElapsedTime = 250;
        #endregion
        
        #region Attributes
        private static string ThreadName => Thread.CurrentThread.Name;
        private readonly CustomQueue _observableQueue;
        private bool _processQueue;
        private volatile bool _stopRequested = false;
        #endregion

        #region Ctor
        public QueueConsumer(CustomQueue queue)
        {
            _observableQueue = queue;
            _observableQueue.OnItemEnqueued += ObservableQueueOnOnItemEnqueued; 
        }
        #endregion

        private void ObservableQueueOnOnItemEnqueued(object sender, EventArgs e)
        {
            Console.WriteLine($"[INF] :: OnItemEnqueued event catched!");
            _processQueue = true;
        }

        private void StopQueueManagement()
            => _processQueue = false;

        private void CheckQueueManagement()
        {
            if (_observableQueue.Count() == 0)
                StopQueueManagement();
        }

        private void ProcessQueue()
        {
            var item = _observableQueue.Dequeue();
            Console.WriteLine($"[Thr: {ThreadName}] ::  Dequeued item -> {item}");

            CheckQueueManagement();
        }

        public void Stop()
            => _stopRequested = true;
        
        public void Consume()
        {
            while(true)
            {
                lock (this)
                {
                    if (_processQueue)
                    {
                        ProcessQueue();
                    }
                }
                
                if (_stopRequested)
                    break;

                Thread.Sleep(QueueElapsedTime);
            }
        }
    }
}