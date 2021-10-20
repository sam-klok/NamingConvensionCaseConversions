using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace NamingConvensionCaseConversions
{
    public static class StringExtension
    {
        public static string ToTiltleCase(this string s)
        {
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            var r = ti.ToTitleCase(s);
            return r;
        }

        public static string ToTiltleCase2(this string s) =>
            CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s);
        public static string ToTrim(this string s) => s.Trim();


        public static string ToCamelCase(this string s)
        {
            var sb = new StringBuilder();

            s.Split(' ')
                .ToList()
                .ForEach(w =>
                {
                    sb.Append(char.ToUpper(w[0]));
                    sb.Append(w.Substring(1));
                    sb.Append(" ");
                });

            var t = sb.ToString().Trim();
            var r = char.ToLower(t[0]) + t.Substring(1);

            return r;
        }

        public static string ToCamelCaseV2(this string s)
        {
            var t = s.Split(' ')
                .Select(w =>
                    char.ToUpper(w[0])
                    + w.Substring(1)
                    + " ")
                .Aggregate((i, j) => i + "" + j)   // we had .Join(" ") in older version of .Net
                .Trim();

            var r = char.ToLower(t[0]) + t.Substring(1);

            return r;
        }
    }

    class Program
    {

        const string TESTSTRING = "The Quick Brown Fox Jumps over the Lazy Dog";  // TitleCase example
        static void Main(string[] args)
        {
            Console.WriteLine($"Test:         {TESTSTRING}");

            Console.WriteLine($"Camel case:   {TESTSTRING.ToCamelCase()}");
            Console.WriteLine($"Camel case 2: {TESTSTRING.ToCamelCaseV2()}");

            Console.WriteLine($"Title case:   {TESTSTRING.ToTiltleCase()}");
        }

        //private static string ConvertToCamelCase(string s)
        //{
        //    var sb = new StringBuilder();

        //    s.Split(' ')
        //        .ToList()
        //        .ForEach(w => sb.Append(char.ToUpper(w[0]) + w.Substring(1)));

        //    var t = sb.ToString();
        //    var r = char.ToLower(t[0]) + t.Substring(1);

        //    return r;
        //}


        //private static string ConvertToTiltleCase(string s)
        //{
        //    TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
        //    var r = ti.ToTitleCase(s);
        //    return r;
        //}




    }
}
