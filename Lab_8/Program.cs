using System;
using System.Collections.Generic;
using System.Diagnostics;
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
			Thread thread1 = new Thread(() =>
            {
				Stopwatch stopWatch = Stopwatch.StartNew();
				for (int i = 0; i <= 50000; ++i)
				{
					if (stopWatch.ElapsedMilliseconds > 10000)
					{
						stopWatch.Stop();
						break;
					}
					if (IsPrimeNumber(i))
					{
						lock (primeNumbers)
						{
							primeNumbers.Add(i);
						}
					}
					Thread.Yield();
				}
			});
			Thread thread2 = new Thread(() =>
			{
				Stopwatch stopWatch = Stopwatch.StartNew();
				for (int i = 50000; i <= 100000; ++i)
				{
					if (stopWatch.ElapsedMilliseconds > 10000)
					{
						stopWatch.Stop();
						break;
					}
					if (IsPrimeNumber(i))
					{
						lock (primeNumbers)
						{
							primeNumbers.Add(i);
						}
					}
					Thread.Yield();
				}
			});
			Thread thread3 = new Thread(() =>
			{
				Stopwatch stopWatch = Stopwatch.StartNew();
				for (int i = 10000; i <= 150000; ++i)
				{
					if (stopWatch.ElapsedMilliseconds > 10000)
					{
						stopWatch.Stop();
						break;
					}
					if (IsPrimeNumber(i))
					{
						lock (primeNumbers)
						{
							primeNumbers.Add(i);
						}
					}
					Thread.Yield();
				}
			});
			Thread thread4 = new Thread(() =>
			{
				Stopwatch stopWatch = Stopwatch.StartNew();
				for (int i = 150000; i <= 200000;)
				{
					if (stopWatch.ElapsedMilliseconds > 10000)
					{
						stopWatch.Stop();
						break;
					}
					if (IsPrimeNumber(i))
					{
						lock (primeNumbers)
						{
							primeNumbers.Add(i);
						}
					}
					Thread.Yield();
				}
			});

			thread1.Start();
			thread2.Start();
			thread3.Start();
			thread4.Start();

			thread1.Join();
			thread2.Join();
			thread3.Join();
			thread4.Join();

			Console.WriteLine($"Ilość liczb pierwszych:  {primeNumbers.Count}");


		}
		public static bool IsPrimeNumber(int number)
		{
			int count = 0;
			for (int i = 1; i <= number; i++)
			{
				if (number % i == 0)
				{
					count += 1;
				}
			}
			return count == 2;

		}

	}

}
