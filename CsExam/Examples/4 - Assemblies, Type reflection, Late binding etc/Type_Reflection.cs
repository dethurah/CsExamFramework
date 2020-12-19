using System;
using System.Reflection;

namespace CsExam.Examples
{
    public class Type_Reflection2
    {
        public static void TestMethod()
        {
            Assembly myAssembly = Assembly.LoadFile("/Users/nicolaiwulff/RiderProjects/CsExam/CsExam/bin/Debug/netcoreapp3.1/AssemblyExample.dll");
            var myType = myAssembly.GetType("AssemblyExample.ClassExample");
            dynamic objMyClass = Activator.CreateInstance(myType);
            Type parameterType = objMyClass.GetType();

            //Vi kan fx printe navnene på alle members af AssemblyExample
            foreach (var memberInfo in parameterType.GetMembers())
            {
                Console.WriteLine(memberInfo.Name);
            }
            
            //Her invokerer vi en metode fra AssemblyExample klassen. Det sker dynamisk ved runtime.
            var res = parameterType.InvokeMember("MessageFromAssembly", BindingFlags.InvokeMethod, null, objMyClass, new Object[]{"Nicolai"});
            Console.WriteLine(res);     
        }
    }
}