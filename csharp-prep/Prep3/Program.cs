using System;

class Program
{
    static void Main(string[] args)
    {
        int guess = 0;
        Random randomGenerator = new Random();
        int input = randomGenerator.Next(1, 11);

        while (guess != input)
        {

            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (guess == input)
            {
                Console.WriteLine("You got it!");
            }
            else if (guess > input)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("Higher");
            }
        }
    }
}