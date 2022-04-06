using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCoronaCheck.Classes
{
    public class BioscoopUitje : Uitje
    {
        public DateTime AanvangsTijdstip { get; private set; }
        public TimeSpan Duur { get; private set; }
        public string Film { get; private set; }
        public string Zaal { get; private set; }
        public string Stoel { get; private set; }

        public BioscoopUitje(bool doorstroom, bool binnenEvent, DateTime aanvangsTijdstip, TimeSpan duur, string film, string zaal, string stoel)
        {
            this.Doorstroom = doorstroom;
            this.BinnenEvent = binnenEvent;
            this.AanvangsTijdstip = aanvangsTijdstip;
            this.Duur = duur;
            this.Film = film;
            this.Zaal = zaal;
            this.Stoel = stoel;
        }
    }
}
