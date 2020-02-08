/*
_____________________________________________________
Created By: George Shea                     ßeta
Created:7/2/2020
Version: 2.0
Version Update: 7/2/2020
Info:
Draft picker for choaches to choice there new recruits
_____________________________________________________
 */

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TestClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Players[,] playerArray = StartUp();

            Printer(playerArray);

            OpperationBoard(playerArray);

        }
        
        static Players[,] StartUp()
        {
            // this is told because how it prints it is 2 big for just the deafult screen size
            Console.WriteLine("This Application works best in full screen mode");
            Console.WriteLine("Please do so once ready press return");
            Console.ReadLine();
            // clears off this as it looks ugly
            Console.Clear();

            // this string is used to store up objects to later be put in the multi array
            List<Players> playerList = new List<Players>();

            // this holds the json information
            List<String> PlayerInfoLine = new List<String>();

            // counter
            int assignCounter = 0;

            // for every line in the json file it does the contents of the loop         // gets file from there
            //
            // IMPORTANT || change the realine to your own directory or this will not work in the slightest
            //
            foreach (string line in System.IO.File.ReadLines(@"C:\Users\shegeoj\source\repos\TestClasses\TestClasses\playerDetails2.txt"))
            {
                // adds in line to the array
                PlayerInfoLine.Add(new String(line));

                // mover takes in the json file and turns that into object data || temporory 
                var mover = JsonConvert.DeserializeObject<Players>(PlayerInfoLine[assignCounter]);

                // adds new object to the list with all the json atributes
                playerList.Add(new Players { Name = mover.Name, Origin = mover.Origin, Position = mover.Position, Price = mover.Price, Rank = mover.Rank });

                assignCounter = assignCounter + 1;
            }

            // uses list and simply plops in into the array
            Players[,] playerArray = new Players[,]
            {
                    { playerList[0], playerList[1], playerList[2], playerList[3], playerList[4]},
                    { playerList[5], playerList[6], playerList[7], playerList[8], playerList[9] },
                    { playerList[10], playerList[11], playerList[12], playerList[13], playerList[14] },
                    { playerList[15], playerList[16], playerList[17], playerList[18], playerList[19] },
                    { playerList[20], playerList[21], playerList[22], playerList[23], playerList[24] },
                    { playerList[25], playerList[26], playerList[27], playerList[28], playerList[29] },
                    { playerList[30], playerList[31], playerList[32], playerList[33], playerList[34] },
                    { playerList[35], playerList[36], playerList[37], playerList[38], playerList[39] }
            };


            Console.WriteLine();
            return playerArray;

        }

        static int Printer(Players[,] playerArray)
        {
            playerArray = playerArray;
            // row
            int i = 0;
            // colloumn
            int j = 0;
            // counter
            int arraySetCount = 0;
            // this is used to see if the coach is spending money  "wisely"
            // this stores the positions so it can be printed
            string[] postions = { "QauterBack", "Running Back", "WideReciever", "DefensiveLineman", "DefensiveBack", "TightEnd", "Line Backer", "Offensive Tackles" };
            // this stores space equivilent so it prints out nicely
            string[] postionsSpaces = { "          ", "            ", "            ", "                ", "             ", "        ", "           ", "                 " };
            // prints out rankings formated to look pretty
            Console.WriteLine("      {0,-20}      {1,-20}      {2,-20}      {3,-20}       {4,-20}       {5,-20}", postionsSpaces[1], "1st", "2nd", "3rd", "4th", "5th");
            Console.WriteLine();
            // simple loop to save some lines of code just prints out the object player array
            while (arraySetCount < 7)
            {
                Console.WriteLine("      {0,-20}      {1,-20}      {2,-20}      {3,-20}       {4,-20}       {5,-20}", postionsSpaces[i], playerArray[i, j].Name, playerArray[i, j + 1].Name, playerArray[i, j + 2].Name, playerArray[i, j + 3].Name, playerArray[i, j + 4].Name);
                Console.WriteLine("      {0,-20}      {1,-20}      {2,-20}      {3,-20}       {4,-20}       {5,-20}", postions[i], playerArray[i, j].Price, playerArray[i, j + 1].Price, playerArray[i, j + 2].Price, playerArray[i, j + 3].Price, playerArray[i, j + 4].Price);
                Console.WriteLine("      {0,-20}      {1,-20}      {2,-20}      {3,-20}       {4,-20}       {5,-20}", postionsSpaces[i], playerArray[i, j].Origin, playerArray[i, j + 1].Origin, playerArray[i, j + 2].Origin, playerArray[i, j + 3].Origin, playerArray[i, j + 4].Origin);
                arraySetCount = arraySetCount + 1;
                i = i + 1;
                Console.WriteLine();
            }
            // total cash
            int fund = 96000000;
            // prints out "rules and tells you how much money you have
            Console.WriteLine("_______________________________________________________________________________________________________________________________________________________________");
            Console.WriteLine("2020 Draft Rules");
            Console.WriteLine("1: You may choose up to 5 players");
            Console.WriteLine("2: You may not go over budget");
            Console.WriteLine("Current Funds: " + fund);
            Console.WriteLine("_______________________________________________________________________________________________________________________________________________________________");

            return fund;
        }

        static void OpperationBoard(Players[,] playerArray)
        {
            int fund = 96000000;
            int economic = 0;
            /*
             This si where things start to pick up pace ie get confusing
             */
            // sets up col/row to deafults to be chosen later
            int pickCol = 0;
            int pickRow = 0;
            // empty array to store your choices 
            string[] choices = { " ", " ", " ", " ", " " };
            string[] choicesO = { " ", " ", " ", " ", " " };
            string[] choicesP = { " ", " ", " ", " ", " " };
            // counter
            int choiceCount = 0;
            Console.WriteLine("press x to conclude choosing");
            // will loop unti either you go bust or you hit 5 players
            while (fund > 0 && choiceCount < 5)
            {
                Console.WriteLine("Enter The Position(Row) You would like to choose from");
                string pickRowstring = Console.ReadLine();
                // this is the important up to 5 players 
                // once you hit x you will leave the program
                if (pickRowstring == "x")
                {
                    break;
                }
                // needs to be converted into a int 
                pickRow = Int32.Parse(pickRowstring);
                // - so that it works normaly ie how most people count
                pickRow = pickRow - 1;
                // makes sure you pick with in the array
                if (pickRow < 8 && pickRow >= 0)
                {
                    // if failed to go in bounds breaks loops back to start
                    Console.WriteLine("Enter The Rank(Coloumn) You would like to choose from");
                    string pickColstring = Console.ReadLine();
                    // once again you can leave now
                    if (pickColstring == "x")
                    {
                        break;
                    }
                    // converts into ints for math
                    pickCol = Int32.Parse(pickColstring);
                    // once again converts it into how people normaly count
                    pickCol = pickCol - 1;
                    // makes sure in bounds if not loops you guess it again
                    if (pickCol < 6 && pickRow >= 0)
                    {
                        // prints it out what you picked to make sure you picked the right person
                        Console.WriteLine("You Choose " + playerArray[pickRow, pickCol].Name);
                        Console.WriteLine("           " + playerArray[pickRow, pickCol].Origin);
                        Console.WriteLine("           " + playerArray[pickRow, pickCol].Price);
                        // asks to confirm that you want this player
                        Console.WriteLine("Is that correct y/n");
                        string check = Console.ReadLine();
                        // if yes do this if not once again back in the loop you go
                        // double checks that picking this player will not make you go in the red
                        // makes sure you do not pick the same player twice
                        if (fund - playerArray[pickRow, pickCol].Price > 0 && check == "y" && playerArray[pickRow, pickCol].Name != choices[0] && playerArray[pickRow, pickCol].Name != choices[1] && playerArray[pickRow, pickCol].Name != choices[2] && playerArray[pickRow, pickCol].Name != choices[3] && playerArray[pickRow, pickCol].Name != choices[4])
                        {
                            // takes away your precisoue money
                            fund = fund - playerArray[pickRow, pickCol].Price;
                            // adds player into your choices into a list so it can print at the end
                            choices[choiceCount] = playerArray[pickRow, pickCol].Name;
                            choicesO[choiceCount] = playerArray[pickRow, pickCol].Origin;
                            choicesP[choiceCount] = Convert.ToString(playerArray[pickRow, pickCol].Price);

                            // writes down current funds
                            Console.WriteLine(fund);
                            // adds one to the choices max 5
                            choiceCount = choiceCount + 1;
                            // this is for the choachs who spend efficiently just adds if the player is in the top 3
                            if (playerArray[pickRow, pickCol].Rank == "1" || playerArray[pickRow, pickCol].Rank == "2" || playerArray[pickRow, pickCol].Rank == "3")
                            {
                                economic = economic + 1;
                            }

                        }

                        // just breaking logic
                        else
                        {
                            Console.WriteLine("Sorry You have already choose that player");
                        }
                    }
                    // just breaking logic
                    else
                    {
                        Console.WriteLine("Out of Bonds");
                    }

                }
                // just breaking logic
                else
                {

                }
            }
            // concludes the chocing phase
            Console.WriteLine();
            Console.WriteLine("All players have been chosen have nice day");
            Console.WriteLine("Your Choices Were ");
            // prints out what you choice for players

            Console.WriteLine("      {0,-20}      {1,-20}      {2,-20}      {3,-20}       {4,-20}", choices[0], choices[1], choices[2], choices[3], choices[4]);
            Console.WriteLine("      {0,-20}      {1,-20}      {2,-20}      {3,-20}       {4,-20}", choicesO[0], choicesO[1], choicesO[2], choicesO[3], choicesO[4]);
            Console.WriteLine("      {0,-20}      {1,-20}      {2,-20}      {3,-20}       {4,-20}", choicesP[0], choicesP[1], choicesP[2], choicesP[3], choicesP[4]);

            // just for niceness tells you left over funds
            Console.WriteLine("You Have $ " + fund + " remaining");
            Console.WriteLine();
            // checks if you were spending wisely
            if (fund > 65000000 && economic > 2)
            {
                Console.WriteLine("Great Work Coach You Were Econmic");
            }
            Console.WriteLine("We hope to see you next year");
            Console.WriteLine("_______________________________________________________________________________________________________________________________________________________________");
        }
    }

        public class Players
        {
            // super exiting variables
            public string Name { get; set; }
            public string Origin { get; set; }
            public int Price { get; set; }
            public string Position { get; set; }
            public string Rank { get; set; }
            

            // used for testing 
            public void bio()
            {
                Console.WriteLine("Name: " + Name + "Origin: " + Origin + "Cost: " + Price + "Rank: " + Rank + "Position: " + Position);
            }

        }
}
