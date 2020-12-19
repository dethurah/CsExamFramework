using System;

namespace CsExam.Examples
{
    public class Attributes
    {
        //Først Laver vi en custom attribute.
        //Den bruger selv en attribut til at markere, hvad den må bruges på.
        
        [AttributeUsage(AttributeTargets.Method)  
        ]  
        public class TestAttribute : System.Attribute  
        {  
            private string name;  
      
            public TestAttribute(string name)  
            {  
                this.name = name;  
            }  
        }

        
        [Test("Nicolai")]
        public void Method1()
        {
            //Kode her
        }
        
        public static void TestMethod()
        {
            Attributes test = new Attributes();
            Type testType = test.GetType();
            var attributes = testType.GetMember("Method1")[0].CustomAttributes;
            foreach (var attribute in attributes)
            {
                Console.WriteLine(attribute); //Det fulde navn
                Console.WriteLine(attribute.AttributeType.Name);
                Console.WriteLine(attribute.ConstructorArguments[0]);
            }
        }
    }
}