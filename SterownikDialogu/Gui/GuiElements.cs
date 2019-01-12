using DBConnector.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SterownikDialogu
{
    public enum GuiElements : int
    {
        LABEL_CAR_TYPE = 1,
        LABEL_ADDRESS = 2,
        LABEL_ADDRESS_NUMBER = 3,
        LABEL_HOUR = 4,
        LABEL_MINUTE = 5,
        LABEL_LISTENING = 6,
        LABEL_FINISH = 7
    }

    public class GuiElementConverter
    {
        public static GuiElements Convert(WrapperType type)
        {
            switch(type)
            {
                case WrapperType.CAR_TYPE:
                    return GuiElements.LABEL_CAR_TYPE;
                case WrapperType.ADDRESS:
                    return GuiElements.LABEL_ADDRESS;
                case WrapperType.ADDERSS_NUMBER:
                    return GuiElements.LABEL_ADDRESS_NUMBER;
                case WrapperType.HOUR:
                    return GuiElements.LABEL_HOUR;
                case WrapperType.MINUTES:
                    return GuiElements.LABEL_MINUTE;
                default:
                    throw new ArgumentException("Cannot convert " + type + "to any GuiElements!");
            }
        }
    }
}
