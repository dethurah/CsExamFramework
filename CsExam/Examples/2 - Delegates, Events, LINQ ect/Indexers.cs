using System;
namespace CsExam.Examples
{
    //Advanced type contruction

    class SampleCollection<T>
    {
        // Declare an array to store the data elements.
        private T[] arr = new T[100];

        // Define the indexer to allow client code to use [] notation.
        public T this[int i]
        {
            get { return arr[i]; }
            set { arr[i] = value; }
        }

        public static void TestMethod()
        {
            var stringCollection = new SampleCollection<string>();
            stringCollection[0] = "Hello, World - One";
            stringCollection[1] = "Hello, World - Two";
            stringCollection[2] = "Hello, World - Three";
            stringCollection[3] = "Hello, World - Four";
          
            for (int i = 0; i < 10; i++)
                Console.WriteLine(stringCollection[i]);

        }
    }
}
