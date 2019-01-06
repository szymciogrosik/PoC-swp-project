using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DBConnector.Model
{
    public class CarType : Wrapper<String>
    {
        public CarType() : base(WrapperType.CAR_TYPE, "")
        {
        }

        public override bool IsValueSet()
        {
            if (Value.Equals("")) return false;
            else return true;
        }
    }

    public class Address : Wrapper<String>
    {
        public Address() : base(WrapperType.ADDRESS, "")
        {
        }

        public override bool IsValueSet()
        {
            if (Value.Equals("")) return false;
            else return true;
        }
    }

    public class AddressNumber : Wrapper<int>
    {
        public AddressNumber() : base(WrapperType.ADDERSS_NUMBER, -1)
        {
        }

        public override bool IsValueSet()
        {
            if (Value.Equals(-1)) return false;
            else return true;
        }
    }

    public class Hour : Wrapper<int>
    {
        public Hour() : base(WrapperType.HOUR, -1)
        {
        }

        public override bool IsValueSet()
        {
            if (Value.Equals(-1)) return false;
            else return true;
        }
    }

    public class Minute : Wrapper<int>
    {
        public Minute() : base(WrapperType.MINUTES, -1)
        {
        }

        public override bool IsValueSet()
        {
            if (Value.Equals(-1)) return false;
            else return true;
        }
    }
}
