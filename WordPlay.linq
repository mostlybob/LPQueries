<Query Kind="Program" />

void Main()
{
    var wordsWithDupes=BuildWordListWithDupes();
    
    var dict=new Dictionary<string,int>();
    
    foreach (var word in wordsWithDupes)
    {
        // needs to be there first
        //dict[word]++;
        
        if (dict.Keys.Contains(word))
            dict[word]++;
        else
            dict[word]=0;
    }
    
    dict.Dump();
}

const int testSize = 5;

List<string> BuildWordListWithDupes()
{
    var words = GetWords();

    var wordSelection = words.Take(testSize).ToArray();

    var searchWords = new List<string>();
    int j = 0, k = 0;
    for (int i = 0; i < testSize; i++)
    {

        var test = ++j % testSize;
        if (test == 0)
        {
            searchWords.Add(wordSelection[k++]);

            if (k == testSize - 1)
                k = 0;
        }
        foreach (var word in words)
        {
            searchWords.Add(word);
        }
    }

    return searchWords;
}

List<string> GetWords()
{
    return new List<string>
    {
        "spike",
        "rail",
        "handcuff",
        "sheave",
        "spindle",
        "umbles",
        "alcalde",
        "ganger",
        "chamber",
        "fear",
        "volitant",
        "dipper",
        "rubdown",
        "embroil",
        "toiletry",
        "trillium",
        "loser",
        "collet",
        "merlin",
        "moulding",
        "nuclide",
        "reindeer",
        "pricket",
        "cutinize",
        "wicked",
        "message",
        "plessor",
        "pratfall",
        "junkman",
        "caracole",
        "nutation",
        "bo",
        "linstock",
        "decent",
        "aloof",
        "dating",
        "crocket",
        "laverock",
        "librate",
        "pawn",
        "nepotism",
        "chausses",
        "lionfish",
        "opine",
        "jackpot",
        "popinjay",
        "warplane",
        "ogive",
        "lethargy",
        "bright",
        "polio",
        "bee",
        "bleed",
        "vanadium",
        "nexus",
        "panther",
        "gunshot",
        "protrude",
        "booze",
        "velar",
        "fugacity",
        "geese",
        "undine",
        "googly",
        "endorse",
        "penknife",
        "batt",
        "ever",
        "trilogy",
        "stopple",
        "thirsty",
        "cream",
        "topside",
        "agminate",
        "ocher",
        "scoff",
        "strap",
        "tadpole",
        "bemuse",
        "lorimer",
        "bicyclic",
        "uncle",
        "gorgerin",
        "proctor",
        "collie",
        "cycloid",
        "batch",
        "ambo",
        "stainer",
        "ravelin",
        "various",
        "infamous",
        "chasten",
        "hackbut",
        "chukka",
        "guanase",
        "underpin",
        "allheal",
        "web",
        "jaunty",
        "copyread",
        "egress",
        "nursing",
        "obtund",
        "columnar",
        "subplot",
        "matinee",
        "helminth",
        "vina",
        "unplug",
        "brainpan",
        "gryphon",
        "unhandy",
        "balmy",
        "built",
        "locoweed",
        "accrete",
        "lyrist",
        "coulee",
        "lathe"
    };
}

// Define other methods and classes here
