using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pariveda_casiono_henrywoods
{
    public class Blackjack
    {
        private Random random = new Random();
        public double Play(double bet){
            int[] userHand = new int[10];
            int[] dealerHand = new int[10];
            int userHandCount = 0;
            int dealerHandCount = 0;

            // Deal initial cards
            userHand[userHandCount++] = DealCard();
            dealerHand[dealerHandCount++] = DealCard();
            userHand[userHandCount++] = DealCard();
            dealerHand[dealerHandCount++] = DealCard();

            System.Console.WriteLine($"Dealer has shown: {dealerHand[0]}");
            ShowHand("Your hand", userHand, userHandCount);

            //your turn
            for (int i = 0; i < 8;){
                Console.Write("Hit or Stand? (h/s): ");
                string choice = Console.ReadLine().ToLower();
                if(choice == "h"){
                    userHand[userHandCount++] = DealCard();
                    ShowHand("Your hand", userHand, userHandCount);
                    if (HandValue(userHand, userHandCount) > 21){
                        System.Console.WriteLine("You busted! Dealer wins.");
                        return -bet; // Player loses the bet
                    }
                    i++;
                }
                else if(choice == "s"){
                    break; // Player stands
                }
                else{
                    System.Console.WriteLine("Invalid choice. Please enter 'h' or 's'.");
                    
                }
            }

            // Dealer's turn
            System.Console.WriteLine("Dealer's turn...");
            ShowHand("Dealer's hand", dealerHand, dealerHandCount);
            for (int i = 0; i < 8 && HandValue(dealerHand, dealerHandCount) < 17; i++){
                dealerHand[dealerHandCount++] = DealCard();
                ShowHand("Dealer's hand", dealerHand, dealerHandCount);
            }
            int userTotal = HandValue(userHand, userHandCount);
            int dealerTotal = HandValue(dealerHand, dealerHandCount);
            System.Console.WriteLine($"\nYour total: {userTotal}\nDealer's total: {dealerTotal}");

            //determine the winner
            if (dealerTotal > 21 || userTotal > dealerTotal){
                System.Console.WriteLine("You win!");
                System.Console.WriteLine("\nPress enter to return to menu");
                Console.ReadLine();
                return bet * 2; // Player wins the bet
            } else if (userTotal < dealerTotal){
                System.Console.WriteLine("Dealer wins!");
                System.Console.WriteLine("\nPress enter to return to menu");
                Console.ReadLine();
                return -bet; // Player loses the bet
            } else {
                System.Console.WriteLine("It's a tie!");
                System.Console.WriteLine("\nPress enter to return to menu");
                Console.ReadLine();
                return bet; // No one wins or loses
            }

        }
        private int DealCard(){
            int card = random.Next(1, 14); // Random card between 1 and 13
            return card > 10 ? 10 : card; // Face cards are worth 10 and ace can be 11 or 1
        }
        private int HandValue(int[] hand, int count){
            int total = 0;
            int aces = 0;
            for (int i = 0; i < count; i++){
                total += hand[i];
                if (hand[i] == 1){
                    aces++; // Count the number of aces
                }
            }
            while (aces > 0 && total + 10 <= 21){
                total += 10; // Convert ace from 1 to 11
                aces--;
            }
            return total;
        }
        private void ShowHand(string name, int[] hand, int count){
            System.Console.Write($"{name}: ");
            for (int i = 0; i < count; i++){
                System.Console.Write($"{hand[i]} ");
            }
            System.Console.WriteLine();
        }
    }
}
