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
    }
}
