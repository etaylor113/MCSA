using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prep
{
    // Make sealed so it can't be interited
    public sealed class Mediator
    {
        // Make it so only one instance of this class can be in memory
        private static readonly Mediator _Instance = new Mediator();

        // Hides the constructor so class cannot be 'newed' up
        private Mediator() {}

        public static Mediator GetInstance()
        {
            return _Instance;
        }

        // Instance functionality
        public event EventHandler<JobChangedEventArgs> JobChanged;

        public void OnJobChanged(object sender, Job job)
        {
            var jobChangedDelegate = JobChanged as EventHandler<JobChangedEventArgs>;
            if (jobChangedDelegate != null)
            {
                jobChangedDelegate(sender, new JobChangedEventArgs { Job = job }); 
            }
        }

    }
}
