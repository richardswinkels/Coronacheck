using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCoronaCheck.Interfaces;

namespace WpfCoronaCheck.Classes
{
    public class Binnenwedstrijd : Wedstrijd, ICoronaCheckEvenement
    {
        public bool Doorstroom { get; private set; }

        public Binnenwedstrijd(bool doorstroom)
        {
            this.Doorstroom = doorstroom;
        }

        public bool VastePlaats()
        {
            //Geef omgekeerde waarde van property Doorstroom terug (Bv: Is het een doorstroomlocatie? Geef dan false terug)
            return !this.Doorstroom;
        }

        public bool Buiten()
        {
            //Geef false terug (Binnenwedstrijd is altijd buiten)
            return false;
        }

        public bool CoronaCheckRequired()
        {
            //Geef waarde terug die VastePlaats teruggeeft
            return VastePlaats();
        }
    }
}
