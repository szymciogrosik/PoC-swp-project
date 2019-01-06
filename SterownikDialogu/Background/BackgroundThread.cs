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

        private Boolean WaitRecognize = true;

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
            this.TTS.SetupPropmptToWelcome();

            while (!this.Order.IsReady())
            {
                this.WaitRecognize = true;
                this.ASR.StartRecognize();
                MainWindow.UpdateElement(GuiElements.LABEL_LISTENING, new string[] { "true" });
                while (WaitRecognize)
                {
                    Thread.Sleep(1000);
                }
                MainWindow.UpdateElement(GuiElements.LABEL_LISTENING, new string[] { "false" });
                this.MakeQuestion();
            }
            MainWindow.UpdateElement(GuiElements.LABEL_FINISH, new string[] { "any" });
            this.TTS.SetupPropmptToGoodbye();
            // koniec podsumowanie zapis do bazy+
        }

        public void Notify(Dictionary<WrapperType, string> dictionary)
        {
            this.ASR.StopRecognize();
            this.WaitRecognize = false;
            this.MakeUpOrder(dictionary);
            this.UpdateGui();
        }

        private void MakeQuestion()
        {
            if (!this.Order.CarType.IsValueSet()) this.TTS.AdditionalQuestion(WrapperType.CAR_TYPE);
            else if (!this.Order.Address.IsValueSet()) this.TTS.AdditionalQuestion(WrapperType.ADDRESS);
            else if (!this.Order.AddressNumber.IsValueSet()) this.TTS.AdditionalQuestion(WrapperType.ADDERSS_NUMBER);
            else if (!this.Order.Hour.IsValueSet()) this.TTS.AdditionalQuestion(WrapperType.HOUR);
            else if (!this.Order.Minute.IsValueSet()) this.TTS.AdditionalQuestion(WrapperType.MINUTES);
        }

        private void MakeUpOrder(Dictionary<WrapperType, string> dictionary)
        {
            foreach (WrapperType type in Enum.GetValues(typeof(WrapperType)))
            {
                if (!dictionary.ContainsKey(type)) continue;
                switch (type)
                {
                    case WrapperType.CAR_TYPE:
                        this.Order.CarType.Value = (string)dictionary[type];
                        break;
                    case WrapperType.ADDRESS:
                        this.Order.Address.Value = (string)dictionary[type];
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

        private void UpdateGui()
        {
            MainWindow.UpdateElement(GuiElements.LABEL_CAR_TYPE, new string[] { this.Order.CarType.Value + "" });
            MainWindow.UpdateElement(GuiElements.LABEL_ADDRESS, new string[] { this.Order.Address.Value + "" });
            MainWindow.UpdateElement(GuiElements.LABEL_ADDRESS_NUMBER, new string[] { this.Order.AddressNumber.Value + "" });
            MainWindow.UpdateElement(GuiElements.LABEL_HOUR, new string[] { this.Order.Hour.Value + "" });
            MainWindow.UpdateElement(GuiElements.LABEL_MINUTE, new string[] { this.Order.Minute.Value + "" });
        }
    }
}
