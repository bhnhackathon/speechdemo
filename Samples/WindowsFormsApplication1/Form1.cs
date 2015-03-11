using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        static bool completed;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create a new SpeechRecognitionEngine instance.
            var sre = new SpeechRecognitionEngine();

            // Configure the input to the recognizer.
           

            // Create a simple grammar that recognizes "red", "green", or "blue".
            var colors = new Choices();
            colors.Add(new string[] { "red", "green", "blue","sahasra","Raji", "Amazon", "Apple Bees", "Itunes", "Bestbuy", "Animol", "Sunil", "Jiju" });

            // Create a GrammarBuilder object and append the Choices object.
            var gb = new GrammarBuilder();
            gb.Append(colors);

            // Create the Grammar instance and load it into the speech recognition engine.
            var g = new Grammar(gb);
            sre.LoadGrammar(g);

            // Register a handler for the SpeechRecognized event.
            sre.SpeechRecognized +=
              new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);
            sre.RecognizeCompleted +=
                  new EventHandler<RecognizeCompletedEventArgs>(
                    RecognizeCompletedHandler);


            sre.SetInputToDefaultAudioDevice();
            completed = false;
            // Start recognition.
            sre.RecognizeAsync(RecognizeMode.Multiple);
            

           
        }

        // Create a simple handler for the SpeechRecognized event.
        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            MessageBox.Show("Speech recognized: " + e.Result.Text);
        }

        static void RecognizeCompletedHandler(
                object sender, RecognizeCompletedEventArgs e)
        {
            Console.WriteLine("  Recognition completed.");
            completed = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new SpeechRecognitionEngine instance.
            var sre = new SpeechRecognitionEngine();

            // Configure the input to the recognizer.


            // Create a simple grammar that recognizes "red", "green", or "blue".
            var colors = new Choices();
            colors.Add(new string[] { "red", "green", "blue", "sahasra", "Raji", "Amazon", "Apple Bees", "Itunes", "Bestbuy", "Animol", "Sunil", "Jiju" });

            // Create a GrammarBuilder object and append the Choices object.
            var gb = new GrammarBuilder();
            gb.Append(colors);

            // Create the Grammar instance and load it into the speech recognition engine.
            var g = new Grammar(gb);
            sre.LoadGrammar(g);

            // Register a handler for the SpeechRecognized event.
            sre.SpeechRecognized +=
              new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);
            sre.RecognizeCompleted +=
                  new EventHandler<RecognizeCompletedEventArgs>(
                    RecognizeCompletedHandler);


            sre.SetInputToDefaultAudioDevice();
            completed = false;
            // Start recognition.
            sre.RecognizeAsync(RecognizeMode.Multiple);
            
        }
    }
}
