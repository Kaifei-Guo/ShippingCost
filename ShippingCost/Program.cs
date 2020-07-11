using System;

namespace ShippingCost
{
    class Program
    {
        static void Main(string[] args)
        {
            ShippingFeesDelegate calcDestinationFee;
            ShippingDestination destination;

            string Zone;
            do
            {
                Console.WriteLine("What is the destination zone?");
                Zone = Console.ReadLine();

                if (!Zone.Equals("exit"))
                {
                    destination = ShippingDestination.GetDestinationInfo(Zone);

                    if (destination != null)
                    {
                        Console.WriteLine("What is the item price?");
                        string thePriceStr = Console.ReadLine();
                        decimal itemPrice = decimal.Parse(thePriceStr);

                        calcDestinationFee = destination.calcFees;

                        if (destination.m_isHighRisk)
                        {
                            calcDestinationFee += delegate (decimal thePrice, ref decimal itemFee)
                            {
                                itemFee += 25.0m;
                            };
                        }

                        decimal theFee = 0.0m;
                        calcDestinationFee(itemPrice, ref theFee);
                        Console.WriteLine("The shipping fees are: {0}", theFee);
                    }
                    else
                    {
                        Console.WriteLine("Hmm, you seem to have entered an unkonwn destination.");
                    }
                }

            } while (Zone != "exit");

            Console.ReadLine();
        }
    }
}
