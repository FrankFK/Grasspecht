using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gesetz.Spiellogik;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gesetz.Pages
{
    public class StartModel : PageModel
    {
        public string AktionsText { get; set; }

        /// <summary>
        /// BindProperty Attribug ist gesetzt, damit der aktuelle Spielschlüssel beim Post zurück kommt (aus einem hidden input)
        /// </summary>
        [BindProperty]
        public int Spielschlüssel { get; set; }

        private readonly Spielspeicher _spielspeicher;
        private readonly SpielAngebot _spielAngebot;

        public StartModel()
        {
            _spielspeicher = new Spielspeicher();
            _spielAngebot = new SpielAngebot(_spielspeicher);

        }

        public IActionResult OnGet()
        {
            var spiel = _spielAngebot.Spiel1();

            if (spiel.Gestartet) {
                // Wenn das Spiel schon gestartet wurde, kann man nur noch teilnehmen
                AktionsText = "Teilnehmen";
            }
            else {
                AktionsText = "Starten";
            }

            Spielschlüssel = spiel.Schlüssel;

            // abgeschrieben aus: https://docs.microsoft.com/de-de/aspnet/core/razor-pages/?view=aspnetcore-5.0&tabs=visual-studio
            return Page();
        }

        // public async Task<IActionResult> OnPostAsync()
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) {
                return Page();
            }

            var spiel = _spielspeicher.Spiel(Spielschlüssel);
            if (!spiel.Gestartet) {
                spiel.Gestartet = true;
                _spielspeicher.ÄnderungSpeichern(spiel);
            }

            return RedirectToPage("./PlayerSelect");
        }
    }
}
