// Advent of code 2025 - Day 3 : Lobby

double totalOutputJoltage = 0;

//string[] banks = { "987654321111111", "811111111111119", "234234234234278", "818181911112111" };
string[] banks = File.ReadAllLines("input.txt");

foreach (string bank in banks)
{
    //Console.WriteLine($"Bank: {bank}");

    try
    {
        int batteryOne = Convert.ToInt32(bank[0].ToString());
        int batteryTwo = Convert.ToInt32(bank[1].ToString());

        for (int i = 1; i < bank.Length; i++)
        {
            int nextBattery = Convert.ToInt32(bank[i].ToString());

            if (nextBattery > batteryOne && i != bank.Length - 1)
            {
                batteryOne = nextBattery;
                batteryTwo = Convert.ToInt32(bank[i+1].ToString());
            }
            else if (nextBattery > batteryTwo)
            {
                batteryTwo = nextBattery;
            }   
        }

        string maxJoltage = batteryOne.ToString() + batteryTwo.ToString();

        totalOutputJoltage += Convert.ToDouble(maxJoltage);
        Console.WriteLine($"Max joltage added: {maxJoltage}");
    }
    catch (Exception e)
    {
        Console.WriteLine($"Error: {e}");
    }
}

Console.WriteLine($"The total output joltage is: {totalOutputJoltage}");
