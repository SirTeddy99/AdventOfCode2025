// Advent of code 2025 - Day 3 : Lobby

double totalOutputJoltage = 0;

// Does not work for only one battery, or with larger than bank size
int numOfBatteriesPerBank = 12;

//string[] banks = { "987654321111111", "811111111111119", "234234234234278", "818181911112111" };
string[] banks = File.ReadAllLines("input.txt");

foreach (string bank in banks)
{
    Console.WriteLine($"Bank: {bank}");

    try
    {
        // Divid the bank into default batteries and the possible batteries
        List<int> defaultBatteries = new List<int>();
        List<int> possibleBatteries = new List<int>();

        for (int i = 0; i < numOfBatteriesPerBank; i++)
        {
            defaultBatteries.Add(Convert.ToInt32(bank[i].ToString()));
        }

        for (int i = numOfBatteriesPerBank; i < bank.Length; i++)
        {
            possibleBatteries.Add(Convert.ToInt32(bank[i].ToString()));
        }

        // Check if their is any of the default batteries that need to be removed.
        // Remove if next battery is bigger and possible batteries is not empty.
        CheckBatteriesAddedToDefault(defaultBatteries, possibleBatteries, 0);

        // Check if their is any of the possible batteries that is bigger than the last default battery
        while (possibleBatteries.Count > 0)
        {
            if (defaultBatteries[numOfBatteriesPerBank - 1] < possibleBatteries[0])
            {
                defaultBatteries[numOfBatteriesPerBank - 1] = possibleBatteries[0];
                possibleBatteries.RemoveAt(0);
                FindCorrectPlacementOfNewBattery(defaultBatteries, possibleBatteries);
            }
            else
            {
                possibleBatteries.RemoveAt(0);
            }
        }

        string maxJoltage = "";
        foreach (var battery in defaultBatteries)
        {
            string battery_string = battery.ToString();
            maxJoltage += battery_string;
        }

        totalOutputJoltage += Convert.ToDouble(maxJoltage);
        Console.WriteLine($"Max joltage added: {maxJoltage}");
    }
    catch (Exception e)
    {
        Console.WriteLine($"Error: {e}");
    }
}

Console.WriteLine($"The total output joltage is: {totalOutputJoltage}");

void CheckBatteriesAddedToDefault(List<int> defaultBatteries, List<int> possibleBatteries, int startIndex)
{
    for (int i = startIndex; i < defaultBatteries.Count - 1; i++)
    {
        if (possibleBatteries.Count == 0)
        {
            break;
        }

        int currentBattery = defaultBatteries[i];
        int nextBattery = defaultBatteries[i + 1];

        if (nextBattery > currentBattery)
        {
            defaultBatteries.RemoveAt(i);
            defaultBatteries.Add(possibleBatteries[0]);
            possibleBatteries.RemoveAt(0);

            int changedBatteryIndex = i;
            i--;

            int movedXTimes = FindCorrectPlacementOfNextBattery(defaultBatteries, possibleBatteries, changedBatteryIndex);
            if (movedXTimes > 0)
            {
                i -= movedXTimes;
            }
        }
    }
}

int FindCorrectPlacementOfNextBattery(List<int> defaultBatteries, List<int> possibleBatteries, int startIndex)
{
    int newBattery = defaultBatteries[startIndex];
    int newBatteriesNeeded = 0;

    for (int i = startIndex - 1; i >= 0; i--)
    {
        newBatteriesNeeded++;

        // Remove all batteries that is lower than the new battery, if their is enough batteries in possible batteries.
        if (newBattery > defaultBatteries[i] && possibleBatteries.Count >= newBatteriesNeeded)
        {
            defaultBatteries.RemoveAt(i);

            if (i == 0)
            {
                newBatteriesNeeded++;
            }
        }
        else
        {
            break;
        }
    }

    for (int i = 0; i < newBatteriesNeeded - 1; i++)
    {
        defaultBatteries.Add(possibleBatteries[0]);
        possibleBatteries.RemoveAt(0);
    }

    return newBatteriesNeeded - 1;
}

void FindCorrectPlacementOfNewBattery(List<int> defaultBatteries, List<int> possibleBatteries)
{
    int newBattery = defaultBatteries[^1];
    int newBatteriesNeeded = 0;

    for (int i = numOfBatteriesPerBank - 1; i > 0; i--)
    {
        newBatteriesNeeded++;

        // Remove all batteries that is lower than the new battery, if their is enough batteries in possible batteries.
        if (newBattery > defaultBatteries[i-1] && possibleBatteries.Count >= newBatteriesNeeded)
        {
            defaultBatteries.RemoveAt(i);
        }
        else
        {
            break;
        }
    }

    defaultBatteries[^1] = newBattery;
    int newPlacementIndex = defaultBatteries.Count - 1;

    for (int i = defaultBatteries.Count; i < numOfBatteriesPerBank; i++)
    {
        defaultBatteries.Add(possibleBatteries[0]);
        possibleBatteries.RemoveAt(0);
    }

    CheckBatteriesAddedToDefault(defaultBatteries, possibleBatteries, newPlacementIndex);
}
