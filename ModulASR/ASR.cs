using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBConnector.Model;
using DBConnector.Service;
using Microsoft.Speech.Recognition;
using Microsoft.Speech.Recognition.SrgsGrammar;


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
               
//                txtConfidence.Text = e.Result.Confidence.ToString("0.0000");
                if (e.Result.Semantics != null && e.Result.Semantics.Count != 0)
                {
                    Console.WriteLine(GetValue(e.Result.Semantics, "Orzeczenie"));

//                    txtValue0.Text = GetValue(e.Result.Semantics, "ORZECZENIE");
//                    txtValue.Text = txtValue0.Text;
//                    txtConfidence0.Text = GetConfidence(e.Result.Semantics, "ORZECZENIE");
//
//                    txtValue1.Text = GetValue(e.Result.Semantics, "BEZOKOLICZNIK");
//                    txtValue.Text += " " + txtValue1.Text;
//                    txtConfidence1.Text = GetConfidence(e.Result.Semantics, "BEZOKOLICZNIK"); ;
//
//                    txtValue2.Text = GetValue(e.Result.Semantics, "LICZBA");
//                    txtValue.Text += " " + txtValue2.Text;
//                    txtConfidence2.Text = GetConfidence(e.Result.Semantics, "LICZBA");
//
//                    txtValue3.Text = GetValue(e.Result.Semantics, "DOPELNIENIE");
//                    txtValue.Text += " " + txtValue3.Text;
//                    txtConfidence3.Text = GetConfidence(e.Result.Semantics, "DOPELNIENIE");
//
//                    txtValue4.Text = GetValue(e.Result.Semantics, "PRZYDAWKA");
//                    txtValue.Text += " " + txtValue4.Text;
//                    txtConfidence4.Text = GetConfidence(e.Result.Semantics, "PRZYDAWKA");
                }
            }
        }


        private Grammar CreateGrammar()
        {
            SrgsRule ruleOrzeczenie = new SrgsRule("Orzeczenie");
            SrgsOneOf orzeczenie = new SrgsOneOf(uberGrammar.orzeczenieDictionary);
            ruleOrzeczenie.Add(orzeczenie);
            //            CreateDescriptionRules(ruleOrzeczenie, 0, 0);

            SrgsRule ruleBezokolicznik = new SrgsRule("Bezokolicznik");
            SrgsOneOf bezokolicznik = new SrgsOneOf(uberGrammar.bezokolicznikDictionary);
            ruleBezokolicznik.Add(bezokolicznik);
            //            CreateDescriptionRules(ruleBezokolicznik, 0, 0);

            SrgsRule ruleCarType = new SrgsRule("Typ_pojazdu");
            SrgsOneOf carType = new SrgsOneOf(uberGrammar.carTypeDictionary);
            ruleCarType.Add(carType);
            //            CreateDescriptionRules(ruleCarType, 0, 0);

            SrgsRule ruleWyrazeniePrzyimkowe1 = new SrgsRule("Wyrazenie_przyimkowe1");
            SrgsOneOf wyrazeniePrzyimkowe1 = new SrgsOneOf(uberGrammar.wyrazeniePrzyimkowe1Dictionary);
            ruleWyrazeniePrzyimkowe1.Add(wyrazeniePrzyimkowe1);
            //            CreateDescriptionRules(ruleWyrazeniePrzyimkowe1, 0, 0);

            SrgsRule ruleAddressStreet = new SrgsRule("Adres_ulica");
            SrgsOneOf addressStreet = new SrgsOneOf(uberGrammar.addressStreetDictionary);
            ruleAddressStreet.Add(addressStreet);
            //            CreateDescriptionRules(ruleAddressStreet, 0, 0);

            SrgsRule ruleAddressNumber = new SrgsRule("Adres_numer");
            SrgsOneOf addressNumber = new SrgsOneOf(uberGrammar.addressNumberDictionary);
            ruleAddressNumber.Add(addressNumber);
            //            CreateDescriptionRules(ruleAddressNumber, 0, 0);

            SrgsRule ruleWyrazeniePrzyimkowe2 = new SrgsRule("Wyrazenie_przyimkowe2");
            SrgsOneOf wyrazeniePrzyimkowe2 = new SrgsOneOf(uberGrammar.wyrazeniePrzyimkowe2Dictionary);
            ruleWyrazeniePrzyimkowe2.Add(wyrazeniePrzyimkowe2);
            //            CreateDescriptionRules(ruleWyrazeniePrzyimkowe2, 0, 0);

            SrgsRule ruleTimeHour = new SrgsRule("Godzina");
            SrgsOneOf timeHour = new SrgsOneOf(uberGrammar.timeHourDictionary);
            ruleTimeHour.Add(timeHour);
            //            CreateDescriptionRules(ruleTimeHour, 0, 0);

            SrgsRule ruleTimeMinute = new SrgsRule("Minuta");
            SrgsOneOf timeMinute = new SrgsOneOf(uberGrammar.timeMinuteDictionary);
            ruleTimeMinute.Add(timeMinute);
            //            CreateDescriptionRules(ruleTimeMinute, 0, 0);


            // utwórz korzeń.
            SrgsRule rootRule = new SrgsRule("rootUber");
            rootRule.Scope = SrgsRuleScope.Public;


            rootRule.Add(new SrgsRuleRef(ruleOrzeczenie, "Orzeczenie"));
            rootRule.Add(new SrgsRuleRef(ruleBezokolicznik, "Bezokolicznik"));
            rootRule.Add(new SrgsRuleRef(ruleCarType, "Typ_pojazdu"));
            rootRule.Add(new SrgsRuleRef(ruleWyrazeniePrzyimkowe1, "Wyrazenie_przyimkowe1"));
            rootRule.Add(new SrgsRuleRef(ruleAddressStreet, "Adres_ulica"));
            rootRule.Add(new SrgsRuleRef(ruleAddressNumber, "Adres_numer"));
            rootRule.Add(new SrgsRuleRef(ruleWyrazeniePrzyimkowe2, "Wyrazenie_przyimkowe2"));
            rootRule.Add(new SrgsRuleRef(ruleTimeHour, "Godzina"));
            rootRule.Add(new SrgsRuleRef(ruleTimeMinute, "Minuta"));


            SrgsDocument docUber = new SrgsDocument();
            docUber.Culture = pRecognitionLanguage;
            docUber.Rules.Add(new SrgsRule[]
                { rootRule, ruleOrzeczenie, ruleBezokolicznik, ruleCarType, ruleWyrazeniePrzyimkowe1, ruleAddressStreet, ruleAddressNumber, ruleWyrazeniePrzyimkowe2, ruleTimeHour, ruleTimeMinute }
             );

            docUber.Root = rootRule;

            System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create("srgsDocument.xml");
            docUber.WriteSrgs(writer);
            writer.Close();

            Grammar gramatyka = new Grammar(docUber, "rootUber");

            return gramatyka;
        }
    }
}
