# DSA Artefaktgenerator

Der DSA Artefaktgenerator ist eine .NET 6.0 Windows Desktop Applikation (x86) und versucht die Regeln rund um die Erstellung magischer Artefakte im DSA 4.1 Regelsystem einfach nutzbar zu machen.

## Download

TODO

## Screenshot

TODO

## Abhängigkeiten

Als Laufzeitumgebung wird die .NET 6.0 Desktop Runtime (x86) benötigt. Diese steht kostenfrei unter https://dotnet.microsoft.com/en-us/download/dotnet/6.0/runtime zur Verfügung.

Weiterhin nutzt der Artefaktgenerator sharpPDF zur Erzeugung der PDF Dokumente. Alles weitere hierzu findet sich im entsprechenden Unterverzeichnis.

## Geschichte

Soweit sich den Commit Logs entnehmen lässt hat Mario Rauschenberg um 2011 die erste Version des DSA Artefaktgenerators erstellt und sie wurde via dsa-hamburg.de verteilt. Es gab sogar einen eingebauten Updater. Bis 2015 wurde nach und nach neue Versionen veröffentlicht, bis zur letzten offiziellen Version 2.5.0. Danac wurde es ruhig, die Domain dsa-hamburg.de steht schon länger zum Verkauf.

Mario Rauschenberg hatte dankenswerter Weise damals schon den Code auf SourceForge unter der GPL veröffentlicht (https://sourceforge.net/projects/artgen/). Von dort hat Dennis Lindemann ab 2017 angefangen die Wege der Alchemie Errata (aus reinem Eigennutz wie er zugibt 😉) einzupflegen und einige Bugfixes zu erstellen. Diese wurde teilweise als Version 2.6.0 Beta im dsa-forum.de verteilt.

Im Februar 2022 ist Michael Prim durch Zufall auf die inoffizielle Weiterentwicklung von Dennis gestoßen, und vor allem die Tatsache, dass der Code zum Generator öffentlich ist.

Nach kurzem Kontakt haben wir uns zusammen getan um das Tool auf .NET 6.0 zu aktualisieren, die UI zu überarbeiten und an heutige Bildschirmauflösungen anzupassen, einige Altlasten wie den jetzt unnützen Updater zu entfernen, und sicherzustellen, dass das Tool auch auf anderen Umgebungen als Dennis speziel dafür eingefrorener Virtuellen Maschine kompiliert.

Unsere Version 3.0 unterstützt hoffentlich die nächste Dekade aller artefaktbegeisterter DSA 4.1 Spieler.

## Danksagung

TODO Ulisses, Mario

## Eigene Artefaktmaterialien

TODO Erklärung für material.mod.artgen einfügen