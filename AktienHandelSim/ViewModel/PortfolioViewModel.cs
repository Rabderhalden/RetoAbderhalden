using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFramework;

namespace AktienHandelSim.ViewModel
{
    public class PortfolioViewModel : ObservableObject
    {

        private static ObservableCollection<AktieViewModel> aktienUebersicht;

        public ObservableCollection<AktieViewModel> AktienUebersicht
        {
            get => aktienUebersicht;
            set
            {
                aktienUebersicht = value;
                RaisePropertyChanged("AktienUebersicht");
            }

        }


        public PortfolioViewModel()
        {

            AktienUebersicht = new ObservableCollection<AktieViewModel>();

            AktienUebersicht.Add(new AktieViewModel() { Abkuerzung = "ABBN", AktuellerKurs = 100, Firmenname = "ABBAlstom", Kaufkurs = 100, AnzahlGekauft = 15, HystoryList = new ObservableCollection<HystoryViewModel>() { new HystoryViewModel() { AktuellerWert = 100, Datum = DateTime.Now.ToString() } } });
            AktienUebersicht.Add(new AktieViewModel() { Abkuerzung = "SBBN", AktuellerKurs = 200, Firmenname = "SBB-Firma", Kaufkurs = 200, AnzahlGekauft = 12, HystoryList = new ObservableCollection<HystoryViewModel>() { new HystoryViewModel() { AktuellerWert = 200, Datum = DateTime.Now.ToString() } } });




        }




    }
}
