using System;
using System.Threading;
namespace Car
{
	internal class Car
	{
		static readonly int MAX_SPEED_LOW_LIMIT = 100;
		static readonly int MAX_SPEED_HIGH_LIMIT = 400;
		static readonly int MIN_SPEED = 0;
		public int MAX_SPEED { get; }
		bool driverInside = false;

		Engine engine;
		Tank tank;
		double speed = 0;

		struct Threads
		{
			public Thread PanelThread { get; set; }
		}
		Threads threads;
		public Car(int volume, double consumption, int max_speed = 250)
		{
			engine = new Engine(consumption);
			tank = new Tank(volume);
			if (max_speed < MAX_SPEED_LOW_LIMIT) { max_speed = MAX_SPEED_LOW_LIMIT; }
			if (max_speed > MAX_SPEED_LOW_LIMIT) { max_speed = MAX_SPEED_HIGH_LIMIT; }
			this.MAX_SPEED = max_speed;
		}

		public void Info()
		{
			engine.Info();
			tank.Info();
			Console.WriteLine($"Max speed = {MAX_SPEED}km/h\nspeed = {speed} km/h");
		}

		void GetIn()
		{
			driverInside = true;
			threads.PanelThread = new Thread(Panel);
			threads.PanelThread.Start();
		}

		void GetOut()
		{
			driverInside = false;
			threads.PanelThread.Join();
			Console.Clear();
			Console.WriteLine("You are out of the car");
		}

		void Panel()
		{
			while (driverInside)
			{
				Console.Clear();
				Console.WriteLine($"Speed = {speed}\nFuel level = {tank.FuelLevel}");
				if (engine.Started)
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("Engine is started");
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Engine isn't started");
				}
				Console.ForegroundColor = ConsoleColor.White;
				Thread.Sleep(100);
			}
		}

		public void Control()
		{
			Console.WriteLine("Press enter to get in");
			ConsoleKey key;
			do
			{
				key = Console.ReadKey(true).Key;
				switch (key)
				{
					case ConsoleKey.F:
						if (!driverInside)
						{
							Console.WriteLine("How many liters do we fill?");
							tank.Fill(Convert.ToDouble(Console.ReadLine()));
						}
						else Console.WriteLine("Get out!");
						break;
					case ConsoleKey.Enter:
						if (!driverInside) GetIn();
						else GetOut();
						break;
					case ConsoleKey.Escape:
						GetOut();
						break;

				}
			} while (key != ConsoleKey.Escape);
		}
	}
}
