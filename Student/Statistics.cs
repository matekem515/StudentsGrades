using System;
using System.Collections.Generic;

namespace ChallengeApp
{
	public class Statistics
	{
		public double Max;
		public double Low;
		public double Sum;
		public int Count;

		public Statistics()
		{
			Count = 0;
			Sum = 0.0;
			Max = double.MinValue;
			Low = double.MaxValue;
		}

		public double Avarage
		{
			get
			{
				return Sum / Count;
			}
		}

		public void Add(double number)
		{
			Sum += number;
			Count++;
			Low = Math.Min(number, Low);
			Max = Math.Max(number, Max);
		}
	}
}