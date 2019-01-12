using DBConnector.Model;
using DBConnector.Model.Domain;
using DBConnector.Service;
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
        private readonly ASR ASR;
        private readonly TTS TTS;
        private readonly OrderService OrderService;
        private OrderElements OrderElements;

        private MainWindow MainWindow;

        private Boolean WaitRecognize = true;

        public BackgroundThread(MainWindow mainWindow)
        {
            this.MainWindow = mainWindow;
            this.OrderElements = new OrderElements();
            this.OrderService = new OrderService();
            this.ASR = new ASR();
            this.ASR.LoadGrammar();
            this.TTS = new TTS();
            this.ASR.AddObserver(this);
        }

        public void Core()
        {
            this.TTS.SetupPropmptToWelcome();

            while (!this.OrderElements.IsReady())
            {
                this.WaitRecognize = true;
                this.ASR.StartRecognize();
                MainWindow.UpdateElement(GuiElements.LABEL_LISTENING, new string[] { "true" });
                while (WaitRecognize)
                {
                    Thread.Sleep(1000);
                }
                this.ASR.StopRecognize();
                MainWindow.UpdateElement(GuiElements.LABEL_LISTENING, new string[] { "false" });
                this.MakeQuestion();
            }
            MainWindow.UpdateElement(GuiElements.LABEL_FINISH, new string[] { "any" });
            this.OrderService.SaveOrder(Order.Create(this.OrderElements));
            this.TTS.SetupPropmptToGoodbye();
        }

        public void Notify(Dictionary<WrapperType, string> dictionary)
        {
            this.WaitRecognize = false;
            this.MakeUpOrderAnUpdateGui(dictionary);
        }

        private void MakeQuestion()
        {
            Wrapper unknownElement = this.OrderElements.elements.Find(ele => !ele.IsValueSet());
            if (unknownElement == null) return;
            this.TTS.AdditionalQuestion(unknownElement.Type);
        }

        private void MakeUpOrderAnUpdateGui(Dictionary<WrapperType, string> dictionary)
        {
            foreach (KeyValuePair<WrapperType, string> entry in dictionary)
            {
                Wrapper orderElement = this.OrderElements.elements.Find(ele => ele.Type == entry.Key);
                orderElement.Value = entry.Value;
                MainWindow.UpdateElement(GuiElementConverter.Convert(orderElement.Type), new string[] { orderElement.Value });
            }
        }
    }
}
