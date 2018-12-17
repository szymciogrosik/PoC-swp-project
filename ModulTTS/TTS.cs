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
            string text = "Witamy w głosowym zamawianiu UBERA. Proszę rozpocząć po sygnale.";
            this.ClearPropmpt();
            this.Prompt.AppendText(text);
            this.StartSpeech();
            this.AttentionSound();
        }

        private void AttentionSound()
        {
            System.Media.SoundPlayer soundPlayer = new System.Media.SoundPlayer();
            soundPlayer.SoundLocation = @"C:\Users\thody\IdeaProjects\swp_projekt\ModulTTS\sounds\AttentionSound.wav";
            soundPlayer.PlaySync();
        }
    }
}
