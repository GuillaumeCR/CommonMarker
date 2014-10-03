using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CommonMarker.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = ReadInput();
            var md2Html = new Md2Html();
            var output = "I exploded and I don't know why";
            try
            {
                output = md2Html.Convert(input);
            }
            catch (ParsingException pe)
            {
                output = pe.Message;
            }
            Console.Write(output);
        }

        private static string ReadInput()
        {
            const int bufferSize = 1000;
            var buffer = (char[])Array.CreateInstance(typeof(char), bufferSize);
            var read = Console.In.Read(buffer, 0, bufferSize);
            var index = bufferSize;
            var input = new string(buffer, 0, read);
            while (read == bufferSize)
            {
                read = Console.In.Read(buffer, index, bufferSize);
                input += new string(buffer, 0, read);
                index += bufferSize;
            }

            return input;
        }
    }
}
