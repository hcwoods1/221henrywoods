using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pariveda_casiono_henrywoods
{
    public class Player
    {
        private string name;
        private double balance;
        public Player(string name, double balance){
            this.name = name;
            this.balance = balance;
        }
        public string GetName(){
            return name;
        }

        public double GetBalance(){
            return balance;
        }

        public bool PlaceBet(double betAmount){
            if (betAmount <= balance){
                balance -= betAmount;
                return true;
            } 
            return false;
        }
        public void WinBet(double winnings){
            balance +=  winnings; //win
        }
    }
}