using System;
using System.Collections.Generic;

namespace ChallengeApp
{
	public class Statistics
	{
		public double High;
		public double Low;
		public double Avarage;

		public Statistics GetStatistics(List<double> grades)
		{
			var result = new Statistics();

			High = double.MinValue;
			Low = double.MaxValue;
			Avarage = 0.0;

			foreach (var grade in grades)
			{
				Low = Math.Min(Low, grade);
				High = Math.Max(High, grade);
				Avarage += grade;
			}
			Avarage /= grades.Count;
			return result;
		}
	}
}