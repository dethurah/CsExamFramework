using System;
using System.Threading;

namespace CsExam.Examples
{
    public class MultiThreads
    {
        public static void Method1() 
        { 
  
            // Printer tallene fra 1 til 10
            for (int I = 0; I <= 10; I++) { 
                Console.WriteLine("Method1 : {0}", I);
            } 
        } 
  
        // static method two 
        public static void Method2() 
        { 
            // Printer tallene fra 1 til 10
            for (int J = 0; J <= 10; J++) { 
                Console.WriteLine("Method2 : {0}", J); 
            }
        }

        public static void TestMethod()
        {
            Thread thr1 = new Thread(Method1); 
            Thread thr2 = new Thread(Method2); 
            thr1.Start(); 
            thr2.Start(); 
        }
    }
}