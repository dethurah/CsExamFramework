using System;

namespace CsExam.Examples
{
    public class AppDomains
    {

        public static void TestMethod()
        {
            //Creates a new App Domain
            AppDomain domain = AppDomain.CreateDomain("MyDomain");

            Console.WriteLine("Host domain: " + AppDomain.CurrentDomain.FriendlyName);
            Console.WriteLine("child domain: " + domain.FriendlyName);
        }
    }
}