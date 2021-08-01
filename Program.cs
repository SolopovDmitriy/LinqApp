using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //LINQ
            int[] elems = new int[30];
            Random random = new Random();
            for (int i = 0; i < elems.Length; i++)
            {
                elems[i] = random.Next(0, 10);  
            }
            /*linq запрос*/
            IEnumerable<int> queryResultOne = from elem in elems select elem;// отложенное выполнение - только в момент обращения к результату
            foreach (var item in queryResultOne)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Четные числа");
            IEnumerable<int> queryResultTwo = from el in elems where el % 2 == 0 select el; // получение кратных чисел коллекции

            foreach (var item in queryResultTwo)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Сортировка массива четных чисел по восходящему");
            IEnumerable<int> queryResultSorted = from el in elems where el % 2 == 0 orderby el descending  select el; // получение кратных чисел коллекции descending - сортировка по нисходящему, ascending - сортировка по восходящему
            foreach (var item in queryResultSorted)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.Write("Группировка по e % 10 ");
            Console.WriteLine();
            int[] bigArr = new int[20];
            for (int i = 0; i < bigArr.Length; i++)
            {
               bigArr[i] = random.Next(10,100);
            }


            /* группирование результатов*/
            IEnumerable<IGrouping<int, int>> groupby = from e in bigArr group e by e % 10;
            foreach (var item in groupby)
            {
                Console.WriteLine("Key: " + item.Key);
                foreach (var value in item)
                {
                    Console.Write(value + " " );
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.Write("сохранение промежуточных значений");
            Console.WriteLine();
            /*сохранение промежуточных значений*/
            IEnumerable<IGrouping<int, int>> groupprom = from jk in bigArr group jk by jk % 10 into tmp where tmp.Count() > 2 select tmp;
            foreach (var item in groupprom)
            {
                Console.WriteLine("Key: " + item.Key);
                foreach( var value in item)
                {
                    Console.Write(value + " ");
                }
                Console.WriteLine();

            }
            Console.WriteLine();
            Console.Write("Split");
            Console.WriteLine();
            Console.WriteLine();
            string[] textString =
            {
                "ElementAt: выбирает элемент последовательности по определенному индексу",
                "SingleOrDefault: выбирает первый элемент коллекции или возвращает значение по умолчанию",
                "Last: выбирает последний элемент коллекции"
            };
            IEnumerable<string> words = from row in textString let one = row.Split(' ', ',', '.')  from word in one where word.Count() > 1 select word;
            foreach (var item in words)
            {
                Console.WriteLine(item);
            }
        }
    }
}
