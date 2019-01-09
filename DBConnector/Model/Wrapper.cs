using System;

namespace DBConnector.Model
{
    public abstract class Wrapper
    {
        public WrapperType Type { get; }
        public String Value { get; set; }

        private String InitialValue = "";

        public Wrapper(WrapperType type)
        {
            this.Type = type;
            this.Value = InitialValue;
        }
        
        public Boolean IsValueSet()
        {
            if (Value.Equals(InitialValue)) return false;
            else return true;
        }
    }

    public enum WrapperType : int
    {
        CAR_TYPE = 1,
        ADDRESS = 2,
        ADDERSS_NUMBER = 3,
        HOUR = 4,
        MINUTES = 5
    }
}
