using System;
using System.Collections.Generic;
using System.Linq;

namespace CsExam.Examples
{
    class Collections
    {
        public static void TestMethod()
        {
            //List
            var salmons = new List<string> { "chinook", "coho", "pink", "sockeye" };
            foreach (var salmon in salmons)
            {
                Console.Write(salmon + " ");
            }
            Console.WriteLine();
            salmons.Remove("coho");

            //Linq eksempel
            List<Element> elements = BuildList();
            var subset = from theElement in elements
                         where theElement.AtomicNumber < 22
                         orderby theElement.Name
                         select theElement;

            foreach (Element theElement in subset)
            {
                Console.WriteLine(theElement.Name + " " + theElement.AtomicNumber);
            }

            Console.WriteLine();
            //Iterator example
            foreach (int number in EvenSequence(5, 18))
            {
                Console.Write(number.ToString() + " ");
            }
            Console.WriteLine();

            //HashTable
            //Key / value pair
            //Langsommere end Dictionary, da den anvender hash - values
            IDictionary<string, Element> map = new Dictionary<string, Element>();
            foreach (var item in elements)
            {
                map.Add(item.Symbol, item);
            }
            if (map.ContainsKey("K"))
            {
                Console.WriteLine(map["K"].Name);
            }

            //LIFO last -in-first -out
            Stack<Element> stack = new Stack<Element>();
            foreach (var item in elements)
            {
                stack.Push(item);
            }
            Console.WriteLine(stack.Pop().Name);

            //FIFO first -in-first -out
            Queue<Element> queue = new Queue<Element>();
            foreach (var item in elements)
            {
                queue.Enqueue(item);
            }
            Console.WriteLine(queue.Dequeue().Name);
        }

        private static List<Element> BuildList()
        {
            return new List<Element>
             {
        { new Element() { Symbol="K", Name="Potassium", AtomicNumber=19}},
        { new Element() { Symbol="Ca", Name="Calcium", AtomicNumber=20}},
        { new Element() { Symbol="Sc", Name="Scandium", AtomicNumber=21}},
        { new Element() { Symbol="Ti", Name="Titanium", AtomicNumber=22}}
            };
        }
        public class Element
        {
            public string Symbol { get; set; }
            public string Name { get; set; }
            public int AtomicNumber { get; set; }
        }

        private static IEnumerable<int> EvenSequence(
           int firstNumber, int lastNumber)
        {
            // Yield even numbers in the range.
            for (var number = firstNumber; number <= lastNumber; number++)
            {
                if (number % 2 == 0)
                {
                    yield return number;
                }
            }
        }

    }
}

//Collections
//Link: https://www.tutorialsteacher.com/csharp/csharp-collection


//IEnumerator, IEnumerable, og ICollection er toplevel interfaces til alle collections I C#.
//IEnumerator
//Understøtter simple iterationer over et non-generic collection. Inkludere metoder og properties som kan implementeres til at understøtte nem iteration med foreach loop.
//IEnumerable
//Inkluderer GetEnumerator() metode som returnerer et objekt af IEnumerator
//ICollection
//Base interface for alle collections som definerer størrelse, enumerators og synkroniseringsmetoder for alle non-generic collections.
//Queue og Stack implementerer ICollection interfacet

//IList
//Inkluderer metoder og properties til add, insert, remove elementer i collection og også individuelle elementer med index.
//ArrayList BitArray implementerer IList interfacet

//IDictionary
//Repræsentere en non - generic collection af key / value pairs.
//HashTable og SortedList implementere IDictionary interfacet, så de gemme key / value pairs.

//Collections

//Arraylist
//Generic type, tager imod alle elementer af alle typer.
//Automatisk resizing, når man tilføjer elementer
//Values skal castes til respektive type for anvendelse
//Kan indeholde flere null og duplicate elementer
//Kan tilgås med foreach, for loop eller indexer
//Bruger Add(), AddRange(), Remove(), RemoveRange(), Insert(),
//InsertRange(), Sort(), Reverse()
//SortedList
//C# har gnereic og non-generic SortedList 
//Gemmer i ascending key order
//Key må ikke være null, value må godt
//HashTable
//Key / value pair
//Langsommere end Dictionary, da den anvender hash - values
//Stack
//LIFO last -in-first -out
//Queue
//FIFO first -in-first -out
