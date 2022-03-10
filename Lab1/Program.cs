using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Ulamek ulamek = new Ulamek();
            Ulamek ulamek2 = new Ulamek();
            Ulamek ulamek3 = ulamek + ulamek2;
            Console.WriteLine("Testowanie wypchnia do gita");
        }
    }
    class Ulamek
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
            return "Tekstowa reprezentacja";
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