class Bestelling<T>
{
    private static int volgnummerGenerator = 1;
    public int Id { get; private set; }
    public T Item { get; set; }
    public DateTime Datum { get; set; }
    public int Aantal { get; set; }
    public Verschijningsperiode? Periode { get; set; }

    public Bestelling(T item, DateTime datum, int aantal)
    {
        Id = volgnummerGenerator++;
        Item = item;
        Datum = datum;
        Aantal = aantal;

        if (item is Tijdschrift tijdschrift)
        {
            Periode = tijdschrift.Verschijningsperiode;
        }
    }

    public (string, int, double) Bestel()
    {
        double totalePrijs = 0;

        if (Item is Boek boek)
        {
            totalePrijs = boek.Prijs * Aantal;
        }

        string isbn = Item is Boek ? (Item as Boek).Isbn : "";
        return (isbn, Aantal, totalePrijs);
    }

    public event Action<string> BoekBesteld;

    public void BevestigBestelling()
    {
        BoekBesteld?.Invoke($"Bestelling {Id}: {Aantal} exemplaren van '{Item}' zijn bevestigd.");
    }
}
