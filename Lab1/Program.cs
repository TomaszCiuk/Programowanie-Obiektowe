using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Ulamek ulamek = new Ulamek(2,3);
            Ulamek ulamek2 = new Ulamek(3,2);
            Ulamek ulamek3 = ulamek + ulamek2;
            Console.WriteLine(ulamek3.ToString());

            Ulamek[] ulamki = new Ulamek[]
        {
            new Ulamek(4, 2),
            new Ulamek(3, 6),
            new Ulamek(4, 10)
        };
            Console.WriteLine("Nie posortowane: ");
            for (int i = 0; i < ulamki.Length; ++i)
                Console.WriteLine(ulamki[i]);

            Array.Sort(ulamki); // podczas sortowania wykorzystana zostanie metoda CompareTo()

            Console.WriteLine("Posortowane: ");
            for (int i = 0; i < ulamki.Length; ++i)
                Console.WriteLine(ulamki[i]);
        }
    }
    public class Ulamek: IComparable<Ulamek>
    {
        uint licznik, mianownik;
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
        }

        public int CompareTo(Ulamek other)
        {
            if (other == null) return -1;
            if (other == this) return 0;

            if (this.mianownik > other.mianownik && this.licznik > other.licznik) return +1;
            if (this.mianownik < other.mianownik && this.licznik < other.licznik) return -1;

            return 0;

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


    }
}