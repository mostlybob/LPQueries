<Query Kind="Program" />

void Main()
{
//    var something="a b  c   d     e          f                g";
//    
//    var builder=new StringBuilder(something);
//    
//    while (builder.ToString().Contains("  "))
//    {
//        builder.Replace("  ", " ");
//    }
//
//    $"|{builder.ToString()}|".Dump();

    var DealerId=1232456;

    var sql = $@"select ct.Name
                        from dbo.ConversicaConversationType ct
                        inner join  dbo.AccountLevelSettings als
                          on ct.ConversicaConversationTypeId = als.ConversicaConversationTypeId
                        where als.AutoAlertDealerId = {DealerId}";
    
    sql.Dump("original");
    //sql.Replace("\t", "#").Dump("tabs");
    //sql.Replace("\n", "#").Dump("new line");
    //sql.Replace("\r", "#").Dump("return");
    //sql.Replace(Environment.NewLine, "#").Dump("Environment.NewLine");
        
    
    StripExtraSpaces(sql, false).Dump("spaces only");
    StripExtraSpaces(sql).Dump("all whitespace characters");

}

private static string StripExtraSpaces(string input, bool stripAllExtraWhitespace = true)
{
    const string one_space = " ";
    const string two_spaces = "  ";

    var output = new System.Text.StringBuilder(input);

    if (stripAllExtraWhitespace)
    {
        output.Replace("\t", one_space);
        output.Replace(Environment.NewLine, one_space);
    }

    while (output.ToString().Contains(two_spaces))
    {
        output.Replace(two_spaces, one_space);
    }

    return output.ToString();
}
