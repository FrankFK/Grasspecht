using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gesetz.Spiellogik
{
    /// <summary>
    /// Von dieser Klasse gibt es immer nur genau eine Instanz.
    /// Technisch gesehen ist diese Klasse ein Repository, das Spiel-Klassen verwaltet
    /// </summary>
    public class Spielspeicher
    {
        public bool EnthältEinSpiel { get { return (s_spiele.Count > 0); } }

        public Spiel IrgendeinNochNichtBeendetesSpiel
        {
            get {
                var irgendeinSpiel = s_spiele.Values.First();
                return irgendeinSpiel;
            }
        }


        private static readonly Dictionary<int, Spiel> s_spiele = new Dictionary<int, Spiel>();


        /// <summary>
        /// Neues Spiel anlegen und seinen Schlüssel zurück geben
        /// </summary>
        /// <returns></returns>
        public int SpielEinfügen()
        {
            var neuerSchlüssel = s_spiele.Count + 1;

            var neu = new Spiel {
                Schlüssel = neuerSchlüssel
            };

            s_spiele.Add(neuerSchlüssel, neu);
            return neuerSchlüssel;
        }

        public Spiel Spiel(int spielschlüssel)
        {
            var spiel = s_spiele[spielschlüssel];

            // Eine Kopie zurück geben, damit nicht das Original-Spiel in _spiele geändert wird.
            // Für das Ändern muss explizit die SpielSpeichern-Methode aufgerufen werden.
            return spiel.Copy();
        }


        public void ÄnderungSpeichern(Spiel spiel)
        {
            s_spiele[spiel.Schlüssel] = spiel;
        }

    }
}
