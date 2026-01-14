using Advent_of_Code.Elemente;
using System.Security.Cryptography;
using System.Text;

namespace Advent_of_Code._2015
{
    internal class Day04: DayBase
    {
        public Day04()
        {
            Part1.Text = "--- Day 4: The Ideal Stocking Stuffer ---\r\nSanta needs help mining some AdventCoins (very similar to bitcoins) to use as gifts for all the economically forward-thinking little girls and boys.\r\n\r\nTo do this, he needs to find MD5 hashes which, in hexadecimal, start with at least five zeroes. The input to the MD5 hash is some secret key (your puzzle input, given below) followed by a number in decimal. To mine AdventCoins, you must find Santa the lowest positive number (no leading zeroes: 1, 2, 3, ...) that produces such a hash.\r\n\r\nFor example:\r\n\r\nIf your secret key is abcdef, the answer is 609043, because the MD5 hash of abcdef609043 starts with five zeroes (000001dbbfa...), and it is the lowest such number to do so.\r\nIf your secret key is pqrstuv, the lowest number it combines with to make an MD5 hash starting with five zeroes is 1048970; that is, the MD5 hash of pqrstuv1048970 looks like 000006136ef....";
            Part1.Input = "iwrupvqb";

            Part2.Text = "--- Part Two ---\r\nNow find one that starts with six zeroes.";
            Part2.Input = Part1.Input;
        }

        public override void DoPart1()
        {
            int number = 0;

            bool found = false;

            using (MD5 md5 = MD5.Create())
            {
                while (!found)
                {
                    string input = string.Format("{0}{1}", Part1.Input, number);

                    byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                    byte[] hashBytes = md5.ComputeHash(inputBytes);

                    StringBuilder sb = new StringBuilder();
                    foreach (byte b in hashBytes)
                        sb.Append(b.ToString("x2")); // "x2" = lowercase hex

                    if(sb.ToString().StartsWith("00000"))
                    {
                        found = true;
                    }
                    else
                        number++;
                }
            }

            Part1.Output = $"Number = {number}";
        }

        public override void DoPart2()
        {
            int number = 0;

            bool found = false;

            using (MD5 md5 = MD5.Create())
            {
                while (!found)
                {
                    string input = string.Format("{0}{1}", Part2.Input, number);

                    byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                    byte[] hashBytes = md5.ComputeHash(inputBytes);

                    StringBuilder sb = new StringBuilder();
                    foreach (byte b in hashBytes)
                        sb.Append(b.ToString("x2")); // "x2" = lowercase hex

                    if (sb.ToString().StartsWith("000000"))
                    {
                        found = true;
                    }
                    else
                        number++;
                }
            }

            Part2.Output = $"Number = {number}";
        }
    }
}
