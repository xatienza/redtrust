using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppRedTrust.Domain
{
    public class CustomQueue
    {
        #region Attributes
        private IList<string> _internalQueue;
        #endregion
        
        
        #region Ctor
        public CustomQueue()
        {
            initQueue();
        }
        #endregion

        private void initQueue()
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

        protected string GetAndRemoveLastElement()
        {
            var item = GetLastElement();
            RemoveLastElement();

            return item;
        }

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
            => _internalQueue.Add(item);
        
        /// <summary>
        /// Return and remove the last item of the list
        /// </summary>
        /// <returns>Last Item of the list</returns>
        public string Dequeue()
            => GetAndRemoveLastElement();

    }
}