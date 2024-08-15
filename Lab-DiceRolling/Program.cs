/*DICE ROLLER
Objective: Random Numbers

Task: Create an application that simulates dice rolling.

What will the application do?
The application asks the user to enter the number of sides for a pair of dice. 
If you have learned about exception handling, make sure the user can only enter numbers
The application prompts the user to roll the dice.
The application “rolls” two n-sided dice, displaying the results of each along with a total
For 6-sided dice, the application recognizes the following dice combinations and displays a message for each. It should not output this for any other size of dice.
Snake Eyes: Two 1s
Ace Deuce: A 1 and 2
Box Cars: Two 6s
Win: A total of 7 or 11
Craps: A total of 2, 3, or 12 (will also generate another message!)
The application asks the user if he/she wants to roll the dice again.

Build Specifications:
Create a static method to generate the random numbers.
Proper method header: 2 points
Program generates random numbers validly within the user-specified range: 1 point
Method returns meaningful value of proper type: 1 point
Create a static method for six-sided dice that takes two dice values as parameters, and returns a string for one of the valid combinations (e.g. Snake Eyes, etc.) or an empty string if the dice don’t match one of the combinations.
Snake Eyes: Two 1s
Ace Deuce: A 1 and 2
Box Cars: Two 6s
Or empty string if no matching combos
Create a static method for six-sided dice that takes two dice values as parameters, and returns a string for one of the valid totals (e.g. Win, etc.) or an empty string if the dice don’t match one of the totals.
Win: A total of 7 or 11
Craps: A total of 2, 3, or 12
Or empty string if no matching combos
Application takes all user input correctly: 1 point
Application loops properly: 1 point

Hints:
Use the Random class to generate a random number.

Extra Challenges:
Come up with a set of winning combinations for other dice sizes besides 6.*/

using System.Runtime.ConstrainedExecution;
using System.Xml.Linq;

Console.WriteLine("Welcome to the dice rolling game.");
Console.WriteLine("We will roll two dice.");


bool runProgram = true;
while (runProgram)
    {

    int dS = 0;
    while (true)
    {
        try
        {
            Console.WriteLine("How many sides do the dice have?");
            dS = int.Parse(Console.ReadLine());
            break;
        }
        catch (Exception e)
        {
            Console.WriteLine("Please enter a number of sides.");
        }

    }
        List<int> rolls = new List<int>();

        for (int i = 0; i < 2; i++)
        {
            rolls.Add(Roll(dS));   
        }

        List<string> Judge = new List<string>()
        {
            "SNAKE EYES!",
            "ACE DECUE!",
            "BOXCARS!",
            "THAT'S A WIN!",
            "CRAPS...",
            "CRIT HIT!!!",
            "CRIT FAIL...",
            "SEVEN ELEVEN STRAIGHT TO HEAVEN!",
            "YOU WIN.... DON'T COME BACK"
        };

        int roll1 = rolls[0];
        int roll2 = rolls[1];
    Console.WriteLine($"First roll is a {roll1}");
    Console.WriteLine($"Second roll is a {roll2}");
    Console.WriteLine($"Your total is: {roll1 + roll2}");
    Console.WriteLine(Combo(roll1, roll2, Judge));
    Console.WriteLine(Outcome(roll1, roll2, Judge));

    Console.WriteLine("Would you like to go again? y/n");
    string continueChoice = Console.ReadLine().Trim();
    if (continueChoice == "y")
    {
        Console.Clear();
        continue;
    }
    else if (continueChoice == "n")
    {
        runProgram = false;
        break;
    }
}

static int Roll(int dS)
{
    Random random = new Random();
    int diceRoll = random.Next(dS) + 1;
    return diceRoll;
}
static string Combo(int roll1, int roll2, List<string> Judge)
{
    if (roll1 == 1 && roll2 == 1)
    {
        return Judge[0];
    }
    else if (roll1 == 1 && roll2 == 2 || roll1 == 2 && roll2 == 1)
    {
        return Judge[1];
    }
    else if (roll1 == 6 && roll2 == 6)
    {
        return Judge[2];
    }
    else if (roll1 == 7 && roll2 == 7)
    {
        return Judge[7];
    }
    else
    {
        return "";
    }
}
static string Outcome(int roll1, int roll2, List<string> Judge) 
{
    if (roll1 + roll2 == 7 || roll1 + roll2 == 11)
    {
        return Judge[3];
    }
    else if (roll1 + roll2 == 2 || roll1 + roll2 == 3 || roll1 + roll2 == 12)
    {
        return Judge[4];
    }
    else if (roll1 + roll2 == 20)
    {
        return Judge[5];
    }
    else if (roll1 + roll2 == 0)
    {
        return Judge[6];
    }
    else if (roll1 + roll2 == 100)
    {
        return Judge[8];
    }
    else
    {
        return "";
    }
}
