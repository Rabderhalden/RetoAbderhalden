using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktienHandelSim.Model
{
    public class Aktie
    {
        public string abkuerzung { get; set; }
        public string firmenname { get; set; }
        public double kaufKurs { get; set; }
        public double aktuellerKurs { get; set; }
        public int anzahlGekauft { get; set; }

        public IEnumerable<Hystory> hystoryList { get; set; }


        public Aktie()
        {
            Hystory hystory = new Hystory() { aktuellerWert = 500, datum = "12:00" };
            hystoryList = new List<Hystory>() { hystory };
        }


    }
}
