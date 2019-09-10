using System;

namespace EndOfTurn
{
    class Program
    {

        delegate void Turn();
        static event Turn AtStartOfTurn;
        static event Turn AtEndOfTurn;

        static bool isStartOfTurn = true;
        static bool isYourTurn = true;

        //Mechanics
        static int actions;
        static int maxActions = 5;

        //Stats
        static int belly;
        static int happiness;


        static void Main(string[] args)
        {
            actions = maxActions;
            Game();
        }

        static void Game()
        {
            if (actions == 0)
            {
                isYourTurn = false;
            }

            if (isStartOfTurn && isYourTurn)
            {
                StartTurn();
                YourTurn();
                isStartOfTurn = false;
                Game();
            }
            else if (isYourTurn)
            {
                YourTurn();
                Game();
            }
            else
            {
                isStartOfTurn = true;
                EndTurn();
            }
        }

        static void YourTurn()
        {
            Console.WriteLine("You have " + actions + " actions left.");
            Console.WriteLine("what would you like to do?");
            Console.WriteLine("actions:");
            Console.WriteLine("Eat");
            Console.WriteLine("Kill");
            Console.WriteLine("Sing");
            Console.WriteLine("Jest");
            Console.WriteLine("");

            //Write out options

            var ans = Console.ReadLine();

            switch (ans)
            {
                case "Eat":
                    if (belly < 6)
                    {
                        Eat();
                        actions -= 1;                      
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Belly is now at: " + belly);
                        Console.WriteLine("You're full.");
                        Console.WriteLine();
                        Console.ReadKey();
                        return;
                    }
                    break;
                case "Kill":
                    break;
                case "Sing":
                    break;
                case "Jest":
                    break;
            }

        }

        static void StartTurn()
        {
            Console.WriteLine("starting turn...");
            //AtStartOfTurn();
        }

        static void EndTurn()
        {
            Console.WriteLine("ending turn...");
            //AtEndOfTurn();
            actions = maxActions;
            isStartOfTurn = true;
            isYourTurn = true;
            Game();
        }

        static void Eat()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("You find some spaghetti in the distance.");
            Console.WriteLine("It ends up tasting really good, much like spaghetti.");
            belly += 1;
            Console.WriteLine("Belly is now at: " + belly);
            Console.WriteLine("");
            Console.ReadKey();
        }

    }
}
