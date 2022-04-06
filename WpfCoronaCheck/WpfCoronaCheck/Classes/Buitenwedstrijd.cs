using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCoronaCheck.Interfaces;

namespace WpfCoronaCheck.Classes
{
    public class Buitenwedstrijd : Wedstrijd, ICoronaCheckEvenement
    {
        public bool Doorstroom { get; private set; }

        public Buitenwedstrijd(bool doorstroom)
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
            //Geef true terug (Buitenwedstrijd is altijd buiten)
            return true;
        }

        public bool CoronaCheckRequired()
        {
            //Geef altijd false terug (Buiten, dus geen coronacheck nodig)
            return false;
        }
    }
}
