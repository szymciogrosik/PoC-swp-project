using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Versioning;
using DBConnector.Model;
using DBConnector.Service;
using Microsoft.Speech.Recognition;
using SterownikDialogu.Background.Listener;

namespace ModulASR
{
    public class ASR : RecognizeEventObservable
    {
        private SpeechRecognitionEngine SRE;
        public System.Globalization.CultureInfo pRecognitionLanguage = new System.Globalization.CultureInfo("pl-PL");
        private OrderService orderService;
        private Order order;

        private List<RecognizeEventObserver> observers;

        public ASR(Order order)
        {
            this.order = order;
            this.observers = new List<RecognizeEventObserver>();
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

        public void LoadGrammar()
        {
            SRE.UnloadAllGrammars();
            SRE.LoadGrammar(CreateGrammar("OrderGrammar"));
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
                    Console.WriteLine("Wysyłam wiadomosć");
                    this.NotifyObserver(e.Result.Text);

                }
            }
        }

        private Grammar CreateGrammar(string grammarName)
        {
//            GrammarBuilder builder = new GrammarBuilder();
            string localPath = Path.Combine(Environment.CurrentDirectory, @"..\..\..\ModulASR\Grammar\", grammarName + ".xml");
            Grammar citiesGrammar = new Grammar(new FileStream(localPath, FileMode.Open));
            return citiesGrammar;
        }

        public void AddObserver(RecognizeEventObserver observer)
        {
            this.observers.Add(observer);
        }

        public void RemoveObserver(RecognizeEventObserver observer)
        {
            this.observers.Remove(observer);
        }

        public void NotifyObserver(String message)
        {
            foreach(RecognizeEventObserver observer in this.observers)
            {
                observer.Notify(message);
            }
        }
    }
}
