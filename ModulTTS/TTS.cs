using DBConnector.Model;
using Microsoft.Speech.Synthesis;

namespace ModulTTS
{
    public class TTS
    {
        private SpeechSynthesizer Synthesizer;
        private PromptBuilder Prompt;

        public TTS()
        {
            this.Synthesizer = new SpeechSynthesizer();
            this.Synthesizer.SetOutputToDefaultAudioDevice();
            this.Prompt = new PromptBuilder();
        }

        private void ClearPropmpt()
        {
            this.Prompt.ClearContent();
        }

        private void StartSpeech()
        {
            this.Synthesizer.Speak(this.Prompt);
        }

        public void setupPropmptToWelcome()
        {
            string text = "Witamy w głosowym zamawianiu UBERA.";
            this.ClearPropmpt();
            this.Prompt.AppendText(text);
            this.StartSpeech();
        }

        public void AdditionalQuestion(WrapperType wrapperType)
        {
            string text = QuestionTextBy(wrapperType);
            this.ClearPropmpt();
            this.Prompt.AppendText(text);
            this.StartSpeech();
        }

        private string QuestionTextBy(WrapperType wrapperType)
        {
            switch(wrapperType)
            {
                case WrapperType.CAR_TYPE:
                    return "Podaj typ zamawianego samochodu";
                case WrapperType.ADDERSS:
                    return "Podaj adres na który ma przyjechać kierowca";
                case WrapperType.ADDERSS_NUMBER:
                    return "Podaj numer wskazanego numeru";
                case WrapperType.HOUR:
                    return "Podaj godzinę o której kieroca ma przyjechać";
                case WrapperType.MINUTES:
                    return "Podaj minute na którą kierowca ma przyjechać";
                default:
                    return "Wystąpił bład";
            }
        }
    }
}
