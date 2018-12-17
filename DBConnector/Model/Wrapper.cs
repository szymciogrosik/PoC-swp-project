﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBConnector.Model
{
    public class Wrapper<T>
    {
        public WrapperType Type { get; }
        public T Value { get; set; }

        public Wrapper(WrapperType type, T Value)
        {
            this.Type = Type;
            this.Value = Value;
        }
    }

    public enum WrapperType : int
    {
        // TODO uzupełnić o pozostałe typy
        CAR_TYPE = 1,
        ADDERSS = 2,
        ADDERSS_NUMBER = 3,
        HOUR = 4,
        MINUTES = 5
    }
}
