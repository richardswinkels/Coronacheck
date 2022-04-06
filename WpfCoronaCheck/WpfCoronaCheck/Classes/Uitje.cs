using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCoronaCheck.Interfaces;

namespace WpfCoronaCheck.Classes
{
    public abstract class Uitje : ICoronaCheckEvenement
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public DateTime StartDatum { get; set; }
        public bool Doorstroom { get; protected set; }
        public bool BinnenEvent { get; protected set; }

        public bool VastePlaats()
        {
            //Geef omgekeerde waarde van property Doorstroom terug (Bv: Is het een doorstroomlocatie? Geef dan false terug)
            return !this.Doorstroom;
        }

        public bool Buiten()
        {
            //Geef omgekeerde waarde van property BinnenEvent terug (Bv: Is het een BinnenEvent? Geef dan false terug)
            return !this.BinnenEvent;
        }

        public bool CoronaCheckRequired()
        {
            //Als evenement buiten is
            if (Buiten())
            {
                //Geef false terug (Buiten, dus coronacheck is niet nodig)
                return false;
            }
            else
            {
                //Geef waarde terug die VastePlaats teruggeeft
                return VastePlaats();
            }
        }
    }
}
