using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Gesetz.Spiellogik
{
    public class Spiel
    {
        public bool Gestartet { get; set; }

        public bool EsSindNochRollenFrei
        {
            get {
                return RolleVerfügbar(RollenTyp.Ankläger) || RolleVerfügbar(RollenTyp.Oberrichter) || RolleVerfügbar(RollenTyp.Richter) || RolleVerfügbar(RollenTyp.Verteidiger);
            }
        }


        public int Schlüssel { get; set; }

        private readonly Dictionary<RollenTyp, int> _freieTeilnehmer = new Dictionary<RollenTyp, int>() {
            { RollenTyp.Ankläger, 2 }, {RollenTyp.Verteidiger, 2 }, {RollenTyp.Richter, 1 }, {RollenTyp.Oberrichter, 1 }
        };

        public Spiel Copy()
        {
            return (Spiel)MemberwiseClone();
        }

        public bool RolleVerfügbar(RollenTyp typ)
        {
            var frei = _freieTeilnehmer[typ];
            return (frei > 0);
        }

        public bool TeilnehmenAls(RollenTyp typ)
        {
            var frei = _freieTeilnehmer[typ];
            if (frei > 0) {
                _freieTeilnehmer[typ] = frei - 1;
                return true;
            }
            else {
                return false;
            }
        }

    }
}
