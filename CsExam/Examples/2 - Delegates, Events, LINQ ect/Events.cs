using System;

namespace CsExam.Examples
{

    public class Events
    {
        public static void TestMethod()
        {
            ProcessBusinessLogic bl = new ProcessBusinessLogic();
            bl.ProcessCompleted += SubscriberClass2.Bl_ProcessCompleted; // register with an event
            bl.ProcessCompleted += SubscriberClass3.ProcessBeganNotify; // register with an event

            bl.ProcessNotify += SubscriberClass1.ProcessNotification;
            bl.StartProcess();
        }
    }

    //Derive EventArgs base class to create custom event data class.
    public class ProcessEventArgs : EventArgs
    {
        public bool IsSuccessful { get; set; }
        public DateTime CompletionTime { get; set; }
    }

    //Publisher af event
    public class ProcessBusinessLogic
    {
        // declaring an event using built-in EventHandler
        public event EventHandler ProcessNotify;
     
        //Use "event" keyword with delegate type variable to declare an event.
        public event EventHandler<ProcessEventArgs> ProcessCompleted;

        public void StartProcess()
        {
            OnProcessStarted(EventArgs.Empty);
            var data = new ProcessEventArgs();

            try
            {
                Console.WriteLine("Process Started!");
               
                // some process code here..
                data.IsSuccessful = true;
                data.CompletionTime = DateTime.Now;
                OnProcessCompleted(data);
            }
            catch (Exception)
            {
                data.IsSuccessful = false;
                data.CompletionTime = DateTime.Now;
                OnProcessCompleted(data);
            }
        }

        private void OnProcessStarted(EventArgs e)
        {
            Console.WriteLine("Notify about process start");
            ProcessNotify?.Invoke(this, e);
        }

        //Denne metode "raises" eventet
        protected virtual void OnProcessCompleted(ProcessEventArgs e)
        {
            //invokes the delegate
            // This will call all the event handler methods registered with the ProcessCompleted event.
            ProcessCompleted?.Invoke(this, e);
        }
    }

    public class SubscriberClass1
    {
        // event handler
        public static void ProcessNotification(object sender, EventArgs e)
        {
            Console.WriteLine("Process started - A simply notify-event without data");
        }
    }

    public class SubscriberClass2
    {
        // event handler
        public static void Bl_ProcessCompleted(object sender, ProcessEventArgs e)
        {
            Console.WriteLine("Process " + (e.IsSuccessful ? "Completed Successfully" : "failed"));
            Console.WriteLine("Completion Time: " + e.CompletionTime.ToLongDateString());
        }
    }

    public class SubscriberClass3
    {
        // event handler
        public static void ProcessBeganNotify(object sender, ProcessEventArgs e)
        {
            Console.WriteLine("\"Update front-end with is successfull: " + e.IsSuccessful + " - message. \" ");
        }
    }
}
