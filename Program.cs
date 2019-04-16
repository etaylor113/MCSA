using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Prep
{
    class Program
    {
        static void Main(string[] args)
        {

            // Is Narcissistic Number
            //bool isNarc1 = Narcissistic(153);
            //bool isNarc2 = Narcissistic(10);
            //bool isNarc3 = Narcissistic(1123);

            // Song Decoder
            //string decoded1 = SongDecoder("WUBWUBABCWUB");
            //string decoded2 = SongDecoder("RWUBWUBWUBLWUB");
            //string decoded3 = SongDecoder("WUBRWUBWUBWUBWUBWUBWUBLWUBWUB");

            // XO 
            //bool isTrue1 = XO("ooxx");
            //bool isTrue2 = XO("xooxx");
            //bool isTrue3 = XO("ooxXm");
            //bool isTrue4 = XO("zpzpzpp");
            //bool isTrue5 = XO("zzoo");

            // Maskify
            //string maskedCardNum1 = Maskify("0123456789");
            //string maskedCardNum2 = Maskify("1");
            //string maskedCardNum3 = Maskify("11111");

            // *** To Lower Case
            //string nameLowerCased = ToLowerCase("EVAN");

            // *** Jewels and Stones problem
            //int total = JewelsAndStones("aA", "aAAbbbb");

            // *** IsPalindrome problem
            //bool pallyOne = IsPalindrome(112211);
            //bool pallyTwo = IsPalindrome(112212);
            //bool pallyThree = IsPalindrome(11211);

            // *** Reverse Int problem
            //int reversedInt = ReverseInteger(-320);

            // *** Two Sum problem
            //int[] nums = new int[4] { 2, 7, 11, 15 };
            //int target = 18;
            //int[] incices = TwoSum(nums, target);

            // Higher level C# methods
            //ParallelDotFor();
            //ParallelDotForeach();
            //ContinuationTasks();
            //RunThreadPool();
            //UnblockUI();
            //AsyncAwait();
            //ConcurrentCollections();
            //ObjectLocking();
            //CancellationToken();
            //Mutex();
            //Semaphore();
            //EventWaitHandle();
            //ManualResetEvent();
            //AutoResetEvent();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\



        public static bool Narcissistic(int value)
        {
            int[] values = Array.ConvertAll(value.ToString().ToArray(), x => (int)x - 48);

            int total = 0;
            foreach (int v in values)
                total += (int)Math.Pow(v, values.Length);

            return total == value ? true : false;
        }

        public static int[] Divisors(int n)
        {
            int[] retArray = { };

            // Check if number is prime
            if (n <= 1)
                return null;

            if (n <= 1) return null;
            if (n % 2 == 0) return null;

            var boundary = (int)Math.Floor(Math.Sqrt(n));

            for (int i = 3; i <= boundary; i += 2)
                if (n % i == 0)
                    return null;

            // Find divisors
            int ct = 0;
            while (ct > 100)
            {
                if (ct >= n)
                    return retArray;
                else
                {

                }

            }

            return retArray;
        }

        public static string SongDecoder(string input)
        {
            input = input.Replace("WUB", " ").Trim();
            char temp = ' ';
            string tempinput = input;
            for (int i = 0; i < input.Length; i++)
            {
                if (temp == input[i])
                    tempinput = input.Remove(i, 2);
                temp = input[i];
            }

            return tempinput;
        }


        public static bool XO(string input)
        {
            return input.ToCharArray().Where(x => x.ToString().ToLower() == "x").Count() == input.ToCharArray().Where(x => x.ToString().ToLower() == "o").Count();
        }

        public static string Maskify(string cc)
        {
            char[] chars = cc.ToCharArray();

            if (chars.Length <= 4)
                return cc;

            for (int i = chars.Length; i > 0; i--)
            {
                if (i < chars.Length - 3)
                    chars[i-1] = '#';
            }

            return new string(chars);
        }


        public static string ToLowerCase(string str)
        {
            return str.ToLower();
        }


        public static int JewelsAndStones(string J, string S)
        {
            // J = aA
            // S = aAAbbbb

            List<char> jewelTypes = new List<char>();
            jewelTypes.AddRange(J.ToCharArray());

            List<char> stones = new List<char>();
            stones.AddRange(S.ToCharArray());

            int jewelCt = 0;

            foreach (char letter in S)
            {
                if (jewelTypes.Contains(letter))
                {
                    jewelCt++;
                    stones.RemoveAll(x => x == letter);
                }
            }

            return jewelCt;

        }


        public static bool IsPalindrome(int x)
        {
            List<char> charList = new List<char>();
            charList.AddRange(x.ToString().ToCharArray());

            string firstHalf = "";
            string secondHalf = "";

            if (charList.Count % 2 != 0)
            {
                int midIdx = (int)(charList.Count/2);         
                charList.RemoveAt(midIdx);
            }

            firstHalf = string.Concat(charList.GetRange(0, charList.Count/2));

            int index = (charList.Count / 2);
            int length = (charList.Count / 2);
            var f = charList.GetRange(index, length);
            f.Reverse();
            secondHalf = string.Concat(f);

            if (secondHalf == firstHalf)
                return true;
            else
                return false;
        }


        static int ReverseInteger(int x)
        {
            int rem = 0;
            int r = 0;

            while (x != 0)
            {
                rem = x % 10;

                if (x > 0 && r > int.MaxValue / 10) return 0;
                if (x < 0 && r < int.MinValue / 10) return 0;

                r = r * 10;

                if (x < 0 && rem < (int.MinValue - r)) return 0;
                if (x > 0 && rem > (int.MaxValue - r)) return 0;

                r = r + rem;
                x = x / 10;
            }
            return r;
        }


        static int[] TwoSum(int[] nums, int target)
        {
            for (int o = 0; o < nums.Length; o++)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (o == i)
                        continue;
                    else if (nums[o] + nums[i] == target)
                        return new int[2] { o, i };
                }
            }
            return null;
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

        public static void Semaphore()
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
            Console.WriteLine("Thread {0} begins and waits for the semaphore.", num);
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

        // EventWaitHandle Example

        // The EventWaitHandle used to demonstrate the difference
        // between AutoReset and ManualReset synchronization events.
        //
        private static EventWaitHandle ewh;

        // A counter to make sure all threads are started and
        // blocked before any are released. A Long is used to show
        // the use of the 64-bit Interlocked methods.
        //
        private static long threadCount = 0;

        // An AutoReset event that allows the main thread to block
        // until an exiting thread has decremented the count.
        //
        private static EventWaitHandle clearCount =
            new EventWaitHandle(false, EventResetMode.AutoReset);

        [MTAThread]
        public static void EventWaitHandle()
        {
            // Create an AutoReset EventWaitHandle.
            //
            ewh = new EventWaitHandle(false, EventResetMode.AutoReset);

            // Create and start five numbered threads. Use the
            // ParameterizedThreadStart delegate, so the thread
            // number can be passed as an argument to the Start 
            // method.
            for (int i = 0; i <= 4; i++)
            {
                Thread t = new Thread(
                    new ParameterizedThreadStart(ThreadProc)
                );
                t.Start(i);
            }

            // Wait until all the threads have started and blocked.
            // When multiple threads use a 64-bit value on a 32-bit
            // system, you must access the value through the
            // Interlocked class to guarantee thread safety.
            //
            while (Interlocked.Read(ref threadCount) < 5)
            {
                Thread.Sleep(500);
            }

            // Release one thread each time the user presses ENTER,
            // until all threads have been released.
            //
            while (Interlocked.Read(ref threadCount) > 0)
            {
                Console.WriteLine("Press ENTER to release a waiting thread.");
                Console.ReadLine();

                // SignalAndWait signals the EventWaitHandle, which
                // releases exactly one thread before resetting, 
                // because it was created with AutoReset mode. 
                // SignalAndWait then blocks on clearCount, to 
                // allow the signaled thread to decrement the count
                // before looping again.
                //
                WaitHandle.SignalAndWait(ewh, clearCount);
            }
            Console.WriteLine();

            // Create a ManualReset EventWaitHandle.
            //
            ewh = new EventWaitHandle(false, EventResetMode.ManualReset);

            // Create and start five more numbered threads.
            //
            for (int i = 0; i <= 4; i++)
            {
                Thread t = new Thread(
                    new ParameterizedThreadStart(ThreadProc)
                );
                t.Start(i);
            }

            // Wait until all the threads have started and blocked.
            //
            while (Interlocked.Read(ref threadCount) < 5)
            {
                Thread.Sleep(500);
            }

            // Because the EventWaitHandle was created with
            // ManualReset mode, signaling it releases all the
            // waiting threads.
            //
            Console.WriteLine("Press ENTER to release the waiting threads.");
            Console.ReadLine();
            ewh.Set();

        }

        public static void ThreadProc(object data)
        {
            int index = (int)data;

            Console.WriteLine("Thread {0} blocks.", data);
            // Increment the count of blocked threads.
            Interlocked.Increment(ref threadCount);

            // Wait on the EventWaitHandle.
            ewh.WaitOne();

            Console.WriteLine("Thread {0} exits.", data);
            // Decrement the count of blocked threads.
            Interlocked.Decrement(ref threadCount);

            // After signaling ewh, the main thread blocks on
            // clearCount until the signaled thread has 
            // decremented the count. Signal it now.
            //
            clearCount.Set();
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////
        //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\


        // Auto Reset Event

        private static AutoResetEvent event_1 = new AutoResetEvent(true);
        private static AutoResetEvent event_2 = new AutoResetEvent(false);

        static void AutoResetEvent()
        {
            Console.WriteLine("Press Enter to create three threads and start them.\r\n" +
                              "The threads wait on AutoResetEvent #1, which was created\r\n" +
                              "in the signaled state, so the first thread is released.\r\n" +
                              "This puts AutoResetEvent #1 into the unsignaled state.");
            Console.ReadLine();

            for (int i = 1; i < 4; i++)
            {
                Thread t = new Thread((ParameterizedThreadStart)ThreadProc);
                t.Name = "Thread_" + i;
                t.Start();
            }
            Thread.Sleep(250);

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Press Enter to release another thread.");
                Console.ReadLine();
                event_1.Set();
                Thread.Sleep(250);
            }

            Console.WriteLine("\r\nAll threads are now waiting on AutoResetEvent #2.");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Press Enter to release a thread.");
                Console.ReadLine();
                event_2.Set();
                Thread.Sleep(250);
            }

            Console.ReadLine();
        }

        static void ThreadProcTwo()
        {
            string name = Thread.CurrentThread.Name;

            Console.WriteLine("{0} waits on AutoResetEvent #1.", name);
            event_1.WaitOne();
            Console.WriteLine("{0} is released from AutoResetEvent #1.", name);

            Console.WriteLine("{0} waits on AutoResetEvent #2.", name);
            event_2.WaitOne();
            Console.WriteLine("{0} is released from AutoResetEvent #2.", name);

            Console.WriteLine("{0} ends.", name);
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////
        //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\


        // Manual Reset Event

        // mre is used to block and release threads manually. It is
        // created in the unsignaled state.
        private static ManualResetEvent mre = new ManualResetEvent(false);

        static void ManualResetEvent()
        {
            Console.WriteLine("\nStart 3 named threads that block on a ManualResetEvent:\n");

            for (int i = 0; i <= 2; i++)
            {
                Thread t = new Thread(ThreadProcThree);
                t.Name = "Thread_" + i;
                t.Start();
            }

            Thread.Sleep(500);
            Console.WriteLine("\nWhen all three threads have started, press Enter to call Set()" +
                              "\nto release all the threads.\n");
            Console.ReadLine();

            mre.Set();

            Thread.Sleep(500);
            Console.WriteLine("\nWhen a ManualResetEvent is signaled, threads that call WaitOne()" +
                              "\ndo not block. Press Enter to show this.\n");
            Console.ReadLine();

            for (int i = 3; i <= 4; i++)
            {
                Thread t = new Thread(ThreadProcThree);
                t.Name = "Thread_" + i;
                t.Start();
            }

            Thread.Sleep(500);
            Console.WriteLine("\nPress Enter to call Reset(), so that threads once again block" +
                              "\nwhen they call WaitOne().\n");
            Console.ReadLine();

            mre.Reset();

            // Start a thread that waits on the ManualResetEvent.
            Thread t5 = new Thread(ThreadProcThree);
            t5.Name = "Thread_5";
            t5.Start();

            Thread.Sleep(500);
            Console.WriteLine("\nPress Enter to call Set() and conclude the demo.");
            Console.ReadLine();

            mre.Set();

            // If you run this example in Visual Studio, uncomment the following line:
            //Console.ReadLine();
        }


        private static void ThreadProcThree()
        {
            string name = Thread.CurrentThread.Name;

            Console.WriteLine(name + " starts and calls mre.WaitOne()");

            mre.WaitOne();

            Console.WriteLine(name + " ends.");
        }
    }

        /* This example produces output similar to the following:

            Start 3 named threads that block on a ManualResetEvent:

            Thread_0 starts and calls mre.WaitOne()
            Thread_1 starts and calls mre.WaitOne()
            Thread_2 starts and calls mre.WaitOne()

            When all three threads have started, press Enter to call Set()
            to release all the threads.


            Thread_2 ends.
            Thread_0 ends.
            Thread_1 ends.

            When a ManualResetEvent is signaled, threads that call WaitOne()
            do not block. Press Enter to show this.


            Thread_3 starts and calls mre.WaitOne()
            Thread_3 ends.
            Thread_4 starts and calls mre.WaitOne()
            Thread_4 ends.

            Press Enter to call Reset(), so that threads once again block
            when they call WaitOne().


            Thread_5 starts and calls mre.WaitOne()

            Press Enter to call Set() and conclude the demo.

        Thread_5 ends.
         */


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
