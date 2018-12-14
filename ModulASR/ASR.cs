using System;
using System.IO;
using DBConnector.Model;
using DBConnector.Service;
using Microsoft.Speech.Recognition;


namespace ModulASR
{
    public class ASR
    {
        private SpeechRecognitionEngine SRE;
        public System.Globalization.CultureInfo pRecognitionLanguage = new System.Globalization.CultureInfo("pl-PL");
        private OrderService orderService;
        private Order order;
        private UberGrammar.UberGrammar uberGrammar;

        public ASR(Order order)
        {
            this.order = order;
            init();
        }

        private void init()
        {
            SRE = new SpeechRecognitionEngine(pRecognitionLanguage);
            SRE.SpeechRecognized += SRE_SpeechRecognized; ;
            SRE.SetInputToDefaultAudioDevice();

            uberGrammar = new UberGrammar.UberGrammar();
            Grammar grammar = CreateGrammar();
            SRE.LoadGrammar(grammar);
        }

        public void startRecognize()
        {
            SRE.RecognizeAsync(RecognizeMode.Multiple);
        }

        public void stopRecognize()
        {
            SRE.RecognizeAsyncStop();
        }

        private string GetValue(SemanticValue Semantics, string keyName)
        {
            string result = "";
            if (Semantics.ContainsKey(keyName))
                result = Semantics[keyName].Value.ToString();
            return result;
        }

        private string GetConfidence(SemanticValue Semantics, string keyName)
        {
            string result = "";
            if (Semantics.ContainsKey(keyName))
                result = Semantics[keyName].Confidence.ToString("0.0000");
            return result;
        }

        private void SRE_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result != null)
            {
                if (e.Result.Semantics != null && e.Result.Semantics.Count != 0)
                {
                    Console.WriteLine(e.Result.Text);
                }
            }
        }


        private Grammar CreateGrammar()
        {
            GrammarBuilder builder = new GrammarBuilder();
            string fileName = @"c:\Users\thody\IdeaProjects\swp_projekt\ModulASR\grammar.xml";
            Grammar citiesGrammar = new Grammar(new FileStream(fileName, FileMode.Open));
            //citiesGrammar.Name = "Stream Cities Grammar";
            return citiesGrammar;
        }
    }
}
