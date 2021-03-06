﻿using System;
using System.Windows.Forms;
using System.Speech.Recognition;

using Balance;

namespace SpeechDemo.UI
{
    public partial class Form1 : Form
    {

        static bool completed;
        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new SpeechRecognitionEngine instance.
            var sre = new SpeechRecognitionEngine();

            // Configure the input to the recognizer.

            var productLines = new Choices();
            var options = new Choices();

            options.Add(new []{"balance", "products"});

            productLines.Add(new string[] {"Amazon", "Apple Bees", "Itunes", "Bestbuy", "besT" });

            // when clicked, it calls Grammar Service to consume
            // Create a GrammarBuilder object and append the Choices object.
            var gb = new GrammarBuilder();
            gb.Append("Get");
            gb.Append(options);
            gb.Append("for");
            gb.Append(productLines); 

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

            // show list of product line.

        }

        // Create a simple handler for the SpeechRecognized event.
        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            label1.Text = "Speech recoginzed: " + e.Result.Text;
            if (e.Result.Text.Contains("balance"))
            {
                IBalanceService balanceService = new BalanceService();
                var balanceInformation = balanceService.GetCardBalance("123131313113213");
                label1.Text = "Balance is $" +
                              balanceInformation.CurrentBalance;
            }
            else // user wants 
            {

            }

        }

        static void RecognizeCompletedHandler(
                object sender, RecognizeCompletedEventArgs e)
        {
           
            completed = true;
        }

        

        
    }
}
