using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gesetz.Spiellogik
{
    /// <summary>
    /// Zurzeit kann man auf der Web-Seite genau ein Spiel gleichzeitig spielen.
    /// (Man könnte sich auch vorstellen, dass mehrere Gruppen auf der gleichen Web-Seite zeitgleich jeweils ihr
    /// eigenes Spiel spielen. Man könnte z.B. maximal 10 Spiele gleichtzeitig erlauben. Dann müssten auf der Startseite
    /// 10 Spiele angezeigt werden. Aktuell wird nur ein Spiel angeboten. 
    /// </summary>
    public  class SpielAngebot
    {
        private readonly Spielspeicher _speicher;

        public SpielAngebot(Spielspeicher speicher)
        {
            _speicher = speicher;
        }
        /// <summary>
        /// Aktuell wird immer nur ein Spiel angeboten.
        /// </summary>
        /// <returns></returns>
        public  Spiel Spiel1()
        {
            // Sicherstellen, dass überhaupt ein Spiel vorhanden ist:
            if (!_speicher.EnthältEinSpiel) {
                _speicher.SpielEinfügen();
            }

            // Ein spielbares Spiel zurück liefern
            return _speicher.IrgendeinNochNichtBeendetesSpiel;
        }
    }
}
