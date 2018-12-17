using Microsoft.Speech.Synthesis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            string text = "Witamy w głosowym zamawianiu UBERA pod dom! Proszę rozpocząć po sygnale.";
            // TODO jakiś sygnał :D
            this.ClearPropmpt();
            this.Prompt.AppendText(text);
            this.StartSpeech();
        }
    }
}
