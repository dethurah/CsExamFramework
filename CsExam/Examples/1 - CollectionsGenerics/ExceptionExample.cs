using System;
namespace CsExam.Examples
{
    public class ExceptionExample
    {
        int result;

        ExceptionExample()
        {
            result = 0;
        }

        public void FaultyDivision(int num1, int num2)
        {
            try
            {
                result = num1 / num2;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Exception caught: {0}", e);
            }
            finally
            {
                Console.WriteLine("Result: {0}", result);
            }
        }
        public static void TestMethod()
        {
            var d = new ExceptionExample();
            d.FaultyDivision(25, 0);
            Console.ReadKey();
        }
    }
}
