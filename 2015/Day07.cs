using Advent_of_Code.Elemente;
using System.Windows.Shapes;

namespace Advent_of_Code._2015
{
    internal class Day07: DayBase
    {
        public enum Operations { PROVIDE, AND, OR, NOT, LSHIFT, RSHIFT };

        public static Dictionary<string, int> Values = new Dictionary<string, int>();

        public List<Gate> Gates = new List<Gate>();

        public class Gate
        {
            public Operations Operation = Operations.PROVIDE;
            public string Input1;
            public int Input1Value = int.MinValue;
            public string Input2;
            public int Input2Value = int.MinValue;
            public string Output;
            public bool handled = false;

            public Gate(string description)
            {
                string[] parts = description.Split(" -> ");
                string instruction = parts[0];
                Output = parts[1];
                int value;
                if (int.TryParse(instruction, out value))
                {
                    Values[Output] = value;
                    handled = true;
                }
                else
                {
                    string[] tokens = instruction.Split(' ');
                    if(!int.TryParse(tokens[0], out Input1Value))
                        Input1 = tokens[0];

                    if (tokens.Length == 1)
                    {
                        //No action needed here
                    }
                    else if (tokens.Length == 2)
                    {
                        Operation = Operations.NOT;
                    }
                    else if (tokens.Length == 3)
                    {
                        if (!int.TryParse(tokens[2], out Input2Value))
                            Input2 = tokens[2];
    
                        switch (tokens[1])
                        {
                            case "AND":
                                Operation = Operations.AND;
                                break;
                            case "OR":
                                Operation = Operations.OR;
                                break;
                            case "LSHIFT":
                                Operation = Operations.LSHIFT;
                                break;
                            case "RSHIFT":
                                Operation = Operations.RSHIFT;
                                break;
                        }
                    }
                }
            }

            public bool CanHandle
            {
                get
                {
                    if (Input1Value == int.MinValue)
                    {
                        if (Input1 == null || (Input1 != null && !Values.ContainsKey(Input1)))
                            return false;
                    }

                    if (Input2Value == int.MinValue)
                    {
                        if(Input2 == null || (Input2 != null && !Values.ContainsKey(Input2)))
                            return false;
                    }

                    return true;
                }
            }

            public void Handle()
            {
                int val1 = Input1Value == int.MinValue ? Values[Input1] : Input1Value;
                int val2 = Input2Value == int.MinValue ? Values[Input2] : Input2Value;
                switch (Operation)
                {
                    case Operations.PROVIDE:
                        Values[Output] = val1;
                        break;
                    case Operations.NOT:
                        Values[Output] = ~val1 & 0xFFFF;
                        break;
                    case Operations.AND:
                        Values[Output] = val1 & val2;
                        break;
                    case Operations.OR:
                        Values[Output] = val1 | val2;
                        break;
                    case Operations.LSHIFT:
                        Values[Output] = (val1 << val2) & 0xFFFF;
                        break;
                    case Operations.RSHIFT:
                        Values[Output] = (val1 >> val2) & 0xFFFF;
                        break;
                }

                Console.WriteLine($"Handled gate: {Operation} {Input1}:{val1} {Input2}:{val2} -> {Output} = {Values[Output]}");
                handled = true;
            }
        }


        public Day07()
        {
            Part1.Text = "--- Day 7: Some Assembly Required ---\r\nThis year, Santa brought little Bobby Tables a set of wires and bitwise logic gates! Unfortunately, little Bobby is a little under the recommended age range, and he needs help assembling the circuit.\r\n\r\nEach wire has an identifier (some lowercase letters) and can carry a 16-bit signal (a number from 0 to 65535). A signal is provided to each wire by a gate, another wire, or some specific value. Each wire can only get a signal from one source, but can provide its signal to multiple destinations. A gate provides no signal until all of its inputs have a signal.\r\n\r\nThe included instructions booklet describes how to connect the parts together: x AND y -> z means to connect wires x and y to an AND gate, and then connect its output to wire z.\r\n\r\nFor example:\r\n\r\n123 -> x means that the signal 123 is provided to wire x.\r\nx AND y -> z means that the bitwise AND of wire x and wire y is provided to wire z.\r\np LSHIFT 2 -> q means that the value from wire p is left-shifted by 2 and then provided to wire q.\r\nNOT e -> f means that the bitwise complement of the value from wire e is provided to wire f.\r\nOther possible gates include OR (bitwise OR) and RSHIFT (right-shift). If, for some reason, you'd like to emulate the circuit instead, almost all programming languages (for example, C, JavaScript, or Python) provide operators for these gates.\r\n\r\nFor example, here is a simple circuit:\r\n\r\n123 -> x\r\n456 -> y\r\nx AND y -> d\r\nx OR y -> e\r\nx LSHIFT 2 -> f\r\ny RSHIFT 2 -> g\r\nNOT x -> h\r\nNOT y -> i\r\nAfter it is run, these are the signals on the wires:\r\n\r\nd: 72\r\ne: 507\r\nf: 492\r\ng: 114\r\nh: 65412\r\ni: 65079\r\nx: 123\r\ny: 456\r\nIn little Bobby's kit's instructions booklet (provided as your puzzle input), what signal is ultimately provided to wire a?";
            Part1.Input = "af AND ah -> ai\r\nNOT lk -> ll\r\nhz RSHIFT 1 -> is\r\nNOT go -> gp\r\ndu OR dt -> dv\r\nx RSHIFT 5 -> aa\r\nat OR az -> ba\r\neo LSHIFT 15 -> es\r\nci OR ct -> cu\r\nb RSHIFT 5 -> f\r\nfm OR fn -> fo\r\nNOT ag -> ah\r\nv OR w -> x\r\ng AND i -> j\r\nan LSHIFT 15 -> ar\r\n1 AND cx -> cy\r\njq AND jw -> jy\r\niu RSHIFT 5 -> ix\r\ngl AND gm -> go\r\nNOT bw -> bx\r\njp RSHIFT 3 -> jr\r\nhg AND hh -> hj\r\nbv AND bx -> by\r\ner OR es -> et\r\nkl OR kr -> ks\r\net RSHIFT 1 -> fm\r\ne AND f -> h\r\nu LSHIFT 1 -> ao\r\nhe RSHIFT 1 -> hx\r\neg AND ei -> ej\r\nbo AND bu -> bw\r\ndz OR ef -> eg\r\ndy RSHIFT 3 -> ea\r\ngl OR gm -> gn\r\nda LSHIFT 1 -> du\r\nau OR av -> aw\r\ngj OR gu -> gv\r\neu OR fa -> fb\r\nlg OR lm -> ln\r\ne OR f -> g\r\nNOT dm -> dn\r\nNOT l -> m\r\naq OR ar -> as\r\ngj RSHIFT 5 -> gm\r\nhm AND ho -> hp\r\nge LSHIFT 15 -> gi\r\njp RSHIFT 1 -> ki\r\nhg OR hh -> hi\r\nlc LSHIFT 1 -> lw\r\nkm OR kn -> ko\r\neq LSHIFT 1 -> fk\r\n1 AND am -> an\r\ngj RSHIFT 1 -> hc\r\naj AND al -> am\r\ngj AND gu -> gw\r\nko AND kq -> kr\r\nha OR gz -> hb\r\nbn OR by -> bz\r\niv OR jb -> jc\r\nNOT ac -> ad\r\nbo OR bu -> bv\r\nd AND j -> l\r\nbk LSHIFT 1 -> ce\r\nde OR dk -> dl\r\ndd RSHIFT 1 -> dw\r\nhz AND ik -> im\r\nNOT jd -> je\r\nfo RSHIFT 2 -> fp\r\nhb LSHIFT 1 -> hv\r\nlf RSHIFT 2 -> lg\r\ngj RSHIFT 3 -> gl\r\nki OR kj -> kk\r\nNOT ak -> al\r\nld OR le -> lf\r\nci RSHIFT 3 -> ck\r\n1 AND cc -> cd\r\nNOT kx -> ky\r\nfp OR fv -> fw\r\nev AND ew -> ey\r\ndt LSHIFT 15 -> dx\r\nNOT ax -> ay\r\nbp AND bq -> bs\r\nNOT ii -> ij\r\nci AND ct -> cv\r\niq OR ip -> ir\r\nx RSHIFT 2 -> y\r\nfq OR fr -> fs\r\nbn RSHIFT 5 -> bq\r\n0 -> c\r\n14146 -> b\r\nd OR j -> k\r\nz OR aa -> ab\r\ngf OR ge -> gg\r\ndf OR dg -> dh\r\nNOT hj -> hk\r\nNOT di -> dj\r\nfj LSHIFT 15 -> fn\r\nlf RSHIFT 1 -> ly\r\nb AND n -> p\r\njq OR jw -> jx\r\ngn AND gp -> gq\r\nx RSHIFT 1 -> aq\r\nex AND ez -> fa\r\nNOT fc -> fd\r\nbj OR bi -> bk\r\nas RSHIFT 5 -> av\r\nhu LSHIFT 15 -> hy\r\nNOT gs -> gt\r\nfs AND fu -> fv\r\ndh AND dj -> dk\r\nbz AND cb -> cc\r\ndy RSHIFT 1 -> er\r\nhc OR hd -> he\r\nfo OR fz -> ga\r\nt OR s -> u\r\nb RSHIFT 2 -> d\r\nNOT jy -> jz\r\nhz RSHIFT 2 -> ia\r\nkk AND kv -> kx\r\nga AND gc -> gd\r\nfl LSHIFT 1 -> gf\r\nbn AND by -> ca\r\nNOT hr -> hs\r\nNOT bs -> bt\r\nlf RSHIFT 3 -> lh\r\nau AND av -> ax\r\n1 AND gd -> ge\r\njr OR js -> jt\r\nfw AND fy -> fz\r\nNOT iz -> ja\r\nc LSHIFT 1 -> t\r\ndy RSHIFT 5 -> eb\r\nbp OR bq -> br\r\nNOT h -> i\r\n1 AND ds -> dt\r\nab AND ad -> ae\r\nap LSHIFT 1 -> bj\r\nbr AND bt -> bu\r\nNOT ca -> cb\r\nNOT el -> em\r\ns LSHIFT 15 -> w\r\ngk OR gq -> gr\r\nff AND fh -> fi\r\nkf LSHIFT 15 -> kj\r\nfp AND fv -> fx\r\nlh OR li -> lj\r\nbn RSHIFT 3 -> bp\r\njp OR ka -> kb\r\nlw OR lv -> lx\r\niy AND ja -> jb\r\ndy OR ej -> ek\r\n1 AND bh -> bi\r\nNOT kt -> ku\r\nao OR an -> ap\r\nia AND ig -> ii\r\nNOT ey -> ez\r\nbn RSHIFT 1 -> cg\r\nfk OR fj -> fl\r\nce OR cd -> cf\r\neu AND fa -> fc\r\nkg OR kf -> kh\r\njr AND js -> ju\r\niu RSHIFT 3 -> iw\r\ndf AND dg -> di\r\ndl AND dn -> do\r\nla LSHIFT 15 -> le\r\nfo RSHIFT 1 -> gh\r\nNOT gw -> gx\r\nNOT gb -> gc\r\nir LSHIFT 1 -> jl\r\nx AND ai -> ak\r\nhe RSHIFT 5 -> hh\r\n1 AND lu -> lv\r\nNOT ft -> fu\r\ngh OR gi -> gj\r\nlf RSHIFT 5 -> li\r\nx RSHIFT 3 -> z\r\nb RSHIFT 3 -> e\r\nhe RSHIFT 2 -> hf\r\nNOT fx -> fy\r\njt AND jv -> jw\r\nhx OR hy -> hz\r\njp AND ka -> kc\r\nfb AND fd -> fe\r\nhz OR ik -> il\r\nci RSHIFT 1 -> db\r\nfo AND fz -> gb\r\nfq AND fr -> ft\r\ngj RSHIFT 2 -> gk\r\ncg OR ch -> ci\r\ncd LSHIFT 15 -> ch\r\njm LSHIFT 1 -> kg\r\nih AND ij -> ik\r\nfo RSHIFT 3 -> fq\r\nfo RSHIFT 5 -> fr\r\n1 AND fi -> fj\r\n1 AND kz -> la\r\niu AND jf -> jh\r\ncq AND cs -> ct\r\ndv LSHIFT 1 -> ep\r\nhf OR hl -> hm\r\nkm AND kn -> kp\r\nde AND dk -> dm\r\ndd RSHIFT 5 -> dg\r\nNOT lo -> lp\r\nNOT ju -> jv\r\nNOT fg -> fh\r\ncm AND co -> cp\r\nea AND eb -> ed\r\ndd RSHIFT 3 -> df\r\ngr AND gt -> gu\r\nep OR eo -> eq\r\ncj AND cp -> cr\r\nlf OR lq -> lr\r\ngg LSHIFT 1 -> ha\r\net RSHIFT 2 -> eu\r\nNOT jh -> ji\r\nek AND em -> en\r\njk LSHIFT 15 -> jo\r\nia OR ig -> ih\r\ngv AND gx -> gy\r\net AND fe -> fg\r\nlh AND li -> lk\r\n1 AND io -> ip\r\nkb AND kd -> ke\r\nkk RSHIFT 5 -> kn\r\nid AND if -> ig\r\nNOT ls -> lt\r\ndw OR dx -> dy\r\ndd AND do -> dq\r\nlf AND lq -> ls\r\nNOT kc -> kd\r\ndy AND ej -> el\r\n1 AND ke -> kf\r\net OR fe -> ff\r\nhz RSHIFT 5 -> ic\r\ndd OR do -> dp\r\ncj OR cp -> cq\r\nNOT dq -> dr\r\nkk RSHIFT 1 -> ld\r\njg AND ji -> jj\r\nhe OR hp -> hq\r\nhi AND hk -> hl\r\ndp AND dr -> ds\r\ndz AND ef -> eh\r\nhz RSHIFT 3 -> ib\r\ndb OR dc -> dd\r\nhw LSHIFT 1 -> iq\r\nhe AND hp -> hr\r\nNOT cr -> cs\r\nlg AND lm -> lo\r\nhv OR hu -> hw\r\nil AND in -> io\r\nNOT eh -> ei\r\ngz LSHIFT 15 -> hd\r\ngk AND gq -> gs\r\n1 AND en -> eo\r\nNOT kp -> kq\r\net RSHIFT 5 -> ew\r\nlj AND ll -> lm\r\nhe RSHIFT 3 -> hg\r\net RSHIFT 3 -> ev\r\nas AND bd -> bf\r\ncu AND cw -> cx\r\njx AND jz -> ka\r\nb OR n -> o\r\nbe AND bg -> bh\r\n1 AND ht -> hu\r\n1 AND gy -> gz\r\nNOT hn -> ho\r\nck OR cl -> cm\r\nec AND ee -> ef\r\nlv LSHIFT 15 -> lz\r\nks AND ku -> kv\r\nNOT ie -> if\r\nhf AND hl -> hn\r\n1 AND r -> s\r\nib AND ic -> ie\r\nhq AND hs -> ht\r\ny AND ae -> ag\r\nNOT ed -> ee\r\nbi LSHIFT 15 -> bm\r\ndy RSHIFT 2 -> dz\r\nci RSHIFT 2 -> cj\r\nNOT bf -> bg\r\nNOT im -> in\r\nev OR ew -> ex\r\nib OR ic -> id\r\nbn RSHIFT 2 -> bo\r\ndd RSHIFT 2 -> de\r\nbl OR bm -> bn\r\nas RSHIFT 1 -> bl\r\nea OR eb -> ec\r\nln AND lp -> lq\r\nkk RSHIFT 3 -> km\r\nis OR it -> iu\r\niu RSHIFT 2 -> iv\r\nas OR bd -> be\r\nip LSHIFT 15 -> it\r\niw OR ix -> iy\r\nkk RSHIFT 2 -> kl\r\nNOT bb -> bc\r\nci RSHIFT 5 -> cl\r\nly OR lz -> ma\r\nz AND aa -> ac\r\niu RSHIFT 1 -> jn\r\ncy LSHIFT 15 -> dc\r\ncf LSHIFT 1 -> cz\r\nas RSHIFT 3 -> au\r\ncz OR cy -> da\r\nkw AND ky -> kz\r\nlx -> a\r\niw AND ix -> iz\r\nlr AND lt -> lu\r\njp RSHIFT 5 -> js\r\naw AND ay -> az\r\njc AND je -> jf\r\nlb OR la -> lc\r\nNOT cn -> co\r\nkh LSHIFT 1 -> lb\r\n1 AND jj -> jk\r\ny OR ae -> af\r\nck AND cl -> cn\r\nkk OR kv -> kw\r\nNOT cv -> cw\r\nkl AND kr -> kt\r\niu OR jf -> jg\r\nat AND az -> bb\r\njp RSHIFT 2 -> jq\r\niv AND jb -> jd\r\njn OR jo -> jp\r\nx OR ai -> aj\r\nba AND bc -> bd\r\njl OR jk -> jm\r\nb RSHIFT 1 -> v\r\no AND q -> r\r\nNOT p -> q\r\nk AND m -> n\r\nas RSHIFT 2 -> at";

            Part2.Text = "--- Part Two ---\r\nNow, given the same instructions, find the position of the first character that causes him to enter the basement (floor -1). The first character in the instructions has position 1, the second character has position 2, and so on.\r\n\r\nFor example:\r\n\r\n) causes him to enter the basement at character position 1.\r\n()()) causes him to enter the basement at character position 5.\r\nWhat is the position of the character that causes Santa to first enter the basement?";
            Part2.Input = Part1.Input;
        }

        public override void DoPart1()
        {
            //Dictionary<string, int> wires = new Dictionary<string, int>();

            foreach(string line in Part1.Input.Split("\r\n"))
            {
                Gates.Add(new Gate(line));
            }

            //while (!Values.ContainsKey("a"))
            //{
                foreach (Gate gate in Gates)
                {
                    if (!gate.handled && gate.CanHandle)
                    {
                        gate.Handle();
                    }
                }
            //}

            Part1.Output = $"Azahl = {Values.Count}";
            //Part1.Output = $"Floor = {Values["a"]}";
        }

        public override void DoPart2()
        {
            var count = 0;


            Part2.Output = $"Character = {count}";
        }
    }
}
