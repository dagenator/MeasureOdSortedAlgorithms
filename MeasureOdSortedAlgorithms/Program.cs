using System;
using System.Collections.Generic;
using System.IO;

namespace MeasureOdSortedAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeMeasure Time = new TimeMeasure(); //  Класс подсчета времени
            TextAndSort textAndSort = new TextAndSort();
            var DirectoryPath= Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName; // Путь до папки с sln 



            Dictionary<int, string> FilesPaths = new Dictionary<int, string>(); // Словарь с соответвием количетву слов и путем до тескта
            foreach (var e in new int[]{ 100, 500, 1000, 2000, 5000 })
            {
                var fileName = "text" + e.ToString() + ".txt"; 
                FilesPaths.Add(e, Path.Combine(DirectoryPath, fileName)); // Файлы с текстом лежат в той же папаке что и решение
            }

            Dictionary<int, string[]> ParsedText = new Dictionary<int, string[]>(); // Файлы с текстом лежат в той же папаке что и решение словарь с соответсвием количетво - текст распарсенный
            foreach (var e in FilesPaths)
            {
                ParsedText.Add(e.Key, textAndSort.ParseText(e.Value));
            }

            
            var FileOfCounterPath = Path.Combine(DirectoryPath, "ResultOfCount.txt"); // Путь к файлу с подсчетом, в папке с решением

            File.WriteAllText(FileOfCounterPath, "");//чистим файл


            using StreamWriter writer = new StreamWriter(FileOfCounterPath, true); // Заполняем файл для каждого текста
            foreach (var e in ParsedText)
            {
                var count = textAndSort.GetCountOfWords(e.Value);
                writer.WriteLine("---------------------------------------------------------------------");
                writer.WriteLine("For text with " + e.Key +" words");
                foreach(var n in count)
                {
                    writer.WriteLine(n.Key +": "+ n.Value);
                }

            }


            foreach (var e in ParsedText) // вывод замеров времени
            {
                Console.WriteLine();
                Console.WriteLine( e.Key +" Words");
                Console.WriteLine("Bubble Sort checks");
                var time = Time.MesureOfWork(textAndSort.StringBubbleSort, 100, e.Value);
                Console.WriteLine("time: " + time.ToString());

                Console.WriteLine("Quick Sort checks");
                time = Time.MesureOfWork(textAndSort.StringQuickSort, 100, e.Value);
                Console.WriteLine("time: " + time.ToString());
            }
           
        }
    }
}
