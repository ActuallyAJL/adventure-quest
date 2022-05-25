using System;
using System.Collections.Generic;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge
            Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
            Challenge theAnswer = new Challenge(
                "What's the answer to life, the universe and everything?", 42, 25);
            Challenge whatSecond = new Challenge(
                "What is the current second?", DateTime.Now.Second, 50);

            int randomNumber = new Random().Next() % 10;
            Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

            Challenge favoriteBeatle = new Challenge(
                @"Who's your favorite Beatle?
                1) John
                2) Paul
                3) George
                4) Ringo
                ",
                4, 20
            );

            Challenge strongestAvenger = new Challenge(
                @"Who's the strongest Avenger?
                1) Hulk
                2) Thor
                3) Captain America
                4) Iron Man
                ", 1, 20);

            Challenge smallestThing = new Challenge(
                @"Which of these is smallest?
                1) Atom
                2) Neutron
                3) Photon
                4) Neutrino
                ", 4, 10);

            // "Awesomeness" is like our Adventurer's current "score"
            // A higher Awesomeness is better

            // Here we set some reasonable min and max values.
            //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
            //  If an Adventurer has an Awesomeness less than the min, they are terrible
            int minAwesomeness = 0;
            int maxAwesomeness = 100;
            Prize prize = new Prize("An uncomfortably cold coin");

            string userName = "Jack";
            Console.WriteLine("What is your name?");
            userName = Console.ReadLine();
            Robe robe = new Robe();
            robe.Length = 2000;

            List<string> robeColors = new List<string>();
            robeColors.Add("Purple");
            robeColors.Add("Yellow");
            robeColors.Add("Black");
            robeColors.Add("Grey");

            robe.Colors = robeColors;

            Hat dumbHat = new Hat();
            dumbHat.ShininessLevel = 10;


            // Make a new "Adventurer" object using the "Adventurer" class
            Adventurer theAdventurer = new Adventurer(userName, robe, dumbHat);
            Console.WriteLine(theAdventurer.GetDescription());

            // A list of challenges for the Adventurer to complete
            // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
            List<Challenge> challenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle,
                strongestAvenger,
                smallestThing
            };

            int GetRandomInt(int min, int max)
            {
                Random rand = new Random();
                int r = rand.Next(min, max + 1);
                return r;
            }

            string keepPlaying = "y";

            while (keepPlaying == "y")
            {
                List<int> Indexes = new List<int>();

                while (Indexes.Count < 5)
                {
                    int Candidate = GetRandomInt(0, challenges.Count - 1);
                    if (!Indexes.Contains(Candidate))
                    {
                        Indexes.Add(Candidate);
                    }
                }
                // Loop through all the challenges and subject the Adventurer to them
                for (int i = 0; i < Indexes.Count; i++)
                {
                    int Index = Indexes[i];
                    challenges[Index].RunChallenge(theAdventurer);
                }

                // This code examines how Awesome the Adventurer is after completing the challenges
                // And praises or humiliates them accordingly
                if (theAdventurer.Awesomeness >= maxAwesomeness)
                {
                    Console.WriteLine("YOU DID IT! You are truly awesome!");
                }
                else if (theAdventurer.Awesomeness <= minAwesomeness)
                {
                    Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
                }
                else
                {
                    Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
                }

                prize.ShowPrize(theAdventurer);

                Console.WriteLine("Press 'y' to play again, or anything else to quit");
                keepPlaying = Console.ReadLine().ToLower();
            }
        }
    }
}