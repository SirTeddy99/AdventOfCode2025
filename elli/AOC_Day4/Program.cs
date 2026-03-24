// Advent of code 2025 - Day 4 : Printing Department

double numAccessibleRolls = 0;

string[] input = File.ReadAllLines("input.txt");

int rowLength = input.Length;
int columnLength = input[0].Length;
Console.WriteLine($"Length {rowLength} {columnLength}");

for (int i = 0; i < rowLength; i++)
{
    int numRollsInAdjacentPositions = 0;

    for (int j = 0; j < columnLength; j++)
    {
        Console.WriteLine(input[i][j]);

        if (input[i][j] == '.')
        {
            continue;
        }

        // Check the three spaces on top
        if (i > 0)
        {
            if (j > 0 && input[i - 1][j - 1] == '@')
            {
                numRollsInAdjacentPositions++;
                Console.WriteLine("top left: +1");
            }
            if (input[i - 1][j] == '@')
            {
                numRollsInAdjacentPositions++;
                Console.WriteLine("top: +1");
            }
            if (j < columnLength - 1 && input[i - 1][j + 1] == '@')
            {
                numRollsInAdjacentPositions++;
                Console.WriteLine("top right: +1");
            }
        }

        // Check before and after
        if (j > 0 && input[i][j - 1] == '@')
        {
            numRollsInAdjacentPositions++;
            Console.WriteLine("left: +1");
        }
        if (j < columnLength - 1 && input[i][j + 1] == '@')
        {
            numRollsInAdjacentPositions++;
            Console.WriteLine("right: +1");
        }

        // Check the three spaces on the bottom
        if (i < rowLength - 1)
        {
            if (j > 0 && input[i + 1][j - 1] == '@')
            {
                numRollsInAdjacentPositions++;
                Console.WriteLine("bottom left: +1");
            }
            if (input[i + 1][j] == '@')
            {
                numRollsInAdjacentPositions++;
                Console.WriteLine("bottom: +1");
            }
            if (j < columnLength - 1 && input[i + 1][j + 1] == '@')
            {
                numRollsInAdjacentPositions++;
                Console.WriteLine("bottom right: +1");
            }
        }

        if (numRollsInAdjacentPositions < 4)
        {
            numAccessibleRolls++;
            Console.WriteLine("Less then four!");
        }
        numRollsInAdjacentPositions = 0;
    }

    Console.WriteLine("");
}

Console.WriteLine($"Number of accessible rolls: {numAccessibleRolls}");
