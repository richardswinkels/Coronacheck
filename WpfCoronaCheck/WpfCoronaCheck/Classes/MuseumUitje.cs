using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCoronaCheck.Classes
{
    public class MuseumUitje : Uitje
    {
        public decimal Toegangsprijs { get; private set; }

        public MuseumUitje(bool doorstroom, bool binnenEvent, decimal toegangsprijs)
        {
            this.Doorstroom = doorstroom;
            this.BinnenEvent = binnenEvent;
            this.Toegangsprijs = toegangsprijs;
        }
    }
}
