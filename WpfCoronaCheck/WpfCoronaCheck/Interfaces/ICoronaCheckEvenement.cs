using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCoronaCheck.Interfaces
{
    public interface ICoronaCheckEvenement
    {
        bool VastePlaats();
        bool Buiten();
        bool CoronaCheckRequired();
    }
}
