using Advent_of_Code.Elemente;
using System.Numerics;

namespace Advent_of_Code._2025
{
    internal class Day09: DayBase
    {
        public Day09()
        {
            Part1.Text = "--- Day 9: Movie Theater ---\r\nYou slide down the firepole in the corner of the playground and land in the North Pole base movie theater!\r\n\r\nThe movie theater has a big tile floor with an interesting pattern. Elves here are redecorating the theater by switching out some of the square tiles in the big grid they form. Some of the tiles are red; the Elves would like to find the largest rectangle that uses red tiles for two of its opposite corners. They even have a list of where the red tiles are located in the grid (your puzzle input).\r\n\r\nFor example:\r\n\r\n7,1\r\n11,1\r\n11,7\r\n9,7\r\n9,5\r\n2,5\r\n2,3\r\n7,3\r\nShowing red tiles as # and other tiles as ., the above arrangement of red tiles would look like this:\r\n\r\n..............\r\n.......#...#..\r\n..............\r\n..#....#......\r\n..............\r\n..#......#....\r\n..............\r\n.........#.#..\r\n..............\r\nYou can choose any two red tiles as the opposite corners of your rectangle; your goal is to find the largest rectangle possible.\r\n\r\nFor example, you could make a rectangle (shown as O) with an area of 24 between 2,5 and 9,7:\r\n\r\n..............\r\n.......#...#..\r\n..............\r\n..#....#......\r\n..............\r\n..OOOOOOOO....\r\n..OOOOOOOO....\r\n..OOOOOOOO.#..\r\n..............\r\nOr, you could make a rectangle with area 35 between 7,1 and 11,7:\r\n\r\n..............\r\n.......OOOOO..\r\n.......OOOOO..\r\n..#....OOOOO..\r\n.......OOOOO..\r\n..#....OOOOO..\r\n.......OOOOO..\r\n.......OOOOO..\r\n..............\r\nYou could even make a thin rectangle with an area of only 6 between 7,3 and 2,3:\r\n\r\n..............\r\n.......#...#..\r\n..............\r\n..OOOOOO......\r\n..............\r\n..#......#....\r\n..............\r\n.........#.#..\r\n..............\r\nUltimately, the largest rectangle you can make in this example has area 50. One way to do this is between 2,5 and 11,1:\r\n\r\n..............\r\n..OOOOOOOOOO..\r\n..OOOOOOOOOO..\r\n..OOOOOOOOOO..\r\n..OOOOOOOOOO..\r\n..OOOOOOOOOO..\r\n..............\r\n.........#.#..\r\n..............\r\nUsing two red tiles as opposite corners, what is the largest area of any rectangle you can make?";
            Part1.Input = "97994,50070\r\n97994,51278\r\n97682,51278\r\n97682,52505\r\n97995,52505\r\n97995,53745\r\n98244,53745\r\n98244,54964\r\n98109,54964\r\n98109,56103\r\n97365,56103\r\n97365,57313\r\n97276,57313\r\n97276,58596\r\n97556,58596\r\n97556,59830\r\n97479,59830\r\n97479,60989\r\n97039,60989\r\n97039,62039\r\n96217,62039\r\n96217,63145\r\n95686,63145\r\n95686,64448\r\n95814,64448\r\n95814,65748\r\n95853,65748\r\n95853,66647\r\n94747,66647\r\n94747,67740\r\n94221,67740\r\n94221,69177\r\n94508,69177\r\n94508,69966\r\n93286,69966\r\n93286,71118\r\n92891,71118\r\n92891,72251\r\n92444,72251\r\n92444,73132\r\n91532,73132\r\n91532,74291\r\n91126,74291\r\n91126,75674\r\n91054,75674\r\n91054,76263\r\n89722,76263\r\n89722,77520\r\n89415,77520\r\n89415,78190\r\n88271,78190\r\n88271,79203\r\n87612,79203\r\n87612,80165\r\n86883,80165\r\n86883,81041\r\n86051,81041\r\n86051,82014\r\n85329,82014\r\n85329,83391\r\n85024,83391\r\n85024,83904\r\n83804,83904\r\n83804,84522\r\n82719,84522\r\n82719,85478\r\n81958,85478\r\n81958,86562\r\n81294,86562\r\n81294,86931\r\n80022,86931\r\n80022,88355\r\n79598,88355\r\n79598,88998\r\n78548,88998\r\n78548,89076\r\n77112,89076\r\n77112,89777\r\n76131,89777\r\n76131,91003\r\n75473,91003\r\n75473,91653\r\n74437,91653\r\n74437,91715\r\n73073,91715\r\n73073,92720\r\n72235,92720\r\n72235,93032\r\n71029,93032\r\n71029,93510\r\n69913,93510\r\n69913,93849\r\n68740,93849\r\n68740,94361\r\n67644,94361\r\n67644,94984\r\n66584,94984\r\n66584,95653\r\n65529,95653\r\n65529,96098\r\n64388,96098\r\n64388,96560\r\n63248,96560\r\n63248,96428\r\n61948,96428\r\n61948,96495\r\n60717,96495\r\n60717,96844\r\n59554,96844\r\n59554,97070\r\n58364,97070\r\n58364,97854\r\n57258,97854\r\n57258,98024\r\n56044,98024\r\n56044,98135\r\n54823,98135\r\n54823,97727\r\n53563,97727\r\n53563,97475\r\n52337,97475\r\n52337,97900\r\n51143,97900\r\n51143,97724\r\n49929,97724\r\n49929,98019\r\n48712,98019\r\n48712,98154\r\n47486,98154\r\n47486,98236\r\n46254,98236\r\n46254,98092\r\n45037,98092\r\n45037,97874\r\n43830,97874\r\n43830,97381\r\n42669,97381\r\n42669,97498\r\n41414,97498\r\n41414,97371\r\n40191,97371\r\n40191,96505\r\n39135,96505\r\n39135,96596\r\n37861,96596\r\n37861,96307\r\n36675,96307\r\n36675,96011\r\n35489,96011\r\n35489,95113\r\n34505,95113\r\n34505,94957\r\n33274,94957\r\n33274,94735\r\n32053,94735\r\n32053,94046\r\n31020,94046\r\n31020,93731\r\n29828,93731\r\n29828,93348\r\n28657,93348\r\n28657,92289\r\n27829,92289\r\n27829,91861\r\n26684,91861\r\n26684,91469\r\n25505,91469\r\n25505,90441\r\n24709,90441\r\n24709,90456\r\n23251,90456\r\n23251,89722\r\n22264,89722\r\n22264,88735\r\n21468,88735\r\n21468,87709\r\n20721,87709\r\n20721,87366\r\n19439,87366\r\n19439,86196\r\n18833,86196\r\n18833,85478\r\n17850,85478\r\n17850,85024\r\n16607,85024\r\n16607,83796\r\n16103,83796\r\n16103,83109\r\n15065,83109\r\n15065,82305\r\n14136,82305\r\n14136,81022\r\n13755,81022\r\n13755,80387\r\n12620,80387\r\n12620,79261\r\n12081,79261\r\n12081,78324\r\n11307,78324\r\n11307,77449\r\n10437,77449\r\n10437,76125\r\n10231,76125\r\n10231,75270\r\n9324,75270\r\n9324,74200\r\n8749,74200\r\n8749,73000\r\n8417,73000\r\n8417,72212\r\n7323,72212\r\n7323,70999\r\n7029,70999\r\n7029,69923\r\n6468,69923\r\n6468,69035\r\n5460,69035\r\n5460,67816\r\n5205,67816\r\n5205,66499\r\n5246,66499\r\n5246,65319\r\n4964,65319\r\n4964,64209\r\n4474,64209\r\n4474,63212\r\n3565,63212\r\n3565,61927\r\n3651,61927\r\n3651,60738\r\n3411,60738\r\n3411,59645\r\n2710,59645\r\n2710,58413\r\n2657,58413\r\n2657,57226\r\n2355,57226\r\n2355,55990\r\n2399,55990\r\n2399,54814\r\n1949,54814\r\n1949,53595\r\n1849,53595\r\n1849,52341\r\n2448,52341\r\n2448,51146\r\n1944,51146\r\n1944,50065\r\n94598,50065\r\n94598,48717\r\n2169,48717\r\n2169,47489\r\n1906,47489\r\n1906,46273\r\n1996,46273\r\n1996,45076\r\n2283,45076\r\n2283,43838\r\n2187,43838\r\n2187,42737\r\n3057,42737\r\n3057,41440\r\n2645,41440\r\n2645,40280\r\n3055,40280\r\n3055,39120\r\n3429,39120\r\n3429,37828\r\n3274,37828\r\n3274,36754\r\n3965,36754\r\n3965,35579\r\n4275,35579\r\n4275,34377\r\n4513,34377\r\n4513,33327\r\n5185,33327\r\n5185,32309\r\n5900,32309\r\n5900,31151\r\n6256,31151\r\n6256,29783\r\n6170,29783\r\n6170,28753\r\n6846,28753\r\n6846,27522\r\n7122,27522\r\n7122,26666\r\n8107,26666\r\n8107,25368\r\n8297,25368\r\n8297,24548\r\n9301,24548\r\n9301,23431\r\n9815,23431\r\n9815,22558\r\n10697,22558\r\n10697,21334\r\n11083,21334\r\n11083,20740\r\n12314,20740\r\n12314,19686\r\n12935,19686\r\n12935,18704\r\n13654,18704\r\n13654,17977\r\n14661,17977\r\n14661,16842\r\n15221,16842\r\n15221,15856\r\n15957,15856\r\n15957,15485\r\n17288,15485\r\n17288,14164\r\n17720,14164\r\n17720,13794\r\n19011,13794\r\n19011,12618\r\n19611,12618\r\n19611,11630\r\n20390,11630\r\n20390,11270\r\n21648,11270\r\n21648,10386\r\n22514,10386\r\n22514,9894\r\n23652,9894\r\n23652,9053\r\n24561,9053\r\n24561,8745\r\n25796,8745\r\n25796,8325\r\n26949,8325\r\n26949,7285\r\n27767,7285\r\n27767,7219\r\n29093,7219\r\n29093,6721\r\n30191,6721\r\n30191,5999\r\n31194,5999\r\n31194,5092\r\n32138,5092\r\n32138,5165\r\n33470,5165\r\n33470,4821\r\n34632,4821\r\n34632,4323\r\n35742,4323\r\n35742,4226\r\n36975,4226\r\n36975,3808\r\n38112,3808\r\n38112,3519\r\n39286,3519\r\n39286,3211\r\n40456,3211\r\n40456,2462\r\n41552,2462\r\n41552,2979\r\n42867,2979\r\n42867,2613\r\n44035,2613\r\n44035,1875\r\n45178,1875\r\n45178,2010\r\n46416,2010\r\n46416,2152\r\n47644,2152\r\n47644,2087\r\n48856,2087\r\n48856,2499\r\n50070,2499\r\n50070,2291\r\n51279,2291\r\n51279,1773\r\n52517,1773\r\n52517,2521\r\n53686,2521\r\n53686,2466\r\n54904,2466\r\n54904,2421\r\n56130,2421\r\n56130,2980\r\n57274,2980\r\n57274,3195\r\n58460,3195\r\n58460,2978\r\n59735,2978\r\n59735,3035\r\n60971,3035\r\n60971,3947\r\n61996,3947\r\n61996,3800\r\n63293,3800\r\n63293,3990\r\n64510,3990\r\n64510,4924\r\n65481,4924\r\n65481,5179\r\n66674,5179\r\n66674,5726\r\n67760,5726\r\n67760,5941\r\n68983,5941\r\n68983,6523\r\n70053,6523\r\n70053,6737\r\n71300,6737\r\n71300,7305\r\n72382,7305\r\n72382,7710\r\n73554,7710\r\n73554,8877\r\n74289,8877\r\n74289,9362\r\n75412,9362\r\n75412,10309\r\n76242,10309\r\n76242,10551\r\n77543,10551\r\n77543,11204\r\n78576,11204\r\n78576,12164\r\n79376,12164\r\n79376,12717\r\n80491,12717\r\n80491,13412\r\n81503,13412\r\n81503,14593\r\n82084,14593\r\n82084,15145\r\n83229,15145\r\n83229,15950\r\n84150,15950\r\n84150,17034\r\n84782,17034\r\n84782,17694\r\n85863,17694\r\n85863,18932\r\n86297,18932\r\n86297,19445\r\n87585,19445\r\n87585,20914\r\n87690,20914\r\n87690,21842\r\n88464,21842\r\n88464,22561\r\n89546,22561\r\n89546,23717\r\n90007,23717\r\n90007,24543\r\n90975,24543\r\n90975,25513\r\n91737,25513\r\n91737,26805\r\n91934,26805\r\n91934,27736\r\n92775,27736\r\n92775,28815\r\n93348,28815\r\n93348,30007\r\n93680,30007\r\n93680,31263\r\n93839,31263\r\n93839,32086\r\n95037,32086\r\n95037,33557\r\n94598,33557\r\n94598,34686\r\n95017,34686\r\n95017,35644\r\n95992,35644\r\n95992,36904\r\n96023,36904\r\n96023,38064\r\n96379,38064\r\n96379,39183\r\n96924,39183\r\n96924,40440\r\n96868,40440\r\n96868,41593\r\n97302,41593\r\n97302,42850\r\n97132,42850\r\n97132,43965\r\n97949,43965\r\n97949,45203\r\n97868,45203\r\n97868,46434\r\n97749,46434\r\n97749,47650\r\n97724,47650\r\n97724,48856\r\n97917,48856\r\n97917,50070";

            Part2.Text = "--- Part Two ---\r\nNow, given the same instructions, find the position of the first character that causes him to enter the basement (floor -1). The first character in the instructions has position 1, the second character has position 2, and so on.\r\n\r\nFor example:\r\n\r\n) causes him to enter the basement at character position 1.\r\n()()) causes him to enter the basement at character position 5.\r\nWhat is the position of the character that causes Santa to first enter the basement?";
            Part2.Input = Part1.Input;
        }

        public override void DoPart1()
        {
            string[] sPoints = Part1.Input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            long maxArea = 0;

            List<Vector2I> points = new List<Vector2I>();
            foreach(string sp in sPoints)
            {
                string[] coords = sp.Split(',');
                int x = int.Parse(coords[0]);
                int y = int.Parse(coords[1]);
                points.Add( new Vector2I(x, y) );
            }

            for(int i = 0; i < points.Count-1; i++)
            {
                for(int j = i + 1; j < points.Count; j++)
                {
                    Vector2I p1 = points[i];
                    Vector2I p2 = points[j];

                    long xRange = (long)(Math.Abs(p1.X - p2.X)+1);
                    long yRange = (long)(Math.Abs(p2.Y - p1.Y)+1);
                    long area = xRange * yRange;

                    //Part1.Log += $"P1: {p1} P2: {p2} Area: {area}\r\n";

                    if (area > maxArea)
                        maxArea = area;
                }
            }

            Part1.Output = $"Maximale Fläche = {maxArea}";
        }

        public override void DoPart2()
        {
            var count = 0;
            int floor = 0;
            foreach (char c in Part2.Input)
            {
                count++;

                if (c == '(')
                    floor++;
                if (c == ')')
                    floor--;

                if(floor == -1)
                    break;
            }

            Part2.Output = $"Character = {count}";
        }
    }

    public class Vector2I
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Vector2I(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }
}
