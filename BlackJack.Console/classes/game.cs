using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Console
{
    public class game 
    {
        public static bool playGame()
        {
            // Just throwing all these vars in the method here locally might not be the best way but works for a simple assigment like this
            string input1; // This string gets the amount of money the player wants to wager
            string input2; // This string stores a "bool" answer when I ask the user if they want to hit or hold
            string input3; // This string is used to see if the user wants to quit the game or keep playing
            int dealerTotal; // The total card score for the dealer
            int userTotal; // The total card score for the user
            int dealerMoney = 100; // Keeps total for dealer
            int userMoney = 100; // Keeps total for the user
            int theBet; // The converted value (stiring to int) from when I asked the user to enter their first bet
            int winStreakCounter = 0; // Keep track of user win strek
            int resetStreak = 0; // take win streak back to 0 if dealer wins

            do
            {
                // generate a random number for each card draw each time through the loop
                Random rnd = new Random();
                int card1 = rnd.Next(1, 10);  
                int card2 = rnd.Next(1, 10);   
                int card3 = rnd.Next(1, 10);
                int card4 = rnd.Next(1, 10);
                int card5 = rnd.Next(1, 10);
                int card6 = rnd.Next(1, 10);

                // reset bools to false each time through the loop
                bool bool1 = false;
                bool bool2 = false;

                // getting the wager from the user. Display the amount back to them if it is a number. If it is NAN I make them put in an actaul number

                System.Console.WriteLine("How much would you like to wager?");
                input1 = System.Console.ReadLine();

                if (int.TryParse(input1, out theBet))
                {
                    // don't do anything yet just convert it if possible
                }
                while (!int.TryParse(input1, out theBet) || theBet <= 0 || userMoney < theBet || dealerMoney < theBet) 
                {
                    System.Console.WriteLine("Not a valid wager. The number must be whole. The number must be 1 or greater. The number must be less than or equal to the person with the lowest dollar total. ");
                    System.Console.WriteLine("How much would you like to wager?");
                    input1 = System.Console.ReadLine();
                }

                System.Console.WriteLine($"\nThank your for your wager of ${theBet}");

                userTotal = card1 + card2;
                System.Console.WriteLine($"Your first card was {card1} and your second card was {card2} so that means your total is {userTotal}.");

                while (bool1 == false)
                {
                    System.Console.WriteLine($"Would you like to draw a third card? Type Y for yes and type N for no.");
                    input2 = System.Console.ReadLine().ToUpper();

                    if (input2 == "Y")
                    {
                        bool1 = true;
                        userTotal += card3;
                        System.Console.WriteLine($"\nYour third card was a {card3}");
                        System.Console.BackgroundColor = ConsoleColor.Red;
                        System.Console.Write($"That means your final total is {userTotal}");
                        System.Console.ResetColor();
                        System.Console.Write($" lets see if that beats the dealer...");

                    }
                    else if (input2 == "N")
                    {
                        bool1 = true;
                        System.Console.WriteLine($"\nYou declined to draw a third card");
                        System.Console.BackgroundColor = ConsoleColor.Red;
                        System.Console.Write($"\nSo that means your final total is {userTotal}");
                        System.Console.ResetColor();
                        System.Console.Write($" lets see if that beats the dealer...");
                    }
                }

                // if the user goes over 21 set their total to 0
                if (userTotal > 21)
                {
                    userTotal = 0;
                }

                System.Console.WriteLine($"\n");

                dealerTotal = card4 + card5;
                if (dealerTotal <= 17 || dealerTotal < userTotal)
                {
                    dealerTotal += card6;
                    System.Console.BackgroundColor = ConsoleColor.Red;
                    System.Console.Write($"The dealer's total is {dealerTotal}");
                    System.Console.ResetColor();
                    System.Console.Write($" their first first card was {card4} then their second card was {card5} and their third card was {card6}");
                }
                else if (userTotal > 21)
                {
                    System.Console.BackgroundColor = ConsoleColor.Red;
                    System.Console.Write($"\nThe dealer's final total is {dealerTotal}");
                    System.Console.ResetColor();
                    System.Console.Write($" their first first card was {card4} then their second card was {card5} and their third card was passed on");
                }

                // If the dealer goes over 21 set their total to 0
                if (dealerTotal > 21)
                {
                    dealerTotal = 0;
                }

                System.Console.WriteLine($"\n");


                // Determine and display who the winner is
                if (userTotal < dealerTotal)
                {
                    winStreakCounter = resetStreak;
                    System.Console.WriteLine($"Dealer wins that round.\n");
                    dealerMoney += theBet;
                    userMoney -= theBet;
                }
                else if (dealerTotal < userTotal)
                {
                    winStreakCounter++;
                    System.Console.WriteLine($"You beat the dealer and won the round!\n");
                    userMoney += theBet;
                    dealerMoney -= theBet;

                }
                else
                {
                    winStreakCounter = resetStreak;
                    System.Console.WriteLine($"Looks like we have a tie. Nobody wins and the money will be given back to each side\n");
                }

                if (winStreakCounter == 3)
                {
                    System.Console.WriteLine($"Nice job on 3 round wins in a row vs the dealer you have won a free sweet tea!!!!\n");
                }

                if (winStreakCounter == 5)
                {
                    System.Console.WriteLine($"Wow that is 5 round wins in a row!! You better not be cheating! If you are I know a secret agent that I will send after you!!\n");
                }

                System.Console.WriteLine($"Updated score is:\t Dealer Money: ${dealerMoney}\t Your Money: ${userMoney}");

                if (userMoney == 0)
                {
                    System.Console.WriteLine("You ran out of money and lost. Thank you for playing press enter to exit");
                    System.Console.ReadLine();
                    return false;

                }

                if (dealerMoney == 0)
                {
                    System.Console.WriteLine("You ran the dealer out of money and won! Thank you for playing press enter to exit");
                    System.Console.ReadLine();
                    return false;
                }

                while (bool2 == false)
                {
                    System.Console.WriteLine($"Thank you for playing, to play another round type Y. To quit game type N");
                    input3 = System.Console.ReadLine().ToUpper();
                    if (input3 == "Y")
                    {
                        bool2 = true;
                        System.Console.WriteLine($"OK get ready for another round.");

                    }
                    if (input3 == "N")
                    {
                        bool2 = true;
                        System.Console.Clear();
                        System.Console.WriteLine($"Game over. Press the enter key to exit console window.");
                        System.Console.ReadLine();
                        return false;
                    }
                }
             
                System.Console.WriteLine($"-------------New Round----------------------");

            } while (true);
        }

    }
}
