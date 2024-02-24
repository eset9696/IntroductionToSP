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
		bool isMoving = false;

		Engine engine;
		Tank tank;
		int speed = 0;


		struct Threads
		{
			public Thread PanelThread { get; set; }
			public Thread EngineThread { get; set; }
			public Thread RideThread { get; set; }
		}
		Threads threads;
		public Car(int volume, double consumption, int max_speed = 250)
		{
			engine = new Engine(consumption);
			tank = new Tank(volume);
			//if (max_speed < MAX_SPEED_LOW_LIMIT) { max_speed = MAX_SPEED_LOW_LIMIT; }
			if (max_speed > MAX_SPEED_HIGH_LIMIT) { max_speed = MAX_SPEED_HIGH_LIMIT; }
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
			if (!engine.Started)
			{
				driverInside = false;
				threads.PanelThread.Join();
				Console.Clear();
				Console.WriteLine("You are out of the car");
			}
			else Console.WriteLine("Stop engine!");
		}

		void EngineStart()
		{
			if (driverInside)
			{
				if (tank.FuelLevel > 0)
				{
					engine.Start();
					threads.EngineThread = new Thread(EngineWork);
					threads.EngineThread.Start();
				}
				else Console.WriteLine("Fuel level is zero!");
			}
			else Console.WriteLine("Get in!");
		}

		void EngineStop()
		{
			engine.Stop();
			threads.EngineThread.Join();
		}

		void EngineWork()
		{
			while(engine.Started)
			{
				if (!isMoving)
				{
					tank.Spend(engine.ConsumptionPerSecond);
					Thread.Sleep(1000);
				}
                else
                {
                    double consumption = (engine.Consumption * speed) / (3600 * 100);
					tank.Spend(consumption);
					Thread.Sleep(1000);
                }
                if (tank.FuelLevel == 0) EngineStop();
			}
		}

		void Gas(int acceleration)
		{
			if(engine.Started)
			{
				if(speed + acceleration >= MAX_SPEED) speed = MAX_SPEED;
				else speed += acceleration;
				if (!isMoving)
				{
					isMoving = true;
					threads.RideThread = new Thread(Ride);
					threads.RideThread.Start();
				}
			}
		}

		void SlowDown(int acceleration)
		{
			if (driverInside && isMoving)
			{
				if (speed - acceleration <= MIN_SPEED)
				{
					speed = MIN_SPEED;
					isMoving = false;
				}
				else speed -= acceleration;
			}
		}

		void Stop()
		{
			if (!isMoving && threads.RideThread != null)
			{
				threads.RideThread.Join();
			}
		}

		void Ride()
		{
			while(isMoving)
			{
				SlowDown(1);
				Thread.Sleep(1000);
			}
			Stop();
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
					if (tank.FuelLevel < 5) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("LOW FUEL"); }
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
						EngineStop();
						GetOut();
						break;
					case ConsoleKey.E:
						if(!engine.Started) EngineStart();
						else EngineStop();
						break;
					case ConsoleKey.W:
						if (engine.Started)	Gas(10);
						break;
					case ConsoleKey.S:
						if (driverInside) SlowDown(10);
						break;
				}
			} while (key != ConsoleKey.Escape);
		}
	}
}
