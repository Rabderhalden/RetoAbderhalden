using MVVMFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AktienHandelSim.ViewModel
{

    public class MainViewModel : ObservableObject
    {

        public ObservableCollection<AktieViewModel> AktienUebersicht { get; set; }
        private Thread threadCalc;
        private ObservableCollection<HystoryViewModel> myHystoryViewModels;
        public string KaufenAbkuerzung { get; set; }
        public string KaufenFirmenname { get; set; }
        public double KaufenKurs { get; set; }
        public int KaufenAnzahl { get; set; }
        public AktieViewModel SelectedAktie { get; set; }

        private double gesamtWert;
        public double GesamtWert
        {
            get
            { return gesamtWert; }
            set
            {
                gesamtWert = value;
                RaisePropertyChanged("GesamtWert");
            }
        }

        private double aktuellerWert;
        public double AktuellerWert
        {
            get { return aktuellerWert;}
            set
            {
                aktuellerWert = value;
                RaisePropertyChanged("AktuellerWert");
            }
        }

        private double differenz;
        public double Differenz
        {
            get { return differenz;}
            set
            {
                differenz = value;
                RaisePropertyChanged("Differenz");
            }
        }

        private double abweichungProzent;
        public double AbweichungProzent
        {
            get { return abweichungProzent; }
            set
            {
                abweichungProzent = value;
                RaisePropertyChanged("AbweichungProzent");
            }
        }

        private string profitLossColour;
        public string ProfitLossColour
        {
            get { return profitLossColour;}
            set
            {
                profitLossColour = value;
                RaisePropertyChanged("ProfitLossColour");
            }
        }


        #region CheckBoxRun

        public ICommand SwitchRun
        {
            get { return new RelayCommand(SwitchRunExecute, SwitchRunCanExecute); }
        }

        void SwitchRunExecute()

        {
            //MessageBox.Show("check");
            if (threadCalc.IsAlive)
            {
                threadCalc.Interrupt();
            }
            else
            {
                StartThreadCalcAktienValues();
            }

        }

        private bool SwitchRunCanExecute()
        {
            return true;
        }


        #endregion

        #region AktieKaufen
        public ICommand AktieKaufen
        {
            get { return new RelayCommand(AktieKaufenExecute, AktieKaufenCanExecute); }
        }

        void AktieKaufenExecute()

        {

            // AktienVM erstellen und der Observable zuordnen

            AktienUebersicht.Add(new AktieViewModel() { Abkuerzung = KaufenAbkuerzung, AktuellerKurs = KaufenKurs, Firmenname = KaufenFirmenname, Kaufkurs = KaufenKurs, AnzahlGekauft = KaufenAnzahl, HystoryList = new List<HystoryViewModel>() { new HystoryViewModel() { AktuellerWert = KaufenKurs, Datum = DateTime.Now.ToString() } } });
            GesamtWert = CalcGesamtWert();

        }

        private bool AktieKaufenCanExecute()
        {
            return true;
        }

        #endregion

        #region Verkaufen

        public ICommand AktieVerkaufen
        {
            get { return new RelayCommand(AktieVerkaufenExecute, AktieVerkaufenCanExecute); }
        }

        void AktieVerkaufenExecute()

        {
            int neueAnzahl = SelectedAktie.AnzahlGekauft - VerkaufenAnzahl;

            foreach (var aktieViewModel in AktienUebersicht)
            {
                if (aktieViewModel.Abkuerzung == SelectedAktie.Abkuerzung)
                {
                    aktieViewModel.AnzahlGekauft = neueAnzahl;
                }
            }

            VerkaufenAnzahl = 0;
            GesamtWert = CalcGesamtWert();
            // AktienVM erstellen und der Observable zuordnen

            //AktienUebersicht.Add(new AktieViewModel() { Abkuerzung = KaufenAbkuerzung, AktuellerKurs = KaufenKurs, Firmenname = KaufenFirmenname, Kaufkurs = KaufenKurs, AnzahlGekauft = KaufenAnzahl, HystoryList = new List<HystoryViewModel>() { new HystoryViewModel() { AktuellerWert = KaufenKurs, Datum = DateTime.Now.ToString() } } });


        }

        private bool AktieVerkaufenCanExecute()
        {
            return true;
        }

        private int verkaufenAnzahl;
        public int VerkaufenAnzahl
        {
            get { return verkaufenAnzahl; }
            set
            {
                verkaufenAnzahl = value;
                RaisePropertyChanged("VerkaufenAnzahl");
            }
        }

        #endregion

        #region Wallet

        double CalcGesamtWert()
        {
            double wert = 0;

            foreach (AktieViewModel aktieViewModel in AktienUebersicht)
            {
                wert = wert+(aktieViewModel.Kaufkurs * aktieViewModel.AnzahlGekauft);
            }

            return wert;
        }

        double CalcAktWert()
        {
            double wert = 0;

            foreach (AktieViewModel aktieViewModel in AktienUebersicht)
            {
                wert = wert + (aktieViewModel.AktuellerKurs * aktieViewModel.AnzahlGekauft);
            }

            return wert;
        }

        double CalcDifferenz()
        {
            return (CalcAktWert()-GesamtWert);
        }

        double CalcProzent()
        {
            return Math.Round(((AktuellerWert - GesamtWert) / GesamtWert) * 100, 2);
        }

        string ChangeFieldColour()
        {
            if (CalcDifferenz() >= 0)
            {
                return "green";
            }
            else
            {
                return "red";
            }
        }


        #endregion

        public MainViewModel()
        {
            AktienUebersicht = new ObservableCollection<AktieViewModel>();


            //myHystoryViewModels = new ObservableCollection<HystoryViewModel>();
            //{
            //    new HystoryViewModel() { AktuellerWert = 500, Datum = "01.01.1990" };
            //};


            AktienUebersicht.Add(new AktieViewModel() { Abkuerzung = "ABBN", AktuellerKurs = 100, Firmenname = "ABBAlstom", Kaufkurs = 100, AnzahlGekauft = 15, HystoryList = new List<HystoryViewModel>() { new HystoryViewModel() { AktuellerWert = 100, Datum = DateTime.Now.ToString() } } });
            AktienUebersicht.Add(new AktieViewModel() { Abkuerzung = "SBBN", AktuellerKurs = 200, Firmenname = "SBB-Firma", Kaufkurs = 200, AnzahlGekauft = 12, HystoryList = new List<HystoryViewModel>() { new HystoryViewModel() { AktuellerWert = 200, Datum = DateTime.Now.ToString() } } });

            StartThreadCalcAktienValues();
            GesamtWert=CalcGesamtWert();
            AktuellerWert = CalcAktWert();
            Differenz = CalcDifferenz();
            AbweichungProzent = CalcProzent();
            ProfitLossColour = ChangeFieldColour();
        }

        #region ThreadStart

        private void StartThreadCalcAktienValues()
        {
            ParameterizedThreadStart myDelegate = new ParameterizedThreadStart(CalcNewAktienValue);
            threadCalc = new Thread(myDelegate);
            threadCalc.Start(AktienUebersicht);              // Thread starten und Referenz auf ObservableCollection mitgeben
        }

        private void CalcNewAktienValue(object obj)
        {
            /* Die Observable Collection Casten und in eine Liste schreiben, damit iteriert werden kann.*/
            /* für die Taktung Sleep 1000ms eingeben*/
            var myAktien = (ObservableCollection<AktieViewModel>)obj;
            try
            {
                do
                {
                    foreach (AktieViewModel aktieViewModel in myAktien)
                    {
                        Random myRandom = new Random();
                        double randomChange = myRandom.Next(-1, 2);
                        Debug.WriteLine("aktuelle Änderung:");
                        Debug.WriteLine(randomChange.ToString());

                        aktieViewModel.AktuellerKurs += randomChange;
                        //Debug.WriteLine(aktieViewModel.AktuellerKurs.ToString());

                        #region Hystory-Eintrag

                        HystoryViewModel myHystoryViewModel = new HystoryViewModel() { AktuellerWert = aktieViewModel.AktuellerKurs, Datum = DateTime.Now.ToString() };

                        aktieViewModel.HystoryList.Add(myHystoryViewModel);


                        #endregion
                    }
                    AktuellerWert = CalcAktWert();
                    Differenz = CalcDifferenz();
                    AbweichungProzent = CalcProzent();
                    ProfitLossColour = ChangeFieldColour();
                    Thread.Sleep(1000);

                } while (true);
            }
            catch
            {

            }
        }

        #endregion

    }


}
