/*
_____________________________________________________
Created By: George Shea                     ßeta
Created:7/2/2020
Version: 2.3
Version Update: 14/2/2020
Info:
Draft picker for choaches to choice there new recruits
_____________________________________________________
 */

using System;
using System.IO;
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

            OperationBoard(playerArray);

        }
        
        // Startup grabs json information and creates an array.
        static Players[,] StartUp()
        {


            // AS this is a bigger application i saw fit to tell them before boot up.
            Console.WriteLine("This Application works best in full screen mode");
            Console.WriteLine("Please do so once ready press return");
            Console.ReadLine();
            Console.Clear();

            // This stores the object information
            List<Players> playerList = new List<Players>();

            // This holds the json information
            List<String> PlayerInfoLine = new List<String>();

            // counter
            int assignCounter = 0;

            // for every line in the json file it does the contents of the loop         // gets file from there

            // gets file location regardless of who is using it
            string fullPath = Path.GetFullPath("playerDetails2.txt");

            foreach (string line in System.IO.File.ReadLines(@fullPath))
            {
                // adds in line to the array
                PlayerInfoLine.Add(new String(line));

                // mover takes in the json file and turns that into object data || temporory 
                var mover = JsonConvert.DeserializeObject<Players>(PlayerInfoLine[assignCounter]);

                // adds new object to the list with all the json atributes
                playerList.Add(new Players { Name = mover.Name, Origin = mover.Origin, Position = mover.Position, Price = mover.Price, Rank = mover.Rank });

                assignCounter += 1;
            }

            // Uses list to fill up the array
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

        // Printer prints the information to the screen.
        static void Printer(Players[,] playerArray)
        {
            // Row
            int i = 0;
            // colloumn
            int j = 0;
            // counter
            int arraySetCount = 0;


            // Positions
            string[] postions = { "QauterBack", "Running Back", "WideReciever", "DefensiveLineman", "DefensiveBack", "TightEnd", "Line Backer", "Offensive Tackles" };
            // Positions but tpyed in spaces
            string[] postionsSpaces = { "          ", "            ", "            ", "                ", "             ", "        ", "           ", "                 " };
            
            // Ranking of players
            Console.WriteLine("      {0,-20}      {1,-20}      {2,-20}      {3,-20}       {4,-20}       {5,-20}", postionsSpaces[1], "1st", "2nd", "3rd", "4th", "5th");
            Console.WriteLine();

            // Prints out player information Name, Origin, Price

            while (arraySetCount < 7)
            {
                Console.WriteLine("      {0,-20}      {1,-20}      {2,-20}      {3,-20}       {4,-20}       {5,-20}", postionsSpaces[i], playerArray[i, j].Name, playerArray[i, j + 1].Name, playerArray[i, j + 2].Name, playerArray[i, j + 3].Name, playerArray[i, j + 4].Name);
                Console.WriteLine("      {0,-20}      {1,-20}      {2,-20}      {3,-20}       {4,-20}       {5,-20}", postions[i], playerArray[i, j].Price, playerArray[i, j + 1].Price, playerArray[i, j + 2].Price, playerArray[i, j + 3].Price, playerArray[i, j + 4].Price);
                Console.WriteLine("      {0,-20}      {1,-20}      {2,-20}      {3,-20}       {4,-20}       {5,-20}", postionsSpaces[i], playerArray[i, j].Origin, playerArray[i, j + 1].Origin, playerArray[i, j + 2].Origin, playerArray[i, j + 3].Origin, playerArray[i, j + 4].Origin);
                arraySetCount = arraySetCount + 1;
                i = i + 1;
                Console.WriteLine();
            }

            // Rules For Picks and Funding to do so.
            Console.WriteLine("_______________________________________________________________________________________________________________________________________________________________");
            Console.WriteLine("2020 Draft Rules");
            Console.WriteLine("1: You may choose up to 5 players");
            Console.WriteLine("2: You may not go over budget");
            Console.WriteLine("Current Funds: 96000000" );
            Console.WriteLine("_______________________________________________________________________________________________________________________________________________________________");

        }

        //OperationBaord allows for player picks and conclusion.
        static void OperationBoard(Players[,] playerArray)
        {

            int fund = 96000000;
            // Used for The economic coach award 
            int economic = 0;

            // Row and col for Picks
            int pickCol = 0;
            int pickRow = 0;
            // Empty arrays to store names,origins...
            string[] choices = { " ", " ", " ", " ", " " };
            string[] choicesO = { " ", " ", " ", " ", " " };
            string[] choicesP = { " ", " ", " ", " ", " " };
            string[] choicesPO = { " ", " ", " ", " ", " " };
            string[] choicesR = { " ", " ", " ", " ", " " };

            // counter
            int choiceCount = 0;
            Console.WriteLine("press x to conclude choosing");
            // Will loop until either you run out of money or picks
            while (fund > 0 && choiceCount < 5)
            {
                Console.WriteLine("Enter The Position(Row) You would like to choose from");
                string pickRowstring = Console.ReadLine();

                // Allows for no more picks
                if (pickRowstring == "x")
                {
                    break;
                }
                // Stops Users from inputing none numbers
                try
                {
                    pickRow = Int32.Parse(pickRowstring);
                }
                catch{}

                pickRow -= 1;

                // Pick within array if fail loops back
                if (pickRow < 8 && pickRow >= 0)
                {
                    Console.WriteLine("Enter The Rank(Column) You would like to choose from");
                    string pickColstring = Console.ReadLine();
                    
                    if (pickColstring == "x")
                    {
                        break;
                    }
                    // Stops user inputing letters
                    try
                    {
                        pickCol = Int32.Parse(pickColstring);
                    }
                    catch { }

                    pickCol -= 1;

                    // Makes sure inbounds and loops if fails
                    if (pickCol < 7 && pickRow >= 0)
                    {
                        // Prints Out Player Info
                        pickCol -= 1;
                        Console.WriteLine("You Choose " + playerArray[pickRow, pickCol].Name);
                        Console.WriteLine("           " + playerArray[pickRow, pickCol].Origin);
                        Console.WriteLine("           " + playerArray[pickRow, pickCol].Price);

                        // Confirm user selected correct player
                        Console.WriteLine("Is that correct y/n");
                        string check = Console.ReadLine();

                        // Double checks funds to make sure you dont go in the Red
                        // Checks if user confirmed pick
                        // Confirms you have not picked the same user already.
                        if (fund - playerArray[pickRow, pickCol].Price > 0 && check == "y" && playerArray[pickRow, pickCol].Name != choices[0] && playerArray[pickRow, pickCol].Name != choices[1] && playerArray[pickRow, pickCol].Name != choices[2] && playerArray[pickRow, pickCol].Name != choices[3] && playerArray[pickRow, pickCol].Name != choices[4])
                        {
                            fund -= playerArray[pickRow, pickCol].Price;

                            // Used for pinter players at end
                            choices[choiceCount] = playerArray[pickRow, pickCol].Name;
                            choicesO[choiceCount] = playerArray[pickRow, pickCol].Origin;
                            choicesP[choiceCount] = Convert.ToString(playerArray[pickRow, pickCol].Price);
                            choicesPO[choiceCount] = playerArray[pickRow, pickCol].Position;
                            choicesR[choiceCount] = playerArray[pickRow, pickCol].Rank;

                            // Tells User Current Funds
                            Console.WriteLine(fund);

                            // Add to player Count
                            choiceCount = choiceCount + 1;

                            // Economic coach award || checks if user rank is high enough
                            if (playerArray[pickRow, pickCol].Rank == "1" || playerArray[pickRow, pickCol].Rank == "2" || playerArray[pickRow, pickCol].Rank == "3")
                            {
                                economic = economic + 1;
                            }

                        }
                        else
                        {
                            if (check != "y")
                            {
                                Console.WriteLine("Feel free to pick another player");
                                Console.WriteLine();
                            }
                            if (fund < 0)
                            {
                                Console.WriteLine("Your do not have sufficent funding");
                                Console.WriteLine();
                            }

                        }
                    }
                    else
                    {
                        Console.WriteLine("Please choose player with in the chart");
                    }

                }
                else { }
            }
            // Concludes the picking phase
            Console.WriteLine();
            Console.WriteLine("All players have been chosen have nice day");
            Console.WriteLine("Your Choices Were ");

            // Prints Out Users Choices
            Console.WriteLine("      {0,-20}      {1,-20}      {2,-20}      {3,-20}       {4,-20}", choicesPO[0] + " " + choicesR[0], choicesPO[1] + " " + choicesR[1], choicesPO[2] + " " + choicesR[2], choicesPO[3] + " " + choicesR[3], choicesPO[4] + " " + choicesR[4]);
            Console.WriteLine("      {0,-20}      {1,-20}      {2,-20}      {3,-20}       {4,-20}", choices[0], choices[1], choices[2], choices[3], choices[4]);
            Console.WriteLine("      {0,-20}      {1,-20}      {2,-20}      {3,-20}       {4,-20}", choicesO[0], choicesO[1], choicesO[2], choicesO[3], choicesO[4]);
            Console.WriteLine("      {0,-20}      {1,-20}      {2,-20}      {3,-20}       {4,-20}", choicesP[0], choicesP[1], choicesP[2], choicesP[3], choicesP[4]);

            Console.WriteLine("You Have $" + fund + " remaining");
            Console.WriteLine();

            // Gives the Economic award
            if (fund > 65000000 && economic > 2)
            {
                Console.WriteLine("Great Work Coach You Were Economic");
                Console.WriteLine();
            }
            Console.WriteLine("We hope to see you next year");
            Console.WriteLine("_______________________________________________________________________________________________________________________________________________________________");
        }
    }

    public class Players
    {
        // super exiting variables
        public string Name { get; set; } = " ";
        public string Origin { get; set; } = " ";
        public int Price { get; set; }
        public string Position { get; set; } = " ";
        public string Rank { get; set; } = " ";
        public string ColorAtr { get; set; } = " ";

    }
}
