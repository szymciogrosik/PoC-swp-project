using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBConnector.Model.Domain
{
    public class OrderElements
    {
        public List<Wrapper> elements = new List<Wrapper>();
        
        public OrderElements()
        {
            elements.Add(new CarType());
            elements.Add(new Address());
            elements.Add(new AddressNumber());
            elements.Add(new Hour());
            elements.Add(new Minute());
        }

        public Boolean IsReady()
        {
            bool isNotSet = this.elements.Any(ele => !ele.IsValueSet());

            if (isNotSet) return false;
            return true;
        }

        public Wrapper Find(WrapperType wrapperType)
        { 
            return this.elements.Find(ele => ele.Type == wrapperType);
        }
    }
}
