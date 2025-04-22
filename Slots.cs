using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pariveda_casiono_henrywoods
{
    public class Slots
    {
        private Random random = new Random();
        public double Play(double bet){
            int result = random.Next(1, 100); // Random number between 1 and 99
            if (result <= 5){
                System.Console.WriteLine("Ja Ja Ja JACKPOT!!!");
                return bet * 10; // 5% chance to win 10x the bet
            }
            else if (result <= 20){
                System.Console.WriteLine("Wow, you won big!!!");
                return bet * 5; // 15% chance to win 5x the bet
            }
            else if (result <= 50){
                System.Console.WriteLine("Nice, you won your bet back...Now keep betting!!!");
                return bet * 2; // 30% chance to win 2x the bet
            }
            else{
                System.Console.WriteLine("Sorry, you lost your bet. But dont leave yet, you can win it back!");
                return -bet; // 50% chance to lose the bet
            }
        }
    }
}