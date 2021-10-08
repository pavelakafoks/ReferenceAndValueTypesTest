using System;
using System.Collections.Generic;
using System.Linq;

// Output example: 
//    Search time in class: 1294.0036 ms, value: 4
//    Search time in struct: 777.068 ms, value: 4

namespace ReferenceAndValueTypesTest
{
    class ItemClass
    {
        public int Value;
    }

    struct ItemStruct
    {
        public int Value;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();

            var listClass = new List<ItemClass>();
            var listStruct = new List<ItemStruct>();
            Console.WriteLine("Generate arrays...");
            for (var i = 0; i < 100 * 1000 * 1000; i++)
            {
                var value = random.Next();
                listClass.Add(new ItemClass(){Value = value});
                listStruct.Add(new ItemStruct(){Value = value});
                if (i < 100)
                {
                    Console.WriteLine($"{i} test value: {value}");
                }

                if (i == 101)
                {
                    Console.WriteLine("Generation, please wait...");
                }
            }

            Console.WriteLine("Begin calculation");

            var startDateClass = DateTime.Now;
            var minValueClass = listClass.Min(x => x.Value);
            Console.WriteLine($"Search time in class: {(DateTime.Now - startDateClass).TotalMilliseconds} ms, value: {minValueClass}");

            var startDateStruct = DateTime.Now;
            var minValueStuct = listStruct.Min(x => x.Value);
            Console.WriteLine($"Search time in struct: {(DateTime.Now - startDateStruct).TotalMilliseconds} ms, value: {minValueStuct}");

            Console.WriteLine("Press Enter");
            Console.ReadLine();
        }
    }
}
