using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Übung_5._7
{

    public delegate void UpdateDisplay();

    public partial class Form1 : Form
    {

        public UpdateDisplay updateMethode; // delegate
        private System.Timers.Timer timer; // timer erstellen


        public Form1()
        {
            InitializeComponent();

            updateMethode = new UpdateDisplay(SetTime);

            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);

        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Invoke(updateMethode);

            // Rechenintensive Aufgabe hier > wird nicht an HauptThread übergeben
            
        }

        private void buttonStartStop_Click(object sender, EventArgs e)
        {

            if (timer.Enabled == true)
            {
                timer.Stop();
            }
            else
            {
                timer.Start();
            }

        }

        void SetTime()
        {
            labelDinamic.Text = String.Format("{0:D2}:{1:D2}:{2:D2}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        }
    }
}
