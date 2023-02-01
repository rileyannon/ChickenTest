using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenTest
{
    public delegate void priceCutEvent(int pr);
    internal class ChickenFarm
    {
        static Random rng = new Random(); //generate egg prices
        public static event priceCutEvent priceCut;
        private static int chickenPrice = 10; //default price

        public int getPrice() { 
            return chickenPrice; 
        }

        public static void changePrice(int price) {
            if (price < chickenPrice && priceCut != null) {
                priceCut(price);
            }

            chickenPrice = price;
        }

        public void farmerFunc() {
            for (int i = 0; i < 50; i++) {      
                Thread.Sleep(500);              //updates price every 5 seconds
                int p = rng.Next(5, 10);        

                ChickenFarm.changePrice(p);
            }
        }


    }        
    
    public class Retailer {
            public void retailerFunc() { 
                ChickenFarm chicken = new ChickenFarm();

                for (int i = 0; i < 10; i++) { 
                    Thread.Sleep(1000);
                    int p = chicken.getPrice();
                    Console.WriteLine("Store{0} has reached price ${1} each", Thread.CurrentThread.Name, p);
                }
            }

            public void chickenOnSale(int p)
            {
                Console.WriteLine("Store{0} has reached LOW price ${1} each", Thread.CurrentThread.Name, p);
            }
        }
}
