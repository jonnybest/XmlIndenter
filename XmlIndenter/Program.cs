using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Diagnostics;

namespace XmlIndenter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("XML test program");

            if (args.Length < 1)
            {
                Console.WriteLine("Usage: XmlIndenter.exe <InFile>\n\n InFile: \tFile to format\n");
            }
            else
            {
                if (File.Exists(args[0]))
                {
                    var doc = XDocument.Load(args[0]);
                    var bakFile = Path.GetTempFileName();
                    File.Delete(bakFile);
                    bakFile = bakFile + ".xml";
                    File.Move(args[0], bakFile);
                    Console.WriteLine("Your backup is at {0}", bakFile);
                    doc.Save(args[0]);
                }
                else
                {
                    Debug.WriteLine("Command line argument \'{0}\' not valid.", args[0]);
                }
            }
        }
    }
}
