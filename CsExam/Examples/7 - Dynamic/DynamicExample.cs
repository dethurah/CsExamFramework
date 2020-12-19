using System;
namespace CsExam.Examples
{
    public class DynamicExample
    {
        static dynamic PrintValue(dynamic val)
        {
            Console.WriteLine("Value: {0}, type: {1}", val, val.GetType());

            // val.  - Virker ikke, da det besluttes under run time.
            if (val is String)
            {
                try
                {
                    return val.ToUpper();
                }
                catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException mcrre)
                {
                    Console.WriteLine(mcrre.Message);
                }
            }
            else
            {
                try
                {
                    Console.WriteLine("Value: {0}", val * 2);
                }
                catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException mcrre)
                {
                    Console.WriteLine(mcrre.Message);
                }

            }
            return val;
        }

        public static void TestMethod()
        {
            Console.WriteLine("Value: {0}", PrintValue("Hello World!!"));
            Console.WriteLine("Value: {0}", PrintValue(100));
            Console.WriteLine("Value: {0}", PrintValue(100.1));
            Console.WriteLine("Value: {0}", PrintValue(true));
            Console.WriteLine("Value: {0}", PrintValue(DateTime.Now));

            //Kontra late binding:
            var varible = "a";
            //varible = 2;

        }
    }
}
