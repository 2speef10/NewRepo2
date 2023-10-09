using Klassen_en_events;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Maak enkele boeken en tijdschriften aan
        var boek1 = new Boek("123456789", "Een Geweldig Boek", "Uitgever X", 20.0m);
        var boek2 = new Boek("987654321", "Nog Een Boek", "Uitgever Y", 10.0m);
        var tijdschrift1 = new Tijdschrift("111111111", "Tijdschrift A", "Uitgever Z", 5.0m, Verschijningsperiode.Wekelijks);
        var tijdschrift2 = new Tijdschrift("222222222", "Tijdschrift B", "Uitgever Z", 6.0m, Verschijningsperiode.Maandelijks);

        // Maak bestellingen voor boeken
        var bestellingBoek1 = new Bestelling<Boek>(boek1, 2);
        var bestellingBoek2 = new Bestelling<Boek>(boek2, 3);

        // Voeg event handlers toe voor boekbestellingen
        bestellingBoek1.BoekBesteld += (boek, aantal, totalePrijs) =>
        {
            Console.WriteLine($"Bestelling van boek '{boek.Naam}' is bevestigd. Aantal: {aantal}, Totale prijs: {totalePrijs:C}");
        };

        bestellingBoek2.BoekBesteld += (boek, aantal, totalePrijs) =>
        {
            Console.WriteLine($"Bestelling van boek '{boek.Naam}' is bevestigd. Aantal: {aantal}, Totale prijs: {totalePrijs:C}");
        };

        // Plaats de bestellingen voor boeken en toon de resultaten
        var bestelling1Resultaat = bestellingBoek1.Bestel();
        var bestelling2Resultaat = bestellingBoek2.Bestel();

        // Maak bestellingen voor tijdschriften
        var bestellingTijdschrift1 = new Bestelling<Tijdschrift>(tijdschrift1, 1);
        var bestellingTijdschrift2 = new Bestelling<Tijdschrift>(tijdschrift2, 5);

        // Plaats de bestellingen voor tijdschriften en toon de resultaten
        var bestellingTijdschrift1Resultaat = bestellingTijdschrift1.Bestel();
        var bestellingTijdschrift2Resultaat = bestellingTijdschrift2.Bestel();

        Console.ReadLine();
    }
}
