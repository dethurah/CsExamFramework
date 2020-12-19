using System;
namespace CsExam.Examples
{
    public class GenericArray<T>
    {
        private T[] array;

        public GenericArray(int size)
        {
            array = new T[size + 1];
        }
        public T getItem(int index)
        {
            return array[index];
        }
        public void setItem(int index, T value)
        {
            array[index] = value;
        }
    }
    class GenericArrayExample
    {
        public static void TestMethod()
        {
            //declaring an int array
            GenericArray<int> intArray = new GenericArray<int>(5);

            //setting values
            for (int c = 0; c < 5; c++)
            {
                intArray.setItem(c, c * 5);
            }

            //retrieving the values
            for (int c = 0; c < 5; c++)
            {
                Console.Write(intArray.getItem(c) + " ");
            }

            Console.WriteLine();

            //declaring a character array
            GenericArray<char> charArray = new GenericArray<char>(5);

            //setting values
            for (int c = 0; c < 5; c++)
            {
                charArray.setItem(c, (char)(c + 97));
            }

            //retrieving the values
            for (int c = 0; c < 5; c++)
            {
                Console.Write(charArray.getItem(c) + " ");
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}




