using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prep
{
    // ===================================================================================================

    //                              EVENTS DELEGATES & LAMBDAS    

    // ===================================================================================================


    class EventsAndDelegates
    {
        // Events Delegates, and Event Handlers
        // Creating delegates, events and EventArgs
        public delegate int PerformedWorkHandler(int hours, WorkType workType);

        public static void CreatingDelegates()
        {
            PerformedWorkHandler del1 = new PerformedWorkHandler(PerformedWork1);
            PerformedWorkHandler del2 = new PerformedWorkHandler(PerformedWork2);
            PerformedWorkHandler del3 = new PerformedWorkHandler(PerformedWork3);

            int finalHours = del1(10, WorkType.GenerateReports);
            Console.WriteLine(finalHours);

            Console.ReadLine();
        }

        static void DoWork(PerformedWorkHandler del)
        {
            del(5, WorkType.GoToMeetings);
        }

        static int PerformedWork1(int hours, WorkType workType)
        {
            Console.WriteLine("PerformedWork1 called " + hours.ToString());
            return hours + 1;
        }

        static int PerformedWork2(int hours, WorkType workType)
        {
            Console.WriteLine("PerformedWork2 called " + hours.ToString());
            return hours + 2;
        }

        static int PerformedWork3(int hours, WorkType workType)
        {
            Console.WriteLine("PerformedWork3 called " + hours.ToString());
            return hours + 3;
        }
    }

    // Handling Events
    public delegate int WorkPerformedHandler(object sender, WorkPerformedEventArgs e);

    class Worker
    {
        public event WorkPerformedHandler WorkPerformed;
        public event EventHandler WorkCompleted;

        public void DoWork(int hours, WorkType workType)
        {
            for (int i = 0; i < hours; i++)
            {
                // raise event
                OnWorkPerformed(i + 1, workType);
            }

            // raise event
            OnJobCompleted();

            Console.ReadLine();
        }

        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            Console.WriteLine($"Working for {hours} hours!");

            var del = WorkPerformed as WorkPerformedHandler;
            if (del != null)
            {
                del(this, new WorkPerformedEventArgs(hours, workType));
            }

            // Short hand version of the above code 
            // (WorkPerformed as WorkPerformedEventHandler)?.Invoke(hours, workType);
        }

        protected virtual void OnJobCompleted()
        {
            Console.WriteLine("Completed Jobs!");

            EventHandler del = WorkCompleted as EventHandler;
            if (del != null)
            {
                del(this, EventArgs.Empty);
            }

            // Short hand version of the above code 
            // (JobCompleted as EventHandler)?.Invoke(this, EventArgs.Empty);
        }
    }


    // Lambdas, Action<T> and Func<T,Result>
    public delegate int BizRulesDelegate(int x, int y);
    class ProcessData
    {
        public void Process(int x, int y, BizRulesDelegate del)
        {
            var result = del(x, y);
            Console.WriteLine(result);
        }

        public void ProcessFunc(int x, int y, Func<int, int, int> del)
        {

        }

        public void ProcessAction(int x, int y, Action<int, int> action)
        {
            action(x, y);
            Console.WriteLine("This action has been processed");
        }

    }






}
