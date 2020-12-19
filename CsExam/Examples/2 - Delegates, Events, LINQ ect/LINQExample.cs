using System;
using System.Collections.Generic;
using System.Linq;

namespace CsExam.Examples
{
    public class NameData
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class AgeData
    {
        public int Id { get; set; }
        public int Age { get; set; }
    }

    public class LINQExample
    {
        // Data source
        static IEnumerable<NameData> NameDataSource()
        {
            yield return new NameData { Name = "Bill", Id = 1 };
            yield return new NameData { Name = "Steve", Id = 2 };
            yield return new NameData { Name = "James", Id = 3 };
            yield return new NameData { Name = "Mohan", Id = 4 };
        }

        // Data source
        static IEnumerable<AgeData> AgeDataSource()
        {
            yield return new AgeData { Age = 97, Id = 1 };
            yield return new AgeData { Age = 22, Id = 2 };
            yield return new AgeData { Age = 76, Id = 3 };
            yield return new AgeData { Age = 65, Id = 4 };
        }

        public static void TestMethod()
        {
            //Join two data sources using Linq Query Syntax - Minder om sql
            var dataFromSource = from name in NameDataSource()
                                 join age in AgeDataSource()
                                 on name.Id equals age.Id
                                 where age.Age > 44
                                 select new
                                 {
                                     name.Id,
                                     name.Name,
                                     age.Age
                                 };

            // Display each person that we've generated and placed in 
            //dataFromSource in the console
            foreach (var person in dataFromSource)
            {
                Console.WriteLine(person);
            }

            // LINQ Query 
            var linqQuery = from a in dataFromSource
                            where a.Name.Contains('a')
                            select a.Name;
            
            foreach (var person in linqQuery)
            {
                Console.WriteLine(person);
            }
        }
    }
}
