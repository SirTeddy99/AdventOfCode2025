// Advent of code 2025 - Day 5 : Cafeteria

int numOfFreshIngredients = 0;

/*string[] input =
{
    "3-5",
    "10-14",
    "16-20",
    "12-18",
    "",
    "1",
    "5",
    "8",
    "11",
    "17",
    "32"
};*/

string[] input = File.ReadAllLines("input.txt");

List<string> ranges = new();
List<string> ids = new();
bool appendRanges = true;

foreach (string row in input)
{
    if (row == "")
    {
        appendRanges = false;
        continue;
    }

    if (appendRanges)
        ranges.Add(row);
    else
        ids.Add(row);
}


foreach (string id in ids)
{
    //Console.WriteLine(id);

    foreach (string range in ranges)
    {
        int dashIndex = range.IndexOf('-');
        string startOfRange = range.Substring(0, dashIndex);
        string endOfRange = range.Substring(dashIndex + 1);

        if (double.Parse(id) < double.Parse(startOfRange))
        {
            continue;
        }

        if (double.Parse(id) > double.Parse(endOfRange))
        {
            continue ;
        }

        numOfFreshIngredients++;
        break;

    }
}

Console.WriteLine($"Number of fresh ingredients: {numOfFreshIngredients}");
