using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
enum Verschijningsperiode
{
    Dagelijks,
    Wekelijks,
    Maandelijks
}


namespace Klassen_en_events
{
    class Bestelling <T>
    
    {
        private static int volgnummerTeller = 1;
        private decimal prijs;
        private T item;

        public int Id { get; private set; }
        public T Item
        {
            get { return item; }
            set
            {
                if (value is Boek boek)
                {
                    // Zorg ervoor dat de prijs van een boek tussen 5€ en 50€ ligt
                    if (boek.Prijs >= 5 && boek.Prijs <= 50)
                    {
                        item = value;
                    }
                    else
                    {
                        throw new ArgumentException("Prijs van het boek moet tussen 5€ en 50€ liggen.");
                    }
                }
                else
                {
                    item = value;
                }
            }
        }

        public DateTime Datum { get; }
        public int Aantal { get; }
        public Verschijningsperiode? Periode { get; }

        public Bestelling(T item, int aantal, Verschijningsperiode? periode = null)
        {
            Id = volgnummerTeller++;
            Item = item;
            Datum = DateTime.Now;
            Aantal = aantal;
            Periode = periode;
        }

        public (string ISBN, int Aantal, decimal TotalePrijs) Bestel()
        {
            if (Item is Boek boek)
            {
                decimal totalePrijs = boek.Prijs * Aantal;
                OnBoekBesteld(boek, Aantal, totalePrijs);
                return (boek.ISBN, Aantal, totalePrijs);
            }
            else
            {
                throw new InvalidOperationException("Kan alleen boeken bestellen.");
            }
        }

        public event Action<Boek, int, decimal> BoekBesteld;

        protected virtual void OnBoekBesteld(Boek boek, int aantal, decimal totalePrijs)
        {
            BoekBesteld?.Invoke(boek, aantal, totalePrijs);
        }
    }
}
