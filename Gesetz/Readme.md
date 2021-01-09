# Gesetz

## Infos für Clemens

### 04.01.2020
* In der Datei wwwroot/css/gesetz_stylesheet.css sind die CSS-Definitionen aus Wireframe/stylesheet.css
* In der Datei Pages/Shared/_LayoutAllgemein.cshtml steht der html-Teil, der für Wireframe/start.html und Wireframe/playerselect.html jeweils derselbe ist
* In Pages/Start.cshtml steht der htlm-Code aus Wireframe/start.html der speziell für Start ist (der allgemeine Teil steht in Pages/Shared/_LayoutAllgemein.cshtml)
* In Pages/PlayerSelect.cshtml analog
* Die Start-Seite wird zurzeit erstmal in Pages/Shared/_Layout.cshtml aufgerufen
* Alle anderen Dateien sind erst mal nicht wichtig.

### 05.01.2020

* Das Layout der Start-Seite musste geändert werden. Damit die Start-Aktion auf der Web-Seite 
  ankommt, muss das Ganze in einem html-form stehen und das Starten wird über einen html-button ausgelöst 

### 09.01.2020

* Spieler-Auswahl funktioniert im Prinzip. Zum Test kommt man nach der Auswahl eines Spielers
  zurück auf die Startseite und kann dann den nächsten Spieler auswählen.
* In PlayerSelect.cshtml wird Style des Buttons wird geändert, wenn die Rolle 
  nicht mehr frei ist. Ich habe das so gemacht, wie es im Wireframe gemacht wurde -
  also mit der id. Das sieht für mich aber seltsam aus. Im Web habe ich andere Beschreibungen gefunden:
  https://stackoverflow.com/questions/35818064/how-to-change-color-of-bootstrap-disabled-button/35818211.
  Das sieht für mich "sauberer" aus, hat aber nicht funktioniert.
