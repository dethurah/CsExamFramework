//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Reflection;
//using System.Reflection.Emit;
//using System.Threading;

////o A DLL (assembly) with the name (Demo.dll)
////o with a default constructor
////o and one method (writing a text)
////o Dll is loaded dynamically
////o Method is fetched and called
//namespace AssemblyBaker
//{
//    public class DynamicAssemblyExample
//    {
//        public static void TestMethod()
//        {
//            AppDomain theDefault = Thread.GetDomain();
//            DynamicAssemblyExample p = new DynamicAssemblyExample();
//            p.Baker(theDefault);
//            Console.WriteLine("Assembly constructed..");
//            Assembly asm = Assembly.Load("Demo");
//            Type t = asm.GetType("Demo.DemoClass");
//            Object o = Activator.CreateInstance(t);
//            MethodInfo mi = t.GetMethod("WriteMsg");
//            mi.Invoke(o, null);
//        }
//        public void Baker(AppDomain curApp)
//        {
//            // general info
//            AssemblyName asmName = new AssemblyName();
//            asmName.Name = "Demo";
//            asmName.Version = new Version("1.0.0.0");
//            // create Assembly
//            //AssemblyBuilder assembly = curApp.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.Save);
//            // create a module in a single-file assembly
//            //ModuleBuilder module = assembly.DefineDynamicModule("Demo", "Demo.dll");
//            //TypeBuilder myType = module.DefineType("Demo.DemoClass", TypeAttributes.Public);
//            //myType.DefineDefaultConstructor(MethodAttributes.Public);
//            //MethodBuilder infoWriter = myType.DefineMethod("WriteMsg",
//            //MethodAttributes.Public, null, null);
//            //ILGenerator methodIl = infoWriter.GetILGenerator();
//            //methodIl.EmitWriteLine("Hi from dynamic assembly");
//            //methodIl.Emit(OpCodes.Ret);
//            //// create type and save
//            //myType.CreateType();
//            //assembly.Save("Demo.dll");
//        }
//    }
//}