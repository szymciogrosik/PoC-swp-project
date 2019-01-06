using DBConnector.Model;
using ModulASR;
using ModulTTS;
using SterownikDialogu.Background.Listener;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Controls;

namespace SterownikDialogu 
{
    class BackgroundThread : RecognizeEventObserver
    {
        private ASR ASR;
        private TTS TTS;
        private Order Order;

        private MainWindow MainWindow;

        public BackgroundThread(MainWindow mainWindow)
        {
            this.MainWindow = mainWindow;
            this.Order = new Order();
            this.ASR = new ASR();
            this.ASR.LoadGrammar();
            this.TTS = new TTS();
            this.ASR.AddObserver(this);
        }

        public void Core()
        {
            this.TTS.setupPropmptToWelcome();

            this.ASR.StartRecognize();
            // odpalamy rozpoznawanie mowy
            // KOLES mowi
            // zatrzymujemy rozpoznawanie
            // wczytujemy do obiektu co powiedziął (wszystko lub cześć)
            // while(czy jest czesc) {
            //      obiektcie 
            // }
            // koniec podsumowanie zapis do bazy+
            while(true)
            {

            }
        }

        public void test()
        {
            for (int i = 0; i < 10000; i++)
            {
                MainWindow.UpdateElement(GuiElements.LABEL_TEXT, new string[] { i+"" });
                Thread.Sleep(1000);
            }
        }

        public void Notify(Dictionary<WrapperType, string> dictionary)
        {
            this.MakeUpOrder(dictionary);
            Console.WriteLine("asdasdas");
        }

        private void MakeUpOrder(Dictionary<WrapperType, string> dictionary)
        {
            foreach (WrapperType type in Enum.GetValues(typeof(WrapperType)))
            {
                if (!dictionary.ContainsKey(type)) continue;
                switch (type)
                {
                    case WrapperType.CAR_TYPE:
                        this.Order.CarType.Value = (string) dictionary[type];
                        break;
                    case WrapperType.ADDRESS:
                        this.Order.Address.Value = (string) dictionary[type];
                        break;
                    case WrapperType.ADDERSS_NUMBER:
                        this.Order.AddressNumber.Value = Int32.Parse(dictionary[type]);
                        break;
                    case WrapperType.HOUR:
                        this.Order.Hour.Value = Int32.Parse(dictionary[type]);
                        break;
                    case WrapperType.MINUTES:
                        this.Order.Minute.Value = Int32.Parse(dictionary[type]);
                        break;
                }
            }
        }
    }
}
