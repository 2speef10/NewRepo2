using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klassen_en_events
{
    class Boek
    {
        private string isbn;
        private string naam;
        private string uitgever;
        private decimal prijs;

        public string ISBN
        {
            get { return isbn; }
            set { isbn = value; }
        }

        public string Naam
        {
            get { return naam; }
            set { naam = value; }
        }

        public string Uitgever
        {
            get { return uitgever; }
            set { uitgever = value; }
        }

        public decimal Prijs
        {
            get { return prijs; }
            set
            {
                if (value >= 5 && value <= 50)
                    prijs = value;
                else
                    throw new ArgumentException("Prijs moet tussen 5€ en 50€ liggen.");
            }
        }

        public Boek(string isbn, string naam, string uitgever, decimal prijs)
        {
            ISBN = isbn;
            Naam = naam;
            Uitgever = uitgever;
            Prijs = prijs;
        }

        public Boek(string naam)
        {
            this.naam = naam;
        }

        public override string ToString()
        {
            return $"{Naam} (ISBN: {ISBN}, Uitgever: {Uitgever}, Prijs: {Prijs:C})";
        }

        public void Lees()
        {
            Console.WriteLine($"Je leest {Naam}");
        }
    }
}