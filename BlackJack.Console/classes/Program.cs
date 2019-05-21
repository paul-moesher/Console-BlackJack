using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Console
{
    class Program
    {
    
        static void Main(string[] args)
        {
            try
            {
                System.Console.WriteLine($"*****************************************");
                System.Console.WriteLine($"WELCOME TO PAULS CONSOLE BLACK JACK GAME");
                System.Console.WriteLine($"*****************************************\n");
                System.Console.WriteLine("This is a simple blackjack game. You start with $100 and the dealer " +
                    "also starts with $100. The game goes until you quit or until one side runs out of money. Each" +
                    " round you need to wager an amount of money, the amount must be less than or equal to the total amount" +
                    " of money that the person with the lower amount of money has. The amount bet also must be whole and must be at least one. Each round you are flipped two cards with the numbers of 1-10 you can choose to " +
                    "get dealt a third card or to stay where you are at. At the end of the round the person with the higher total " +
                    "wins and takes the money that was bet for that round, however if one side goes over 21 and the other side stays" +
                    " under 21 the side that stayed under 21 wins by default.\n");
                System.Console.WriteLine($"Dealer Money: $100 \t Your Money: $100");
                game g1 = new game();
                game.playGame();
            } catch (Exception ex)
            {
                System.Console.WriteLine($"Error please contact Paul Moesher for help");
            }
        }
    }
}



