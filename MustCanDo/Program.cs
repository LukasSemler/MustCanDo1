using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UebungMustCanDo01
{
    class Program
    {
        // darf nicht verändert werden!
        static List<string> obstListe = new List<string>() { "Pflaume", "Honigmelone", "Birne", "Traube", "Limone", "Birne", "Pflaume", "Birne", "Mango", "Limone", "Mango", "Birne", "Dattel", "Mango", "Apfel", "Kirsche", "Kirsche", "Birne", "Limone", "Apfel", "Apfel", "Dattel", "Birne", "Traube", "Kirsche", "Erdbeere", "Feigen", "Birne", "Apfel", "Erdbeere", "Erdbeere", "Feigen", "Limone", "Apfel", "Birne", "Erdbeere", "Mango", "Mango", "Honigmelone", "Erdbeere", "Limone", "Zitrone", "Honigmelone", "Erdbeere", "Apfel", "Feigen", "Birne", "Traube", "Apfel", "Pflaume" };
        // darf nicht verändert werden!
        static string obstSchüssel = "Pflaumen;Apfel;Limonen;Brombeere;Brombeere;Apfel;Mango;Limone;Erdbeer;Apfel;Birnen;Wassermelone;Feigen;Apfel;Trauben;Birnen;Zitronen;Apfel;Birnen;Feigen;;;";

        // hier implementieren
        // diese Funktion soll die Datei uebung01 zeilenweise einlesen
        // in jeder Zeile stehen Zahlen durch ein Leerzeichen getrennt
        // alle Zahlen aller Zeilen die größer als 50 sind, sollen aufsummiert werden
        // die Funktion liefert dann diese Summe zurück
        internal static int DateiLesen()
        {
            int erg = 0;
            // aktuelles Verzeichnis ist /bin/debug ... daher 2 Verzeichnisse hinauf
            StreamReader stream = new StreamReader(@"../../uebung01.csv");
            // solange nicht "end of stream" erreicht ist ... führe den folgenden Block aus
            while (stream.EndOfStream == false)
            {
                string line = stream.ReadLine();
                string[] zahlen = line.Split(' ');

                foreach (var item in zahlen)
                {
                    if (Convert.ToInt32(item) > 50)
                    {
                        erg += Convert.ToInt32(item);
                    }
                }


            }
            // den stream am Ende des Lesens wieder schliessen!
            stream.Close();
            return erg;
        }

        // hier implementieren
        // Diese Funktion soll eine neue Liste an Obst zurückgeben.
        // Die Liste die übergeben wird enthält "Birne", die zurückgegebene Liste soll keine Birnen mehr enthalten.
        // Oder anders formuliert: Erstelle eine neue Liste, die alles bis auf "Birne" von der Originalliste enthält.
        private static List<string> ListeOhneBirnen(List<string> obstL)
        {
            List<string> ListeNeu = new List<string> { };
            foreach (var item in obstListe)
            {
                if (item != "Birne")
                {
                    ListeNeu.Add(item);
                }

            }
            return ListeNeu;
        }


        // Implementiere eine Funktion: ObstKlein
        // diese Funktion bekommt einen string obst
        // wenn das obst ein Apfel, Birnen oder Brombere ist, dann gibt die Funktion das Obst als Mus zurück .. dh aus "Apfel" wird "Apfelmus"
        // für alle anderen Obstsorten werden Würfel zurückgegeben z.B. Feigenwürfel

        // Implementiere eine Funktion: MacheObstSalat
        // Diese Funktion bekommt einen String ObstSchüssel - der Obst durch ; getrennt enthält
        // Schreibt den Code der den übergebenen String nach ";" aufteilt und für jedes Obst die Funktion ObstKlein aufruft und das Ergebnis am 
        // Bildschirm ausgibt. Achtung das Ende der ObstSchüssel ist etwas, das ihr beachten müsst.


        // hier ObstKlein implementieren
        public static string ObstKlein(string obst)
        {

            string zurückgeben;

            if (obst == "Apfel" || obst == "Birne" || obst == "Brombeere")
            {
                zurückgeben = obst + "mus";
            }
            else
                zurückgeben = obst + "würfel";

            return zurückgeben;
        }


        // hier MacheObstSalat implementieren

        public static string MacheObstSalat(string Obstschüssel)
        {
            string erg = "";
            string[] wörter = Obstschüssel.Split(';');
            foreach (var item in wörter)
            {
                erg += ObstKlein(item);
            }
            return erg;

        }


        static void Main(string[] args)
        {

            Console.WriteLine($"Summe 1: {DateiLesen()}"); // Summe 1: 11643
            Console.ReadKey();


            /*
            Console.WriteLine($"Liste ohne Birnen: {ListeOhneBirnen(obstListe).Count}"); // Liste ohne Birnen: 41
            Console.ReadKey();
            */

            /*
            Console.WriteLine(MacheObstSalat(obstSchüssel)); 
            // PflaumenwürfelApfelmusLimonenwürfelBrombeerewürfelBrombeerewürfelApfelmusMangowürfelLimonewürfelErdbeerwürfelApfelmusBirnenmusWassermelonewürfelFeigenwürfelApfelmusTraubenwürfelBirnenmusZitronenwürfelApfelmusBirnenmusFeigenwürfel
            Console.ReadKey();
            */
        }


    }
}
