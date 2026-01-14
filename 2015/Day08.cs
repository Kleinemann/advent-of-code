using Advent_of_Code.Elemente;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Advent_of_Code._2015
{
    internal class Day08: DayBase
    {
        public Day08()
        {
            Part1.Text = "--- Day 8: Matchsticks ---\r\nSpace on the sleigh is limited this year, and so Santa will be bringing his list as a digital copy. He needs to know how much space it will take up when stored.\r\n\r\nIt is common in many programming languages to provide a way to escape special characters in strings. For example, C, JavaScript, Perl, Python, and even PHP handle special characters in very similar ways.\r\n\r\nHowever, it is important to realize the difference between the number of characters in the code representation of the string literal and the number of characters in the in-memory string itself.\r\n\r\nFor example:\r\n\r\n\"\" is 2 characters of code (the two double quotes), but the string contains zero characters.\r\n\"abc\" is 5 characters of code, but 3 characters in the string data.\r\n\"aaa\\\"aaa\" is 10 characters of code, but the string itself contains six \"a\" characters and a single, escaped quote character, for a total of 7 characters in the string data.\r\n\"\\x27\" is 6 characters of code, but the string itself contains just one - an apostrophe ('), escaped using hexadecimal notation.\r\nSanta's list is a file that contains many double-quoted string literals, one on each line. The only escape sequences used are \\\\ (which represents a single backslash), \\\" (which represents a lone double-quote character), and \\x plus two hexadecimal characters (which represents a single character with that ASCII code).\r\n\r\nDisregarding the whitespace in the file, what is the number of characters of code for string literals minus the number of characters in memory for the values of the strings in total for the entire file?\r\n\r\nFor example, given the four strings above, the total number of characters of string code (2 + 5 + 10 + 6 = 23) minus the total number of characters in memory for string values (0 + 3 + 7 + 1 = 11) is 23 - 11 = 12.";
            Part1.Input = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "2015", "Day08.txt"));

            Part2.Text = "--- Part Two ---\r\nNow, given the same instructions, find the position of the first character that causes him to enter the basement (floor -1). The first character in the instructions has position 1, the second character has position 2, and so on.\r\n\r\nFor example:\r\n\r\n) causes him to enter the basement at character position 1.\r\n()()) causes him to enter the basement at character position 5.\r\nWhat is the position of the character that causes Santa to first enter the basement?";
            Part2.Input = Part1.Input;
        }

        int CharacterCount(string arg) => Regex.Match(arg, @"^""(\\x..|\\.|.)*""$").Groups[1].Captures.Count;
        int EncodedStringCount(string arg) => 2 + arg.Sum(CharsToEncode);
        int CharsToEncode(char c) => c == '\\' || c == '\"' ? 2 : 1;



        public override void DoPart1()
        {
            var lines = Part1.Input.Split("\r\n");

            int totalCode = lines.Sum(l => l.Length);
            int totalCharacters = lines.Sum(CharacterCount);
            int totalEncoded = lines.Sum(EncodedStringCount);

            int res = totalCode - totalCharacters;

            Part1.Output = $"code = {totalCode}; chars = {totalCharacters}; Total = {res}";
        }

        public override void DoPart2()
        {
            var lines = Part2.Input.Split("\r\n");

            int totalCode = lines.Sum(l => l.Length);
            int totalCharacters = lines.Sum(CharacterCount);
            int totalEncoded = lines.Sum(EncodedStringCount);

            int res1 = totalCode - totalCharacters;
            int res = totalEncoded - totalCode;

            Part2.Output = $"code = {totalCode}; chars = {totalCharacters}; Total = {res}";
        }
    }
}
