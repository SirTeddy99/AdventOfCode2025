// Advent of code 2025 - Day 2 : Gift Shop

double sumOfInvalidIDs = 0;

//string input = "11-22, 95-115, 998-1012, 1188511880-1188511890, 222220-222224, 1698522-1698528, 446443-446449, 38593856-38593862, 565653-565659, 824824821-824824827, 2121212118-2121212124";
string input = File.ReadAllText("input.txt"); 
string[] ranges = input.Replace(" ", "").Split(',');

foreach (string range in ranges)
{
    try
    {
        double firstID = Convert.ToDouble(range.Substring(0, range.IndexOf("-")));
        double lastID = Convert.ToDouble(range.Substring(range.IndexOf("-") + 1));

        while (firstID <= lastID)
        {
            string currentID = Convert.ToString(firstID);
            int currentIDLength = currentID.Length;

            // Check if all numbers are the same, if there is at least two digits.
            string firstNumber = currentID[0].ToString();

            if (currentID.Replace(firstNumber, "") == "" && currentIDLength > 1)
            {
                Console.WriteLine($"Invalid ID: {firstID}");
                sumOfInvalidIDs += firstID;
            }
            else
            {
                // Check for possible factors
                bool addedSymmetrical = false;
                
                for (int i = 2; i < currentIDLength; i++)
                {
                    // Check if divisible by any number between 2 and ID.Length-1
                    if (currentIDLength % i == 0)
                    {
                        // If perfectly symmetric
                        if (currentIDLength % 2 == 0)
                        {
                            int lengthOfHalf = currentIDLength / 2;
                            double partOne = Convert.ToDouble(currentID[..lengthOfHalf]);
                            double partTwo = Convert.ToDouble(currentID[lengthOfHalf..]);

                            if (partOne == partTwo)
                            {
                                if (!addedSymmetrical)
                                {
                                    sumOfInvalidIDs += firstID;
                                    Console.WriteLine($"Invalid ID: {firstID}");
                                    addedSymmetrical = true;
                                }
                            }
                        }

                        // If not symmetric, but possible repeates
                        if (currentIDLength % i == 0 && addedSymmetrical == false && i != 2)
                        {
                            List<string> possibleMatches = [];

                            for (int j = 0; j < currentIDLength; j += currentIDLength / i)
                            {
                                string match = "";

                                for (int k = 0; k < currentIDLength / i; k++)
                                {
                                    match += currentID[j + k];
                                }

                                possibleMatches.Add(match);
                                match = "";
                            }

                            bool isMatch = true;
                            for (int j = 0; j < possibleMatches.Count - 1; j++)
                            {
                                if (possibleMatches[j] != possibleMatches[j + 1])
                                {
                                    isMatch = false;
                                    break;
                                }
                            }

                            if (isMatch == true)
                            {
                                sumOfInvalidIDs += firstID;
                                Console.WriteLine($"Invalid ID: {firstID}");
                            } 
                        }
                    }
                }
                addedSymmetrical = false;
            }

            firstID++;
        }
    }
    catch (Exception e)
    {
        Console.WriteLine($"Error: {e}");
    }
}

Console.WriteLine($"The sum of all invalid IDs are: {sumOfInvalidIDs}");
