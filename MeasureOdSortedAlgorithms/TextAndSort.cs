using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MeasureOdSortedAlgorithms
{
    class TextAndSort
    {
        public string[] ParseText(string FilePath) //парсим текст
        {
            string text = ReadingText(FilePath);
            string[] splittedText = text.Split( new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            return splittedText;
        }

        public Dictionary<string, int> GetCountOfWords(string[] SortedText) //получить словарь  сколько раз слово встр в тексте
        {
            var words = SortedText.Select(word => word.ToLower());
            var dict = new Dictionary<string, int>();
            foreach (var e in words)
            {
                if (!string.IsNullOrEmpty(e))
                {
                    if (!dict.ContainsKey(e)) dict[e] = 0;
                    dict[e]++;
                }
            }
            return dict;
        }

        public string[] StringBubbleSort(string[] stringArray) //сортировка пузырьком для строк
        {
            string temp;
            for (int i = 0; i < stringArray.Length - 1; i++)
            {
                for (int j = 0; j < stringArray.Length - i - 1; j++)
                {

                    if (String.Compare(stringArray[j + 1], stringArray[j]) < 0)
                    {
                        temp = stringArray[j + 1];
                        stringArray[j + 1] = stringArray[j];
                        stringArray[j] = temp;
                    }
                }
            }
            return stringArray;
        }

        public string[] StringQuickSort(string[] stringArray) //быстрая сортировка для строк
        {
            if (stringArray.Length < 2) { return stringArray; }
            int p = stringArray[0].Length;
            return StringQuickSort(stringArray.Where(x => x.Length < p).ToArray())
                .Concat(stringArray.Where(x => x.Length == p))
                .Concat(StringQuickSort(stringArray.Where(x => x.Length > p).ToArray()))
                .ToArray();
        }

        private string ReadingText(string path) //читаем файл (уже лежит в проекте)
        {
            using StreamReader text = new StreamReader(path);
            return text.ReadToEnd();
        }

        public string[] GetSortedText(int sort, string FilePath)//1 - быстрая сортировка, 2 - пузырьком (корявая логика, кек)
        {
            string[] parsedText = ParseText(FilePath);
            if (sort == 1)
                return StringQuickSort(parsedText);
            if (sort == 2)
                return StringBubbleSort(parsedText);
            else return parsedText;
        }

    }
}
