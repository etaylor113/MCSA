﻿using Prep.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Prep.NullPractice;

namespace Prep
{
    public enum WorkType
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }

    class Program
    {
        static void Main(string[] args)
        {

            // *****************************************************************
            // Null 
                NullTest.Start();
            // *****************************************************************


            // *****************************************************************
            // Interfaces
                InterfacePractice.Start();
            // *****************************************************************


            // *****************************************************************
            // Delegates and Events
                //Mediator.GetInstance().OnJobChanged(new object(), new Job() { Title = "Software Developer" });
                //Mediator.GetInstance().JobChanged += (s, e) => BindData(e.Job);

                //var data = new ProcessData();

                //BizRulesDelegate addDel = (x, y) => x + y;
                //BizRulesDelegate multiplyDel = (x, y) => x * y;
                //data.Process(2,3, addDel);
                //data.Process(2, 3, multiplyDel);

                //Func<int, int, int> funcAddDel = (x, y) => x + y;
                //Func<int, int, int> funcMultiplyDel = (x, y) => x * y;
                //data.ProcessFunc(3, 2, funcAddDel);

                //EventsAndDelegates.Run();
                //EventsAndDelegates.CreatingDelegates();
            // *****************************************************************


            // *****************************************************************
            // Dependency Injection (constructor)
                //DependencyInjection di = new DependencyInjection(new Format());
                //di.Print();
            // *****************************************************************


            //CallMethod();
            //LambdaPractice();
            //LinqPractice();
            //NullCoalescePractice();
            //NullConditionalPractice();
            //AsIsOperatorPractice();
            //YieldPractice();
            //InterfacePractice();
            //StructPractice();
            //ImplicitExplicitPractice();
            //NameOfPractice();
            //ExceptionFilterPractice();
            //GenericsPractice();
            //int x = FunctionOverLoading(1);
            //string y = FunctionOverLoading("1");
            //DerrivedClass derrivedClass = new DerrivedClass();
            //derrivedClass.Print();

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

            Console.ReadLine();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        private static void BindData(Job job)
        {
            Console.WriteLine("Binding data");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\


        // Async & Await
        private static async void AsyncAwaitPractice()
        {
            Task<int> task = Method1();

            Method2();

            int count = await task;

            Method3(count);

            Console.ReadLine();
        }

        private static async Task<int> Method1()
        {
            int count = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(" Method 1");
                    count += 1;
                    Thread.Sleep(100);
                }
            });
            return count;
        }

        private static void Method2()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(" Method 2");
                Thread.Sleep(100);
            }
        }

        private static void Method3(int count)
        {
            Console.WriteLine("Total count is " + count);
        }


        // Lambdas
        private static void LambdaPractice()
        {
            List<string> listPeople = new List<string>() { "Evan", "Jeff", "Mike", "Erikson", "Jameson" };
            List<string> listSonNames = new List<string>();

            listSonNames.AddRange(listPeople.Where(x => x.Contains("son")));

            listSonNames.ForEach(delegate(string name)
            {
                Console.WriteLine(name);
            });

            Console.ReadLine();
        }


        // LINQ
        private static void LinqPractice()
        {
            List<string> listPeople = new List<string>() { "Evan", "Jeff", "Mike", "Erikson", "Jameson" };
            List<string> listSonNames = new List<string>();

            var query =
                from name in listPeople
                where name.Contains("son")
                select name;

            listSonNames.AddRange(query);
        }


        // Null Coalesce
        private static void NullCoalescePractice()
        {
            string firstName = null;

            string fullName = $"FirstName: {firstName ?? "N/A"}";
        }


        // Null Conditional
        private static void NullConditionalPractice()
        {
            Dog fido = new Dog();
            string name = fido?.Name;
            fido.Name = "Spot";
            string dogName = fido.Name;
        }


        // As and Is operators
        private static void AsIsOperatorPractice()
        {
            // is operator
            Dog spot = new Dog();

            if (spot is Dog)
                Console.WriteLine("Spot is a dog.");
            else
                Console.WriteLine("Spot is not a dog.");

            // as operator
            List<object> numbers = new List<object>() { 1, "2", 3, '4', "5", 6 };

            foreach (object n in numbers)
            {
                if (n is string print) // print is the dummy object
                    Console.WriteLine($"Object {print} is a string.");
                else
                    Console.WriteLine("Object was not a string.");
            }
        }


        // Yield keyword
        private static void YieldPractice()
        {
            foreach (int i in Integers())
                Console.WriteLine(i.ToString());

            foreach (var number in GenerateWithYield())
                Console.WriteLine(number);

            Console.ReadLine();
        }

        private static IEnumerable<int> Integers()
        {
            yield return 4;
            yield return 1;
            yield return 2;
            yield return 8;
            yield return 16;
            yield return 16777216;
        }

        private static IEnumerable<int> GenerateWithYield()
        {
            var i = 0;
            while (i < 5)
                yield return ++i;
        } 


        // Interfaces
        private static void PracticeInterface()
        {
            // Look at 'Robot' class
            // 'Robot' must implement all properties and methods from interface 'IRobot'
            // If 'Robot' does not implement all properties and methods, it will not compile
        }

        public interface IRobot
        {
            double BatteryLevel { get; set; }
            void Walk();
            void ChargeBatteries();
        }

        class Robot : IRobot
        {
            public double BatteryLevel { get; set; } = 100;

            public void Walk()
            {

            }

            public void ChargeBatteries()
            {

            }
        }


        // Structs
            //
            // - Structures are value types
            // - Can have methods, fields, indexers, properties, operator methods, and events
            // - Can have contructors but not destructors
            // - Can implement one or more interfaces
            // - Cannot be specified as abstract, virtual, or protected
        struct Books {
            public string title;
            public string author;
            public string subject;
            public int bookID;
        }

        private static void StructPractice()
        {
            Books book1;
            Books book2;

            book1.author = "Micheal T. Fitsimons";
            book1.bookID = 5342;
            book1.subject = "Horror";
            book1.title = "Sewer Troll";

            book2.author = "Ricardo Garcia";
            book2.bookID = 2867;
            book2.subject = "Comedy";
            book2.title = "Poco Luz";
        }


        // Static vs. Non-Static =================================================================
        // Static classes always derive from object, can can't specify a different base type
        // Static classes cannot implement an interface
        // Static classes cannot have an instance members
        // Static classes can't declare any contructors
        // Static classes are implicitly abstract, you can't add it yourself
        // Static classes can be generic 
        // Static classes can have nested types, static or non-static
        // Only static, top-level non-generic classes can contain extension methods
        // It is bad practice for OOP to have public static variables. 
        // =======================================================================================

        // Implicit vs Explicit
        private static void ImplicitExplcitExample()
        {
            // Implicit - Something is being done for you automatically
            int x = 10;
            long y = x;

            // Explicit -  You've written something in the source code to indicate what you want to happen
            int explicitVar = (int)y;
        }


        // Constructor
        Program()
        {
            // Constructor is called upon instantiation of class
        }

        // Destructor
        ~Program()
        {
            // Destructor is called when this object is disposed. 
            // Since C# is garbage collected, it is usually not necessary to use this
        }


        // Encapsulation ===============================================================================================================================

        // private
        // Allows a class to expose its member variables to other functions and objects

        // public 
        // Allows a class to hide its member variables and functions from other functions and objects

        // protected
        // Allows a child class to access the member variables and member functions of its base class

        // internal
        // Allows a class to expose its member variables and functions to other functions and objects in the current assembly

        // protected internal
        // Allows a class to hide its member variables and functions from other class objects and functions, except a child class within the same application

        // ==============================================================================================================================================


        // Virtual Methods ==============================================================================================================================

        // Virtual methods can be redifined. The virtual keyword designates a mthod that is overridden in derived classes. We can add derived types 
        // without modifying the rest of the program. The runtime type of objects thus determines behavior.

        // ==============================================================================================================================================


        private static void NameOfPractice()
        {
            string name1 = nameof(NameOfPractice);
            string name2 = nameof(name1);
            string name3 = nameof(Robot);
        }


        private static void ExceptionFilterPractice()
        {
            try
            {
                string path = Environment.CurrentDirectory + "\\TestFile.txt";
                string fileText = File.ReadAllText(path);

                if (fileText == null || fileText.Trim() == "")
                    throw new NullReferenceException();
            }
            catch (FileNotFoundException)
            {

            }
            catch (NullReferenceException)
            {

            }
        }


        // Generics
        private static void GenericsPractice()
        {
            MyGenericArray<int> intArray = new MyGenericArray<int>(5);

            //setting values
            for (int c = 0; c < 5; c++)
            {
                intArray.setItem(c, c * 5);
            }

            //retrieving the values
            for (int c = 0; c < 5; c++)
            {
                Console.Write(intArray.getItem(c) + " ");
            }

            Console.WriteLine();

            //declaring a character array
            MyGenericArray<char> charArray = new MyGenericArray<char>(5);

            //setting values
            for (int c = 0; c < 5; c++)
            {
                charArray.setItem(c, (char)(c + 97));
            }

            //retrieving the values
            for (int c = 0; c < 5; c++)
            {
                Console.Write(charArray.getItem(c) + " ");
            }

            Console.WriteLine();
            Console.ReadKey();
        }

        public class MyGenericArray<T>
        {
            private T[] array;

            public MyGenericArray(int size)
            {
                array = new T[size + 1];
            }

            public T getItem(int index)
            {
                return array[index];
            }

            public void setItem(int index, T value)
            {
                array[index] = value;
            }
        }


        // Function Overloading
        private static int FunctionOverLoading(int x)
        {
            return x + 1;
        }

        private static string FunctionOverLoading(string x)
        {
            return x + 1;
        }

        // Function Overriding
        class BaseClass
        {
            public void Show()
            {
                Console.WriteLine("Base Class");
            }

            public virtual void Print()
            {
                Console.WriteLine("Base class says hi!");
            }
        }

        class DerrivedClass : BaseClass
        {
            // Overrides BaseClass's show function
            new static void Show()
            {
                Console.WriteLine("Derived Class");
            }

            public override void Print()
            {
                base.Print();
                Console.WriteLine("Derived class says hi!");
            }
        }


        // Anonymous methods

        delegate void AnonymousPracticeDelegate(int name);

        private static void AnonymousMethodPractice()
        {
            AnonymousPracticeDelegate number = delegate (int x)
            {
                Console.WriteLine("Anonymous method called!");
            };
            
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
            for (int i = 0; i < 5; i++)
                Console.WriteLine(i.ToString());
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

        [STAThread]
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

            Console.ReadLine();
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
