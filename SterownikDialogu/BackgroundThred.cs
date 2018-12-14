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
    class BackgroundThred
    {
        private ASR asr;
        private TTS tts;

        private MainWindow MainWindow;

        public BackgroundThred(MainWindow mainWindow)
        {
            this.MainWindow = mainWindow;
            this.asr = new ASR(null);
            this.tts = new TTS();
        }

        public void core()
        {
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
