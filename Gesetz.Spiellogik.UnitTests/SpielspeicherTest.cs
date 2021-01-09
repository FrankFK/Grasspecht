using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace Gesetz.Spiellogik.UnitTests
{
    [TestClass]
    public class SpielspeicherTest
    {

        [TestMethod]
        public void NeuesSpiel_KannAngelegtWerden()
        {
            var testObjekt = new Spielspeicher();
            var schlüssel = testObjekt.SpielEinfügen();
            var spiel = testObjekt.Spiel(schlüssel);

            spiel.Should().NotBeNull();
        }

        [TestMethod]
        public void ÄnderungSpeichern_Funktioniert()
        {
            var spiele = new Spielspeicher();
            var schlüssel = spiele.SpielEinfügen();
            var spiel = spiele.Spiel(schlüssel);

            // Spiel ändern, aber noch nicht abspeichern
            spiel.Gestartet.Should().BeFalse();
            spiel.Gestartet = true;

            // Spiel noch mal abfragen, Wert ist noch nicht geändert
            var spielNeueAbgefragt = spiele.Spiel(schlüssel);
            spielNeueAbgefragt.Gestartet.Should().BeFalse();

            // Spiel speichern
            spiele.ÄnderungSpeichern(spiel);

            // Spiel jetzt neu abfragen, Änderung ist angekommen
            var spielNochmalbgefragt = spiele.Spiel(schlüssel);
            spielNochmalbgefragt.Gestartet.Should().BeTrue();
        }

        [TestMethod]
        public void TeilnehmerSpeichern_Funktioniert()
        {
            var spiele = new Spielspeicher();
            var schlüssel = spiele.SpielEinfügen();
            var spiel = spiele.Spiel(schlüssel);

            // Spiel ändern
            spiel.TeilnehmenAls(RollenTyp.Oberrichter);
            spiel.RolleVerfügbar(RollenTyp.Oberrichter).Should().BeFalse();

            // Spiel speichern
            spiele.ÄnderungSpeichern(spiel);

            // Spiel jetzt neu abfragen, ob die Änderungen von oben noch vorhanden sind
            var spielNochmalbgefragt = spiele.Spiel(schlüssel);
            spielNochmalbgefragt.RolleVerfügbar(RollenTyp.Oberrichter).Should().BeFalse();
        }

        [TestMethod]
        public void GültigerSchlüssel_Funktioniert()
        {
            var spiele = new Spielspeicher();

            if (!spiele.EnthältEinSpiel) {
                spiele.SpielEinfügen();
            }

            var spiel = spiele.IrgendeinNochNichtBeendetesSpiel;

            spiel.Should().NotBeNull();
        }
    }
}
