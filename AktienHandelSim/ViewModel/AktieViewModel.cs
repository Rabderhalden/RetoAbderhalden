using AktienHandelSim.Model;
using MVVMFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktienHandelSim.ViewModel
{

    public class AktieViewModel : ObservableObject
    {
        private Aktie aktie;

        private ObservableCollection<HystoryViewModel> historyList;
        private HystoryViewModel myCurrentHystory;


        public AktieViewModel()
        {
            myCurrentHystory = new HystoryViewModel();
            myCurrentHystory.AktuellerWert = 0;
            myCurrentHystory.Datum = DateTime.Now.Date.ToString();


            aktie = new Aktie(); 
            historyList = new ObservableCollection<HystoryViewModel>(){ myCurrentHystory };

         
            aktie.abkuerzung = "Unbekannt";
            aktie.firmenname = "Unbekannt";
            aktie.kaufKurs = 500;
            aktie.aktuellerKurs = 500;
            aktie.anzahlGekauft = 12;

        }

        public Aktie Aktie
        {
            get { return aktie; }
            set { aktie = value; }
        }

        public string Abkuerzung
        {
            get { return aktie.abkuerzung; }
            set
            {
                aktie.abkuerzung = value;
                RaisePropertyChanged("Abkuerzung");
            }
        }

        public string Firmenname
        {
            get { return aktie.firmenname; }
            set
            {
                aktie.firmenname = value;
                RaisePropertyChanged("Firmenname");
            }
        }

        public double Kaufkurs
        {
            get { return aktie.kaufKurs; }
            set
            {
                aktie.kaufKurs = value;
                RaisePropertyChanged("Kaufkurs");
            }
        }

        public double AktuellerKurs
        {
            get { return aktie.aktuellerKurs; }
            set
            {
                aktie.aktuellerKurs = value;
                RaisePropertyChanged("AktuellerKurs");
            }
        }

        public int AnzahlGekauft
        {
            get { return aktie.anzahlGekauft; }

            set
            {
                aktie.anzahlGekauft = value;
                RaisePropertyChanged("AnzahlGekauft");
            }
        }

        public ObservableCollection<HystoryViewModel> HystoryList
        {
            get
            {
                return historyList;
            }

            set
            {
                historyList = value;
                this.RaisePropertyChanged("HystoryList");
            }

        }
    }
}
