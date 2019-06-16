using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Übung_5._8
{

    /* Erstelle Winform-App, die Arbeitintensiven-Code im HauptThread(UI-Thread) ausführt
    > GUI wird folglich nicht mehr richtig funktionieren!
    > löse das Problem mit Background Thread.
         */
    public partial class Form1 : Form
    {

        public BackgroundWorker RetosBackgroundWorker;
        public Form1()
        {
            InitializeComponent();

            RetosBackgroundWorker = new BackgroundWorker();
            //RetosBackgroundWorker.DoWork += RetosBackground_Do_Work;
            RetosBackgroundWorker.DoWork += new DoWorkEventHandler(RetosBackground_Do_Work);
            RetosBackgroundWorker.WorkerReportsProgress = true; // Stand des akutellen Progress

        }


        private void buttonBackgroundThrad_Click(object sender, EventArgs e)
        {
            RetosBackgroundWorker.RunWorkerAsync();
        }

        private void buttonStartInUIThread_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 1000; i++)
            {
                Debug.WriteLine("In my Foreground-Thread.." + i + Thread.CurrentThread.ManagedThreadId.ToString());
                Thread.Sleep(500);
            }
        }


        public void RetosBackground_Do_Work(object sender, EventArgs e)
        {
            try
            {
                int currentInput;
                bool check=Int32.TryParse(textBoxInputValue.Text, out currentInput);

                if (!check)
                {
                    throw new Exception("Falsche Eingabe");
                }

                for (int i = 0; i <= currentInput; i++)
                {
                    Debug.WriteLine("In my Background-Thread.." + i + Thread.CurrentThread.Name);

                    this.Invoke(new EventHandler(delegate
                    {
                        labelCurrentValue.Text = $"aktueller Wert ist: {i}";

                    }));


                    // Funktioniert so nicht! > weil Threadübergreiffend..
                    //labelOutput.Text = $"aktueller Wert ist: {1}";

                    Thread.Sleep(400);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Falsche Eingabe!" + exception);

                this.Invoke(new EventHandler(delegate
                {
                    textBoxInputValue.Text = null;
                }));

                // geht nicht! Threadübergreiffend
                // textBoxInputValue.Text = null;

            }

        }
    }
}
