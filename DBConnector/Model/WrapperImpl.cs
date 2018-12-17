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
    }

    public class Address : Wrapper<String>
    {
        public Address() : base(WrapperType.ADDERSS, "")
        {
        }
    }

    public class AddressNumber : Wrapper<int>
    {
        public AddressNumber() : base(WrapperType.ADDERSS_NUMBER, -1)
        {

        }
    }

    public class Hour : Wrapper<int>
    {
        public Hour() : base(WrapperType.HOUR, -1)
        {

        }
    }

    public class MINUTES : Wrapper<int>
    {
        public MINUTES() : base(WrapperType.MINUTES, -1)
        {

        }
    }
}
