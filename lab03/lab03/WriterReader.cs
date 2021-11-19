using System;
using System.IO;
using System.Collections;

namespace rw
{
    class Writer
    {
        public static void write(int[] arr, string filename)
        {
            File.WriteAllText(filename, string.Join("\n", arr));
        }
    }

    class Reader
    {
        public static void read(string filename, out string[] arr)
        {
            arr = File.ReadAllLines(filename)[0].Split(' ');
        }
    }

}