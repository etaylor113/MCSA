using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MCSA
{
    class Program
    {
        static void Main(string[] args)
        {
            ParallelDotFor();
            ParallelDotForeach();
            ContinuationTasks();
            RunThreadPool();
            UnblockUI();
            AsyncAwait();
            ConcurrentCollections();
            ObjectLocking();
            CancellationToken();
        }

        /// <summary>
        /// Parallel.For Loop
        /// </summary>
        private static void ParallelDotFor()
        {
            List<int> listInts = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                listInts.Add(i);
            }

            Parallel.For(0, listInts.Count, i =>
            {
                Console.WriteLine(i.ToString());
            });

            Console.ReadLine();
        }

        /// <summary>
        /// Parallel.Foreach Loop
        /// </summary>
        private static void ParallelDotForeach()
        {
            List<int> listInts = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                listInts.Add(i);
            }

            Parallel.ForEach(listInts, (num) =>
            {
                Console.WriteLine(num.ToString());
            });

            Console.ReadLine();
        }

        /// <summary>
        /// Continuation Task
        /// </summary>
        private static async Task ContinuationTasks()
        {
            Task<DayOfWeek> taskA = Task.Run(() => DateTime.Today.DayOfWeek);

            await taskA.ContinueWith(antecedent => Console.WriteLine($"Today is {0}", antecedent.Result));
        }

        /// <summary>
        /// ThreadPool Class
        /// </summary>
        private static void RunThreadPool()
        {
            ThreadInfo threadInfo = new ThreadInfo
            {
                FileName = "file.txt",
                SelectedIndex = 3
            };

            ThreadPool.QueueUserWorkItem(new WaitCallback(DoStuff), threadInfo);
        }
        private static void DoStuff(object a)
        {
            // Doing Stuff...
        }

        /// <summary>
        /// A few ways to unblock the UI
        /// </summary>
        private static async void UnblockUI()
        {
            // First Way
            Task newTask = new Task(DoSomething);
            newTask.Start();

            // Second Way
            await Task.Run(() => DoSomething());

            // Use a background worker 
        }
        private static void DoSomething()
        {

        }

        /// <summary>
        /// Using Async and Await
        /// </summary>
        private static async void AsyncAwait()
        {
            int number = await Task.Run(() => DoSomethingAsync());
        }
        private static int DoSomethingAsync()
        {
            return 1;
        }

        /// <summary>
        /// Concurrent Collections
        /// </summary>
        private static void ConcurrentCollections()
        {
            // This collection can be accessed by multiple threads at the one time
            ConcurrentStack<int> stack = new ConcurrentStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            if (stack.IsEmpty)
                Console.WriteLine("Stack is empty.");
            else
                Console.WriteLine("Stack is not empty");
        }

        /// <summary>
        /// Manage Multithreading
        /// </summary>
        private ReaderWriterLock rwl = new ReaderWriterLock();
        private int myNumber;
        public int Number
        {
            get {
                rwl.AcquireReaderLock(Timeout.Infinite);
                rwl.ReleaseReaderLock();
                return myNumber;
            }
            set { myNumber = value; }
        }


        /// <summary>
        /// Locking an object
        /// </summary>
        static readonly object _object = new object();
        private static void ObjectLocking()
        {
            lock (_object)
            {
                // Do Stuff
            }
        }

        /// <summary>
        /// Cancel a long running task using a cancellation token
        /// </summary>
        CancellationTokenSource tokenSource = new CancellationTokenSource();
        CancellationToken token = new CancellationToken();

        private static void CancellationToken()
        {
            CancellationToken token = new CancellationToken();

            for (int i = 0; i < 100000; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("In iteration {0}, cancellation has been requested...",
                                      i + 1);
                    // Perform cleanup if necessary.
                    // Terminate the operation.
                    break;
                }
                // Simulate some work.
                Thread.SpinWait(500000);
            }
        }

        
    }
}
