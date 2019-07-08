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
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using AktienHandelSim.Validations;

namespace AktienHandelSim.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        private Thread threadCalc;

        public AktieViewModel SelectedAktie { get; set; }

        private string verkaufenAnzahl;
        private string kaufenAbkuerzung;
        private string kaufenFirmenname;
        private string kaufenKurs;
        private string kaufenAnzahl;

        private static bool aktieNameExists = false;

        private AktieViewModel selectedAktieViewModel;

        private double gesamtWert;
        private double aktuellerWert;
        private double differenz;
        private double abweichungProzent;
        private string profitLossColour;

        private PortfolioViewModel portfolioView;

        public PortfolioViewModel PortfolioViewModel
        {
            get { return portfolioView; }
            set { portfolioView = value; }
        }

        // neu im Portfolio
        //private static ObservableCollection<AktieViewModel> aktienUebersicht;

        // neu im Portfolio
        //public ObservableCollection<AktieViewModel> AktienUebersicht
        //{
        //    get => aktienUebersicht;
        //    set
        //    {
        //        aktienUebersicht = value;
        //        RaisePropertyChanged("AktienUebersicht");
        //    }

        //}
        public string KaufenAbkuerzung
        {
            get
            { return kaufenAbkuerzung; }

            set
            {
                kaufenAbkuerzung = value;
                RaisePropertyChanged("KaufenAbkuerzung");
            }
        }
        public string KaufenFirmenname
        {
            get
            { return kaufenFirmenname; }
            set
            {
                kaufenFirmenname = value;
                RaisePropertyChanged("KaufenFirmenname");
            }
        }
        public string KaufenKurs
        {
            get { return kaufenKurs; }
            set
            {
                kaufenKurs = value;
                RaisePropertyChanged("KaufenKurs");
            }
        }
        public string KaufenAnzahl
        {
            get { return kaufenAnzahl; }
            set
            {
                kaufenAnzahl = value;
                RaisePropertyChanged("KaufenAnzahl");
            }
        }

        public string VerkaufenAnzahl
        {
            get { return verkaufenAnzahl; }
            set
            {
                verkaufenAnzahl = value;
                RaisePropertyChanged("VerkaufenAnzahl");
            }
        }
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
        public double AktuellerWert
        {
            get { return aktuellerWert; }
            set
            {
                aktuellerWert = value;
                RaisePropertyChanged("AktuellerWert");
            }
        }
        public double Differenz
        {
            get { return differenz; }
            set
            {
                differenz = value;
                RaisePropertyChanged("Differenz");
            }
        }
        public double AbweichungProzent
        {
            get { return abweichungProzent; }
            set
            {
                abweichungProzent = value;
                RaisePropertyChanged("AbweichungProzent");
            }
        }
        public string ProfitLossColour
        {
            get { return profitLossColour; }
            set
            {
                profitLossColour = value;
                RaisePropertyChanged("ProfitLossColour");
            }
        }
        public AktieViewModel SelectedAktieViewModel
        {
            get { return selectedAktieViewModel; }
            set
            {
                if (selectedAktieViewModel == value)
                {
                    return;
                }

                selectedAktieViewModel = value;
                RaisePropertyChanged("SelectedAktieViewModel");
            }
        }


        #region CheckBoxRun

        public ICommand SwitchRun
        {
            get { return new RelayCommand(SwitchRunExecute, SwitchRunCanExecute); }
        }

        void SwitchRunExecute()

        {
            if (threadCalc != null)
            {
                if (threadCalc.IsAlive)
                {
                    threadCalc.Interrupt();
                }
                else
                {
                    StartThreadCalcAktienValues();
                }
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

            PortfolioViewModel.AktienUebersicht.Add(new AktieViewModel() { Abkuerzung = KaufenAbkuerzung, AktuellerKurs = Double.Parse(KaufenKurs), Firmenname = KaufenFirmenname, Kaufkurs = Double.Parse(KaufenKurs), AnzahlGekauft = Int32.Parse(KaufenAnzahl), HystoryList = new ObservableCollection<HystoryViewModel>() { new HystoryViewModel() { AktuellerWert = Double.Parse(KaufenKurs), Datum = DateTime.Now.ToString() } } });
            GesamtWert = CalcGesamtWert(PortfolioViewModel.AktienUebersicht);

            KaufenAbkuerzung = null;
            KaufenFirmenname = null;
            KaufenKurs = null;
            KaufenAnzahl = null;

        }

        private bool AktieKaufenCanExecute()
        {
            bool aktieNotExists = true;
            foreach (AktieViewModel aktieViewModel in PortfolioViewModel.AktienUebersicht)
            {
                if (aktieViewModel.Abkuerzung == KaufenAbkuerzung)
                {
                    aktieNotExists = false;
                }
            }

            // TryParse > schauen,ob Zahlenwert.. Bool benutzen für empty-string
            int kaufenAnzahl;

            bool successAnzahl = Int32.TryParse(KaufenAnzahl, out kaufenAnzahl);

            double kaufenKurs;

            bool successKurs = Double.TryParse(KaufenKurs, out kaufenKurs);


            bool isEmptyOrZero = (KaufenAbkuerzung != String.Empty && KaufenFirmenname != String.Empty &&
                                  kaufenAnzahl > 0);
            return (isEmptyOrZero && successAnzahl && successKurs && aktieNotExists);
        }

        #endregion

        #region Verkaufen

        public ICommand AktieVerkaufen
        {
            get { return new RelayCommand(AktieVerkaufenExecute, AktieVerkaufenCanExecute); }
        }

        void AktieVerkaufenExecute()

        {
            if (SelectedAktieViewModel != null)
            {
                int neueAnzahl = SelectedAktieViewModel.AnzahlGekauft - Int32.Parse(VerkaufenAnzahl);

                AktieViewModel currentAktie = new AktieViewModel();

                foreach (var aktieViewModel in PortfolioViewModel.AktienUebersicht)
                {
                    if (aktieViewModel.Abkuerzung == SelectedAktieViewModel.Abkuerzung)
                    {

                        if (neueAnzahl <= 0)
                        {
                            currentAktie = aktieViewModel;
                        }
                        else
                        {

                            aktieViewModel.AnzahlGekauft = neueAnzahl;
                        }
                    }
                }

                VerkaufenAnzahl = "0";

                if (neueAnzahl <= 0)
                {
                    PortfolioViewModel.AktienUebersicht.Remove(currentAktie);
                }

                GesamtWert = CalcGesamtWert(PortfolioViewModel.AktienUebersicht);

            }
            else
            {

            }

        }

        private bool AktieVerkaufenCanExecute()
        {

            int verkaufenAnzahl;

            bool successAnzahl = Int32.TryParse(VerkaufenAnzahl, out verkaufenAnzahl);



            bool isPositiv = (verkaufenAnzahl > 0);

            return (isPositiv && successAnzahl);

        }



        #endregion

        #region Portfolio Calculations

        public static double CalcGesamtWert(ObservableCollection<AktieViewModel> aktieViewModels)
        {
            double wert = 0;

            foreach (AktieViewModel aktieViewModel in aktieViewModels)
            {
                wert = wert + (aktieViewModel.Kaufkurs * aktieViewModel.AnzahlGekauft);
            }

            return wert;
        }

        double CalcAktWert()
        {
            double wert = 0;

            foreach (AktieViewModel aktieViewModel in PortfolioViewModel.AktienUebersicht)
            {
                wert = wert + (aktieViewModel.AktuellerKurs * aktieViewModel.AnzahlGekauft);
            }

            return wert;
        }

        double CalcDifferenz()
        {
            return (CalcAktWert() - GesamtWert);
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

           PortfolioViewModel= new PortfolioViewModel();

            // neu im Portfolio
            //AktienUebersicht = new ObservableCollection<AktieViewModel>();



            // neu im Portfolio
            //AktienUebersicht.Add(new AktieViewModel() { Abkuerzung = "ABBN", AktuellerKurs = 100, Firmenname = "ABBAlstom", Kaufkurs = 100, AnzahlGekauft = 15, HystoryList = new ObservableCollection<HystoryViewModel>() { new HystoryViewModel() { AktuellerWert = 100, Datum = DateTime.Now.ToString() } } });
            //AktienUebersicht.Add(new AktieViewModel() { Abkuerzung = "SBBN", AktuellerKurs = 200, Firmenname = "SBB-Firma", Kaufkurs = 200, AnzahlGekauft = 12, HystoryList = new ObservableCollection<HystoryViewModel>() { new HystoryViewModel() { AktuellerWert = 200, Datum = DateTime.Now.ToString() } } });

            SelectedAktieViewModel = PortfolioViewModel.AktienUebersicht.First();

            GesamtWert = CalcGesamtWert(PortfolioViewModel.AktienUebersicht);
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
            threadCalc.Start(PortfolioViewModel.AktienUebersicht);              // Thread starten und Referenz auf ObservableCollection mitgeben
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

                        int anzahlItemInHistory;

                        aktieViewModel.AktuellerKurs += randomChange;
                        //Debug.WriteLine(aktieViewModel.AktuellerKurs.ToString());

                        #region Hystory-Eintrag

                        HystoryViewModel myHystoryViewModel = new HystoryViewModel() { AktuellerWert = aktieViewModel.AktuellerKurs, Datum = DateTime.Now.ToString() };

                        //App.Current.Dispatcher.Invoke(() => aktieViewModel.HystoryList.Add(myHystoryViewModel));
                        App.Current.Dispatcher.Invoke(() => aktieViewModel.HystoryList.Insert(0, myHystoryViewModel));

                        if (aktieViewModel.HystoryList.Count >= 13)
                        {
                            App.Current.Dispatcher.Invoke(() => aktieViewModel.HystoryList.RemoveAt(12));
                        }

                        //aktieViewModel.HystoryList.Add(myHystoryViewModel);


                        #endregion
                    }

                    GesamtWert = CalcGesamtWert(PortfolioViewModel.AktienUebersicht);
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

        #region Validierung

        public static bool CallValidation(string value)
        {


            aktieNameExists = false;
            return CheckValue(value);
        }

        private static bool CheckValue(string value)
        {
            foreach (AktieViewModel aktieViewModel in aktienUebersicht)
            {

                if (aktieViewModel.Abkuerzung == value)
                {
                    aktieNameExists = true;
                }
            }
            return aktieNameExists;
        }
    }

    #endregion

}

