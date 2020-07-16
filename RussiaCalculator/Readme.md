# Russische Bauernmultiplikation

Original taken from https://ccd-school.de/coding-dojo/function-katas/russische-bauernmultiplikation/

1. Methode mit Signatur:

    int Mul(int x, int y);

Der Algorithmus der sogenannten Russischen Bauernmultiplikation verläuft wie folgt: 
- man halbiert die linke der beiden Zahlen so lange, bis die 1 erreicht ist. 
- Nachkommastellen werden abgerundet. 
- Die rechte Zahl wird jeweils daneben geschrieben und verdoppelt.
- Von den rechten Zahlen werden alle gestrichen, neben denen links eine gerade Zahl steht.
- Die verbleibenden nicht gestrichenen Zahlen der rechten Seite werden dann addiert und bilden das Ergebnis der Multiplikation.

Example:

    5 * 3
    -------
    5   3
    2   (6)
    1   12
    -------
        15

2. Erweitern Sie die Method um die folgenden Zusatzinformationen:
- Wieviele Teilungen sind es bis zum erreichen der 1?
- Wieviele gestrichenen Zahlen gab es?