// Advent of code 2025 - Day 1 : Secret Entrance

int password = 0;
int updatedPasswordWith = 0;

int dial_position = 50;
Console.WriteLine($"- The dial starts by pointing at {dial_position}.");

//string[] rotations = {"L68", "L30", "R48", "L5", "R60", "L55", "L1", "L99", "R14", "L82"};
string[] rotations = File.ReadAllLines("input.txt"); 

foreach (string rotation in rotations)
{
    try
    {
        char direction = rotation[0];
        int distance = Convert.ToInt32(rotation[1..]);
        dial_position = RotateTheDial(dial_position, direction, distance);
    }
    catch (Exception e)
    {
        Console.WriteLine($"Error: {e}");
    }
}

Console.WriteLine($"The password is: {password}");


int RotateTheDial(int dial_position, char direction, int distance)
{

    if (direction == 'R')
    {
        dial_position += distance;
        if (dial_position > 99)
        {
            int num_rotations = dial_position / 100;
            password += num_rotations;
            updatedPasswordWith = num_rotations;

            dial_position %= 100;
        }
    }
    else if (direction == 'L')
    {
        if (distance > dial_position && dial_position != 0)
        {
            int leftFromPosZero = distance - dial_position;
            password++;
            updatedPasswordWith++;
  
            if (leftFromPosZero > 99)
            {
                int num_rotations = leftFromPosZero / 100;
                password += num_rotations;
                updatedPasswordWith += num_rotations;
                dial_position = 100 - (leftFromPosZero %= 100);

                if (dial_position == 100)
                {
                    dial_position = 0;
                }
            }
            else
            {
                dial_position = 100 - leftFromPosZero;
            }
        }
        else if (distance > 99)
        {
            int num_rotations = distance / 100;
            password += num_rotations;
            updatedPasswordWith += num_rotations;
            int leftAfterRotations = distance - (num_rotations * 100);
            dial_position = 100 - leftAfterRotations;

            if (dial_position == 100)
            {
                dial_position = 0;
            }
        }
        else
        {
            if (dial_position == 0)
            {
                dial_position = 100;
            }

            dial_position -= distance;

            if (dial_position == 0)
            {
                password++;
                updatedPasswordWith++;
            }
        }
    }

    if (updatedPasswordWith > 0)
    {
        if (updatedPasswordWith == 1)
        {
            Console.WriteLine($"- The dial is rotated {direction}{distance} to point at now at {dial_position}; during this rotation, it points at 0 once.");
        }
        else
        {
            Console.WriteLine($"- The dial is rotated {direction}{distance} to point at now at {dial_position}; during this rotation, it points at 0 a number of {updatedPasswordWith} times.");
        }
        updatedPasswordWith = 0;
    }
    else
    {
        Console.WriteLine($"- The dial is rotated {direction}{distance} to point at now at {dial_position}.");
    }
    return dial_position;
}
