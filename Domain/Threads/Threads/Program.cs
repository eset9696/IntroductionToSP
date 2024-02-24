using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http.Headers;

namespace Threads
{
	internal class Program
	{
		static bool finish = false;
		static bool suspendPlus = false;
		static bool suspendMinus = false;
		static void Main(string[] args)
		{

			/*Plus();
			Minus();*/
			Thread plusThread = new Thread(Plus);
			Thread minusThread = new Thread(Minus);
			plusThread.Start();
			minusThread.Start();
			Console.WriteLine($"{Thread.CurrentThread.GetHashCode()}");
			Console.WriteLine("Press any key");
			ConsoleKey key;
			do
			{
				key = Console.ReadKey(true).Key;
				switch (key)
				{
					case ConsoleKey.Escape: 
						finish = true; 
						break;
					case ConsoleKey.OemPlus: 
						plusThread.Suspend(); 
						break;
				}

			} while (key != ConsoleKey.Escape);
			finish = true;
		}

		static void Plus() 
		{ 
			while(!finish)
			{
				Console.Write($"+ {Thread.CurrentThread.GetHashCode()}\t");
				Thread.Sleep(500);
			}
		}

		static void Minus()
		{
			while (!finish)
			{
				Console.Write($"+ {Thread.CurrentThread.GetHashCode()}\t");
				Console.Write("- ");
				Thread.Sleep(500);
			}
		}
	}
}
