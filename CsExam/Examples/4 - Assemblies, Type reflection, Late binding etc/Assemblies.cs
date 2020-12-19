using System;
using AssemblyExample;

namespace CsExam.Examples
{
    public class Assemblies
    {
        public static void TestMethod()
        {
            ClassExample example = new ClassExample();
            Console.WriteLine(example.MessageFromAssembly("Nicolai"));
        }
        
    }
}