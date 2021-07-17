using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConvertData
{
    class Program
    {
        static void Main(string[] args)
        {
            string dirname = Directory.GetCurrentDirectory();
            string strRemoved = @"\ConvertData\bin\Debug";
            dirname = dirname.Replace(strRemoved, "");

            string csvFile= dirname + @"\data.csv";

            var csvFileData = File
                .ReadAllLines(csvFile)
                .SkipWhile(line => string.IsNullOrWhiteSpace(line))
                .Select((line, index) => line.Replace(",", "\t"))
                .ToList();

            string path = dirname + @"\fifa-tab.tsv";

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            File.WriteAllLines(path, csvFileData);

            Console.ReadKey();

        }
    }
}
