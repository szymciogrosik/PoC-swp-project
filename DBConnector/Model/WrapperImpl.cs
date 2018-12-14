using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DBConnector.Model
{
    class CarType : Wrapper<String>
    {
        public CarType() : base(WrapperType.CAR_TYPE, "")
        {
        }
    }

    class Address : Wrapper<String>
    {
        public Address() : base(WrapperType.ADDERSS, "")
        {
        }
    }
}
