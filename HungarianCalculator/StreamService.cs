using System.Collections.Generic;
using System.IO;

namespace HungarianCalculator
{
    public class StreamService
    {
        public IEnumerable<string> ReadFromFile(string path)
        {
            using (StreamReader streamReader = new StreamReader(path, System.Text.Encoding.Default))
            {
                List<string> result = new List<string>();
                string lineFromStream;
                while ((lineFromStream = streamReader.ReadLine()) != null)
                {
                    result.Add(lineFromStream);
                }
                return result;
            }
        }

        public void WriteToFile(IEnumerable<string> lines, string writePath)
        {
            Calculator calculator = new Calculator();
            using (StreamWriter streamWriter = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                foreach (var item in lines)
                {
                    switch (calculator.Calculate(calculator.GetArithmeticExpression(item)))
                    {
                        case double.NegativeInfinity:
                            streamWriter.WriteLine(item + " = ошибка деления на ноль");
                            break;
                        case double.PositiveInfinity:
                            streamWriter.WriteLine(item + " = ошибка деления на ноль");
                            break;
                        case double.NaN:
                            streamWriter.WriteLine(item + " = ошибка в выражении");
                            break;
                        default:
                            streamWriter.WriteLine(item + " = " + calculator.Calculate(calculator.GetArithmeticExpression(item)));
                            break;
                    }
                }
            }
        }
    }
}
