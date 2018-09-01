
# Aufgabe “**D**okumenten **M**anagement **S**ystem”

Es soll eine WPF-Applikation für die Verwaltung von privaten Verträgen und Quittungen erstellt werden. Ziel ist, dass alle Verträge resp. Quittungen in digitaler Form aufbewahrt werden und gesucht werden können. Dazu werden die jeweiligen Dokumente eingescannt und im Dokumenten Management System abgelegt. Damit Dokumente wiedergefunden werden können, werden Metadaten zu den jeweiligen Dokumenten erfasst. Ihre Designerin hat nun eine WPF-Applikation erstellt, welche Sie nun mit Leben füllen müssen. Dazu hat Ihr Product Owner User Stories erstellt. Setzten Sie diese um und stellen Sie die Qualität der Software mittels Komponenten- und Integrationstests sicher. Gefordert ist eine Testabeckung von >80%.

![](https://github.com/n1ku/ZbW.Testing.Dms/raw/master/docs/dms0.png)

![](https://github.com/n1ku/ZbW.Testing.Dms/raw/master/docs/dms1.png)

![](https://github.com/n1ku/ZbW.Testing.Dms/raw/master/docs/dms2.png)

 


# #1258 Benutzer | Anmelden an Applikation

Als Benutzer kann ich mich mit meinem Namen an der Applikation anmelden, damit zu einem späteren Zeitpunkt nachvollzogen werden kann, wer die Dokumente abgelegt hat.

## Acceptance Criterias

AC01: Wir die Applikation gestartet, erscheint ein Anmeldedialog

AC02: Der Benutzer kann seinen Namen eingeben.

AC03: Durch das Klicken auf den [Login]-Button gelangt der Benutzer auf den Hauptbildschirm.

AC04: Der [Login]-Button ist nur dann aktiv, wenn ein Benutzername angegeben wurde.

AC05: Wird auf den [Abbrechen]-Button gedrückt, wird die Applikation beendet.

## Abgrenzungen

AG01: Es wird kein Password für einen Login benötigt

  

# #1259 Benutzer | Navigation in der Applikation

Als Benutzer kann auf dem Hauptbildschirm in unter Menüs navigiert werden, damit sämtliche Features der Software zugänglich werden.

## Acceptance Criterias

AC01: Durch einen Klick auf den [Suchen]-Button wird auf die Suchmaske navigiert.

AC02: Durch einen Klick auf den [Hinzufügen]-Button wird auf die Detailmaske navigiert.

AC03: Der angemeldete Benutzer wird unten Rechts angezeigt.

## Abgrenzungen

AG01: Die Applikation lässt zurzeit nur das Hinzufügen von Dokumenten zu. Löschen und Bearbeiten wird nicht implementiert.

  

# #1260 Benutzer | Metadaten für neue Dokumente

Der Benutzer kann für neue Dokumente Metadaten definiere, damit diese zu einem späteren Zeitpunkt wiedergefunden werden können.

### Acceptance Criterias

AC01: In der Detailmaske kann der Benutzer neue Dokumente hinzufügen.

AC02: Der Benutzer muss folgende Metadaten zu jedem Dokument angeben:

-Bezeichnung*

-Valuta Datum* (z.B. Vertragsdatum / Quittungsdatum)

-Typ* (z.B. Vertrag o. Quittung)

-Stichwörter (optional)

* Pflichtfelder

AC03: Durch den Klick auf den [Durchsuchen]-Button öffnet sich einen OpenFileDialog und der Benutzer kann eine Datei auswählen, die er ins System aufnehmen möchte.

AC04: Wird die CheckBox «Datei löschen» markiert, wird die Datei nach dem erfolgreichem Einlesevorgang vom Filesystem gelöscht.

AC05: Das Erfassungsdatum sowie der Benutzer werden vom System generiert.

AC06: Wird auf den [Speichern]-Button geklickt, wird überprüft, ob alle Pflichtfelder (Siehe AC02) ausgefüllt wurden.

AC06.1: Schlägt die Validierung fehl, erschient eine MessageBox mit folgendem Text «Es müssen alle Pflichtfelder ausgefüllt werden!».

AC07: Wurde kein Validierungsfehler erkannt, wird die Datei eingelesen.

### Abgrenzungen

AG01: Der Speichervorgang wird in einer separaten Story umschrieben.

  

# #1261 System | Dokumente in Repository ablegen

Das System verwaltet die hinzugefügten Dokumente und Metadaten, in einem proprietären Repository auf dem Filesystem, damit dieses z.B. auf Dropbox bereitgestellt werden kann.

### Acceptance Criterias

AC01: In der App.Config der Applikation kann ein Repositorypfad angegeben werden, unter dem die Dokumente sowie die Metadaten gespeichert werden.

AC02: Anhand des Valuta Datum wird pro Jahr ein Ordner erzeugt, sofern dieser noch nicht vorhanden ist.

<![if !vml]>![](file:///C:\Users\ibe\AppData\Local\Temp\msohtmlclip1\01\clip_image007.png)<![endif]>


AC03: Es wird jeweils das Dokument sowie eine Metadatendatei (XML) abgelegt.

AC04: Die Dokumente werden mit folgender Konvention benannt: {GUID}_Content.{Extension}

AC05: Die Metadatenfiles werden mit folgender Konvention benannt: {GUID}_Metadata.xml

<![if !vml]>![](file:///C:\Users\ibe\AppData\Local\Temp\msohtmlclip1\01\clip_image008.png)<![endif]>

AC06: Das Content- und das Metadata-File tragen immer die gleiche GUID.

### Abgrenzungen

Keine

  

# #1262 Benutzer | Dokumente suchen und öffnen

Als Benutzer kann ich nach Dokumenten suchen, damit ich diese schnellst möglich finden kann.

### Acceptance Criterias

AC01: Es kann mit einem Suchbegriff und/oder nach dem Typ eines Dokuments gesucht werden.

AC02: Wird ein Suchbegriff angegeben, wird in im Bezeichnung- sowie im Stichwortfeld gesucht.

AC03: Wird der [Suchen]-Butten betätigt wird nach Dokumenten welche den Filterkriterien entsprechend gesucht.

AC04: Das Resultat, wird im DataGrid angezeigt.

AC05: Wird auf den [Reset]-Button geklickt, werden alle Filterkriterien sowie das Resultat zurückgesetzt.

AC06: Wurde ein Dokument markiert, kann auf den [Öffnen]-Button geklickt werden.

AC07: Wird auf den [Öffnen]-Button geklickt, wird das ausgewählte Dokument geöffnet.

AC08: Im DataGrid werden sämtliche Metadaten in Form von Columns angezeigt.

### Abgrenzungen

AG01: Wurde kein Filterkriterium definiert, kann die Suche nicht angestossen werden.
