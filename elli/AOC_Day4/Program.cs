// Advent of code 2025 - Day 4 : Printing Department

double numAccessibleRolls = 0;

/*string[] input =
{
    "..@@.@@@@.",
    "@@@.@.@.@@",
    "@@@@@.@.@@",
    "@.@@@@..@.",
    "@@.@@@@.@@",
    ".@@@@@@@.@",
    ".@.@.@.@@@",
    "@.@@@.@@@@",
    ".@@@@@@@@.",
    "@.@.@@@.@."
};*/

string[] input = File.ReadAllLines("input.txt");

int rowLength = input.Length;
int columnLength = input[0].Length;

// Convert to char array
char[,] diagramOfRolls = new char[rowLength, columnLength];

for(int i = 0; i < rowLength; i++)
{
    for (int  j = 0; j < columnLength; j++)
    {
        diagramOfRolls[i, j] = input[i][j];
        //Console.Write(diagramOfRolls[i, j]);
    }
    //Console.WriteLine();
}

List<(int i, int j)> removeRollsAt = new List<(int i, int j)>();
bool newRollsAdded = false;

do
{
    foreach (var (i, j) in removeRollsAt)
    {
        //Console.WriteLine($"({i}, {j})");
        diagramOfRolls[i, j] = '.';
    }
    newRollsAdded = false;

    for (int i = 0; i < rowLength; i++)
    {
        int numRollsInAdjacentPositions = 0;

        for (int j = 0; j < columnLength; j++)
        {
            //Console.WriteLine(diagramOfRolls[i, j]);

            if (diagramOfRolls[i, j] == '.')
            {
                continue;
            }

            // Check the three spaces on top
            if (i > 0)
            {
                if (j > 0 && diagramOfRolls[i - 1, j - 1] == '@')
                {
                    numRollsInAdjacentPositions++;
                }
                if (diagramOfRolls[i - 1, j] == '@')
                {
                    numRollsInAdjacentPositions++;
                }
                if (j < columnLength - 1 && diagramOfRolls[i - 1, j + 1] == '@')
                {
                    numRollsInAdjacentPositions++;
                }
            }

            // Check before and after
            if (j > 0 && diagramOfRolls[i, j - 1] == '@')
            {
                numRollsInAdjacentPositions++;
            }
            if (j < columnLength - 1 && diagramOfRolls[i, j + 1] == '@')
            {
                numRollsInAdjacentPositions++;
            }

            // Check the three spaces on the bottom
            if (i < rowLength - 1)
            {
                if (j > 0 && diagramOfRolls[i + 1, j - 1] == '@')
                {
                    numRollsInAdjacentPositions++;
                }
                if (diagramOfRolls[i + 1, j] == '@')
                {
                    numRollsInAdjacentPositions++;
                }
                if (j < columnLength - 1 && diagramOfRolls[i + 1, j + 1] == '@')
                {
                    numRollsInAdjacentPositions++;
                }
            }

            if (numRollsInAdjacentPositions < 4)
            {
                numAccessibleRolls++;
                //Console.WriteLine("Less then four!");
                removeRollsAt.Add((i, j));
                newRollsAdded = true;
            }
            numRollsInAdjacentPositions = 0;
        }

        //Console.WriteLine("");
    }

    Console.WriteLine($"Number of accessible rolls: {numAccessibleRolls}");
}
while (newRollsAdded);
