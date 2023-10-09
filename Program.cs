namespace Klassen_en_events;
class Program
{
    
    static List<Boek> boeken = new List<Boek>();
    static List<Tijdschrift> tijdschriften = new List<Tijdschrift>();
    static List<Bestelling<object>> bestellingen = new List<Bestelling<object>>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Voeg een boek toe");
            Console.WriteLine("2. Voeg een tijdschrift toe");
            Console.WriteLine("3. Plaats een bestelling");
            Console.WriteLine("4. Afsluiten");

            string keuze = Console.ReadLine();

            switch (keuze)
            {
                case "1":
                    VoegBoekToe();
                    break;
                case "2":
                    VoegTijdschriftToe();
                    break;
                case "3":
                    PlaatsBestelling();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Ongeldige keuze. Probeer opnieuw.");
                    break;
            }
        }
    }

    static void VoegBoekToe()
    {
        Console.WriteLine("Voer ISBN in:");
        string isbn = Console.ReadLine();
        Console.WriteLine("Voer de naam van het boek in:");
        string naam = Console.ReadLine();
        Console.WriteLine("Voer de uitgever van het boek in:");
        string uitgever = Console.ReadLine();
        Console.WriteLine("Voer de prijs van het boek in:");
        double prijs = double.Parse(Console.ReadLine());

        var boek = new Boek(isbn, naam, uitgever, prijs);
        boeken.Add(boek);

        Console.WriteLine($"Boek '{naam}' is toegevoegd.");
    }

    static void VoegTijdschriftToe()
    {
        Console.WriteLine("Voer ISBN in:");
        string isbn = Console.ReadLine();
        Console.WriteLine("Voer de naam van het tijdschrift in:");
        string naam = Console.ReadLine();
        Console.WriteLine("Voer de uitgever van het tijdschrift in:");
        string uitgever = Console.ReadLine();
        Console.WriteLine("Voer de prijs van het tijdschrift in:");
        double prijs = double.Parse(Console.ReadLine());
        Console.WriteLine("Kies de verschijningsperiode (1 voor Dagelijks, 2 voor Wekelijks, 3 voor Maandelijks):");
        int periodeIndex = int.Parse(Console.ReadLine());
        Verschijningsperiode periode = (Verschijningsperiode)(periodeIndex - 1);

        var tijdschrift = new Tijdschrift(isbn, naam, uitgever, prijs, periode);
        tijdschriften.Add(tijdschrift);

        Console.WriteLine($"Tijdschrift '{naam}' is toegevoegd.");
    }

    static void PlaatsBestelling()
    {
        Console.WriteLine("Selecteer een item om te bestellen:");
        Console.WriteLine("1. Boek");
        Console.WriteLine("2. Tijdschrift");
        string keuze = Console.ReadLine();

        if (keuze == "1")
        {
            Console.WriteLine("Beschikbare boeken:");
            for (int i = 0; i < boeken.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {boeken[i].Naam}");
            }
            int boekIndex = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("Voer de bestelhoeveelheid in:");
            int aantal = int.Parse(Console.ReadLine());

            var bestelling = new Bestelling<object>(boeken[boekIndex], DateTime.Now, aantal);
            bestellingen.Add(bestelling);

            Console.WriteLine($"Bestelling voor boek '{boeken[boekIndex].Naam}' is geplaatst.");
        }
        else if (keuze == "2")
        {
            Console.WriteLine("Beschikbare tijdschriften:");
            for (int i = 0; i < tijdschriften.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tijdschriften[i].Naam}");
            }
            int tijdschriftIndex = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("Voer de bestelhoeveelheid in:");
            int aantal = int.Parse(Console.ReadLine());

            var bestelling = new Bestelling<object>(tijdschriften[tijdschriftIndex], DateTime.Now, aantal);
            bestellingen.Add(bestelling);

            Console.WriteLine($"Bestelling voor tijdschrift '{tijdschriften[tijdschriftIndex].Naam}' is geplaatst.");
        }
        else
        {
            Console.WriteLine("Ongeldige keuze.");
        }
    }
}