using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Ulamek ulamek = new Ulamek(2,3);
            Ulamek ulamek2 = new Ulamek(10,7);
            Ulamek ulamek3 = ulamek + ulamek2;
            Console.WriteLine(ulamek3.ToString());
            Console.WriteLine();

            Ulamek[] ulamki = new Ulamek[]
        {
            new Ulamek(4, 2),
            new Ulamek(3, 6),
            new Ulamek(4, 10)
        };
            Console.WriteLine("Nie posortowane: ");
            for (int i = 0; i < ulamki.Length; ++i)
                Console.WriteLine(ulamki[i]);

            Array.Sort(ulamki);

            Console.WriteLine("Posortowane: ");
            for (int i = 0; i < ulamki.Length; ++i)
                Console.WriteLine(ulamki[i]);
            Console.WriteLine();
            
            Console.WriteLine(ulamek == ulamek2);
            Console.WriteLine(ulamek == ulamek3);
            Console.WriteLine(ulamek == ulamek);
            Console.WriteLine();

            Console.WriteLine(ulamek.Equals(ulamek2));
            Console.WriteLine(ulamek.Equals(ulamek3));
            Console.WriteLine();

            Console.WriteLine(ulamek.Equals(null));
            Console.WriteLine(ulamek.Equals(ulamek));
            Console.WriteLine();

            Console.WriteLine(ulamek.roundDown());
            Console.WriteLine(ulamek.roundUp());
            Console.WriteLine(ulamek2.roundDown());
            Console.WriteLine(ulamek2.roundUp());

            Ulamek ulamekUzytkownika = new Ulamek(UInt16.Parse(Console.ReadLine()), UInt16.Parse(Console.ReadLine()));
            Console.WriteLine(ulamekUzytkownika.ToString());
        }
    }
    public class Ulamek : IComparable<Ulamek>, IEquatable<Ulamek>
    {
        uint licznik { get; }
        uint mianownik { get; }
        ///
        /// <summary>
        /// Tworzy ułamek na podstawie podanego licznika i mianownika
        /// </summary>
        public Ulamek()
        {

        }
        public Ulamek(uint licznik, uint mianownik)
        {
            this.licznik = licznik;
            this.mianownik = mianownik;
        }
        public Ulamek(Ulamek ulamek)
        {
            this.licznik = ulamek.licznik;
        }
        public override string ToString()
        {
            return licznik+"/"+mianownik;
            /// Reprezentacja tekstowa klasy, wyświetla licznik/ułamek ułamka
        }

        public int CompareTo(Ulamek other)
        {
            if (other == null) return -1;
            if (other == this) return 0;

            if (this.mianownik > other.mianownik && this.licznik > other.licznik) return +1;
            if (this.mianownik < other.mianownik && this.licznik < other.licznik) return -1;

            return 0;

        }

        public bool Equals(Ulamek other)
        {
            if (other == null) return false;
            if (other == this) return true;

            return Object.Equals(this.licznik, other.licznik) && Object.Equals(this.mianownik, other.mianownik);
        }

        public static Ulamek operator +(Ulamek a, Ulamek b)
        {
            return new Ulamek(a.licznik * b.mianownik + b.licznik * a.mianownik, a.mianownik * b.mianownik);
        }
        public static Ulamek operator -(Ulamek a, Ulamek b)
        {
            return new Ulamek(a.licznik * b.mianownik - b.licznik * a.mianownik, a.mianownik * b.mianownik);
        }
        public static Ulamek operator *(Ulamek a, Ulamek b)
        {
            return new Ulamek(a.licznik * b.licznik, a.mianownik * b.mianownik);
        }
        public static Ulamek operator /(Ulamek a, Ulamek b)
        {
            return new Ulamek(a.licznik * b.mianownik, a.mianownik * b.licznik);
        }
        public static Ulamek operator ==(Ulamek a, Ulamek b)
        {
            if (a.licznik == b.licznik && a.mianownik == b.mianownik)
                return new Ulamek(a.licznik, a.mianownik);
            else return new Ulamek();
        }
        public static Ulamek operator !=(Ulamek a, Ulamek b)
        {
            if (a.licznik != b.licznik || a.mianownik != b.mianownik)
                return new Ulamek();
            else return new Ulamek(a.licznik, a.mianownik);
    
        }
        public double roundUp()
        {
            double num = Convert.ToDouble(licznik)/ Convert.ToDouble(mianownik);
            return Math.Floor(num);
        }
        public double roundDown()
        {
            double num = Convert.ToDouble(licznik)/ Convert.ToDouble(mianownik);
            return Math.Floor(num);
        }


    }
}