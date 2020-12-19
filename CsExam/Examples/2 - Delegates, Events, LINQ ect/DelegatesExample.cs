using System;

namespace CsExam.Examples
{

    public class DelegatesExample
    {
        public delegate void StrDelegate(string var);

        static string str = "The text is ---> ";

        public static void GetData1(string Name)
        {
            str += "GetData_One : " + Name;
        }

        public static void GetData2(string Name)
        {
            str += " GetData_Two : " + Name;
        }

        public static void GetData3(string Name)
        {
            str += " GetData_Three : " + Name;
        }
        public static string getStr()
        {
            return str;
        }

        public static void testings()
        {
            //create delegate instances
            StrDelegate objMyDelegate = new StrDelegate(GetData1);
            Console.WriteLine("Value of str: {0}", getStr());

            ////GetData1 is called
            objMyDelegate("1 ");
            Console.WriteLine("Value of str: {0}", getStr());

            objMyDelegate += new StrDelegate(GetData2);
            ////GetData1 + GetData2 is called
            objMyDelegate("2 ");
            Console.WriteLine("Value of str: {0}", getStr());

            objMyDelegate = new StrDelegate(GetData1) + new StrDelegate(GetData2) + new StrDelegate(GetData3);
            ////GetData1 + GetData2 + GetData3 is called
            objMyDelegate("3 ");
            Console.WriteLine("Value of str: {0}", getStr());

            objMyDelegate -= new StrDelegate(GetData2);
            ////GetData1 + GetData3 is called
            objMyDelegate("4 ");
            Console.WriteLine("Value of str: {0}", getStr());

            someOtherMethod(objMyDelegate);
        }
        static void someOtherMethod(Delegate obj)
        {
            Console.WriteLine(obj.ToString());
        }
    }
}
