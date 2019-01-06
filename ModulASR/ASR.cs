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

        public ASR(Order order)
        {
            this.order = order;
            Init();
        }

        private void Init()
        {
            SRE = new SpeechRecognitionEngine(pRecognitionLanguage);
            SRE.SpeechRecognized += SRE_SpeechRecognized; ;
            SRE.SetInputToDefaultAudioDevice();
        }

        public void StartRecognize()
        {
            if (SRE.Grammars.Count == 0)
            {
                Console.WriteLine("ASR module doesnt load the Grammar.");
                return;
            }
            SRE.RecognizeAsync(RecognizeMode.Multiple);
        }

        public void StopRecognize()
        {
            SRE.RecognizeAsyncStop();
        }

        public void LoadGrammar(WrapperType wrapperType = WrapperType.UNKNOWN)
        {
            // czy może jadnak ładować kilka a nie jedną ??
            SRE.UnloadAllGrammars();
            switch (wrapperType)
            {
                case WrapperType.CAR_TYPE:
                    Console.WriteLine("Load grammar not omplemented");
                    break;
                case WrapperType.ADDERSS:
                    Console.WriteLine("Load grammar not omplemented");
                    break;
                case WrapperType.ADDERSS_NUMBER:
                    Console.WriteLine("Load grammar not omplemented");
                    break;
                case WrapperType.HOUR:
                    Console.WriteLine("Load grammar not omplemented");
                    break;
                case WrapperType.MINUTES:
                    Console.WriteLine("Load grammar not omplemented");
                    break;
                default:
                    SRE.LoadGrammar(CreateGrammar("grammar"));
                    break;
            }
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

        private Grammar CreateGrammar(string grammarName)
        {
            GrammarBuilder builder = new GrammarBuilder();
            string fileName = @"c:\Users\thody\IdeaProjects\swp_projekt\ModulASR\" + grammarName + ".xml";
            Grammar citiesGrammar = new Grammar(new FileStream(fileName, FileMode.Open));
            return citiesGrammar;
        }
    }
}
