using System;
using System.Collections.Generic;

namespace TestBed
{
    internal class Program
    {
        private static void Main()
        {
            var list = new List<string>();
            list.Add("s1");
            list.Add("s2");
            list.Add("s3");
            list.Add("s4");
            list.Add("s5");
            list.Add("s6");
            list.Add("s7");
            list.Add("s8");
            list.Add("s9");
            var list2 = new List<string>();
            list2.Add("s7");
            list2.Add("s8");
            list2.Add("s9");
            var list3 = list2;
            var list4 = new List<string>();
            var enumerator = list.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    var current = enumerator.Current;
                    var enumerator2 = list3.GetEnumerator();
                    try
                    {
                        while (enumerator2.MoveNext())
                        {
                            var current2 = enumerator2.Current;
                            if (current2.Equals(current, StringComparison.OrdinalIgnoreCase))
                            {
                                list4.Add(current2);
                                var text = string.Concat("This is the ", current2, " in the ", current);
                                var text2 = string.Concat("This is the ", current2, " in the ", current);
                                Console.WriteLine(string.Concat(text, text2));
                            }
                        }
                    }
                    finally
                    {
                        enumerator2.Dispose();
                    }
                }
            }
            finally
            {
                enumerator.Dispose();
            }

            enumerator = list4.GetEnumerator();
            try
            {
                while (enumerator.MoveNext()) Console.WriteLine(enumerator.Current);
            }
            finally
            {
                enumerator.Dispose();
            }

            Console.ReadKey();
        }
        //static void Main(string[] args)
        //{
        //    var MainList = new List<string>() { "s1", "s2", "s3", "s4", "s5", "s6", "s7", "s8", "s9" };
        //    var SubList = new List<string>() { "s7", "s8", "s9" };
        //    var RemainingList = new List<string>();
        //    foreach (var item in MainList)
        //    {
        //        foreach (var l in SubList)
        //            if (l.Equals(item, StringComparison.OrdinalIgnoreCase))
        //                RemainingList.Add(l);
        //    }
        //    foreach (var item in RemainingList)
        //        Console.WriteLine(item);
        //    Console.ReadKey();
        //}
    }
}