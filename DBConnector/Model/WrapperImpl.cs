using System;


namespace DBConnector.Model
{
    public class CarType : Wrapper
    {
        public CarType() : base(WrapperType.CAR_TYPE) { }
    }

    public class Address : Wrapper
    {
        public Address() : base(WrapperType.ADDRESS) { }
    }

    public class AddressNumber : Wrapper
    {
        public AddressNumber() : base(WrapperType.ADDERSS_NUMBER) { }
    }

    public class Hour : Wrapper
    {
        public Hour() : base(WrapperType.HOUR) { }
    }

    public class Minute : Wrapper
    {
        public Minute() : base(WrapperType.MINUTES) { }
    }
}
