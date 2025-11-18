using Advent_of_Code.Elemente;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Shapes;

namespace Advent_of_Code._2015
{
    internal class Day06: DayBase
    {
        public enum LightEnum { ON, OFF, TOGGLE };

        public Day06()
        {
            Part1.Text = "--- Day 6: Probably a Fire Hazard ---\r\nBecause your neighbors keep defeating you in the holiday house decorating contest year after year, you've decided to deploy one million lights in a 1000x1000 grid.\r\n\r\nFurthermore, because you've been especially nice this year, Santa has mailed you instructions on how to display the ideal lighting configuration.\r\n\r\nLights in your grid are numbered from 0 to 999 in each direction; the lights at each corner are at 0,0, 0,999, 999,999, and 999,0. The instructions include whether to turn on, turn off, or toggle various inclusive ranges given as coordinate pairs. Each coordinate pair represents opposite corners of a rectangle, inclusive; a coordinate pair like 0,0 through 2,2 therefore refers to 9 lights in a 3x3 square. The lights all start turned off.\r\n\r\nTo defeat your neighbors this year, all you have to do is set up your lights by doing the instructions Santa sent you in order.\r\n\r\nFor example:\r\n\r\nturn on 0,0 through 999,999 would turn on (or leave on) every light.\r\ntoggle 0,0 through 999,0 would toggle the first line of 1000 lights, turning off the ones that were on, and turning on the ones that were off.\r\nturn off 499,499 through 500,500 would turn off (or leave off) the middle four lights.\r\nAfter following the instructions, how many lights are lit?";
            Part1.Input = "turn on 887,9 through 959,629\r\nturn on 454,398 through 844,448\r\nturn off 539,243 through 559,965\r\nturn off 370,819 through 676,868\r\nturn off 145,40 through 370,997\r\nturn off 301,3 through 808,453\r\nturn on 351,678 through 951,908\r\ntoggle 720,196 through 897,994\r\ntoggle 831,394 through 904,860\r\ntoggle 753,664 through 970,926\r\nturn off 150,300 through 213,740\r\nturn on 141,242 through 932,871\r\ntoggle 294,259 through 474,326\r\ntoggle 678,333 through 752,957\r\ntoggle 393,804 through 510,976\r\nturn off 6,964 through 411,976\r\nturn off 33,572 through 978,590\r\nturn on 579,693 through 650,978\r\nturn on 150,20 through 652,719\r\nturn off 782,143 through 808,802\r\nturn off 240,377 through 761,468\r\nturn off 899,828 through 958,967\r\nturn on 613,565 through 952,659\r\nturn on 295,36 through 964,978\r\ntoggle 846,296 through 969,528\r\nturn off 211,254 through 529,491\r\nturn off 231,594 through 406,794\r\nturn off 169,791 through 758,942\r\nturn on 955,440 through 980,477\r\ntoggle 944,498 through 995,928\r\nturn on 519,391 through 605,718\r\ntoggle 521,303 through 617,366\r\nturn off 524,349 through 694,791\r\ntoggle 391,87 through 499,792\r\ntoggle 562,527 through 668,935\r\nturn off 68,358 through 857,453\r\ntoggle 815,811 through 889,828\r\nturn off 666,61 through 768,87\r\nturn on 27,501 through 921,952\r\nturn on 953,102 through 983,471\r\nturn on 277,552 through 451,723\r\nturn off 64,253 through 655,960\r\nturn on 47,485 through 734,977\r\nturn off 59,119 through 699,734\r\ntoggle 407,898 through 493,955\r\ntoggle 912,966 through 949,991\r\nturn on 479,990 through 895,990\r\ntoggle 390,589 through 869,766\r\ntoggle 593,903 through 926,943\r\ntoggle 358,439 through 870,528\r\nturn off 649,410 through 652,875\r\nturn on 629,834 through 712,895\r\ntoggle 254,555 through 770,901\r\ntoggle 641,832 through 947,850\r\nturn on 268,448 through 743,777\r\nturn off 512,123 through 625,874\r\nturn off 498,262 through 930,811\r\nturn off 835,158 through 886,242\r\ntoggle 546,310 through 607,773\r\nturn on 501,505 through 896,909\r\nturn off 666,796 through 817,924\r\ntoggle 987,789 through 993,809\r\ntoggle 745,8 through 860,693\r\ntoggle 181,983 through 731,988\r\nturn on 826,174 through 924,883\r\nturn on 239,228 through 843,993\r\nturn on 205,613 through 891,667\r\ntoggle 867,873 through 984,896\r\nturn on 628,251 through 677,681\r\ntoggle 276,956 through 631,964\r\nturn on 78,358 through 974,713\r\nturn on 521,360 through 773,597\r\nturn off 963,52 through 979,502\r\nturn on 117,151 through 934,622\r\ntoggle 237,91 through 528,164\r\nturn on 944,269 through 975,453\r\ntoggle 979,460 through 988,964\r\nturn off 440,254 through 681,507\r\ntoggle 347,100 through 896,785\r\nturn off 329,592 through 369,985\r\nturn on 931,960 through 979,985\r\ntoggle 703,3 through 776,36\r\ntoggle 798,120 through 908,550\r\nturn off 186,605 through 914,709\r\nturn off 921,725 through 979,956\r\ntoggle 167,34 through 735,249\r\nturn on 726,781 through 987,936\r\ntoggle 720,336 through 847,756\r\nturn on 171,630 through 656,769\r\nturn off 417,276 through 751,500\r\ntoggle 559,485 through 584,534\r\nturn on 568,629 through 690,873\r\ntoggle 248,712 through 277,988\r\ntoggle 345,594 through 812,723\r\nturn off 800,108 through 834,618\r\nturn off 967,439 through 986,869\r\nturn on 842,209 through 955,529\r\nturn on 132,653 through 357,696\r\nturn on 817,38 through 973,662\r\nturn off 569,816 through 721,861\r\nturn on 568,429 through 945,724\r\nturn on 77,458 through 844,685\r\nturn off 138,78 through 498,851\r\nturn on 136,21 through 252,986\r\nturn off 2,460 through 863,472\r\nturn on 172,81 through 839,332\r\nturn on 123,216 through 703,384\r\nturn off 879,644 through 944,887\r\ntoggle 227,491 through 504,793\r\ntoggle 580,418 through 741,479\r\ntoggle 65,276 through 414,299\r\ntoggle 482,486 through 838,931\r\nturn off 557,768 through 950,927\r\nturn off 615,617 through 955,864\r\nturn on 859,886 through 923,919\r\nturn on 391,330 through 499,971\r\ntoggle 521,835 through 613,847\r\nturn on 822,787 through 989,847\r\nturn on 192,142 through 357,846\r\nturn off 564,945 through 985,945\r\nturn off 479,361 through 703,799\r\ntoggle 56,481 through 489,978\r\nturn off 632,991 through 774,998\r\ntoggle 723,526 through 945,792\r\nturn on 344,149 through 441,640\r\ntoggle 568,927 through 624,952\r\nturn on 621,784 through 970,788\r\ntoggle 665,783 through 795,981\r\ntoggle 386,610 through 817,730\r\ntoggle 440,399 through 734,417\r\ntoggle 939,201 through 978,803\r\nturn off 395,883 through 554,929\r\nturn on 340,309 through 637,561\r\nturn off 875,147 through 946,481\r\nturn off 945,837 through 957,922\r\nturn off 429,982 through 691,991\r\ntoggle 227,137 through 439,822\r\ntoggle 4,848 through 7,932\r\nturn off 545,146 through 756,943\r\nturn on 763,863 through 937,994\r\nturn on 232,94 through 404,502\r\nturn off 742,254 through 930,512\r\nturn on 91,931 through 101,942\r\ntoggle 585,106 through 651,425\r\nturn on 506,700 through 567,960\r\nturn off 548,44 through 718,352\r\nturn off 194,827 through 673,859\r\nturn off 6,645 through 509,764\r\nturn off 13,230 through 821,361\r\nturn on 734,629 through 919,631\r\ntoggle 788,552 through 957,972\r\ntoggle 244,747 through 849,773\r\nturn off 162,553 through 276,887\r\nturn off 569,577 through 587,604\r\nturn off 799,482 through 854,956\r\nturn on 744,535 through 909,802\r\ntoggle 330,641 through 396,986\r\nturn off 927,458 through 966,564\r\ntoggle 984,486 through 986,913\r\ntoggle 519,682 through 632,708\r\nturn on 984,977 through 989,986\r\ntoggle 766,423 through 934,495\r\nturn on 17,509 through 947,718\r\nturn on 413,783 through 631,903\r\nturn on 482,370 through 493,688\r\nturn on 433,859 through 628,938\r\nturn off 769,549 through 945,810\r\nturn on 178,853 through 539,941\r\nturn off 203,251 through 692,433\r\nturn off 525,638 through 955,794\r\nturn on 169,70 through 764,939\r\ntoggle 59,352 through 896,404\r\ntoggle 143,245 through 707,320\r\nturn off 103,35 through 160,949\r\ntoggle 496,24 through 669,507\r\nturn off 581,847 through 847,903\r\nturn on 689,153 through 733,562\r\nturn on 821,487 through 839,699\r\nturn on 837,627 through 978,723\r\ntoggle 96,748 through 973,753\r\ntoggle 99,818 through 609,995\r\nturn on 731,193 through 756,509\r\nturn off 622,55 through 813,365\r\nturn on 456,490 through 576,548\r\nturn on 48,421 through 163,674\r\nturn off 853,861 through 924,964\r\nturn off 59,963 through 556,987\r\nturn on 458,710 through 688,847\r\ntoggle 12,484 through 878,562\r\nturn off 241,964 through 799,983\r\nturn off 434,299 through 845,772\r\ntoggle 896,725 through 956,847\r\nturn on 740,289 through 784,345\r\nturn off 395,840 through 822,845\r\nturn on 955,224 through 996,953\r\nturn off 710,186 through 957,722\r\nturn off 485,949 through 869,985\r\nturn on 848,209 through 975,376\r\ntoggle 221,241 through 906,384\r\nturn on 588,49 through 927,496\r\nturn on 273,332 through 735,725\r\nturn on 505,962 through 895,962\r\ntoggle 820,112 through 923,143\r\nturn on 919,792 through 978,982\r\ntoggle 489,461 through 910,737\r\nturn off 202,642 through 638,940\r\nturn off 708,953 through 970,960\r\ntoggle 437,291 through 546,381\r\nturn on 409,358 through 837,479\r\nturn off 756,279 through 870,943\r\nturn off 154,657 through 375,703\r\nturn off 524,622 through 995,779\r\ntoggle 514,221 through 651,850\r\ntoggle 808,464 through 886,646\r\ntoggle 483,537 through 739,840\r\ntoggle 654,769 through 831,825\r\nturn off 326,37 through 631,69\r\nturn off 590,570 through 926,656\r\nturn off 881,913 through 911,998\r\nturn on 996,102 through 998,616\r\nturn off 677,503 through 828,563\r\nturn on 860,251 through 877,441\r\nturn off 964,100 through 982,377\r\ntoggle 888,403 through 961,597\r\nturn off 632,240 through 938,968\r\ntoggle 731,176 through 932,413\r\nturn on 5,498 through 203,835\r\nturn on 819,352 through 929,855\r\ntoggle 393,813 through 832,816\r\ntoggle 725,689 through 967,888\r\nturn on 968,950 through 969,983\r\nturn off 152,628 through 582,896\r\nturn off 165,844 through 459,935\r\nturn off 882,741 through 974,786\r\nturn off 283,179 through 731,899\r\ntoggle 197,366 through 682,445\r\nturn on 106,309 through 120,813\r\ntoggle 950,387 through 967,782\r\nturn off 274,603 through 383,759\r\nturn off 155,665 through 284,787\r\ntoggle 551,871 through 860,962\r\nturn off 30,826 through 598,892\r\ntoggle 76,552 through 977,888\r\nturn on 938,180 through 994,997\r\ntoggle 62,381 through 993,656\r\ntoggle 625,861 through 921,941\r\nturn on 685,311 through 872,521\r\nturn on 124,934 through 530,962\r\nturn on 606,379 through 961,867\r\nturn off 792,735 through 946,783\r\nturn on 417,480 through 860,598\r\ntoggle 178,91 through 481,887\r\nturn off 23,935 through 833,962\r\ntoggle 317,14 through 793,425\r\nturn on 986,89 through 999,613\r\nturn off 359,201 through 560,554\r\nturn off 729,494 through 942,626\r\nturn on 204,143 through 876,610\r\ntoggle 474,97 through 636,542\r\nturn off 902,924 through 976,973\r\nturn off 389,442 through 824,638\r\nturn off 622,863 through 798,863\r\nturn on 840,622 through 978,920\r\ntoggle 567,374 through 925,439\r\nturn off 643,319 through 935,662\r\ntoggle 185,42 through 294,810\r\nturn on 47,124 through 598,880\r\ntoggle 828,303 through 979,770\r\nturn off 174,272 through 280,311\r\nturn off 540,50 through 880,212\r\nturn on 141,994 through 221,998\r\nturn on 476,695 through 483,901\r\nturn on 960,216 through 972,502\r\ntoggle 752,335 through 957,733\r\nturn off 419,713 through 537,998\r\ntoggle 772,846 through 994,888\r\nturn on 881,159 through 902,312\r\nturn off 537,651 through 641,816\r\ntoggle 561,947 through 638,965\r\nturn on 368,458 through 437,612\r\nturn on 290,149 through 705,919\r\nturn on 711,918 through 974,945\r\ntoggle 916,242 through 926,786\r\ntoggle 522,272 through 773,314\r\nturn on 432,897 through 440,954\r\nturn off 132,169 through 775,380\r\ntoggle 52,205 through 693,747\r\ntoggle 926,309 through 976,669\r\nturn off 838,342 through 938,444\r\nturn on 144,431 through 260,951\r\ntoggle 780,318 through 975,495\r\nturn off 185,412 through 796,541\r\nturn on 879,548 through 892,860\r\nturn on 294,132 through 460,338\r\nturn on 823,500 through 899,529\r\nturn off 225,603 through 483,920\r\ntoggle 717,493 through 930,875\r\ntoggle 534,948 through 599,968\r\nturn on 522,730 through 968,950\r\nturn off 102,229 through 674,529";

            Part2.Text = "--- Part Two ---\r\nNow, given the same instructions, find the position of the first character that causes him to enter the basement (floor -1). The first character in the instructions has position 1, the second character has position 2, and so on.\r\n\r\nFor example:\r\n\r\n) causes him to enter the basement at character position 1.\r\n()()) causes him to enter the basement at character position 5.\r\nWhat is the position of the character that causes Santa to first enter the basement?";
            Part2.Input = Part1.Input;
        }

        public override void DoPart1()
        {
            int ligths = 0;
            int[,] grid = new int[1000, 1000];

            string[] lines = Part1.Input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            foreach(string line in lines)
            {
                LightEnum ligts = LightEnum.TOGGLE;
                Vector2 from;
                Vector2 to;

                string[] parts = line.Split(' ');
                if (parts.Length == 4)
                {
                    from = ParseCoord(parts[1]);
                    to = ParseCoord(parts[3]);
                }
                else
                {
                    if (parts[1] == "on")
                        ligts = LightEnum.ON;
                    else
                        ligts = LightEnum.OFF;

                    from = ParseCoord(parts[2]);
                    to = ParseCoord(parts[4]);
                }

                for(int x = (int)from.X; x <= (int)to.X; x++)
                {
                    for (int y = (int)from.Y; y <= (int)to.Y; y++)
                    {
                        switch (ligts)
                        {
                            case LightEnum.ON:
                                grid[x, y] = 1;
                                break;
                            case LightEnum.OFF:
                                grid[x, y] = 0;
                                break;
                            case LightEnum.TOGGLE:
                                grid[x, y] = grid[x, y] == 1 ? 0 : 1;
                                break;
                        }
                    }
                }
            }

            for(int x = 0; x < 1000; x++)
            {
                for(int y = 0; y < 1000; y++)
                {
                    if (grid[x, y] == 1)
                        ligths++;
                }
            }


            Part1.Output = $"Ligths = {ligths}";
        }

        Vector2 ParseCoord(string coord)
        {
            string[] parts = coord.Split(',');
            return new Vector2(int.Parse(parts[0]), int.Parse(parts[1]));
        }

        public override void DoPart2()
        {
            int ligths = 0;
            int[,] grid = new int[1000, 1000];

            string[] lines = Part1.Input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                LightEnum ligts = LightEnum.TOGGLE;
                Vector2 from;
                Vector2 to;

                string[] parts = line.Split(' ');
                if (parts.Length == 4)
                {
                    from = ParseCoord(parts[1]);
                    to = ParseCoord(parts[3]);
                }
                else
                {
                    if (parts[1] == "on")
                        ligts = LightEnum.ON;
                    else
                        ligts = LightEnum.OFF;

                    from = ParseCoord(parts[2]);
                    to = ParseCoord(parts[4]);
                }

                for (int x = (int)from.X; x <= (int)to.X; x++)
                {
                    for (int y = (int)from.Y; y <= (int)to.Y; y++)
                    {
                        switch (ligts)
                        {
                            case LightEnum.ON:
                                grid[x, y] += 1;
                                break;
                            case LightEnum.OFF:
                                grid[x, y] -= 1;
                                if(grid[x, y] < 0)
                                    grid[x, y] = 0;
                                break;
                            case LightEnum.TOGGLE:
                                grid[x, y] += 2;
                                break;
                        }
                    }
                }
            }

            for (int x = 0; x < 1000; x++)
            {
                for (int y = 0; y < 1000; y++)
                {
                    ligths += grid[x, y];
                }
            }

            Part2.Output = $"Character = {ligths}";
        }
    }
}
