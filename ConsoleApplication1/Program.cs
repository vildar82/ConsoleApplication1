using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Windows.Media;
using NetLib;

namespace ConsoleApplication1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var pik = @"c:\Users\khisyametdinovvt\AppData\Roaming\Autodesk\Revit\Addins\2017\PIK";
            var addin = Path.GetFullPath(Path.Combine(pik, @"..\"));
            Console.WriteLine(addin);
            Console.ReadKey();
        }
    }
}
