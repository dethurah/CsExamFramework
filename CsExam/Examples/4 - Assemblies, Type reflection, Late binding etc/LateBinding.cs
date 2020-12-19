using System;
namespace CsExam.Examples
{
    public class LateBinding
    {
        public static void TestMethod()
        {
           // Dynamiske objeke. Kompilatoren kender ikke deres type. Kendes først ved run-time;
            dynamic obj = 4;
            dynamic obj1 = 5.678;
            dynamic obj2 = "Besked";

            //Skriv objekternes typer. Brug .GetType til at hente den.
            Console.WriteLine("Objekternes type er :");
            Console.WriteLine(obj.GetType());
            Console.WriteLine(obj1.GetType());
            Console.WriteLine(obj2.GetType());
        }
    }
}