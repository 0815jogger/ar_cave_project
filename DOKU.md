# Umsetzung einer Gestenbasierten Steuerung für die Cave der HTW Berlin

Das Projekt wird in "Behaviours" und in "Gestures" gegliedert.
Es existieren vier Modi. Bei dem ersten Modus handelt es sich um einen Pausen Modus. Mit den nachfolgenden drei Modi Translation, Rotation und Skalierung wird jeweils das Objekt manipuliert (Behaviours).
Mit einer Geste (Winken mit der linken Hand) wird zwischen die 4 Modi hin und her gewechselt.
Ist der letzte Modi erreicht wird mit einem weiteren Winken in den ersten Modus zurück gesprungen.

## Umsetzung

Als Basis dieses Projektes wird die Kinect Version 2 verwendet mit dem Kinect-SDK. Mittels dieses SDKs wird die Positionierung des Anwenders in der Cave erfasst. Die oben genannten Behaviours und Gestures werden mit Hilfe der Daten aus dem SDK ermöglicht. Zusätzlich wird der CAVE-Player verwendet, um die Darstellung zu ermöglichen.

## Probleme

Der Erfassungsbereich der Kinect Version 2 deckt nicht die komplette Cave ab.
Daher ist es wichtig, dass die Person direkt vor der Kamera steht.
Die Position ist vertikal in der Mitte und horizontal etwas nach links.
Die Winkgeste wird dadurch auch etwas schwierig erkannt, wenn die Person nicht korrekt vor der Kamera steht.
Auch werden die Behaviours manchmal ruckelig dargestellt, wenn die rechte Hand aus dem Sichtbereich der Kinect wandert.
Zusätzlich kommt hinzu, dass die Kinect durch den Winkel nicht optimal ausgerichtet ist.
Dadurch entsteht ein im Winkel verschobenes Koordinatensystem. Dieses Problem tritt nicht auf, wenn die Kinect zum Testen an den Laptop angeschlossen wird und korrekt horizontal ausgerichtet ist.
Erschwerend kommt hinzu, dass mehrere Personen schon das Erkennen der Geste und die Manipulation des Objektes fast unmöglich machen.

## Fazit

Das Programm kann an einigen Stellen verbessert oder erweitert werden. So kann dies durch weitere Gesten oder weitere Behaviours ausgebaut werden. Durch Vorlage der bisherigen Gesten und Behaviours können diese einfach implementiert werden.
Eine zusätzliche Idee ist es, dass das zu manipulierende Objekt durch den Anwender ausgewählt werden kann.
Ebenfalls kann durch den Einsatz einer zweiten Kinect Kamera versucht werden, den Anwender genauer zu erfassen oder Blickwinkel zu überwachen, welche von der bisherigen Kinect Kamera nicht sichtbar sind.
Weitere Funktionen können auch über den bereits vorhanden Wii Controller eingebaut werden, wie beispielsweise die Bewegung des virtuellen Spielers.
