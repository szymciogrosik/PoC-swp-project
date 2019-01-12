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

        private List<RecognizeEventObserver> observers;

        public ASR()
        {
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

        private void SRE_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result != null)
            {
                if (e.Result.Semantics != null && e.Result.Semantics.Count != 0)
                {
                    Console.WriteLine(e.Result.Text);

                    Dictionary<WrapperType, string> recognizeMap = new Dictionary<WrapperType, string>();
                    SemanticValue semantic = e.Result.Semantics;
                    
                    foreach (WrapperType type in Enum.GetValues(typeof(WrapperType)))
                    {
                        string s = type.ToString();
                        SemanticValue obj = semantic[type.ToString()];
                        if (obj.Value.Equals("")) continue;
                        recognizeMap.Add(type, (string) obj.Value);
                    }
                    Console.WriteLine("Wysyłam wiadomosć");
                    this.NotifyObserver(recognizeMap);
                }
            }
        }

        private Grammar CreateGrammar(string grammarName)
        {
            string localPath = Path.Combine(Environment.CurrentDirectory, @"..\..\..\ModulASR\Grammar\", grammarName + ".xml");
            Grammar grammar = new Grammar(new FileStream(localPath, FileMode.Open));
            return grammar;
        }

        public void AddObserver(RecognizeEventObserver observer)
        {
            this.observers.Add(observer);
        }

        public void RemoveObserver(RecognizeEventObserver observer)
        {
            this.observers.Remove(observer);
        }

        public void NotifyObserver(Dictionary<WrapperType, string> dictionary)
        {
            foreach(RecognizeEventObserver observer in this.observers)
            {
                observer.Notify(dictionary);
            }
        }
    }
}
