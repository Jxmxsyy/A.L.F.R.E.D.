using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;

namespace Alfred
{
    public partial class Form1 : Form
    {

        SpeechRecognitionEngine sr = new SpeechRecognitionEngine();
        SpeechSynthesizer Alfred = new SpeechSynthesizer();        
        SpeechRecognitionEngine startlistening = new SpeechRecognitionEngine();
        Random rnd = new Random();
        int replyTimeout = 0;
        DateTime TimeNow = DateTime.Now;
        int ranNum;



        public Form1()
        {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            Alfred.SelectVoice("IVONA 2 Brian OEM");
            sr.SetInputToDefaultAudioDevice();
            sr.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"DefaultCommands.txt")))));
            sr.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Default_SpeechRecognized);
            sr.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(sr_SpeechRecognized);
            sr.RecognizeAsync(RecognizeMode.Multiple);


            startlistening.SetInputToDefaultAudioDevice();
            startlistening.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"DefaultCommands.txt")))));
            startlistening.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(startlistening_SpeechRecognized);

            foreach (var voice in Alfred.GetInstalledVoices())
            {
                Console.WriteLine(voice.VoiceInfo.Description);
                Console.WriteLine(voice.VoiceInfo.Name);                
            }
        }

        private void Default_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            
            string speech = e.Result.Text;

            if (speech == "Hello")
            {
                Alfred.SpeakAsync("Hello sir, how can I help");
            }
            if (speech == "Good morning Alfred")
            {
                Alfred.SpeakAsync("Good morning sir, how can I help today");
            }
            if (speech == "What is the weather like today")
            {

            }            
            if (speech == "What is your name")
            {
                Alfred.SpeakAsync("Allow me to introduce myself, I am Alfred, a virtual artificial intelligence, and I am here to assist you with a" +
                    "variety of tasks as best I can, 24 hours a day, 7 days a week.");
            }
            if (speech == "How are you")
            {
                Alfred.SpeakAsync("I am working normally");
            }
            if (speech == "What time is it")
            {
                Alfred.SpeakAsync("The time is currently " + TimeNow.ToString("h mm tt"));
            }
            if (speech == "Stop talking")
            {
                Alfred.SpeakAsyncCancelAll();
                ranNum = rnd.Next(1,3);

                if(ranNum == 1)
                {
                    Alfred.SpeakAsync("Yes sir");
                }
                else if (ranNum == 2)
                {
                    Alfred.SpeakAsync("As you wish sir");
                }
                else if (ranNum == 3)
                {
                    Alfred.SpeakAsync("Very well sir");
                }
            }
            if (speech == "Stop listening")
            {
                ranNum = rnd.Next(1, 6);

                if (ranNum == 1)
                {
                    Alfred.SpeakAsync("Should you need anything, you need only ask");
                    sr.RecognizeAsyncCancel();
                    startlistening.RecognizeAsync(RecognizeMode.Multiple);
                }
                else if (ranNum == 2)
                {
                    Alfred.SpeakAsync("As you wish sir");
                    sr.RecognizeAsyncCancel();
                    startlistening.RecognizeAsync(RecognizeMode.Multiple);
                }
                else if (ranNum == 3)
                {
                    Alfred.SpeakAsync("Very well sir");
                    sr.RecognizeAsyncCancel();
                    startlistening.RecognizeAsync(RecognizeMode.Multiple);
                }
                else if (ranNum == 4)
                {
                    Alfred.SpeakAsync("Voice commands disabled");
                    sr.RecognizeAsyncCancel();
                    startlistening.RecognizeAsync(RecognizeMode.Multiple);
                }
                else if (ranNum == 5)
                {
                    Alfred.SpeakAsync("Unless you need anything, I'll be running diagnostics");
                    sr.RecognizeAsyncCancel();
                    startlistening.RecognizeAsync(RecognizeMode.Multiple);
                }

            }
            if (speech == "Show commands")
            {
                string[] commands = (File.ReadAllLines(@"DefaultCommands.txt"));
                cmdList.Items.Clear();
                cmdList.SelectionMode = SelectionMode.None;
                cmdList.Visible = true;

                foreach(string cmd in commands)
                {
                    cmdList.Items.Add(cmd);
                }
            }
            if (speech == "Hide commands")
            {
                cmdList.Visible = false;
            }
            if (speech == "Hillary Clinton") 
            {
                var url = "https://www.google.com/search?q=hillary+clinton+fucked&source=lnms&tbm=isch&sa=X&ved=2ahUKEwjPy4KT1-buAhXFRxUIHV_fCtgQ_AUoAnoECAkQBA&biw=1920&bih=937#imgrc=R297llJjt5HYCM";
               
                using (var process = new System.Diagnostics.Process())
                {
                    process.StartInfo.FileName = "chrome.exe";
                    process.StartInfo.Arguments = url + " --incognito";
                    process.Start();
                }                    
            }
            if (speech == "Prisha play the dinga dinga lightbulb song")
            {
                var url = "https://www.youtube.com/watch?v=DJztXj2GPfk";                
               
                using (var process = new System.Diagnostics.Process())
                {
                    process.StartInfo.FileName = "chrome.exe";
                    process.StartInfo.Arguments = url + " --incognito";
                    process.Start();
                }

            }
            if (speech == "Run game")
            {
                Alfred.SpeakAsync("Which game would you like to play");

                string game = e.Result.Text;

                switch (game)
                {
                    case "CS":
                        System.Diagnostics.Process.Start("steam://run/730");
                        break;
                    case "GTA":
                        System.Diagnostics.Process.Start("steam://run/271590");
                        break;
                    case "Payday":
                    case "Payday 2":
                        System.Diagnostics.Process.Start("steam://run/218620");
                        break;
                    case "Golf With Friends":
                    case "Golf With Your Friends":
                        System.Diagnostics.Process.Start("steam://run/431240");
                        break;
                    case "Among Us":
                        System.Diagnostics.Process.Start("steam://run/945360");
                        break;
                }
                
            }
            if (speech == "Turn camera off")
            {
                Alfred.SpeakAsync("Camera de-activated");
            }
            if (speech == "Turn camera on")
            {
                Alfred.SpeakAsync("Camera activated");
            }
            if (speech == "Set an alarm for")
            {

            }
            if (speech == "Move it out the way")
            {

            }
            if (speech == "")
            {

            }

        }

        private void sr_SpeechRecognized(object sender, SpeechDetectedEventArgs e)
        {
            replyTimeout = 0;
        }

        private void startlistening_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            ranNum = rnd.Next(1, 12);
            
            if(speech == "Wake up")
            {
                if(ranNum == 1)
                {
                    startlistening.RecognizeAsyncCancel();
                    Alfred.SpeakAsync("I am here");
                    sr.RecognizeAsync(RecognizeMode.Multiple);
                }
                if (ranNum == 2)
                {
                    startlistening.RecognizeAsyncCancel();
                    Alfred.SpeakAsync("Greetings Sir");
                    sr.RecognizeAsync(RecognizeMode.Multiple);
                }
                if (ranNum == 3)
                {
                    startlistening.RecognizeAsyncCancel();
                    Alfred.SpeakAsync("Welcome back, how may I be of assistance?");
                    sr.RecognizeAsync(RecognizeMode.Multiple);
                }
                if (ranNum == 4)
                {
                    startlistening.RecognizeAsyncCancel();
                    Alfred.SpeakAsync("Resuming voice commands");
                    sr.RecognizeAsync(RecognizeMode.Multiple);
                }
                if (ranNum == 5)
                {
                    startlistening.RecognizeAsyncCancel();
                    Alfred.SpeakAsync("Awaiting instructions");
                    sr.RecognizeAsync(RecognizeMode.Multiple);
                }
                if (ranNum == 6)
                {
                    startlistening.RecognizeAsyncCancel();
                    Alfred.SpeakAsync("May I be of any assistance?");
                    sr.RecognizeAsync(RecognizeMode.Multiple);
                }
                if (ranNum == 7)
                {
                    startlistening.RecognizeAsyncCancel();
                    Alfred.SpeakAsync("At your service");
                    sr.RecognizeAsync(RecognizeMode.Multiple);
                }
                if (ranNum == 8)
                {
                    startlistening.RecognizeAsyncCancel();
                    Alfred.SpeakAsync("Ready when you are");
                    sr.RecognizeAsync(RecognizeMode.Multiple);
                }
                if (ranNum == 9)
                {
                    startlistening.RecognizeAsyncCancel();
                    Alfred.SpeakAsync("Voice commands enabled");
                    sr.RecognizeAsync(RecognizeMode.Multiple);
                }
                if (ranNum == 10)
                {
                    startlistening.RecognizeAsyncCancel();
                    Alfred.SpeakAsync("Resuming voice command");
                    sr.RecognizeAsync(RecognizeMode.Multiple);
                }
                if (ranNum == 11)
                {
                    startlistening.RecognizeAsyncCancel();
                    Alfred.SpeakAsync("Is there anything I can help you with?");
                    sr.RecognizeAsync(RecognizeMode.Multiple);
                }

            }
        }

        private void TimerSpeaking_Tick(object sender, EventArgs e)
        {
            if (replyTimeout == 10)
            {
                sr.RecognizeAsyncCancel();
            }
            else if (replyTimeout == 11)
            {
                TimerSpeaking.Stop();
                startlistening.RecognizeAsync(RecognizeMode.Multiple);
                replyTimeout = 0;
            }
        }
    }

}

