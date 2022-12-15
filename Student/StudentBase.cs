using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeApp
{
	public delegate void OnGradeAddedLowDelegate(object sender, EventArgs args);
	public abstract class StudentBase : Person, IStudent
	{
		public  StudentBase(string name, string surname) : base(name, surname)
		{

		}

		public event OnGradeAddedLowDelegate LowGradeAdded;

		public abstract void AddGrade(double grade);

		public abstract void AddGrade(string grade);

		public abstract Statistics GetStatistics();

		public void GradeUnder()
		{
			if (LowGradeAdded != null)
			{
				LowGradeAdded(this, new EventArgs());
			}
		}

		public void ShowStatistics()
		{
				Console.WriteLine($"Avarage price:  {GetStatistics().Avarage}");
				Console.WriteLine($"Minimal price:  {GetStatistics().Low}");
				Console.WriteLine($"Maximal price: {GetStatistics().Max}");
		}
	}
}
