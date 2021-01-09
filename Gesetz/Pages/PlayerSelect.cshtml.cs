using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gesetz.Spiellogik;
using Gesetz.UiLogik;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gesetz.Pages
{
    public class PlayerSelectModel : PageModel
    {
        public bool AnklaegerEnabled { get; set; }

        public bool VerteidigerEnabled { get; set; }

        public bool RichterEnabled { get; set; }

        public bool OberrichterEnabled { get; set; }

        private readonly Spielspeicher _spielspeicher;

        public PlayerSelectModel()
        {
            _spielspeicher = new Spielspeicher();
        }

        public void OnGet()
        {
            var spielschlüssel = Status.LeseSpielschlüssel(HttpContext.Session);
            var spiel = _spielspeicher.Spiel(spielschlüssel);
            VerteidigerEnabled = spiel.RolleVerfügbar(RollenTyp.Verteidiger);
            AnklaegerEnabled = spiel.RolleVerfügbar(RollenTyp.Ankläger);
            RichterEnabled = spiel.RolleVerfügbar(RollenTyp.Richter);
            OberrichterEnabled = spiel.RolleVerfügbar(RollenTyp.Oberrichter);

        }

        public IActionResult OnPostAnklaeger()
        {
            return TeilnehmerAction(RollenTyp.Ankläger);
        }
        public IActionResult OnPostVerteidiger()
        {
            return TeilnehmerAction(RollenTyp.Verteidiger);
        }
        public IActionResult OnPostRichter()
        {
            return TeilnehmerAction(RollenTyp.Richter);
        }
        public IActionResult OnPostOberrichter()
        {
            return TeilnehmerAction(RollenTyp.Oberrichter);
        }

        private IActionResult TeilnehmerAction(RollenTyp spielerTyp)
        {
            if (!ModelState.IsValid) {
                return Page();
            }

            var spielschlüssel = Status.LeseSpielschlüssel(HttpContext.Session);
            var spiel = _spielspeicher.Spiel(spielschlüssel);
            var teilnahmeOk = spiel.TeilnehmenAls(spielerTyp);
            if (teilnahmeOk) {
                // TO-DO: Hier muss man je nach spielerTyp auf die nächste Seite
                _spielspeicher.ÄnderungSpeichern(spiel);
                return RedirectToPage("./Start");
            }
            else {
                // TO-DO: Hier müsste eine Fehlermeldung hin
                return Page();
            }
        }

    }
}
