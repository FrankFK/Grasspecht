using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gesetz.Spiellogik
{
    public class Spiel
    {
        public bool Gestartet { get; set; }

        public int Schlüssel { get; set; }

        public Spiel Copy()
        {
            return (Spiel)MemberwiseClone();
        }
    }
}
