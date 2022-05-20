using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab_8
{
    class Program
    {
        static void Main(string[] args)
        {
			//Thread thread = new Thread(() =>
			//{
			//	for (int i = 1; i <= 5; ++i)
			//	{
			//		Console.WriteLine("Iteration1: " + i);
			//		Thread.Sleep(1000); // sleeps created thread for 1 second
			//	}
			//});
			//Thread thread2 = new Thread(() =>
			//{
			//	for (int i = 1; i <= 5; ++i)
			//	{
			//		Console.WriteLine("Iteration2: " + i);
			//		Thread.Sleep(1000); // sleeps created thread for 1 second
			//	}
			//});
			//thread.Start();
			//thread2.Start();
			// Wątki wykonują się w tym samym czasie wiec w konsoli raz Interacja1 będzie wykonywac się pierwsza a raz Iteracja2.
			// To jest losowe co będzie pierwsze
			//bool looped = true;

			//Thread thread3 = new Thread(() =>
			//{
			//	Console.WriteLine("Started");

			//	for (int i = 1; looped; ++i)
			//	{
			//		Console.WriteLine("Iteration: " + i);
			//		Thread.Sleep(300);
			//	}

			//	Console.WriteLine("Stopping");
			//});

			//Console.WriteLine("Starting");

			//thread3.Start();

			//Thread.Sleep(1000);  // Opóźnia główny wątek programu o 1 sekunde
			//looped = false; 

			//thread3.Join();       // Główny wątek zostanie uśpiony póki nie zostanie utworzony

			//Console.WriteLine("Stopped");

			HashSet<int> primeNumbers = new HashSet<int>();
			bool looped = true;
			Thread thread1 = new Thread(() =>
            {
				Console.WriteLine("Started");

				for (int i = 1; looped; ++i)
				{
					if (IsPrime(i) == true)
                    {
						primeNumbers.Add(i);
						Console.WriteLine("Iteration: " + i);

					}
				}

				Console.WriteLine("Stopping");
			});
			thread1.Start();
			Thread.Sleep(10000);
			looped = false;
			thread1.Join();
		}
		public static bool IsPrime(int number)
		{
			if (number <= 1) return false;
			if (number == 2) return true;
			if (number % 2 == 0) return false;

			var boundary = (int)Math.Floor(Math.Sqrt(number));

			for (int i = 3; i <= boundary; i += 2)
				if (number % i == 0)
					return false;

			return true;
		}

	}

}
