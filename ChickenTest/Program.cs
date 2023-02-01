// See https://aka.ms/new-console-template for more information

using ChickenTest;
using System.Linq.Expressions;

ChickenFarm chicken = new ChickenFarm();
Thread farmer = new Thread(new ThreadStart(chicken.farmerFunc));
farmer.Start();
Retailer chickenstore = new Retailer();
ChickenFarm.priceCut += new priceCutEvent(chickenstore.chickenOnSale); //we set the event as "chickenOnSale"

Thread[] retailers = new Thread[3];

for (int i = 0; i < 3; i++)
{
    retailers[i] = new Thread(new ThreadStart(chickenstore.retailerFunc));
    retailers[i].Name = (i + 1).ToString();
    retailers[i].Start();
}