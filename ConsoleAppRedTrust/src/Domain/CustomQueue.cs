using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppRedTrust.Domain
{
    public class CustomQueue : ICustomQueue
    {
        #region Attributes
        private IList<string> _internalQueue;
        #endregion

        #region Events

        public event EventHandler OnItemEnqueued;

        #endregion

        #region Ctor

        public CustomQueue()
        {
            InitQueue();
        }

        #endregion

        #region Queue Management

        private void InitQueue()
        {
            _internalQueue = new List<string>();
        }

        private string GetLastElement()
            => Count() > 0 ? _internalQueue.LastOrDefault() : string.Empty;


        private void RemoveLastElement()
        {
            if (Count() > 0)
                _internalQueue.RemoveAt(Count() - 1);
        }

        private string GetAndRemoveLastElement()
        {
            var item = GetLastElement();
            RemoveLastElement();

            return item;
        }

        #endregion

        #region Signals

        private void SignalItemEnqueued()
        {
            if (Count() == 1)
                OnItemEnqueued?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        /// <summary>
        /// Get the number of items in the list 
        /// </summary>
        /// <returns>The number of items</returns>
        public int Count()
            => _internalQueue?.Count ?? 0;

        /// <summary>
        /// Add an item to the list
        /// </summary>
        public void Enqueue(string item)
        {
            _internalQueue.Add(item);

            SignalItemEnqueued();
        }

        /// <summary>
        /// Return and remove the last item of the list
        /// </summary>
        /// <returns>Last Item of the list</returns>
        public string Dequeue()
            => GetAndRemoveLastElement();
    }
}