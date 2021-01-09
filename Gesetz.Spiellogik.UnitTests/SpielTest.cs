using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace Gesetz.Spiellogik.UnitTests
{
    [TestClass]
    public class SpielTest
    {
        [TestMethod]
        public void ZuBeginnIstDasSpielNichtGestartet()
        {
            var testObjekt = new Spiel();
            testObjekt.Gestartet.Should().BeFalse();
        }

        [TestMethod]
        [DataRow(RollenTyp.Ankläger)]
        [DataRow(RollenTyp.Verteidiger)]
        [DataRow(RollenTyp.Oberrichter)]
        [DataRow(RollenTyp.Richter)]
        public void ZuBeginnSindAlleRollenWählbar(RollenTyp typ)
        {
            var testObjekt = new Spiel();
            testObjekt.RolleVerfügbar(typ).Should().BeTrue();
        }

        [TestMethod]
        [DataRow(RollenTyp.Oberrichter)]
        [DataRow(RollenTyp.Richter)]
        public void WennEinerDrinIstKannKeinWeitererRein(RollenTyp typ)
        {
            var testObjekt = new Spiel();
            var teilnahmeErfolgreich = testObjekt.TeilnehmenAls(typ);
            teilnahmeErfolgreich.Should().BeTrue();
            testObjekt.RolleVerfügbar(typ).Should().BeFalse();
        }

        [TestMethod]
        [DataRow(RollenTyp.Verteidiger)]
        [DataRow(RollenTyp.Ankläger)]
        public void MaximalZweiKönnenTeilnehmen(RollenTyp typ)
        {
            var testObjekt = new Spiel();
            var teilnahmeErfolgreich = testObjekt.TeilnehmenAls(typ);
            teilnahmeErfolgreich.Should().BeTrue();
            var teilnahmeErfolgreich2 = testObjekt.TeilnehmenAls(typ);
            teilnahmeErfolgreich2.Should().BeTrue();
            testObjekt.RolleVerfügbar(typ).Should().BeFalse();
        }
    }
}
