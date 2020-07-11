using System;
using System.Collections.Generic;
using System.Text;

namespace ShippingCost
{
    public delegate void ShippingFeesDelegate(decimal thePrice, ref decimal fee);

    abstract class ShippingDestination 
    {
        public bool m_isHighRisk;
        public virtual void calcFees(decimal price, ref decimal fee) { }

        public static ShippingDestination GetDestinationInfo(string dest) 
        {
            if (dest.Equals("zone1"))
            {
                return new Dest_Zone1();
            }
            if (dest.Equals("zone2"))
            {
                return new Dest_Zone2();
            }
            if (dest.Equals("zone3"))
            {
                return new Dest_Zone3();
            }
            if (dest.Equals("zone4"))
            {
                return new Dest_Zone4();
            }
            if (dest.Equals("zone5"))
            {
                return new Dest_Zone5();
            }
            return null;
        }
    }

    class Dest_Zone1 : ShippingDestination
    {
        public Dest_Zone1()
        {
            this.m_isHighRisk = false;
        }
        public override void calcFees(decimal price, ref decimal fee)
        {
            fee = price * 0.25m;
        }
    }

    class Dest_Zone2 : ShippingDestination
    {
        public Dest_Zone2()
        {
            this.m_isHighRisk = true;
        }
        public override void calcFees(decimal price, ref decimal fee)
        {
            fee = price * 0.12m;
        }
    }

    class Dest_Zone3 : ShippingDestination //change rate
    {
        public Dest_Zone3()
        {
            this.m_isHighRisk = true;
        }
        public override void calcFees(decimal price, ref decimal fee)
        {
            fee = price * 0.12m;
        }
    }

    class Dest_Zone4 : ShippingDestination
    {
        public Dest_Zone4()
        {
            this.m_isHighRisk = true;
        }
        public override void calcFees(decimal price, ref decimal fee)
        {
            fee = price * 0.04m;
        }
    }

    class Dest_Zone5 : ShippingDestination
    {
        public Dest_Zone5()
        {
            this.m_isHighRisk = false;
        }
        public override void calcFees(decimal price, ref decimal fee)
        {
            fee = price * 0.15m;
        }
    }

}
