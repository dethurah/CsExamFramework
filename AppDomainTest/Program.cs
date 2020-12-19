using System;
using System.IO;
using System.Reflection;

namespace AppDomainTest
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            // Her sætter vi applikation domænets setup information
            AppDomainSetup domaininfo = new AppDomainSetup();
            domaininfo.ApplicationBase = "/Users/nicolaiwulff/RiderProjects/AppDomainTest"; //Roden af applikationen

            //Her laver vi et nyt AppDomain ud fra setup klassen.
            Console.WriteLine("Creating new AppDomain.");
            AppDomain domain = AppDomain.CreateDomain("MyDomain", null, domaininfo);

            //Vi kan tilgå informationer om måde "host" domænet, og det nye domæne.
            Console.WriteLine("Host domain: " + AppDomain.CurrentDomain.FriendlyName);
            Console.WriteLine("child domain: " + domain.FriendlyName);
            Console.WriteLine("Application base is: " + domain.SetupInformation.ApplicationBase);


            //Her vil vi loade en assembly ind i det nye AppDomain.
            //Først læses bytes i assembly'et
            string path = @"/Users/nicolaiwulff/RiderProjects/AppDomainTest/AppDomainTest/bin/Debug/AssemblyExample.dll"; 
            byte[] buffer = File.ReadAllBytes(path);
            
            //Vi loader assembly i domænet.
            Assembly a = domain.Load(buffer);
            // Finder typen på den klasse, vi vil bruge.
            Type myType = a.GetType("AssemblyExample.ClassExample");
            // Finder en metode.
            MethodInfo myMethod = myType.GetMethod("MessageFromAssembly");
            // Laver en instance.
            object obj = Activator.CreateInstance(myType);
            
            // Eksekverer metoden
            var res = myMethod.Invoke(obj, new object[]{"Nicolai"});
            Console.WriteLine(res);  
            
            //Her vil vi unloade vores AppDomain
            try
            {
                AppDomain.Unload(domain);
                Console.WriteLine();
                Console.WriteLine("Host domain: " + AppDomain.CurrentDomain.FriendlyName);
                // Dette smider en exception, fordi domænet ikke findes længere.
                Console.WriteLine("child domain: " + domain.FriendlyName);
            }
            catch (AppDomainUnloadedException e)
            {
                Console.WriteLine(e.GetType().FullName);
                Console.WriteLine("The appdomain MyDomain does not exist.");
            }
        }
    }
}