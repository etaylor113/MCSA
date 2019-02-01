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
            Mutex();
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////
        //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\


        // Parallel.For

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


        ////////////////////////////////////////////////////////////////////////////////////////////////
        //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\


        // Parallel.Foreach Loop

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


        ////////////////////////////////////////////////////////////////////////////////////////////////
        //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\



        // Continuation Task

        private static async Task ContinuationTasks()
        {
            Task<DayOfWeek> taskA = Task.Run(() => DateTime.Today.DayOfWeek);

            await taskA.ContinueWith(antecedent => Console.WriteLine($"Today is {0}", antecedent.Result));
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////
        //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\



        // ThreadPool Class

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


        ////////////////////////////////////////////////////////////////////////////////////////////////
        //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\


        // A few ways to unblock the UI

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


        ////////////////////////////////////////////////////////////////////////////////////////////////
        //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\


        // Using Async and Await

        private static async void AsyncAwait()
        {
            int number = await Task.Run(() => DoSomethingAsync());
        }
        private static int DoSomethingAsync()
        {
            return 1;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////
        //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\


        // Concurrent Collections

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


        ////////////////////////////////////////////////////////////////////////////////////////////////
        //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\


        // Manage Multithreading

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


        ////////////////////////////////////////////////////////////////////////////////////////////////
        //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\


        // Locking an object

        static readonly object _object = new object();
        private static void ObjectLocking()
        {
            lock (_object)
            {
                // Do Stuff
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////
        //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\


        // Cancel a long running task using a cancellation token

        CancellationTokenSource tokenSource = new CancellationTokenSource();
        CancellationToken token = new CancellationToken();

        private static void CancellationToken()
        {
            CancellationToken token = new CancellationToken();

            for (int i = 0; i < 100000; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("In iteration {0}, cancellation has been requested...", i + 1);
                    // Perform cleanup if necessary.
                    // Terminate the operation.
                    break;
                }
                // Simulate some work.
                Thread.SpinWait(500000);
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////
        //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\


        // Mutex Example

        // NOTE: A mutex locks a resource so that multiple threads cannot access it at the same time

        private static Mutex mutex = new Mutex();
        private const int numIterations = 1;
        private const int numThreads = 3;

        private static void Mutex()
        {
            // Create the threads that will use the protected resource.
            for (int i = 0; i < numThreads; i++)
            {
                Thread newThread = new Thread(new ThreadStart(ThreadProc))
                {
                    Name = String.Format("Thread{0}", i + 1)
                };
                newThread.Start();
            }

            // The main thread exits, but the application continues to
            // run until all foreground threads have exited.

        }

        private static void ThreadProc()
        {
            for (int i = 0; i < numIterations; i++)
            {
                UseResource();
            }
        }

        // This method represents a resource that must be synchronized
        // so that only one thread at a time can enter.
        private static void UseResource()
        {
            // Wait until it is safe to enter.
            Console.WriteLine("{0} is requesting the mutex", Thread.CurrentThread.Name);
            mutex.WaitOne();

            Console.WriteLine("{0} has entered the protected area", Thread.CurrentThread.Name);

            // Place code to access non-reentrant resources here.

            // Simulate some work.
            Thread.Sleep(500);

            Console.WriteLine("{0} is leaving the protected area",
                Thread.CurrentThread.Name);

            // Release the Mutex.
            mutex.ReleaseMutex();
            Console.WriteLine("{0} has released the mutex",
                Thread.CurrentThread.Name);
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////
        //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        
        // Semaphore Example

        // NOTE: Limits the number of threads that can access a resource or pool of resources concurrently

        // A semaphore that simulates a limited resource pool.
        private static Semaphore _pool;

        // A padding interval to make the output more orderly.
        private static int _padding;

        public static void Main()
        {
            // Create a semaphore that can satisfy up to three concurrent requests. Use an initial 
            // count of zero, so that the entire semaphore count is initially owned by the main
            // program thread.
            _pool = new Semaphore(0, 3);

            // Create and start five numbered threads. 
            //
            for (int i = 1; i <= 5; i++)
            {
                Thread t = new Thread(new ParameterizedThreadStart(Worker));

                // Start the thread, passing the number.
                t.Start(i);
            }

            // Wait for half a second, to allow all the threads to start and to block on the semaphore.
            Thread.Sleep(500);

            // The main thread starts out holding the entire semaphore count. Calling Release(3) brings the 
            // semaphore count back to its maximum value, and allows the waiting threads to enter the semaphore,
            // up to three at a time.
            Console.WriteLine("Main thread calls Release(3).");
            _pool.Release(3);

            Console.WriteLine("Main thread exits.");
        }

        private static void Worker(object num)
        {
            // Each worker thread begins by requesting the semaphore.
            Console.WriteLine("Thread {0} begins " +
                "and waits for the semaphore.", num);
            _pool.WaitOne();

            // A padding interval to make the output more orderly.
            int padding = Interlocked.Add(ref _padding, 100);

            Console.WriteLine("Thread {0} enters the semaphore.", num);

            // The thread's "work" consists of sleeping for about a second. Each thread "works" a little 
            // longer, just to make the output more orderly.
            Thread.Sleep(1000 + padding);

            Console.WriteLine("Thread {0} releases the semaphore.", num);
            Console.WriteLine("Thread {0} previous semaphore count: {1}", num, _pool.Release());
        }





        ////////////////////////////////////////////////////////////////////////////////////////////////
        //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\




        ////////////////////////////////////////////////////////////////////////////////////////////////
        //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\




        ////////////////////////////////////////////////////////////////////////////////////////////////
        //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\




        ////////////////////////////////////////////////////////////////////////////////////////////////
        //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\




        ////////////////////////////////////////////////////////////////////////////////////////////////
        //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\




        ////////////////////////////////////////////////////////////////////////////////////////////////
        //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\




        ////////////////////////////////////////////////////////////////////////////////////////////////
        //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\




        ////////////////////////////////////////////////////////////////////////////////////////////////
        //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\




        ////////////////////////////////////////////////////////////////////////////////////////////////
        //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    }
}
