using AktienHandelSim.Model;
using MVVMFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktienHandelSim.ViewModel
{

    public class HystoryViewModel : ObservableObject
    {
        private Hystory _hystory;

        public HystoryViewModel()
        {
            _hystory = new Hystory() { datum = "01.01.1990", aktuellerWert = 500 };
        }
        public Hystory Hystory
        {
            get { return _hystory; }
            set { _hystory = value; }
        }
        public string Datum
        {
            get
            {
                return _hystory.datum;
            }
            set
            {
                _hystory.datum = value;
                RaisePropertyChanged("Datum");
            }
        }
        public double AktuellerWert
        {
            get
            {
                return _hystory.aktuellerWert;
            }

            set
            {
                _hystory.aktuellerWert = value;
                RaisePropertyChanged("AktuellerWert");
            }
        }
    }
}
