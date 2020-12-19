using System;
using System.Threading;

namespace CsExam.Examples
{
    public class MultiThreads_Locks
    {
        static bool done;
 
        public static void TestMethod()
        {
            new Thread (WriteDone).Start();
            WriteDone();
        }
        
        static void WriteDone() 
        {
            if (!done)
            {
                Console.WriteLine ("Done"); //Læg mærke til, "Done" bliver printet to gange! 
                done = true;
            }
        }
        
        static readonly object locker = new object();
        
        static void WriteDoneWithLock() 
        {
            lock (locker) {
                if (!done)
                {
                    Console.WriteLine ("Done"); //Læg mærke til, "Done" bliver printet to gange! 
                    done = true;
                }
            }
        }
        
        public static void TestMethod2()
        {
            new Thread (WriteDoneWithLock).Start();
            WriteDoneWithLock();
        }
    }
}