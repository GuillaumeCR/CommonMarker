using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace CommonMarker.Tests
{
    /// <summary>
    /// Creates a unit test class that tests each example found in the spec.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var httpRequest = WebRequest.CreateHttp("http://jgm.github.io/stmd/spec.html");
            var responseReader = new StreamReader(httpRequest.GetResponse().GetResponseStream());
            var responseBody = responseReader.ReadToEnd();
            var parser = new ExampleParser();
            var examples = parser.Parse(responseBody);
            var unitTestCreator = new UnitTestCreator();
            var unitTestClass = unitTestCreator.Create(examples);
            File.WriteAllText("Spec.cs", unitTestClass);
        }
    }
}
