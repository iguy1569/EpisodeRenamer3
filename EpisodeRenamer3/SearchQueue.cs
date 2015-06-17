using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EpisodeRenamer3
{
    class SearchQueue
    {
        private Queue<SearchObject> _buffer;

        private Thread _worker;

        private Form _parent;

        public SearchQueue(int searchQueueLimit, Form parent)
        {
            _parent = parent;
            _buffer = new Queue<SearchObject>();
            _worker = null;

            for (int i = 0; i < searchQueueLimit; i++)
            {
                _worker = new Thread(new ParameterizedThreadStart(ProcessSearch));
                _worker.IsBackground = true;
                _worker.Start(null);
            }
        }

        public void AddSearch(Func<object> operation, SearchObject.delVoidObj returnMethod)
        {
            lock (_buffer)
            {
                _buffer.Enqueue(new SearchObject(operation, returnMethod));
                Monitor.PulseAll(_buffer);
            }
        }

        private void ProcessSearch(object obj)
        {
            SearchObject search;
            do
            {
                lock (_buffer)
                {
                    while (_buffer.Count <= 0)
                        Monitor.Wait(_buffer);

                    search = _buffer.Dequeue();
                }
                object temp = search._operation();
                _parent.Invoke(search._returnMethod, temp);
                Thread.Sleep(500);
            }
            while (true);
        }
    }

    public class SearchObject
    {        
        public Func<object> _operation;
        public delegate void delVoidObj(object o);
        public delVoidObj _returnMethod;

        public SearchObject(Func<object> operation, delVoidObj dReturnMethod)
        {
            _operation = operation;
            _returnMethod = dReturnMethod;
        }
    }
}
