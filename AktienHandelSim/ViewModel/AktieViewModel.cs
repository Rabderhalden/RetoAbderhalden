using AktienHandelSim.Model;
using MVVMFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktienHandelSim.ViewModel
{

    public class AktieViewModel : ObservableObject
    {

        private Aktie _aktie;

        private List<HystoryViewModel> _historyList;
        private HystoryViewModel myCurrentHystory;
        private int _anzahlGekauft;

        //public string abkuerzung { get => _abkuerzung; set => _abkuerzung = value; }
        //public string firmenname { get; set; }
        //public double kaufkurs { get => _kaufkurs; set => _kaufkurs = value; }
        //public double aktuellerKurs { get; set; }

        public AktieViewModel()
        {
            myCurrentHystory = new HystoryViewModel();
            myCurrentHystory.AktuellerWert = 0;
            myCurrentHystory.Datum = DateTime.Now.Date.ToString();


            _aktie = new Aktie(); /*{ abkuerzung = "Unbekannt", aktuellerKurs = 0, firmenname = "Unbekannt", kaufKurs = 0,hystoryList=HystoryList };*/
            _historyList = new List<HystoryViewModel>() { myCurrentHystory };

            //_aktie.hystoryList = _historyList;
            _aktie.abkuerzung = "Unbekannt";
            _aktie.firmenname = "Unbekannt";
            _aktie.kaufKurs = 500;
            _aktie.aktuellerKurs = 500;
            _aktie.anzahlGekauft = 12;

        }

        public Aktie Aktie
        {
            get { return _aktie; }
            set { _aktie = value; }
        }

        public string Abkuerzung
        {
            get { return _aktie.abkuerzung; }
            set
            {
                _aktie.abkuerzung = value;
                RaisePropertyChanged("Abkuerzung");
            }
        }

        public string Firmenname
        {
            get { return _aktie.firmenname; }
            set
            {
                _aktie.firmenname = value;
                RaisePropertyChanged("Firmenname");
            }
        }

        public double Kaufkurs
        {
            get { return _aktie.kaufKurs; }
            set
            {
                _aktie.kaufKurs = value;
                RaisePropertyChanged("Kaufkurs");
            }
        }

        public double AktuellerKurs
        {
            get { return _aktie.aktuellerKurs; }
            set
            {
                _aktie.aktuellerKurs = value;
                RaisePropertyChanged("AktuellerKurs");
            }
        }

        public int AnzahlGekauft
        {
            get { return _aktie.anzahlGekauft; }

            set
            {
                _aktie.anzahlGekauft = value;
                RaisePropertyChanged("AnzahlGekauft");
            }
        }

        public List<HystoryViewModel> HystoryList
        {
            get
            {
                return _historyList;
            }

            set
            {
                _historyList = value;
                this.RaisePropertyChanged("HystoryList");
            }

        }

    }

}
