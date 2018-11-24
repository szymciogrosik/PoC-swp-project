using Microsoft.Speech.Recognition.SrgsGrammar;

namespace ModulASR.UberGrammar
{
    public class UberGrammar
    {
        public SrgsItem[] orzeczenieDictionary { get; set; }
        public SrgsItem[] bezokolicznikDictionary { get; set; }
        public SrgsItem[] carTypeDictionary { get; set; }
        public SrgsItem[] wyrazeniePrzyimkowe1Dictionary { get; set; }
        public SrgsItem[] addressStreetDictionary { get; set; }
        public SrgsItem[] addressNumberDictionary { get; set; }
        public SrgsItem[] wyrazeniePrzyimkowe2Dictionary { get; set; }
        public SrgsItem[] timeHourDictionary { get; set; }
        public SrgsItem[] timeMinuteDictionary { get; set; }

        public UberGrammar()
        {
            this.orzeczenieDictionary = getOrzeczenieDictionary();
            this.bezokolicznikDictionary = getBezokolicznikDictionary();
            this.carTypeDictionary = getCarTypeDictionary();
            this.wyrazeniePrzyimkowe1Dictionary = getWyrazeniePrzyimkowe1Dictionary();
            this.addressStreetDictionary = getAddressStreetDictionary();
            this.addressNumberDictionary = getAddressNumberDictionary();
            this.wyrazeniePrzyimkowe2Dictionary = getWyrazeniePrzyimkowe2Dictionary();
            this.timeHourDictionary = getTimeHourDictionary();
            this.timeMinuteDictionary = getTimeMinuteDictionary();
        }

        private SrgsItem[] getOrzeczenieDictionary()
        {
            return new SrgsItem[]
            {
                new SrgsItem(0, 1, "chciałbym"),
                new SrgsItem(0, 1, "daj"),
                new SrgsItem(0, 1, "dawaj"),
                new SrgsItem(0, 1, "podaj"),
                new SrgsItem(0, 1, "poproszę"),
                new SrgsItem(0, 1, "proszę"),
                new SrgsItem(0, 1, "sprzedaj"),
                new SrgsItem(0, 1, "czy mogę")
            };
        }

        private SrgsItem[] getBezokolicznikDictionary()
        {
            return new SrgsItem[]
            {
                new SrgsItem(0, 1, "zamówić"),
                new SrgsItem(0, 1, "dostać"),
                new SrgsItem(0, 1, "zarezerwować"),
                new SrgsItem(0, 1, "wynająć")
            };
        }

        private SrgsItem[] getCarTypeDictionary()
        {
            return new SrgsItem[]
            {
                new SrgsItem("samochód"),
                new SrgsItem("wan"),
                new SrgsItem("helikopter"),
                new SrgsItem("hulajnoge"),
                new SrgsItem("rower")
            };
        }

        private SrgsItem[] getWyrazeniePrzyimkowe1Dictionary()
        {
            return new SrgsItem[]
            {
                new SrgsItem(0, 1, "na ulicę"),
                new SrgsItem(0, 1, "przy ulicy"),
                new SrgsItem(0, 1, "na adres"),
                new SrgsItem(0, 1, "pod adres"),
                new SrgsItem(0, 1, "w miejsce")
            };
        }

        private SrgsItem[] getAddressStreetDictionary()
        {
            return new SrgsItem[]
            {
                new SrgsItem("Miodowa"),
                new SrgsItem("Długa"),
                new SrgsItem("Okopowa"),
                new SrgsItem("Konrada")
            };
        }

        private SrgsItem[] getAddressNumberDictionary()
        {
            return new SrgsItem[]
            {
                new SrgsItem("1"),
                new SrgsItem("11"),
                new SrgsItem("22"),
                new SrgsItem("30"),
                new SrgsItem("45")
            };
        }

        private SrgsItem[] getWyrazeniePrzyimkowe2Dictionary()
        {
            return new SrgsItem[]
            {
                new SrgsItem("na godzinę"),
                new SrgsItem("o godzinie")
            };
        }

        private SrgsItem[] getTimeHourDictionary()
        {
            SrgsItem[] resultTable = new SrgsItem[24];

            for (int i = 0; i < 24; i++)
            {
                resultTable[i] = new SrgsItem(i.ToString());
            }

            return resultTable;
        }

        private SrgsItem[] getTimeMinuteDictionary()
        {
            SrgsItem[] resultTable = new SrgsItem[60];

            for (int i = 0; i < 60; i++)
            {
                resultTable[i] = new SrgsItem(i.ToString());
            }

            return resultTable;
        }
    }
}