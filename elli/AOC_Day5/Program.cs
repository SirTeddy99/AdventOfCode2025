// Advent of code 2025 - Day 5 : Cafeteria

double numOfFreshIngredients = 0;
double numOfFreshIngredientsIDs = 0;

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

List<string> sortedRanges = ranges.OrderBy(r => double.Parse(r.Split('-')[0])).ToList();
List<string> finalRanges = [sortedRanges[0]];
int startAtIndex = 0;

for (int i = 1; i < sortedRanges.Count; i++)
{
    for (int j = startAtIndex; j < finalRanges.Count; j++)
    {
        Console.WriteLine($"Compare: {finalRanges[j]} with {sortedRanges[i]}");

        if (double.Parse(sortedRanges[i].Split('-')[0]) > double.Parse(finalRanges[j].Split('-')[1]))
        {
            finalRanges.Add(sortedRanges[i]);
            startAtIndex = finalRanges.Count - 1;
            break;
        }

        string tempRange = "";

        if (double.Parse(sortedRanges[i].Split('-')[1]) > double.Parse(finalRanges[j].Split('-')[1]))
        {
            tempRange = finalRanges[j].Split('-')[0] + "-" + sortedRanges[i].Split('-')[1];
        }
        else
        {
            tempRange = finalRanges[j].Split('-')[0] + "-" + finalRanges[j].Split('-')[1];
        }
        finalRanges[j] = tempRange;
    }
}

foreach (string range in finalRanges)
{
    numOfFreshIngredientsIDs += double.Parse(range.Split('-')[1]) - double.Parse(range.Split('-')[0]) + 1;
}

foreach (string id in ids)
{

    foreach (string range in finalRanges)
    {
        int dashIndex = range.IndexOf('-');
        string startOfRange = range.Substring(0, dashIndex);
        string endOfRange = range.Substring(dashIndex + 1);

        if (double.Parse(id) < double.Parse(startOfRange))
        {
            break;
        }

        if (double.Parse(id) > double.Parse(endOfRange))
        {
            continue ;
        }

        numOfFreshIngredients++;
        break;
    }
}

Console.WriteLine($"Number of fresh ingredients ids: {numOfFreshIngredientsIDs}");
Console.WriteLine($"Number of fresh ingredients: {numOfFreshIngredients}");
