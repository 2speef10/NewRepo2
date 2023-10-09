class Tijdschrift : Boek
{
    public Verschijningsperiode Verschijningsperiode { get; set; }

    public Tijdschrift(string isbn, string naam, string uitgever, double prijs, Verschijningsperiode periode)
        : base(isbn, naam, uitgever, prijs)
    {
        Verschijningsperiode = periode;
    }

    public override string ToString()
    {
        return base.ToString() + $", Verschijningsperiode: {Verschijningsperiode}";
    }
}