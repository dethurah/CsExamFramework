using System;

namespace AssemblyExample
{
    //When the project is build, AssemblyExample is assembled into AssemblyExample.dll
    //Can then be added as a reference to the CsExam project and used as a library.
    public class ClassExample
    {
        public string _greetingMsg = "This message is from the AssemblyExample library.";
        
        public string MessageFromAssembly(string name)
        {
            return "Hello, " + name + ". " + _greetingMsg;
        }

        private void AnotherMethod()
        {
            //Code here
        }
    }
}