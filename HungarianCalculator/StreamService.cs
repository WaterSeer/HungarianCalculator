using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungarianCalculator
{
    public class StreamService
    {
        public IEnumerable<string> ReadFromFile(string path)
        {
            using(StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                List<string> result = new List<string>();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    result.Add(line);
                }
                return result;
            } 
        }

        public void WriteToFile(IEnumerable<string> lines, string writePath)
        {
            Calculator c = new Calculator();
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                foreach (var item in lines)
                {
                    switch (c.Calculate(c.ProcessInput(item)))
                    {
                        case double.NegativeInfinity:
                            sw.WriteLine(item + " = ошибка деления на ноль");
                            break;
                        case double.PositiveInfinity:
                            sw.WriteLine(item + " = ошибка деления на ноль");
                            break;
                        case double.NaN:
                            sw.WriteLine(item + " = ошибка в выражении");
                            break;                        
                        default:
                            sw.WriteLine(item + " = " + c.Calculate(c.ProcessInput(item)));
                            break;
                    }
                }
            }
        }
    }
}
