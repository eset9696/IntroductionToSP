using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
	internal class Engine
	{
		static readonly double MIN_CONSUMPTION = 3;
		static readonly double MAX_CONSUMPTION = 30;
		double consumption;
		double consumptionPerSecond;

		public bool Started
		{
			get; 
			private set;
		}

		public double Consumption
		{
			get { return consumption; }
			set
			{
				if (value < MIN_CONSUMPTION) { value = MIN_CONSUMPTION; }
				if (value > MAX_CONSUMPTION) { value = MAX_CONSUMPTION; }
				this.consumption = value;
				setConsumptionPerSecond();
			}
		}

		public void Start() { Started = true; }
		public void Stop() { Started = false; }

		public double ConsumptionPerSecond
		{
			get { return consumptionPerSecond; } 
		}

		public Engine(double consumption)
		{
			Consumption = consumption;
			Started = false;
		}
	
		void setConsumptionPerSecond()
		{
			consumptionPerSecond = consumption * 3e-5;
		}

		public void Info()
		{
			Console.WriteLine($"Consumption per 100 km = {Consumption}\nConsumptionPerSecond = {ConsumptionPerSecond}");
		}
	}
}
