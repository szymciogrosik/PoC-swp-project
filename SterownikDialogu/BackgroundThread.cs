using DBConnector.Model;
using ModulASR;
using ModulTTS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Controls;

namespace SterownikDialogu
{
    class BackgroundThread
    {
        private ASR ASR;
        private TTS TTS;
        private Order Order;

        private MainWindow MainWindow;

        public BackgroundThread(MainWindow mainWindow)
        {
            this.MainWindow = mainWindow;
            this.Order = new Order();
            this.ASR = new ASR(this.Order);
            this.ASR.LoadGrammar();
            this.TTS = new TTS();
        }

        public void Core()
        {
            this.TTS.setupPropmptToWelcome();
           
            // odpalamy rozpoznawanie mowy
            // KOLES mowi
            // zatrzymujemy rozpoznawanie
            // wczytujemy do obiektu co powiedziął (wszystko lub cześć)
            // while(czy jest czesc) {
            //      obiektcie 
            // }
            // koniec podsumowanie zapis do bazy+
        }

        public void test()
        {
            for (int i = 0; i < 10000; i++)
            {
                MainWindow.UpdateElement(GuiElements.LABEL_TEXT, new string[] { i+"" });
                Thread.Sleep(1000);
            }
        }
    }
}
