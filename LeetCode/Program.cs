using LeetCode;
using LeetCode.Tasks;
using LeetCode.Mettle;

//Utils.PrintResultEnumerable(expectedOutput, func, inputParameters);

Utils.PrintResult(0, new Task1().Solve, 1);


Console.WriteLine();

Utils.PrintResultEnumerable(new[] { -1, 1, 0, -1 }, new MinReverseOperations().Solve, 4, 2, new int[0], 4);
Utils.PrintResultEnumerable(new[] { 0, -1, -1, 1 }, new MinReverseOperations().Solve, 4, 0, new[] { 1, 2 }, 4);
Utils.PrintResultEnumerable(new[] { 0, -1, -1, -1, -1 }, new MinReverseOperations().Solve, 5, 0, new[] { 2, 4 }, 3);
Utils.PrintResultEnumerable(new[] { -1, -1, 0, -1 }, new MinReverseOperations().Solve, 4, 2, new[] { 0,1,3 }, 1);
Utils.PrintResultEnumerable(new[] { 0, -1, -1 }, new MinReverseOperations().Solve, 3, 0, new[] { 1 }, 2);
Utils.PrintResultEnumerable(new[] { 0, -1, -1, 1 }, new MinReverseOperations().Solve, 4, 0, new int[0], 4);

Console.WriteLine();

//Utils.PrintResultEnumerable(new[] { 8, 3 }, new GroupsOfStrings().GroupStrings, new[] { "ghnv", "uip", "tenv", "hvepx", "e", "ktc", "byjdt", "ulm", "cae", "ea" });
//Utils.PrintResultEnumerable(new[] { 1, 3 }, new GroupsOfStrings().GroupStrings, new[] { "abc", "ade", "abd" });
//Utils.PrintResultEnumerable(new[] { 2, 3 }, new GroupsOfStrings().GroupStrings, new[] { "a", "b", "ab", "cde" });
//Utils.PrintResultEnumerable(new[] { 6, 3 }, new GroupsOfStrings().GroupStrings, new[] { "zobly", "zyqv", "emjxk", "vd", "b", "c", "a", "wqvy", "fser" });
//Utils.PrintResultEnumerable(new[] { 7, 3 }, new GroupsOfStrings().GroupStrings, new[] { "xhg", "kove", "ti", "cs", "itfzx", "m", "nrszq", "suc", "gs" });
//Utils.PrintResultEnumerable(new[] { 7, 2 }, new GroupsOfStrings().GroupStrings, new[] { "p", "fhag", "ds", "bns", "pw", "ynvo", "pgz", "lgrx" });
//Utils.PrintResultEnumerable(new[] { 1, 5 }, new GroupsOfStrings().GroupStrings, new[] { "abc", "abc", "abc", "ade", "abd" });
//Utils.PrintResultEnumerable(new[] { 6, 3 }, new GroupsOfStrings().GroupStrings, new[] { "zobly", "zyqv", "emjxk", "vd", "b", "c", "a", "wqvy", "fser" });
//Utils.PrintResultEnumerable(new[] { 4, 1 }, new GroupsOfStrings().GroupStrings, new[] { "xo", "t", "uhc", "gf" });
//Utils.PrintResultEnumerable(new[] { 1, 3 }, new GroupsOfStrings().GroupStrings, new[] { "a", "ab", "abc" });
//Utils.PrintResultEnumerable(new[] { 75, 2 }, new GroupsOfStrings().GroupStrings, new[] { "eyxvifp", "jniobfegha", "kncwmhsxjp", "qvrbgnuhme", "lzmtnhxdo", "nkplcb", "xkmryis", "iybkj", "hwojzf", "brudki", "kveluogxp", "kncgfmezdv", "ykwbsxl", "ncvytgmwj", "krqzinuxm", "beucam", "ysbfve", "ibcqtsoum", "clwsozmiy", "uenqsm", "dlznvjryb", "gyshmt", "omiwl", "vjlbwspuhi", "tscaqndyhb", "zeyajcm", "evkiogcnpw", "vetndxlyf", "esbnptdfvy", "yxnqph", "adguvckty", "juayzhxl", "xzysojwn", "ijnxyahm", "fdjtoymsq", "aebnjrf", "nalbftmcd", "mqvjpsot", "ozdvxqjae", "ndiakougsf", "prufvybgcn", "rlaewuzhi", "onduwmgcep", "fvcxdk", "skbcje", "zpvyflhjdt", "vsrqxhwyf", "htgbncopf", "uxizl", "beurzqk", "mrbsi", "qgbwvdz", "oknrv", "gaxkuysrc", "hcwuebsmgr", "nyobvgect", "bpmgac", "vtxnuyrosq", "skdzaupny", "bdwvnziyk", "yrqwbxa", "poqwzaxe", "zedfbhj", "ibfawlte", "gytfca", "nmajcrfxus", "upizl", "ntjwfo", "buldyecj", "mvyza", "gqekoyxn", "poserhn", "xwndujhzs", "yimadqevoj", "ewfromcn", "zoyixfgt" });

//new SuperEggDrop().Test();

//Utils.PrintResult(14, new SuperEggDrop().Solve, 100, 10000);
//Utils.PrintResult(7, new SuperEggDrop().Solve, 14, 100);
//Utils.PrintResult(7, new SuperEggDrop().Solve, 3, 42);
//Utils.PrintResult(4, new SuperEggDrop().Solve, 2, 7);
//Utils.PrintResult(3, new SuperEggDrop().Solve, 2, 4);
//Utils.PrintResult(2, new SuperEggDrop().Solve, 2, 2);
//Utils.PrintResult(2, new SuperEggDrop().Solve, 2, 3);
//Utils.PrintResult(3, new SuperEggDrop().Solve, 2, 6);
//Utils.PrintResult(2, new SuperEggDrop().Solve, 1, 2);
//Utils.PrintResult(4, new SuperEggDrop().Solve, 3, 14);

//Utils.PrintResult(0, new ShortestSubarrayWithSumAtLeastK().Solve, LongInput.tle, 377684406);
//Utils.PrintResult(3, new ShortestSubarrayWithSumAtLeastK().Solve, new[] { 2, 6, 5, 9 }, 20);
//Utils.PrintResult(3, new ShortestSubarrayWithSumAtLeastK().Solve, new[] { -2, 6, 7, 9, -2, -7, 5, -3, 1, 8 }, 20);
//Utils.PrintResult(3, new ShortestSubarrayWithSumAtLeastK().Solve, new[] { -7, 4, 9, 9, -4, -2, 9, -4, -5, 6 }, 20);
//Utils.PrintResult(4, new ShortestSubarrayWithSumAtLeastK().Solve, new[] { 9, -4, -3, -3, 4, 3, 8, 6, -4, 9 }, 20);
//Utils.PrintResult(7, new ShortestSubarrayWithSumAtLeastK().Solve, new[] { -10, -5, -5, -18, 16, 7, -13, 10, 9, 14, 1, 1, 8, 12, -15, -20, 1, -14, 19, -7 }, 50);

//var rnd = new Random();

//while (true)
//{
//    var nums = Enumerable.Range(0, 10).Select(x => rnd.Next(-10, 10)).ToArray();
//    var res1 = new ShortestSubarrayWithSumAtLeastK().Solve(nums, 20);
//    var res2 = new ShortestSubarrayWithSumAtLeastK().SolveBrute(nums, 20);
//    if (res1 != res2)
//    {
//        Console.WriteLine($"{res1} {res2}");
//        Console.WriteLine(string.Join(", ", nums));
//    }
//}


//Utils.PrintResult(11, new ShortestSubarrayWithSumAtLeastK().Solve, new[] { 17985, -36292, -23941, 80618, 20594, -6181, 9181, 65796, -25716, 66593, -6873, 34062, 29878, 852, -4767, -36415, 11783, 8085, -41063, -39940, 74284, 66272, 82385, 51634, -48550, 9028, -30777, 86509, 44623, 9413, -38369, -1822, 46408, 35217, 72635, -16560, 85373, 52105, 39477, 3852, 45974, -21593, 15481, 47280, 73889, -42981, 54978, 95169, -19615, 93133 }, 387303);
//Utils.PrintResult(9, new ShortestSubarrayWithSumAtLeastK().Solve, new[] { -23, 51, -14, -6, 36, 33, 76, -26, -6, 58, -16, 1, 98, 2, -20, 48, -19, -41, -34, 62 }, 221);
//Utils.PrintResult(9, new ShortestSubarrayWithSumAtLeastK().Solve, new[] { -36, 10, -28, -42, 17, 83, 87, 79, 51, -26, 33, 53, 63, 61, 76, 34, 57, 68, 1, -30 }, 484);
//Utils.PrintResult(3, new ShortestSubarrayWithSumAtLeastK().Solve, new[] { 84, -37, 32, 40, 95 }, 167);
//Utils.PrintResult(3, new ShortestSubarrayWithSumAtLeastK().Solve, new[] { -1, 2, -1, 2 }, 3);
//Utils.PrintResult(3, new ShortestSubarrayWithSumAtLeastK().Solve, new[] { 2, -1, 2 }, 3);
//Utils.PrintResult(4, new ShortestSubarrayWithSumAtLeastK().Solve, new[] { 1, 93, 5, 54, 47, -7, 23, -28, -9, 43 }, 193);
//Utils.PrintResult(1, new ShortestSubarrayWithSumAtLeastK().Solve, new[] { 45, 95, 97, -34, -42 }, 21);
//Utils.PrintResult(1, new ShortestSubarrayWithSumAtLeastK().Solve, new[] { 1 }, 1);
//Utils.PrintResult(-1, new ShortestSubarrayWithSumAtLeastK().Solve, new[] { 1, 2 }, 4);

Utils.PrintResult(true, new ContainsDuplicateIII().ContainsNearbyAlmostDuplicate, new[] { 1, 2, 3, 1 }, 3, 0);
Utils.PrintResult(false, new ContainsDuplicateIII().ContainsNearbyAlmostDuplicate, new[] { 1, 5, 9, 1, 5, 9 }, 2, 3);

//Utils.PrintResult(true, new SplitArraySameAverage().Solve, new[] { 6795, 3310, 8624, 475, 7609, 7858, 7086, 8934, 6197, 2431, 3310, 760, 1432, 7518, 7068, 7182, 2681, 2679, 6461, 9928, 9651, 3258, 9346, 1666, 5400, 8384, 2751, 1234, 2183, 3520 });
//Utils.PrintResult(false, new SplitArraySameAverage().Solve, new[] { 9990, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30 });
//Utils.PrintResult(true, new SplitArraySameAverage().Solve, new[] { 5, 16, 4, 11, 4 });
//Utils.PrintResult(true, new SplitArraySameAverage().Solve, new[] { 18, 0, 16, 2 });
//Utils.PrintResult(true, new SplitArraySameAverage().Solve, new[] { 1, 2, 3, 4, 5, 6, 7, 8 });
//Utils.PrintResult(false, new SplitArraySameAverage().Solve, new[] { 3, 1 });

//Utils.PrintResult(1, new LongestIncreasingSubsequence2().LengthOfLIS, new[] { 1, 5 }, 1);
//Utils.PrintResult(2, new LongestIncreasingSubsequence2().LengthOfLIS, new[] { 1, 4 }, 3);
//Utils.PrintResult(5, new LongestIncreasingSubsequence2().LengthOfLIS, new[] { 4, 2, 1, 4, 3, 4, 5, 8, 15 }, 3);
//Utils.PrintResult(4, new LongestIncreasingSubsequence2().LengthOfLIS, new[] { 7, 4, 5, 1, 8, 12, 4, 7 }, 5);

//Utils.PrintResult(510488787, new CountNumberOfIdealArrays().IdealArrays, 184, 389);
//Utils.PrintResult(1, new CountNumberOfIdealArrays().IdealArrays, 10000, 1);
//Utils.PrintResult(10001, new CountNumberOfIdealArrays().IdealArrays, 10000, 2);
//Utils.PrintResult(3 + 9999 * 2, new CountNumberOfIdealArrays().IdealArrays, 10000, 3);
//Utils.PrintResult(4 + 9999 * 4 + 49985001, new CountNumberOfIdealArrays().IdealArrays, 10000, 4);
//Utils.PrintResult(34676649, new CountNumberOfIdealArrays().IdealArrays, 40, 85);
//Utils.PrintResult(10, new CountNumberOfIdealArrays().IdealArrays, 2, 5);
//Utils.PrintResult(11, new CountNumberOfIdealArrays().IdealArrays, 5, 3);

//Utils.PrintResult("1", new FindClosestPalindrome().NearestPalindromic, "0");
//Utils.PrintResult("0", new FindClosestPalindrome().NearestPalindromic, "1");
//Utils.PrintResult("10001", new FindClosestPalindrome().NearestPalindromic, "9999");
//Utils.PrintResult("9999", new FindClosestPalindrome().NearestPalindromic, "10001");
//Utils.PrintResult("999", new FindClosestPalindrome().NearestPalindromic, "1001");
//Utils.PrintResult("9", new FindClosestPalindrome().NearestPalindromic, "11");
//Utils.PrintResult("722313227", new FindClosestPalindrome().NearestPalindromic, "722312312");
//Utils.PrintResult("1991", new FindClosestPalindrome().NearestPalindromic, "2002");
//Utils.PrintResult("1837667381", new FindClosestPalindrome().NearestPalindromic, "1837722381");
//Utils.PrintResult("109901", new FindClosestPalindrome().NearestPalindromic, "110011");
//Utils.PrintResult("1221", new FindClosestPalindrome().NearestPalindromic, "1199");
//Utils.PrintResult("16361", new FindClosestPalindrome().NearestPalindromic, "16312");
//Utils.PrintResult("12421", new FindClosestPalindrome().NearestPalindromic, "12389");
//Utils.PrintResult("1080801", new FindClosestPalindrome().NearestPalindromic, "1081001");
//Utils.PrintResult("11011", new FindClosestPalindrome().NearestPalindromic, "11111");
//Utils.PrintResult("979", new FindClosestPalindrome().NearestPalindromic, "984");
//Utils.PrintResult("121", new FindClosestPalindrome().NearestPalindromic, "123");
//Utils.PrintResult("101", new FindClosestPalindrome().NearestPalindromic, "99");
//Utils.PrintResult("1221", new FindClosestPalindrome().NearestPalindromic, "1234");
//Utils.PrintResult("1221", new FindClosestPalindrome().NearestPalindromic, "1213");
//Utils.PrintResult("999", new FindClosestPalindrome().NearestPalindromic, "1000");

//var s = "kfedcbdngvlykqyrbvwbnaassgjifjxtawlafhcpjtpzfnbsqfasohevbbhkwmtnmixolfepkjmcbadqcljmsbonrngsgfqwzqiisbiwiqgtqtqddukgtjymbxzmtxrobuhkdxmdmqccrauzkrjisstznnkhupiandekzcchsrzwintkkzhvqomqmnbasynmvtxwydcvwoukqmgrpmgzqancuzapgncasxnbyznlrdvcbomdptjftgxdzeqzyavfdpseoxpvohpxtikyjfvskxyqbubgnseraxtrcrwjxloxymhqgaxwbbvzhjsbncqrlpdbiuakdjzjrbclhxgnjjyfrqyjchlsdrcwtdoktviqwjctlmzqemumgmjufcbixkfhzkugsvnkrrakccguybwhmuexiemqusltaaqrswsezccqzaputgaabrjdeihmkpzbojnusmhkwjdxvgiexwdkkazhhmlalgzvxgqgncfytrxuhkwhwcxhmlbvkhjcnyztepwnlpthozdqexvhxpvheopjrsjzkqrstczffkhkikelwydcbnghfiibeyabgegdgaqvasujmggltkvokmnsmontjzsmzoeeqenafvurbnbwqbizvaqxfgnoxasctfrwvqmoufvpajdkethlvbhbehxahcpcizocbchwfznhuqtblwepeqdhycrovqosmxxeeqaffjvvclmpcqdugndexexcykyusetuamymszlteobxkestwbzubpstbwrstuovlybycevedzgurqvlgkouvavcukccgixixsrndurvrkfegegnchbhockujlafxexlxhgysraviztkjymiqxrlldcixvfnzrpserrqycbfmesqbltywmandcqtluccbisfqzosbvedqhsxepdjevaasylvjmfpvyxqvclaalgxytiukyarojmzyovmiunkvqhkouhxxhbemavagrhteofpowvlpdunjjpwgcjibagfswrzwkgrwklppchvtukzncvoqorlsskyghkhrazwvyqqjfygmduhsfkrseddgmtdvlqeruxogmyttdqmdpmscspatkoifauivwjtbwisiiqztrllfqnjvbagrfylrpjudjmvwhdkhahyxlsfbkuuyofryfgblllzeacfiqqawridcbtqnroxwuqhyspqmwhxmjztqokofnkfvupcykszthicdgjbrgafpztktrcwtayoulnjaazigkinnpttghhyboiczvtswenshlmqyelnwhzqlswblqssiiynypfcxerlykpiyimkoodimdfdlzbwmlwflylcqwaflivqeonjswvowxgeoafmppodmfbvooodtnzgmhfnchenaaywqevklrpgajbmbxgiopofghlouhjfarjxlclcullsgyzhohowtragbkaebrvbkmxfxughlirtikheojbrrgxtqldfdnqxndzvfgajiltnqnuwavxbrvuiycsizunlglwnivpseyfwmgydmmpzhxkdtpuzpddacjmjhvncdoicedkimdgaqobdfagpggvjemstqbsshynyvhdyslgldvkapqgusmnuroqxcivjifkhrotomxodficktxmcytkbqitrlalpbtphowfgtzgfacabjodvivgykorvmxhzpqvskolkbfpbdgowlighossrlwiomgohfhgklmlnekniqfjmvvqvmimkeddfxnxwzzroospxvndynetghkgrakuslukqsrdtmjkblwrmwhzzojcwwogrjvnftdwwpoqcjqimvjbwgqgpeffjnwlzdyhkhwmvpwpcmjmdqneexqwcrvdxsfsnidwyflwxwngczklprhoazeeqwclrqvnicfvrtbqailbwrqxadxslouwdjycidupemdwhpkqekaxxprtdtmjficrhlvqidvgwkllaowyyajkxugqiztbpzvjqtpuyugkvdfcaczzruskvucsxtvroljnjojuzncatgnypbzwvilbajqqnjovqxcfunwwbxgshrjlajwveaswqegidfnedpxqdreddvawrpbllkcshlafnxyocbmwacytvgtoonlkukqhxwbfxcfnbgmrfcnkvtxmygiyjoyoljd";
//Utils.PrintResult(s.Substring(936, 1149), new FindSubstringWithGivenHash().SubStrHash, s, 71717, 94536, 1149, 39999);
//Utils.PrintResult("fjrejytcgflrnnxxsxowqbteycujnr", new FindSubstringWithGivenHash().SubStrHash, "kejydsxgcgyroavsefjrejytcgflrnnxxsxowqbteycujnrbaokjibq", 8, 54, 30, 16);
//Utils.PrintResult("ee", new FindSubstringWithGivenHash().SubStrHash, "leetcode", 7, 20, 2, 0);
//Utils.PrintResult("nekv", new FindSubstringWithGivenHash().SubStrHash, "xxterzixjqrghqyeketqeynekvqhc", 15, 94, 4, 16);
//Utils.PrintResult("fbx", new FindSubstringWithGivenHash().SubStrHash, "fbxzaad", 31, 100, 3, 32);


//Utils.PrintResult(6, new NumOfWays2SeparateNum().NumberOfCombinations, "24896");
//Utils.PrintResult(6, new NumOfWays2SeparateNumOld().NumberOfCombinations, "24896");
//Utils.PrintResult(101, new NumOfWays2SeparateNum().NumberOfCombinations, "9999999999999");
//Utils.PrintResult(2, new NumOfWays2SeparateNum().NumberOfCombinations, "327");
//Utils.PrintResult(-1, new NumOfWays2SeparateNum().NumberOfCombinations, new string(Enumerable.Repeat('1', 3500).ToArray()));

//Utils.PrintResult(true, ValidNumber.IsNumber, "2");
//Utils.PrintResult(true, ValidNumber.IsNumber, "0089");
//Utils.PrintResult(true, ValidNumber.IsNumber, "-0.1");
//Utils.PrintResult(true, ValidNumber.IsNumber, "+3.14");
//Utils.PrintResult(true, ValidNumber.IsNumber, "4.");
//Utils.PrintResult(true, ValidNumber.IsNumber, "-.9");
//Utils.PrintResult(true, ValidNumber.IsNumber, "2e10");
//Utils.PrintResult(true, ValidNumber.IsNumber, "-90E3");
//Utils.PrintResult(true, ValidNumber.IsNumber, "3e+7");
//Utils.PrintResult(true, ValidNumber.IsNumber, "+6e-1");
//Utils.PrintResult(true, ValidNumber.IsNumber, "53.5e93");
//Utils.PrintResult(true, ValidNumber.IsNumber, "-123.456e789");
//Utils.PrintResult(false, ValidNumber.IsNumber, "abc");
//Utils.PrintResult(false, ValidNumber.IsNumber, "1a");
//Utils.PrintResult(false, ValidNumber.IsNumber, "1e");
//Utils.PrintResult(false, ValidNumber.IsNumber, "e3");
//Utils.PrintResult(false, ValidNumber.IsNumber, "99e2.5");
//Utils.PrintResult(false, ValidNumber.IsNumber, "--6");
//Utils.PrintResult(false, ValidNumber.IsNumber, "-+3");
//Utils.PrintResult(false, ValidNumber.IsNumber, "95a54e53");

//Utils.PrintResult(0, new PartArrayIntoTwoToMinSumDiff().MinimumDifference, new[] { 2, -1, 0, 4, -2, -9 });
//Utils.PrintResult(2, new PartArrayIntoTwoToMinSumDiff().MinimumDifference, new[] { 3, 9, 7, 3 });
//Utils.PrintResult(72, new PartArrayIntoTwoToMinSumDiff().MinimumDifference, new[] { -36, 36 });
//Utils.PrintResult(11077, MinimumDifference.Run, new[] { -54, -48, -17, -31, -51, -97642, 38, 96, 80, 87, 78, -95, -38, 16, 11, 69840, -93, 46004, -22, -84, -23025, -42, -23, 29069, 69, -38, -26, -67, 24, -23 });
//Utils.PrintResult(2, MinimumDifference.Run, new[] { 3, 9, 7, 3 });
//Utils.PrintResult(60, MinimumDifference.Run, new[] { 27, 25, 32, 25, -71, -2 });
//Utils.PrintResult(1, MinimumDifference.Run, new[] { 7772197, 4460211, -7641449, -8856364, 546755, -3673029, 527497, -9392076, 3130315, -5309187, -4781283, 5919119, 3093450, 1132720, 6380128, -3954678, -1651499, -7944388, -3056827, 1610628, 7711173, 6595873, 302974, 7656726, -2572679, 0, 2121026, -5743797, -8897395, -9699694 });
//Utils.PrintResult(72, MinimumDifference.Run, new[] { -36, 36 });

//BookMyShow b; 

//b = new BookMyShow(576, 253413753);
//Utils.PrintResult(true, b.Scatter, 644966605, 481);
//Utils.PrintResultEnumerable(new int[0], b.Gather, 958624646, 498);
//Utils.PrintResult(true, b.Scatter, 780253385, 480);
//Utils.PrintResultEnumerable(new int[0], b.Gather, 880612591, 113);
//Utils.PrintResultEnumerable(new int[0], b.Gather, 793115993, 559);
//Utils.PrintResult(true, b.Scatter, 294354936, 133);
//Utils.PrintResult(true, b.Scatter, 955897057, 201);

//b = new BookMyShow(3, 999999999);
//Utils.PrintResult(true, b.Scatter, 1000000000, 2);
//Utils.PrintResultEnumerable(new[] { 2, 0 }, b.Gather, 999999999, 2);
//Utils.PrintResultEnumerable(new int[0], b.Gather, 999999999, 2);
//Utils.PrintResultEnumerable(new int[0], b.Gather, 999999999, 2);

//b = new BookMyShow(2, 5);
//Utils.PrintResultEnumerable(new[] { 0, 0 }, b.Gather, 4, 0);
//Utils.PrintResultEnumerable(new int[0], b.Gather, 2, 0);
//Utils.PrintResult(true, b.Scatter, 5, 1);
//Utils.PrintResult(false, b.Scatter, 5, 1);

//b = new BookMyShow(4, 5);
//Utils.PrintResult(true, b.Scatter, 6, 2);
//Utils.PrintResultEnumerable(new int[0], b.Gather, 6, 3);
//Utils.PrintResult(false, b.Scatter, 9, 1); 

//b = new BookMyShow(50000, 1);
//for (var i = 0; i < 50000; ++i)
//{
//    if (b.Scatter(50000, 49999) != false)
//    {
//        Console.WriteLine("Wrong!");
//        break;
//    }
//}

//Utils.PrintResult(3, new StrongPasswordChecker().Check, "...");
//Utils.PrintResult(23, new StrongPasswordChecker().Check, "FFF" + "FFF" + "FFF" + "FFF" + "FFF" + "111" + "111" + "111" + "111" + "111" + "111" + "11" + "AAA");
//Utils.PrintResult(1, new StrongPasswordChecker().Check, "aaaB1");
//Utils.PrintResult(2, new StrongPasswordChecker().Check, "xxxxx");
//Utils.PrintResult(3, new StrongPasswordChecker().Check, "12345678901" + "zzz" + "xxxxx" + "yyy");
//Utils.PrintResult(8, new StrongPasswordChecker().Check, "bb" + "aaa" + "aaa" + "aaa" + "aaa" + "aaa" + "ccc" + "ccc");
//Utils.PrintResult(3, new StrongPasswordChecker().Check, "123");
//Utils.PrintResult(3, new StrongPasswordChecker().Check, "111" + "111" + "111" + "1");
//Utils.PrintResult(2, new StrongPasswordChecker().Check, "ABABABABABABABABABAB1");
//Utils.PrintResult(6, new StrongPasswordChecker().Check, "");
//Utils.PrintResult(2, new StrongPasswordChecker().Check, "12345678");
//Utils.PrintResult(2, new StrongPasswordChecker().Check, "123444");
//Utils.PrintResult(2, new StrongPasswordChecker().Check, "444444");
//Utils.PrintResult(2, new StrongPasswordChecker().Check, "123456789012345678xxx");
//Utils.PrintResult(4, new StrongPasswordChecker().Check, "12345678901234567890xyz");

//Utils.PrintResult(true, WildcardMatching.IsMatch, "abcabczzzde", "*abc???de*");
//Utils.PrintResult(true, WildcardMatching.IsMatch, "", "*");
//Utils.PrintResult(true, WildcardMatching.IsMatch, "aa", "a*");
//Utils.PrintResult(true, WildcardMatching.IsMatch, "aa", "*a");
//Utils.PrintResult(true, WildcardMatching.IsMatch, "aa", "*");
//Utils.PrintResult(false, WildcardMatching.IsMatch, "abcd", "d*");
//Utils.PrintResult(false, WildcardMatching.IsMatch, "aaa", "");
//Utils.PrintResult(true, WildcardMatching.IsMatch, "aaa", "a*a");
//Utils.PrintResult(false, WildcardMatching.IsMatch, "aa", "a");
//Utils.PrintResult(false, WildcardMatching.IsMatch, "mississippi", "m??*ss*?i*pi");
//Utils.PrintResult(false, WildcardMatching.IsMatch, "aaabbbaabaaaaababaabaaabbabbbbbbbbaabababbabbbaaaaba", "a*******b");
//Utils.PrintResult(false, WildcardMatching.IsMatch, "abbabaaabbabbaababbabbbbbabbbabbbabaaaaababababbbabababaabbababaabbbbbbaaaabababbbaabbbbaabbbbababababbaabbaababaabbbababababbbbaaabbbbbabaaaabbababbbbaababaabbababbbbbababbbabaaaaaaaabbbbbaabaaababaaaabb", "**aa*****ba*a*bb**aa*ab****a*aaaaaa***a*aaaa**bbabb*b*b**aaaaaaaaa*a********ba*bbb***a*ba*bb*bb**a*b*bb");

//Utils.PrintResult(false, Regular.IsMatch, "a", ".*..a*");
//Utils.PrintResult(false, Regular.IsMatch, "abcd", "d*");
//Utils.PrintResult(true, Regular.IsMatch, "aaa", "ab*a*c*a");
//Utils.PrintResult(false, Regular.IsMatch, "mississippi", "mis*is*p*.");
//Utils.PrintResult(false, Regular.IsMatch, "ab", ".*c");
//Utils.PrintResult(false, Regular.IsMatch, "aaa", "");
//Utils.PrintResult(true, Regular.IsMatch, "aaa", "a*a");
//Utils.PrintResult(true, Regular.IsMatch, "ab", ".*");
//Utils.PrintResult(false, Regular.IsMatch, "aa", "a");
//Utils.PrintResult(true, Regular.IsMatch, "aa", "a*");

Console.WriteLine("Hello, World!");

