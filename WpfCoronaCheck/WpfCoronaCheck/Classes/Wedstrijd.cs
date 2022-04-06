using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCoronaCheck.Classes
{
    public abstract class Wedstrijd
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public DateTime StartDatum { get; set; }
        public TimeSpan WedstrijdDuur { get; set; }
    }
}
