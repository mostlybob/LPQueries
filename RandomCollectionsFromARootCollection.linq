<Query Kind="Program" />

void Main()
{
    var perms = new[] { "one", "two", "three" };

    var len = perms.Count();

    var cube = Math.Pow(len, 10);

    var userPermsCollection = new List<List<string>>();

    var rnd = BuildNewRandom();

    for (int i = 0; i < cube; i++)
    {
        var userPerms = new List<string>();
        var noOfPerms = rnd.Next(0, len);

        for (int j = 0; j <= noOfPerms; j++)
        {
            var perm = perms[rnd.Next(0, len)];
            var safety = 0;
            var stop = false;

            if (userPerms.Contains(perm) == false)
            {
                userPerms.Add(perm);
                continue;
            }

            while (userPerms.Contains(perm) && stop == false)
            {
                if (safety == 20)
                    stop = true;

                perm = perms[rnd.Next(0, len)];

                safety++;
            }

            if (stop)
                "stop got hit".Dump();

            userPerms.Add(perm);
        }

        var flattenedUserPermsCollection = userPermsCollection.Select(x => String.Join("", x));
        var flattenedUserPerms = String.Join("", userPerms);

        if (flattenedUserPermsCollection.Contains(flattenedUserPerms) == false)
            userPermsCollection.Add(userPerms);
        // - in this case, order matters
        // - may be in other cases order doesn't matter
        //   e.g. ["two", "three"] would be the same as ["three", "two"]
        // - that condition would require more sophisticated exclusion logic
    }

    userPermsCollection.Dump();
}

int seed = -1;

Random BuildNewRandom()
{
    while (seed == DateTime.Now.Millisecond)
    { }

    seed = DateTime.Now.Millisecond;

    return new Random(seed);
}